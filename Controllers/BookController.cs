using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using SurfsUp.Models;

namespace SurfsUp.Controllers;

public class BookController : Controller
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
    public JsonResult AddBooking(string firstName, string lastName, DateTime time, long phone, string email)
    {
        BookFormModel bookForm = new()
        {
            ID = IDMaker(),
            FirstName = firstName,
            LastName = lastName,
            Time = time,
            Phone = phone,
            Email = email,
            Equipment = HttpContext.Session.GetObject<DetailModel>("Cart") ?? new DetailModel()
            {
                Equipment = new List<EquipmentModel>(),
                Suits = new List<SuitModel>(),
                Addons = new List<AddonModel>()
            }
        };
        BookRepository.Add(bookForm);
        // return View(nameof(Index));
        // return RedirectToAction("Index", "Home");

        return Json(new { message = "Booking added!", booking = bookForm });
    }
}