namespace AllPhi.HoGent.Blazor.Services
{
    public class FuelCardServices : IFuelCardServices
    {
        private readonly HttpClient _httpClient;

        public FuelCardServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
