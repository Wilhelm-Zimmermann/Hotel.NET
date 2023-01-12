using Hotel.Domain.Api.Helpers;
using Hotel.Domain.Commands;
using Hotel.Domain.Entities;
using Hotel.Domain.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Domain.Api.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController
    {
        [HttpPost]
        [Route("create")]
        public async Task<GenericCommandResult> CreateUser([FromBody] CreateUserCommand command, [FromServices] UserHandler handler)
        {
            var result = (GenericCommandResult)await handler.Handle(command);

            return result;
        }

        [HttpPost]
        [Route("login")]
        public async Task<GenericCommandResult> LoginUser([FromBody] LoginUserCommand command, [FromServices] UserHandler handler)
        {
            var result = (GenericCommandResult)await handler.Handle(command);
            var token = "";

            if (result.Data != null)
            {
                token = JwtTokenService.GenerateToken((User)result.Data);
                var userRole = JwtTokenService.GetUserRole(token);

                return new GenericCommandResult("Ok", result.Success, new
                {
                    Token = token,
                });
            }

            return result;
        }
    }
}
