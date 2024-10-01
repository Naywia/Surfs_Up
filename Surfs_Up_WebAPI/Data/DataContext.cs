using Microsoft.EntityFrameworkCore;
using Surfs_Up_WebAPI.Models;

namespace Surfs_Up_WebAPI.Data
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