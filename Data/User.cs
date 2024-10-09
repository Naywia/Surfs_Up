using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace SurfsUp.Data
{
    public class User : IdentityUser
    {
        // [Display(Name = "Husk mig?")]
        public bool RememberMe { get; set; }
    }
}