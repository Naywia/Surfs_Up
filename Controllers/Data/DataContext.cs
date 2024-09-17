using Microsoft.EntityFrameworkCore;
using SurfsUp.Models;

namespace SurfsUp.Data
{
    class DataContext : DbContext
    {
        public static DbSet<AddonModel> Addons { get; set; }
        public static DbSet<BookingModel> Bookings { get; set; }
        public static DbSet<EquipmentModel> Equipments { get; set; }
        public static DbSet<SuitModel> Suits { get; set; }

        public DataContext()
        {}

        public DataContext(DbContextOptions options) : base(options)
        {}
    }
}