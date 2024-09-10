using System.ComponentModel.DataAnnotations;

namespace SurfsUp.Models;

public class BookFormModel
{
    public string ID {get; set;}
    
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
    [Display(Name = "Telefonnummer")]
    public long Phone {get; set;}

    [Required]
    [Display(Name = "E-mail")]
    public string Email {get; set;}

    [Required]
    [Display(Name = "Udstyr")]
    public DetailModel Equipment {get; set;}
}