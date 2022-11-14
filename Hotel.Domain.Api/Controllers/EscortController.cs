using Hotel.Domain.Commands;
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
    }
}
