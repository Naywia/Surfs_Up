using System.ComponentModel.DataAnnotations;

namespace SurfsUp.Models;

public class DetailModel
{
    [Key]
    public int ID { get; set; }
    public List<EquipmentModel> Equipment { get; set; } = null!;
    public List<SuitModel> Suits { get; set; } = null!;
    public List<AddonModel> Addons { get; set; } = null!;
}