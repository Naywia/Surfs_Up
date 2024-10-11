using System.ComponentModel.DataAnnotations.Schema;

namespace Surfs_Up_WebAPI.Models;

[NotMapped]
public class BookingRequestModel
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime Time { get; set; }
    public long Phone { get; set; }
    public string Email { get; set; } = null!;
    public List<int>? EquipmentIDs { get; set; } = null;
    public List<int>? SuitIDs { get; set; } = null;
    public List<int>? AddonIDs { get; set; } = null;
}