using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SurfsUp.Data;

namespace SurfsUp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        // private readonly SignInManager<User> _signInManager;

        public AccountController(ILogger<AccountController> logger)
        { _logger = logger; }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(User user)
        {
            if (ModelState.IsValid)
            {
                var result = await 
            }
        }
    }
}