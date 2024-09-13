using System.Diagnostics;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SurfsUp.Extensions;
using SurfsUp.Models;

namespace SurfsUp.Controllers;

public class BookingController : Controller
{
    private string IDMaker()
    {
        return "INPUT ID HERE!";
    }

    [HttpPost]
    public IActionResult AddBooking(BookingModel booking)
    {
        booking.ID = IDMaker();
        booking.Equipment = HttpContext.Session.GetObject<DetailModel>("Cart") ?? new DetailModel()
        {
            Equipment = new List<EquipmentModel>(),
            Suits = new List<SuitModel>(),
            Addons = new List<AddonModel>()
        };
        BookingRepository.Add(booking);

        TempData["BookingInfo"] = JsonConvert.SerializeObject(booking); // Convert the object to JSON
        TempData["ShowModal"] = "true";

        // return View(nameof(Index));
        return RedirectToAction("Index", "Home");

        // return Json(new { message = "Booking added!", booking = booking });
    }
}