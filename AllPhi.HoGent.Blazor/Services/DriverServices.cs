namespace AllPhi.HoGent.Blazor.Services
{
    public class DriverServices : IDriverServices
    {
        private readonly HttpClient _httpClient;

        public DriverServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
