namespace Bookings.Services.TokenServices
{
    public interface IHttpService
    {
        void AddAcceptHeader(string acceptHeader);
        void AddBearerToken(string bearerToken);
        void AddContent(HttpContent content);
        void AddMethod(HttpMethod method);
        void AddRequestUri(string requestUri);
        void AddTimeout(TimeSpan timeout);
        void Dispose();
        string GenerateUri<T>(string baseUri, T obj);
        Task<string> GetResponseAsString(HttpResponseMessage message);
        Task<T> GetResponseObject<T>(HttpResponseMessage message);
        Task<HttpResponseMessage> HttpGetAsync(string url);

        Task<HttpResponseMessage> HttpGetAsync<T>(string url, T requestModel);
        Task<HttpResponseMessage> HttpPostAsync<T>(string url, T requestModel);
        Task<HttpResponseMessage> SimpleHttpPostAsync(string url);
    }
}