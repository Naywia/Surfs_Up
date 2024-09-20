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
        if (!ModelState.IsValid)
        {
            // Collect field-specific errors into TempData
            var errors = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToList()
                );

            TempData["ValidationErrors"] = JsonConvert.SerializeObject(errors);
            TempData["Booking"] = "true";
            return RedirectToAction("Index", "Home");
        }

        booking.ID = IDMaker();
        booking.SetCart(HttpContext.Session.GetObject<DetailModel>("Cart") ?? new DetailModel());
        BookingRepository.Add(booking);

        TempData["BookingInfo"] = JsonConvert.SerializeObject(booking); // Convert the object to JSON
        TempData["ShowModal"] = "true";

        TempData["Booking"] = "true";

        // return View(nameof(Index));
        return RedirectToAction("Index", "Home");

        // return Json(new { message = "Booking added!", booking = booking });
    }
}