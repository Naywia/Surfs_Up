using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Surfs_Up_WebAPI.Data;

namespace Surfs_Up_WebAPI.Models;

[Table("Booking")]
public class BookingModel
{
    [Key]
    public string ID { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime Time { get; set; }
    public long Phone { get; set; }
    public string Email { get; set; } = null!;
    public List<EquipmentModel>? Equipment { get; set; }
    public List<SuitModel>? Suits { get; set; }
    public List<AddonModel>? Addons { get; set; }

    public static explicit operator BookingModel((BookingRequestModel request, DataContext context) source)
    {
        var (v, dc) = source;

        if (v == null)
        {
            throw new ArgumentNullException(nameof(v));
        }

        return new BookingModel
        {
            FirstName = v.FirstName,
            LastName = v.LastName,
            Time = v.Time,
            Phone = v.Phone,
            Email = v.Email,
            Equipment = v.EquipmentIDs != null ? MapEquipment(v.EquipmentIDs, dc) : null,
            Suits = v.SuitIDs != null ? MapSuits(v.SuitIDs, dc) : null,
            Addons = v.AddonIDs != null ? MapAddons(v.AddonIDs, dc) : null
        };
    }

    // Refactored mapping methods that take a DataContext instance as a parameter
    private static List<EquipmentModel> MapEquipment(List<int> equipmentIds, DataContext dc)
    {
        return [.. dc.Equipment.Where(e => equipmentIds.Contains(e.ID))];
    }

    private static List<SuitModel> MapSuits(List<int> suitIds, DataContext dc)
    {
        return [.. dc.Suit.Where(s => suitIds.Contains(s.ID))];
    }

    private static List<AddonModel> MapAddons(List<int> addonIds, DataContext dc)
    {
        return [.. dc.Addon.Where(a => addonIds.Contains(a.ID))];
    }
}