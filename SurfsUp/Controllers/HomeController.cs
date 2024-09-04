using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SurfsUp.Models;

namespace SurfsUp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public WeatherData WD { get; set; }

    public HomeController(ILogger<HomeController> logger)
    {
        WD = new();
        _logger = logger;
    }

    public IActionResult Index()
    {
        this.ViewData["WD"] = WD;
        var equipment = EquipmentRepository.GetEquipment();
        return View(equipment);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    public IActionResult AddBooking(BookFormModel bookForm) {
        BookRepository.Add(bookForm);
        return View(nameof(Index));
    }
}
