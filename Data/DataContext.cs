using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SurfsUp.Models;

namespace SurfsUp.Data
{
    class DataContext : IdentityDbContext<User>
    {
        public DbSet<AddonModel> Addons { get; set; } = null!;
        public DbSet<BookingModel> Bookings { get; set; } = null!;
        public DbSet<EquipmentModel> Equipments { get; set; } = null!;
        public DbSet<SuitModel> Suits { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("identity");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=surfsup.db;Cache=Shared;");
        }
    }
}