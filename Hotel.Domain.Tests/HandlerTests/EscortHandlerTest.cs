using Hotel.Domain.Commands;
using Hotel.Domain.Entities;
using Hotel.Domain.Handlers;
using Hotel.Domain.Repositories.Contracts;
using Moq;
using Xunit;

namespace Hotel.Domain.Tests.HandlerTests
{
    public class EscortHandlerTest
    {
        [Fact]
        public async Task ShouldBeAbleToCreateNewEscort()
        {
            var fakeEscortRepository = new Mock<IEscortsRepository>();
            var fakeHotelGuestRepository = new Mock<IHotelGuestsRepository>();
            var hotelGuest = new HotelGuest("Joseph", "19 RCB", new DateTime(2003, 03, 20), "21939140", "joseph@gmail.com");

            fakeHotelGuestRepository.Setup(x => x.GetHotelGuestById(It.IsAny<Guid>())).ReturnsAsync(hotelGuest);

            var createEscortCommand = new CreateEscortCommand("Ana", "Esposa", new DateTime(2002, 02, 12), hotelGuest.Id);

            var escortHandler = new EscortHandler(fakeEscortRepository.Object, fakeHotelGuestRepository.Object);

            var result = (GenericCommandResult) await escortHandler.Handle(createEscortCommand);

            Assert.True(result.Success);
        }
    }
}
