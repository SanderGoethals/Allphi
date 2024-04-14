using AllPhi.HoGent.Blazor.Dto;

namespace AllPhi.HoGent.Blazor.Services
{
    public interface IDriverVehicleServices
    {
        Task<(List<DriverVehicleDto>, bool status, string message)> GetDriverWithConnectedVehiclesByDriverId(Guid driverId);
    }
}
