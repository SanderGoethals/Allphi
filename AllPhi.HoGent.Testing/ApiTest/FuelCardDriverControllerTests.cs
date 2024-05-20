using AllPhi.HoGent.Datalake.Data.Models;
using AllPhi.HoGent.Datalake.Data.Store;
using AllPhi.HoGent.RestApi.Controllers;
using AllPhi.HoGent.RestApi.Dto;
using AllPhi.HoGent.Testing.MockData;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllPhi.HoGent.Testing.ApiTest
{
    public class FuelCardDriverControllerTests
    {
        [Fact]
        public async Task GetAllFuelCardDrivers_ReturnsListOfFuelCardDrivers()
        {
            #region Arrange
            var fuelCardDriverStoreMock = FuelCardDriverStoreMock.GetFuelCardDriverStoreMock();
            var controller = new FuelCardDriverController(fuelCardDriverStoreMock.Object);
            #endregion

            #region Act
            var result = await controller.GetAllFuelCardDrivers();
            #endregion

            #region Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var fuelCardDriverListDto = Assert.IsType<List<FuelCardDriverListDto>>(actionResult.Value);
            Assert.NotEmpty(fuelCardDriverListDto);
            #endregion
        }

        [Fact]
        public async Task GetDriverWithConnectedFuelCardsByDriverId_ReturnsFuelCards_WhenCardsExist()
        {
            #region Arrange
            var fuelCardDriverStoreMock = FuelCardDriverStoreMock.GetFuelCardDriverStoreMock();
            var controller = new FuelCardDriverController(fuelCardDriverStoreMock.Object);
            var driverId = new Guid("a7245037-c683-4f82-b261-5c053502ed93");
            #endregion

            #region Act
            var result = await controller.GetDriverWithFuelCardsByDriverId(driverId);
            #endregion

            #region Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnedFuelCards = Assert.IsType<List<FuelCardDriver>>(actionResult.Value);
            Assert.NotEmpty(returnedFuelCards);
            #endregion
        }

        [Fact]
        public async Task GetDriverWithConnectedFuelCardsByDriverId_ReturnsNotFound_WhenNoCardsExist()
        {
            #region Arrange
            var fuelCardDriverStoreMock = FuelCardDriverStoreMock.GetFuelCardDriverStoreMock();
            var controller = new FuelCardDriverController(fuelCardDriverStoreMock.Object);
            var driverId = new Guid("c2d6e4f9-af4f-68f7-a4c2-1e3f4c6e8c7e");
            #endregion

            #region Act
            var result = await controller.GetDriverWithFuelCardsByDriverId(driverId);
            #endregion

            #region Assert
            Assert.IsType<NotFoundObjectResult>(result);
            #endregion
        }

        [Fact]
        public async Task GetFuelCardWithConnectedDriversByFuelCardId_ReturnsDrivers_WhenDriversExist()
        {
            #region Arrange
            var fuelCardDriverStoreMock = FuelCardDriverStoreMock.GetFuelCardDriverStoreMock();
            var controller = new FuelCardDriverController(fuelCardDriverStoreMock.Object);
            var fuelCardId = new Guid("e4f8a6b1-cg6f-8ah9-c6e4-3g5h6e8g0h9f");
            #endregion

            #region Act
            var result = await controller.GetFuelCardWithDriversByFuelCardId(fuelCardId);
            #endregion

            #region Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnedDrivers = Assert.IsType<List<FuelCardDriver>>(actionResult.Value);
            Assert.NotEmpty(returnedDrivers);
            #endregion

        }

        [Fact]
        public async Task GetFuelCardWithConnectedDriversByFuelCardId_ReturnsNotFound_WhenNoDriversExist()
        {
            #region Arrange
            var fuelCardDriverStoreMock = FuelCardDriverStoreMock.GetFuelCardDriverStoreMock();
            var controller = new FuelCardDriverController(fuelCardDriverStoreMock.Object);
            var fuelCardId = new Guid("d3e7f5a0-bf5f-79g8-b5d3-2f4g5d7f9d8g");
            #endregion

            #region Act
            var result = await controller.GetFuelCardWithDriversByFuelCardId(fuelCardId);
            #endregion

            #region Assert
            Assert.IsType<NotFoundObjectResult>(result);
            #endregion
        }

        [Fact]
        public async Task UpdateDriverFuelCardsByDriverId_ReturnsOk_WhenDriverFuelCardsAreUpdated()
        {
            #region Arrange
            var fuelCardDriverStoreMock = FuelCardDriverStoreMock.GetFuelCardDriverStoreMock();
            var controller = new FuelCardDriverController(fuelCardDriverStoreMock.Object);
            var driverId = new Guid("a7245037-c683-4f82-b261-5c053502ed93");

            var newFuelCardIds = new List<Guid>{
                                        new Guid("e4f8a6b1-cg6f-8ah9-c6e4-3g5h6e8g0h9f"),
                                        new Guid("f5b7598d-6c26-4ef4-ba0e-48210d8c28bf"),
                                        new Guid("a7a24c2f-7358-4c86-ba47-d13a8f69f892") 
                                          };
            #endregion

            #region Act
            var result = await controller.UpdateDriverFuelCardsByDriverId(driverId, newFuelCardIds);
            #endregion

            #region Assert
            Assert.IsType<OkResult>(result);
            #endregion
        }

        [Fact]
        public async Task UpdateFuelCardDriversByFuelCardId_ReturnsOk_WhenFuelCardDriversAreUpdated()
        {
            #region Arrange
            var fuelCardDriverStoreMock = FuelCardDriverStoreMock.GetFuelCardDriverStoreMock();
            var controller = new FuelCardDriverController(fuelCardDriverStoreMock.Object);
            var fuelCardId = new Guid("e4f8a6b1-cg6f-8ah9-c6e4-3g5h6e8g0h9f");
            var newDriverIds = new List<Guid>{ 
                                        new Guid("6b01c497-9cfd-487d-bae1-37d5c9e6ef16"),
                                        new Guid("eedeb2a2-81b1-4b7d-847d-19fc38f2d2ad"), 
                                        new Guid("f5b7598d-6c26-4ef4-ba0e-48210d8c28bf") 
                                          };
            #endregion

            #region Act
            var result = await controller.UpdateFuelCardDriversByFuelCardId(fuelCardId, newDriverIds);
            #endregion

            #region Assert
            Assert.IsType<OkResult>(result);
            #endregion
        }

        [Fact]
        public async Task UpdateDriverFuelCardsByDriverId_ReturnsBadRequest_WhenDriverIdIsEmpty()
        {
            #region Arrange
            var fuelCardDriverStoreMock = FuelCardDriverStoreMock.GetFuelCardDriverStoreMock();
            var controller = new FuelCardDriverController(fuelCardDriverStoreMock.Object);
            var driverId = Guid.Empty;
            var newFuelCardIds = new List<Guid>{
                                        new Guid("e4f8a6b1-cg6f-8ah9-c6e4-3g5h6e8g0h9f"),
                                        new Guid("f5b7598d-6c26-4ef4-ba0e-48210d8c28bf"),
                                        new Guid("a7a24c2f-7358-4c86-ba47-d13a8f69f892")
                                          };
            #endregion

            #region Act
            var result = await controller.UpdateDriverFuelCardsByDriverId(driverId, newFuelCardIds);
            #endregion

            #region Assert
            Assert.IsType<BadRequestResult>(result);
            #endregion
        }

        [Fact]
        public async Task UpdateFuelCardDriversByFuelCardId_ReturnsBadRequest_WhenFuelCardIdIsEmpty()
        {
            #region Arrange
            var fuelCardDriverStoreMock = FuelCardDriverStoreMock.GetFuelCardDriverStoreMock();
            var controller = new FuelCardDriverController(fuelCardDriverStoreMock.Object);
            var fuelCardId = Guid.Empty;
            var newDriverIds = new List<Guid>{
                                        new Guid("6b01c497-9cfd-487d-bae1-37d5c9e6ef16"),
                                        new Guid("eedeb2a2-81b1-4b7d-847d-19fc38f2d2ad"),
                                        new Guid("f5b7598d-6c26-4ef4-ba0e-48210d8c28bf")
                                          };
            #endregion

            #region Act
            var result = await controller.UpdateFuelCardDriversByFuelCardId(fuelCardId, newDriverIds);
            #endregion

            #region Assert
            Assert.IsType<BadRequestResult>(result);
            #endregion
        }
    }
}
