using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SurfsUp.Extensions;
using SurfsUp.Models;

namespace SurfsUp.Controllers;

public class BookingController : Controller
{
    private string _latestId = "0000-0000";
    private string IDMaker(string? latestId = null)
    {
        latestId ??= _latestId;

        int idH, idL;
        string[] idArr = latestId.Split('-');

        idH = int.Parse(idArr[0], NumberStyles.HexNumber);
        idL = int.Parse(idArr[1], NumberStyles.HexNumber);

        if (idL >= 65535)   { idH++; } // 65.535 == FFFF
        else                { idL++; }

        string newId = _latestId = $"{idH:X4}-{idL:X4}";
        return newId;
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