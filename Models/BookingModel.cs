using System.ComponentModel.DataAnnotations;

namespace SurfsUp.Models;

public class BookingModel
{
    public string? ID {get; set;}
    
    [Required(ErrorMessage="Fornavn mangler*")]
    [Display(Name = "Fornavn")]
    public string FirstName {get; set;}

    [Required(ErrorMessage="Efternavn mangler*")]
    [Display(Name = "Efternavn")]
    public string LastName {get; set;}

    [Required(ErrorMessage="Tidspunkt mangler*")]
    [Display(Name = "Tidspunkt")]
    public DateTime Time {get; set;}

    [Required(ErrorMessage="Telefonnummer mangler*")]
    [Display(Name = "Telefonnummer")]
    public long? Phone {get; set;}

    [Required(ErrorMessage="E-mail mangler*")]
    [Display(Name = "E-mail")]
    public string Email {get; set;}

    [Display(Name = "Udstyr")]
    public DetailModel? Equipment {get; set;}
}