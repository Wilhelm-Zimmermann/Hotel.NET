using Microsoft.EntityFrameworkCore;
using Hotel.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Hotel.Domain.Infra.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DbSet<HotelGuest> HotelGuests { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelGuest>(entity =>
            {
                entity.ToTable("hotel_guests");
                entity.Property(x => x.Id);
                entity.Property(x => x.Name);
                entity.Property(x => x.BirthDate);
                entity.Property(x => x.Email);
                entity.Property(x => x.PhoneNumber);
                entity.Property(x => x.Om);
            });
        }
    }
}