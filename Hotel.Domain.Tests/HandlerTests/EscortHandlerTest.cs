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

        [Fact]
        public async Task ShouldNotBeAbleToCreateEscortWithNoExistingHotelGuest()
        {
            var fakeEscortRepository = new Mock<IEscortsRepository>();
            var fakeHotelGuestRepository = new Mock<IHotelGuestsRepository>();
            var hotelGuest = new HotelGuest("Joseph", "19 RCB", new DateTime(2003, 03, 20), "21939140", "joseph@gmail.com");

            var createEscortCommand = new CreateEscortCommand("Ana", "Esposa", new DateTime(2002, 02, 12), hotelGuest.Id);

            var escortHandler = new EscortHandler(fakeEscortRepository.Object, fakeHotelGuestRepository.Object);

            var result = (GenericCommandResult)await escortHandler.Handle(createEscortCommand);

            Assert.False(result.Success);
        }

        [Fact]

        public async Task ShouldNotBeAbleToCreateEscortWithWrongFields()
        {
            var fakeEscortRepository = new Mock<IEscortsRepository>();
            var fakeHotelGuestRepository = new Mock<IHotelGuestsRepository>();
            var hotelGuest = new HotelGuest("Joseph", "19 RCB", new DateTime(2003, 03, 20), "21939140", "joseph@gmail.com");

            fakeHotelGuestRepository.Setup(x => x.GetHotelGuestById(It.IsAny<Guid>())).ReturnsAsync(hotelGuest);

            var createEscortCommand = new CreateEscortCommand("", "Esposa", new DateTime(2002, 02, 12), hotelGuest.Id);

            var escortHandler = new EscortHandler(fakeEscortRepository.Object, fakeHotelGuestRepository.Object);

            var result = (GenericCommandResult)await escortHandler.Handle(createEscortCommand);

            Assert.Equal("Some Field might be invalid", result.Message);
        }

        [Fact]
        public async Task ShouldBeAbleToUpdateAnExistingEscort()
        {
            var fakeEscortRepository = new Mock<IEscortsRepository>();
            var fakeHotelGuestRepository = new Mock<IHotelGuestsRepository>();
            var hotelGuest = new HotelGuest("Joseph", "19 RCB", new DateTime(2003, 03, 20), "21939140", "joseph@gmail.com");
            var escort = new Escort("Jessica", "Filha", new DateTime(2012, 05, 11), hotelGuest.Id);

            fakeHotelGuestRepository.Setup(x => x.GetHotelGuestById(It.IsAny<Guid>())).ReturnsAsync(hotelGuest);
            fakeEscortRepository.Setup(x => x.GetEscortById(It.IsAny<Guid>())).ReturnsAsync(escort);

            var updateEscortCommand = new UpdateEscortCommand("Bruna", "Esposa", new DateTime(2002, 02, 12), Guid.NewGuid());

            var escortHandler = new EscortHandler(fakeEscortRepository.Object, fakeHotelGuestRepository.Object);

            var result = (GenericCommandResult)await escortHandler.Handle(updateEscortCommand);

            Assert.True(result.Success);
        }

        [Fact]
        public async Task ShouldNotBeAbleToUpdateAnExistingEscortWithNoValidHotelGuest()
        {
            var fakeEscortRepository = new Mock<IEscortsRepository>();
            var fakeHotelGuestRepository = new Mock<IHotelGuestsRepository>();
            var hotelGuest = new HotelGuest("Joseph", "19 RCB", new DateTime(2003, 03, 20), "21939140", "joseph@gmail.com");
            var escort = new Escort("Jessica", "Filha", new DateTime(2012, 05, 11), hotelGuest.Id);

            fakeEscortRepository.Setup(x => x.GetEscortById(It.IsAny<Guid>())).ReturnsAsync(escort);

            var updateEscortCommand = new UpdateEscortCommand("Bruna", "Esposa", new DateTime(2002, 02, 12), Guid.NewGuid());

            var escortHandler = new EscortHandler(fakeEscortRepository.Object, fakeHotelGuestRepository.Object);

            var result = (GenericCommandResult)await escortHandler.Handle(updateEscortCommand);

            Assert.False(result.Success);
        }

        [Fact]
        public async Task ShouldNotBeAbleToUpdateANonExistingEscort()
        {
            var fakeEscortRepository = new Mock<IEscortsRepository>();
            var fakeHotelGuestRepository = new Mock<IHotelGuestsRepository>();

            var hotelGuest = new HotelGuest("Joseph", "19 RCB", new DateTime(2003, 03, 20), "21939140", "joseph@gmail.com");

            fakeHotelGuestRepository.Setup(x => x.GetHotelGuestById(It.IsAny<Guid>())).ReturnsAsync(hotelGuest);

            var updateEscortCommand = new UpdateEscortCommand("Bruna", "Esposa", new DateTime(2002, 02, 12), Guid.NewGuid());

            var escortHandler = new EscortHandler(fakeEscortRepository.Object, fakeHotelGuestRepository.Object);

            var result = (GenericCommandResult)await escortHandler.Handle(updateEscortCommand);

            Assert.False(result.Success);
        }
    }
}
