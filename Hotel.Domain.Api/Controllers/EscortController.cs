using Hotel.Domain.Commands;
using Hotel.Domain.Entities;
using Hotel.Domain.Handlers;
using Hotel.Domain.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Domain.Api.Controllers
{
    [ApiController]
    [Route("escorts")]
    public class EscortController
    {
        [HttpPost]
        [Route("create/{hotelGuestId}")]
        public async Task<GenericCommandResult> CreateEscort([FromBody] CreateEscortCommand command, [FromServices] EscortHandler handler, Guid hotelGuestId)
        {
            command.HotelGuestId = hotelGuestId;
            var result = await handler.Handle(command);


            return (GenericCommandResult) result;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<Escort>> GetAllEscorts([FromServices] IEscortsRepository repository)
        {
            var result = await repository.GetAllEscorts();

            return result;
        }

        [HttpGet]
        [Route("{hotelGuestId}")]
        public async Task<GenericCommandResult> GetAllEscortsByHotelGuestsId([FromServices] IEscortsRepository repository, Guid hotelGuestId)
        {
            var result = await repository.GetEsortsByHotelGuestId(hotelGuestId);

            if (result is null)
                return new GenericCommandResult("escort not found", false, null);

            return new GenericCommandResult("Escort Was found", true, result);
        }

        [HttpPut]
        [Route("{id}/update")]
        public async Task<GenericCommandResult> UpdateEscort([FromBody] UpdateEscortCommand command, [FromServices] EscortHandler handler, Guid id)
        {
            command.Id = id;
            var result = (GenericCommandResult) await handler.Handle(command);

            return result;
        }

        [HttpDelete]
        [Route("{id}/delete")]
        public async Task<GenericCommandResult> DeleteEscort([FromServices] IEscortsRepository repository, Guid id)
        {
            var escort = await repository.GetEscortById(id);

            if (escort is null)
                return new GenericCommandResult("Escort does not exists", false, null);

            await repository.DeleteEscort(escort);

            return new GenericCommandResult("Successfull Deleted", true, escort);
        }
    }
}
