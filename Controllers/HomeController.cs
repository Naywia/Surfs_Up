using Microsoft.AspNetCore.Mvc;
using SurfsUp.Models;

namespace SurfsUp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public WeatherData WD { get; set; }

    public static DetailModel cart;

    private List<EquipmentModel> equipment = EquipmentRepository.GetEquipment();
    private List<SuitModel> suits = SuitRepository.GetSuits();
    private List<AddonModel> addons = AddonsRepository.GetAddons();

    public HomeController(ILogger<HomeController> logger)
    {
        WD = new();

        _logger = logger;
    }

    public IActionResult Index()
    {
        this.ViewData["WD"] = WD;

        cart = HttpContext.Session.GetObject<DetailModel>("Cart") ?? new DetailModel() { Equipment = new List<EquipmentModel>(), Suits = new List<SuitModel>(), Addons = new List<AddonModel>() };
        DetailModel model = new()
        {
            Equipment = equipment,
            Suits = suits,
            Addons = addons
        };

        return View(model);
    }

    [HttpPost]
    public JsonResult AddToCart(int id, string type)
    {
        switch (type)
        {
            case "equipment":
                EquipmentModel e = equipment.FirstOrDefault(i => i.ID == id);
                if (e != null)
                {
                    cart.Equipment.Add(e);
                }
                break;
            case "suit":
                SuitModel s = suits.FirstOrDefault(i => i.ID == id);
                if (s != null)
                {
                    cart.Suits.Add(s);
                }
                break;
            case "addon":
                AddonModel a = addons.FirstOrDefault(i => i.ID == id);
                if (a != null)
                {
                    cart.Addons.Add(a);
                }
                break;
        }
        HttpContext.Session.SetObject("Cart", cart);

        // Return the updated list as JSON
        return Json(new { message = "Item added!" });
    }

    [HttpGet]
    public IActionResult GetCartCount()
    {
        int count = HttpContext.Session.GetCartCount();
        return Json(count);
    }

    [HttpGet]
    public JsonResult GetCartItems()
    {
        var cart = HttpContext.Session.GetObject<DetailModel>("Cart") ?? new DetailModel();
        return Json(cart);
    }
}