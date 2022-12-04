using Xunit;
using Moq;
using Hotel.Domain.Repositories.Contracts;
using Hotel.Domain.Entities;
using Hotel.Domain.Handlers;
using Hotel.Domain.Commands;

namespace Hotel.Domain.Tests.HandlerTests
{

    public class HotelGuestHandlerTest
    {
        [Fact]
        public async Task ShouldReturnTrueWithObjectCreated()
        {
            var fakeHotelGuestRepository = new Mock<IHotelGuestsRepository>();
            fakeHotelGuestRepository.Setup(x => x.CreateHotelGuest(It.IsAny<HotelGuest>()));
            var fakeHanlder = new HotelGuestHandler(fakeHotelGuestRepository.Object);

            var createHotelGuestCommand = new CreateHotelGuestCommand("Jotaro Kujo", "23 Bi", new DateTime(2002, 11, 10), "(22) 12865-7856", "jotaro@gmail.com");

            var result = (GenericCommandResult)await fakeHanlder.Handle(createHotelGuestCommand);

            Assert.True(result.Success);
        }

        [Fact]
        public async Task ShouldReturnFalseWithObjectNotCreated()
        {
            var fakeHotelGuestRepository = new Mock<IHotelGuestsRepository>();
            fakeHotelGuestRepository.Setup(x => x.CreateHotelGuest(It.IsAny<HotelGuest>()));
            var fakeHanlder = new HotelGuestHandler(fakeHotelGuestRepository.Object);

            var createHotelGuestCommand = new CreateHotelGuestCommand("", "23 Bi", DateTime.UtcNow, "(22) 12865-7856", "jotaro@gmail.com");

            var result = (GenericCommandResult)await fakeHanlder.Handle(createHotelGuestCommand);

            Assert.False(result.Success);
        }

        [Fact]
        public async Task ShouldReturnTrueWithObjectUpdated()
        {
            var fakeHotelGuestRepository = new Mock<IHotelGuestsRepository>();
            var hotelGuest = new HotelGuest("raki", "23 bi", new DateTime(2002, 11, 09), "(12) 19237-9128", "wil@gmail.com");

            fakeHotelGuestRepository.Setup(x => x.UpdateHotelGuest(hotelGuest));
            fakeHotelGuestRepository.Setup(x => x.GetHotelGuestById(It.IsAny<Guid>())).ReturnsAsync(hotelGuest);

            var fakeHanlder = new HotelGuestHandler(fakeHotelGuestRepository.Object);

            var updateHotelGuestCommand = new UpdateHotelGuestCommand("Hanzo hasashi", "23 Bi", new DateTime(2002, 11, 10), "(22) 12865-7856", "jotaro@gmail.com", hotelGuest.Id);

            var result = (GenericCommandResult)await fakeHanlder.Handle(updateHotelGuestCommand);

            Assert.True(result.Success);
        }

        [Fact]
        public async Task ShouldReturnFalseeWithObjectNotUpdated()
        {
            var fakeHotelGuestRepository = new Mock<IHotelGuestsRepository>();
            var hotelGuest = new HotelGuest("raki", "23 bi", new DateTime(2002, 11, 09), "(12) 19237-9128", "wil@gmail.com");

            fakeHotelGuestRepository.Setup(x => x.UpdateHotelGuest(hotelGuest));
            fakeHotelGuestRepository.Setup(x => x.GetHotelGuestById(It.IsAny<Guid>())).ReturnsAsync(hotelGuest);

            var fakeHanlder = new HotelGuestHandler(fakeHotelGuestRepository.Object);

            var updateHotelGuestCommand = new UpdateHotelGuestCommand("", "23 Bi", DateTime.Now, "(22) 12865-7856", "jotaro@gmail.com", hotelGuest.Id);

            var result = (GenericCommandResult)await fakeHanlder.Handle(updateHotelGuestCommand);

            Assert.False(result.Success);
        }

        [Fact]
        public async Task ShouldReturnAllHotelGuests()
        {
            var fakeHotelGuestRepository = new Mock<IHotelGuestsRepository>();
            var hotelGuest = new HotelGuest("Joseph", "44 BIB", new DateTime(2002, 10, 11), "(11) 91283-1234", "joseph@gmail.com");
            fakeHotelGuestRepository.Setup(x => x.GetAllHotelGuests()).ReturnsAsync(new List<HotelGuest>{hotelGuest});

            var result = await fakeHotelGuestRepository.Object.GetAllHotelGuests();

            Assert.IsType<List<HotelGuest>>(result);
        }

        [Fact]
        public async Task ShouldReturnASpecificHotelGuestById()
        {
            var fakeHotelGuestRepository = new Mock<IHotelGuestsRepository>();
            var hotelGuest = new HotelGuest("Joseph", "44 BIB", new DateTime(2002, 10, 11), "(11) 91283-1234", "joseph@gmail.com");
            fakeHotelGuestRepository.Setup(x => x.GetHotelGuestById(It.IsAny<Guid>())).ReturnsAsync(hotelGuest);


            var result = await fakeHotelGuestRepository.Object.GetHotelGuestById(hotelGuest.Id);
            
            Assert.Equal(hotelGuest.Id, result.Id);
        }

        [Fact]
        public async Task ShouldBeAbleToDeleteAHotelGuest()
        {
            var fakeHotelGuestRepository = new Mock<IHotelGuestsRepository>();
            var hotelGuest = new HotelGuest("Joseph", "44 BIB", new DateTime(2002, 10, 11), "(11) 91283-1234", "joseph@gmail.com");

            fakeHotelGuestRepository.Setup(x => x.DeleteHotelGuest(It.IsAny<HotelGuest>()));
            fakeHotelGuestRepository.Setup(x => x.GetHotelGuestById(It.IsAny<Guid>())).ReturnsAsync(hotelGuest);

            var hotelGuestToDelete = await fakeHotelGuestRepository.Object.GetHotelGuestById(hotelGuest.Id);
            await fakeHotelGuestRepository.Object.DeleteHotelGuest(hotelGuestToDelete);

            Assert.NotNull(hotelGuestToDelete);
        }
    }
}
