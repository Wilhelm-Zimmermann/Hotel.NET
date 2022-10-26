using Microsoft.AspNetCore.Mvc;
using Hotel.Domain.Commands;
using Hotel.Domain.Entities;
using Hotel.Domain.Handlers;
using Hotel.Domain.Repositories;
using Hotel.Domain.Repositories.Contracts;

namespace Hotel.Domain.Api.Controller
{
    [ApiController]
    [Route("hotel-guest")]

    public class HotelGuestController
    {
        [HttpPost]
        [Route("create")]
        public async Task<GenericCommandResult> CreateHotelGuest([FromBody] CreateHotelGuestCommand command, [FromServices] HotelGuestHandler handler)
        {
            var handle = (GenericCommandResult) await handler.Handle(command);

            return handle;
        }

        [HttpGet]
        public async Task<IEnumerable<HotelGuest>> GetHotelGuests([FromServices] IHotelGuestsRepository repository)
        {
            return await repository.GetAllHotelGuests();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<HotelGuest> GetHotelGuestById([FromServices] IHotelGuestsRepository repository, Guid id)
        {
            return await repository.GetHotelGuestById(id);
        }


        [HttpPut]
        [Route("udpate/{id}")]
        public async Task<GenericCommandResult> UpdateHotelGuest([FromBody] UpdateHotelGuestCommand command, [FromServices] HotelGuestHandler handler, Guid id)
        {
            command.Id = id;
            var result = await handler.Handle(command);

            return (GenericCommandResult) result;
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<GenericCommandResult> DeleteHotelGuest([FromServices] IHotelGuestsRepository repository, Guid id)
        {
            var hotelGuest = await repository.GetHotelGuestById(id);

            await repository.DeleteHotelGuest(hotelGuest);

            return new GenericCommandResult("Hotel Guest deleted successfuly", true, hotelGuest);
        }
    }
}