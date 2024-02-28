namespace AllPhi.HoGent.Blazor.Services
{
    public class FuelCardDriverServices : IFuelCardDriverServices
    {
        private readonly HttpClient _httpClient;

        public FuelCardDriverServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
