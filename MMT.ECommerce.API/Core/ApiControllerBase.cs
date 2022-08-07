using Bookings.Shared;
using Bookings.Shared.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Transactions;

namespace Bookings.API.Core
{
    public class ApiControllerBase : Controller
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _fXDBUnitOfWork;

        public ApiControllerBase(IMediator mediator, IUnitOfWork fXDBUnitOfWork)
        {
            _mediator = mediator;
            _fXDBUnitOfWork = fXDBUnitOfWork;
        }

        protected async Task<IActionResult> Ok<TResponse>(IRequest<TResponse> query)
        {
            var response = await _mediator.Send(query);
            return base.Ok(response);
        }

        protected async Task<IActionResult> NoContent<TResponse>(IRequest<TResponse> command)
        {
            await _mediator.Send(command);
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await _fXDBUnitOfWork.SaveChangesAsync();
            }
            return base.NoContent();
        }

        /// <summary>
        /// Handles the request in API endpoint methods
        /// </summary>
        /// <typeparam name="TResponse">Any class that derives from BaseResponseModel</typeparam>
        /// <param name="request">the request</param>
        /// <returns>
        /// OK - when responseData.Success == true (request is successful)
        /// BAD REQUEST - when responseData.Success == false (request is not successful, either from an error that has occured or conditions were not met)
        /// </returns>
        protected async Task<IActionResult> HandleRequest<TResponse>(IRequest<TResponse> request) where TResponse : BaseResponseModel
        {
            var response = await _mediator.Send(request);

            switch(response.ResponseCode)
            {
                case HttpStatusCode.OK:
                    return Ok(response);

                case HttpStatusCode.NoContent:
                    return NoContent();

                case HttpStatusCode.NotFound:
                    return NotFound(response);

                case HttpStatusCode.BadRequest:
                    return BadRequest(response);

                case HttpStatusCode.InternalServerError:
                case HttpStatusCode.BadGateway:
                default:
                    return StatusCode((int)response.ResponseCode, response);
            }
        }
    }
}
