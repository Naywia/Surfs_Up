namespace Surfs_Up_WebAPI.Models;
public class EquipmentModel
{
    public int ID { get; set; }
    public string Name { get; set; } = null!;
    public double Length { get; set; }
    public double Width { get; set; }
    public double Thickness { get; set; }
    public double Volume { get; set; }
    public string Type { get; set; } = null!;
    public double Price { get; set; }
    public string Equipment { get; set; } = null!;
    public string ImagePath { get; set; } = null!;
    public List<BookingModel>? Bookings { get; set; }
}