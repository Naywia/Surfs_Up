using Microsoft.EntityFrameworkCore;
using Surfs_Up_WebAPI.Models;

namespace Surfs_Up_WebAPI.Data;

public class DataContext : DbContext
{
    public DbSet<AddonModel> Addon { get; set; } = null!;
    public DbSet<BookingModel> Booking { get; set; } = null!;
    public DbSet<EquipmentModel> Equipment { get; set; } = null!;
    public DbSet<SuitModel> Suit { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=surfsup.db;Cache=Shared;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Fluent API for many-to-many relationship
        modelBuilder.Entity<BookingModel>()
            .HasMany(b => b.Addons)
            .WithMany(a => a.Bookings)
            .UsingEntity(join => join.ToTable("BookingAddon"));

        modelBuilder.Entity<BookingModel>()
            .HasMany(b => b.Suits)
            .WithMany(s => s.Bookings)
            .UsingEntity(join => join.ToTable("BookingSuit"));

        modelBuilder.Entity<BookingModel>()
            .HasMany(b => b.Equipment)
            .WithMany(e => e.Bookings)
            .UsingEntity(join => join.ToTable("BookingEquipment"));
    }
}