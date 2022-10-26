using Microsoft.EntityFrameworkCore;
using Hotel.Domain.Entities;

namespace Hotel.Domain.Infra.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DbSet<HotelGuest> HotelGuests { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Data");
        }
    }
}