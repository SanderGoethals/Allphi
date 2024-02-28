namespace AllPhi.HoGent.Blazor.Services
{
    public class VehicleServices : IVehicleServices
    {
        private readonly HttpClient _httpClient;

        public VehicleServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
