namespace AppView.Services
{
    //call API tai day
    public class ApiClient
    {
        private readonly IHttpClientFactory _factory;
        private IConfiguration _configuration;

        public ApiClient (IHttpClientFactory factory, IConfiguration configuration)
        {
            _configuration = configuration;
            _factory = factory;
        }

    }
}
