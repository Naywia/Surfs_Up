using Microsoft.AspNetCore.Mvc;
using SurfsUp.Models;
using SurfsUp.Extensions;
using Newtonsoft.Json;

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

        Dictionary<string, List<string>> validationErrors = null;

        if (TempData["ValidationErrors"] != null)
        {
            validationErrors = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(TempData["ValidationErrors"].ToString());
        }

        ViewBag.ValidationErrors = validationErrors;

        if (TempData["ShowModal"] != null && TempData["ShowModal"].ToString() == "true")
        {
            // Retrieve booking information from TempData
            var bookingInfoJson = TempData["BookingInfo"] as string;
            if (!string.IsNullOrEmpty(bookingInfoJson))
            {
                // Deserialize the booking information back into a BookFormModel object
                var bookingInfo = JsonConvert.DeserializeObject<BookingModel>(bookingInfoJson);
                ViewBag.BookingInfo = bookingInfo;
                ViewBag.ShowModal = "show"; // Flag to display the modal
            }
        }

        if (TempData["Booking"] != null && TempData["Booking"].ToString() == "true") {
            ViewBag.Booking = "true";
        }

        cart = HttpContext.Session.GetObject<DetailModel>("Cart") ?? new DetailModel();
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