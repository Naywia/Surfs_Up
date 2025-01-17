using System.ComponentModel.DataAnnotations.Schema;

namespace SurfsUp.Models;

[NotMapped]
public class DetailModel
{
    public List<EquipmentModel> Equipment { get; set; } = [];
    public List<SuitModel> Suits { get; set; } = [];
    public List<AddonModel> Addons { get; set; } = [];
}