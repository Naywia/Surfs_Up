using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Surfs_Up_WebAPI.Models;

[Table("Addon")]
public class AddonModel
{
    [Key]
    public int ID { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public string Type { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ImagePath { get; set; } = null!;
    [Required]
    public double Price { get; set; }
    public List<BookingModel>? Bookings { get; set; }
}