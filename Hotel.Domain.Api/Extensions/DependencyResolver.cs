using Hotel.Domain.Handlers;
using Hotel.Domain.Infra.Contexts;
using Hotel.Domain.Repositories.Contracts;
using Hotel.Domain.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Domain.Api.Extensions
{
    public static class DependencyResolver
    {
        public static void Resolve(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("WebApiDatabase");

            builder.Services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            builder.Services.AddScoped<IHotelGuestsRepository, HotelGuestsRepository>();
            builder.Services.AddScoped<IEscortsRepository, EscortsRepository>();
            builder.Services.AddScoped<EscortHandler, EscortHandler>();
            builder.Services.AddScoped<HotelGuestHandler, HotelGuestHandler>();
        }
    }
}