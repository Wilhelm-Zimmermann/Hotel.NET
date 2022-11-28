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

            var createHotelGuestCommand = new CreateHotelGuestCommand("Jotaro Kujo", "23 Bi", DateTime.UtcNow, "(22) 12865-7856", "jotaro@gmail.com");

            var result = (GenericCommandResult) await fakeHanlder.Handle(createHotelGuestCommand);

            Assert.True(result.Success);
        }

        [Fact]
        public async Task ShouldReturnFalse()
        {
            var fakeHotelGuestRepository = new Mock<IHotelGuestsRepository>();
            fakeHotelGuestRepository.Setup(x => x.CreateHotelGuest(It.IsAny<HotelGuest>()));
            var fakeHanlder = new HotelGuestHandler(fakeHotelGuestRepository.Object);

            var createHotelGuestCommand = new CreateHotelGuestCommand("", "23 Bi", DateTime.UtcNow, "(22) 12865-7856", "jotaro@gmail.com");

            var result = (GenericCommandResult)await fakeHanlder.Handle(createHotelGuestCommand);

            Assert.False(result.Success);
        }
    }
}
