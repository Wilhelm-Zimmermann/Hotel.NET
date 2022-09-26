using Microsoft.AspNetCore.Mvc;
using Hotel.Domain.Commands;
using Hotel.Domain.Entities;
using Hotel.Domain.Handlers;
using Hotel.Domain.Repositories;
using Hotel.Domain.Repositories.Contracts;

namespace Hotel.Domain.Api.Controller
{
    [ApiController]
    [Route("token")]

    public class TokenController
    {
        [HttpPost]
        [Route("create")]
        public async Task<GenericCommandResult> CreateToken([FromBody] CreateTokenCommand command, [FromServices] TokenHandler handler)
        {
            var handle = (GenericCommandResult) await handler.Handle(command);

            return handle;
        }

        [HttpGet]
        public async Task<IEnumerable<Token>> GetTokens([FromServices] ITokensRepository repository)
        {
            return await repository.GetAllTokens();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Token> GetTokenById([FromServices] ITokensRepository repository, Guid id)
        {
            return await repository.GetTokenById(id);
        }
    }
}