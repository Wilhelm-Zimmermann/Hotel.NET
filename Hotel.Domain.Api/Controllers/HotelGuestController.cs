using Microsoft.AspNetCore.Mvc;
using Hotel.Domain.Commands;
using Hotel.Domain.Entities;
using Hotel.Domain.Handlers;
using Hotel.Domain.Repositories;
using Hotel.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace Hotel.Domain.Api.Controller
{
    [ApiController]
    [Route("hotel-guest")]

    public class HotelGuestController
    {
        [HttpPost]
        [Route("create")]
        [Authorize(Roles = "manager")]
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
        public async Task<GenericCommandResult> GetHotelGuestById([FromServices] IHotelGuestsRepository repository, Guid id)
        {
            var result = await repository.GetHotelGuestById(id);

            if (result == null)
                return new GenericCommandResult("HotelGuest not found", false, null);

            return new GenericCommandResult("Find successfull", true, result);
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