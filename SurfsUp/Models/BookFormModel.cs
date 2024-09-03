using System.ComponentModel.DataAnnotations;

namespace SurfsUp.Models;

public class BookFormModel
{
    [Required]
    [Display(Name = "Fornavn")]
    public string FirstName {get; set;}

    [Required]
    [Display(Name = "Efternavn")]
    public string LastName {get; set;}

    [Required]
    [Display(Name = "Tidspunkt")]
    public DateTime Time {get; set;}

    [Required]
    [Display(Name = "Udstyr")]
    public EquipmentModel Equipment {get; set;}
}