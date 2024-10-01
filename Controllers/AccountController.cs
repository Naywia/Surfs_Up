using Microsoft.AspNetCore.Mvc;

namespace SurfsUp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        { _logger = logger; }

        public IActionResult Login()
        {
            return View();
        }
    }
}