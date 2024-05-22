using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using AllPhi.HoGent.Datalake.Data.Models.Enums;
using AllPhi.HoGent.Datalake.Data.Models;
using AllPhi.HoGent.Datalake.Data.Store;

namespace AllPhi.HoGent.Testing.MockData
{
    public class FuelCardStoreMock
    {
        public static Mock<IFuelCardStore> GetFuelCardsStoreMock()
        {
            var mock = new Mock<IFuelCardStore>();

            var fuelcardMock_1 = new FuelCard
            {
                Id = Guid.NewGuid(),
                Pin = 1234,
                ValidityDate = DateTime.Now.AddYears(2),
                CreatedAt = DateTime.Now.AddYears(-2),
                CardNumber = "123456789",
                Status = Status.Active,

            };

            var fuelCardMock_2 = new FuelCard
            {
                Id = Guid.NewGuid(),
                Pin = 4321,
                ValidityDate = DateTime.Now.AddYears(4),
                CreatedAt = DateTime.Now,
                CardNumber = "987654321",
                Status = Status.Active,
            };

            return mock;
        }
    }
}
