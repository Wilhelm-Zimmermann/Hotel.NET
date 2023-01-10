using Microsoft.EntityFrameworkCore;
using Hotel.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Hotel.Domain.Repositories.Contracts;

namespace Hotel.Domain.Infra.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DbSet<HotelGuest> HotelGuests { get; set; }
        public DbSet<Escort> Escorts { get; set; }
        public DbSet<User> Users { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelGuest>(entity =>
            {
                entity.ToTable("hotel_guests");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name);
                entity.Property(x => x.BirthDate);
                entity.Property(x => x.Email);
                entity.Property(x => x.PhoneNumber);
                entity.Property(x => x.Om);
            });

            modelBuilder.Entity<Escort>(entity =>
            {
                entity.ToTable("escorts");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name);
                entity.Property(x => x.BirthDate);
                entity.Property(x => x.Relationship);
                entity.HasOne(x => x.HotelGuest).WithMany(x => x.Escorts).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name);
                entity.Property(x => x.Password);
                entity.Property(x => x.Role);
            });
        }
    }
}