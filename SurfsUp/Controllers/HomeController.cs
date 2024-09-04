using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SurfsUp.Models;

namespace SurfsUp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // var equipment = EquipmentRepository.GetEquipment();

        List<EquipmentModel> equipment = EquipmentRepository.GetEquipment();
        List<SuitModel> suits = SuitRepository.GetSuits();
        DetailModel model = new()
        {
            Equipment = equipment,
            Suits = suits
        };

        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    public IActionResult AddBooking(BookFormModel bookForm)
    {
        BookRepository.Add(bookForm);
        return View(nameof(Index));
    }
}
