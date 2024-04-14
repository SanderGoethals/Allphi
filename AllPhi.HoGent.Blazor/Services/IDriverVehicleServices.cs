using AllPhi.HoGent.Blazor.Dto;

namespace AllPhi.HoGent.Blazor.Services
{
    public interface IDriverVehicleServices
    {
        Task<(List<DriverVehicleDto>, bool status, string message)> GetDriverWithConnectedVehiclesByDriverId(Guid driverId);
        Task<(List<DriverVehicleDto>, bool status, string message)> GetVehicleWithConnectedDriversByVehicleId(Guid vehicleId);
        Task<(bool, string message)> UpdateVehicleWithDrivers(Guid vehicleId, List<Guid> driverGuids);
    }
}
