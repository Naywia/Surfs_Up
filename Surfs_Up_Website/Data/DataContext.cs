using Microsoft.EntityFrameworkCore;
using SurfsUp.Models;

namespace SurfsUp.Data
{
    class DataContext : DbContext
    {
        public DbSet<AddonModel> Addons { get; set; } = null!;
        public DbSet<BookingModel> Bookings { get; set; } = null!;
        public DbSet<EquipmentModel> Equipments { get; set; } = null!;
        public DbSet<SuitModel> Suits { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=surfsup.db;Cache=Shared;");
        }
    }
}