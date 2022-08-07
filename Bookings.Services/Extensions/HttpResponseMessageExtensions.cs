using Bookings.Shared.CustomExceptions;
using Newtonsoft.Json;
using System.Net;

namespace Bookings.Services.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<T> GetResponse<T>(this HttpResponseMessage response, string noResponseMessage = "No reponse received from the API.")
        {
            if (response == null)
            {
                throw new Exception(noResponseMessage);
            }

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(json);
                case HttpStatusCode.NoContent:
                    return default(T);
                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedAccessException($"Response code received: {response.StatusCode}. Message: {response.ReasonPhrase}");
                case HttpStatusCode.NotFound:
                    throw new HttpStatusNotFoundException($"Response code received: {response.StatusCode}. Message: {response.ReasonPhrase}");
                default:
                    throw new Exception($"Response code received: {response.StatusCode}. Message: {response.ReasonPhrase}");
            }

        }
    }
}
