using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurfsUp.Models;

[Table("Booking")]
public class BookingModel
{
    [Key]
    public string? ID { get; set; }

    [Required(ErrorMessage = "Fornavn mangler*")]
    [Display(Name = "Fornavn")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Efternavn mangler*")]
    [Display(Name = "Efternavn")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "Tidspunkt mangler*")]
    [Display(Name = "Tidspunkt")]
    public DateTime Time { get; set; }

    [Required(ErrorMessage = "Telefonnummer mangler*")]
    [Display(Name = "Telefonnummer")]
    public long Phone { get; set; }

    [Required(ErrorMessage = "E-mail mangler*")]
    [Display(Name = "E-mail")]
    public string Email { get; set; } = null!;

    [Display(Name = "Udstyr")]
    public List<EquipmentModel>? Equipment { get; set; }
    public List<SuitModel>? Suits { get; set; }
    public List<AddonModel>? Addons { get; set; }

    public DetailModel GetCart()
    {
        if (Equipment == null || Suits == null || Addons == null)
        { throw new NullReferenceException($"Either {nameof(Equipment)}, {nameof(Suits)} or {nameof(Addons)} was null"); }

        return new()
        {
            Equipment = Equipment,
            Suits = Suits,
            Addons = Addons
        };
    }

    public void SetCart(DetailModel dm)
    {
        Equipment = dm.Equipment;
        Suits = dm.Suits;
        Addons = dm.Addons;
    }
}