using Hotel.Domain.Handlers;
using Microsoft.EntityFrameworkCore;
using Hotel.Domain.Infra.Contexts;
using Hotel.Domain.Repositories.Contracts;
using Hotel.Domain.Infra.Repositories;

namespace Hotel.Domain.Api.Extensions
{
    public static class DependencyResolver
    {
        public static void Resolve(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<DatabaseContext>(opt => opt.UseInMemoryDatabase("Database"));
            builder.Services.AddScoped<ITokensRepository, TokensRepository>();
            builder.Services.AddScoped<TokenHandler, TokenHandler>();
        }
    }
}