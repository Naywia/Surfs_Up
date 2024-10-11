using Microsoft.AspNetCore.Mvc;
using SurfsUp.Models;
using SurfsUp.Extensions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System.Net.Http.Headers;

namespace SurfsUp.Controllers;

public class HomeController : Controller
{
    private static readonly string api_url = "https://localhost:7052/";
    private readonly ILogger<HomeController> _logger;
    public WeatherData WD { get; set; }

    private static DetailModel _cart = null!;

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

        Dictionary<string, List<string>>? validationErrors = null;

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

        _cart = HttpContext.Session.GetObject<DetailModel>("Cart") ?? new DetailModel();
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
                    _cart.Equipment.Add(e);
                }
                break;
            case "suit":
                SuitModel s = suits.FirstOrDefault(i => i.ID == id);
                if (s != null)
                {
                    _cart.Suits.Add(s);
                }
                break;
            case "addon":
                AddonModel a = addons.FirstOrDefault(i => i.ID == id);
                if (a != null)
                {
                    _cart.Addons.Add(a);
                }
                break;
        }
        HttpContext.Session.SetObject("Cart", _cart);

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

    private HttpRequestMessage? CreateRequest(HttpMethod method, string url, string content)
    {
        var request = new HttpRequestMessage(method, url);
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        request.Content = new StringContent(content, Encoding.UTF8);
        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        return request;
    }

    [HttpGet]
    public string TestRegister()
    {
        using HttpClient client = new();
        var parameters = new Dictionary<string, string>
        {
            {"email", "karl@mail.com"},
            {"password", "Kode123!"}
        };

        var req = CreateRequest(
            HttpMethod.Post,
            $"{api_url}register",
            JsonConvert.SerializeObject(parameters)
        ) ?? throw new NullReferenceException("What the heeeeel");

        var response = client.SendAsync(req).Result;
        return $"Register response...\n{(int)response.StatusCode}: {response.StatusCode}";
    }

    [HttpGet]
    public string TestLogin()
    {
        using HttpClient client = new();
        var parameters = new Dictionary<string, string>
        {
            {"email", "karl@mail.com"},
            {"password", "Kode123!"}
        };
        
        var req = CreateRequest(
            HttpMethod.Post,
            $"{api_url}login",
            JsonConvert.SerializeObject(parameters)
        ) ?? throw new NullReferenceException("What the heeeeel");

        var response = client.SendAsync(req).Result;
        return $"Login response...\n{(int)response.StatusCode}: {response.StatusCode}";
    }
}