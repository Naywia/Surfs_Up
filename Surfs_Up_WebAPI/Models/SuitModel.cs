namespace Surfs_Up_WebAPI.Models;

public class SuitModel
{
    public int ID { get; set; }
    public string Name { get; set; } = null!;
    public string Sizes { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ImagePath { get; set; } = null!;
    public double Price { get; set; }
    public List<BookingModel>? Bookings { get; set; }
}