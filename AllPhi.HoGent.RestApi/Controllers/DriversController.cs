using AllPhi.HoGent.Datalake.Data.Helpers;
using AllPhi.HoGent.Datalake.Data.Models;
using AllPhi.HoGent.Datalake.Data.Store;
using AllPhi.HoGent.RestApi.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Runtime.InteropServices;

namespace AllPhi.HoGent.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableRateLimiting("AllPhiFixedLimiter")]
    public class DriversController : ControllerBase
    {
        private readonly IDriverStore _driverStore;
        private readonly IFuelCardDriverStore _fuelCardDriverStore;

        public DriversController(IDriverStore driverStore, IFuelCardDriverStore fuelCardDriverStore)
        {
            _driverStore = driverStore;
            _fuelCardDriverStore = fuelCardDriverStore;
        }

        [HttpGet("getalldrivers")]
        public async Task<ActionResult<(List<DriverDto>, int)>> GetAllDrivers([Optional] string? sortBy, [Optional] bool isAscending, Pagination? pagination = null)
        {
            var (drivers, count) = await _driverStore.GetAllDriversAsync(sortBy, isAscending, pagination);
            if (drivers == null || !drivers.Any())
            {
                return NotFound("Driver not found");
            }

            DriverListDto driverListDtos = MapToDriverListDto(drivers, count);
            return Ok(driverListDtos);

        }

        [HttpGet("getdriverbyid/{driverId}")]
        public async Task<ActionResult<DriverDto>> GetDriverById(Guid driverId)
        {
            Driver driver = await _driverStore.GetDriverByIdAsync(driverId);
            if (driver == null)
            {
                return NotFound("Driver not found");
            }
            DriverDto driverDto = MapToDriverDto(driver);
            return Ok(driverDto);
        }

        [HttpPost("adddriver")]
        public async Task<IActionResult> AddDriver([FromBody] DriverDto driverDto)
        {
            try
            {
                Driver driver = MapToDriver(driverDto);
                await _driverStore.AddDriver(driver);
                return Ok("Driver successfully added");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("updatedriver")]
        public async Task<IActionResult> UpdateDriver([FromBody] DriverDto driverDto)
        {
            try
            {
                Driver driver = MapToDriver(driverDto);
                await _driverStore.UpdateDriver(driver);
                return Ok("Driver successfully updated!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deletedriver/{driverId}")]
        public async Task<IActionResult> DeleteDriver(Guid driverId)
        {
            try
            {
                await _driverStore.RemoveDriver(driverId);
                return Ok($"Driver with ID {driverId} successfully deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // [HttpGet("getdriverincludedfuelcardsbydriverid/{driverId}")]

        [ApiExplorerSettings(IgnoreApi = true)]
        private DriverDto MapToDriverDto(Driver driver)
        {
            return new DriverDto
            {
                Id = driver.Id,
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                City = driver.City,
                Street = driver.Street,
                HouseNumber = driver.HouseNumber,
                PostalCode = driver.PostalCode,
                RegisterNumber = driver.RegisterNumber,
                TypeOfDriverLicense = driver.TypeOfDriverLicense,
                Status = driver.Status
            };
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        private Driver MapToDriver(DriverDto driverDto)
        {
            return new Driver
            {
                Id = driverDto.Id,
                FirstName = driverDto.FirstName,
                LastName = driverDto.LastName,
                City = driverDto.City,
                Street = driverDto.Street,
                HouseNumber = driverDto.HouseNumber,
                PostalCode = driverDto.PostalCode,
                RegisterNumber = driverDto.RegisterNumber,
                TypeOfDriverLicense = driverDto.TypeOfDriverLicense,
                Status = driverDto.Status
            };
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        private DriverListDto MapToDriverListDto(List<Driver> drivers, int count)
        {
            return new DriverListDto
            {
                DriverDtos = drivers.Select(MapToDriverDto).ToList(),
                TotalItems = count
            };
        }
    }
}