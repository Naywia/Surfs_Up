using System.Diagnostics;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using SurfsUp.Models;

namespace SurfsUp.Controllers;

public class BookController : Controller
{
    private string IDMaker()
    {
        return "INPUT ID HERE!";
    }

    [HttpPost]
    public JsonResult AddBooking(BookFormModel bookForm)
    {
        bookForm.ID = IDMaker();
        bookForm.Equipment = HttpContext.Session.GetObject<DetailModel>("Cart") ?? new DetailModel()
        {
            Equipment = new List<EquipmentModel>(),
            Suits = new List<SuitModel>(),
            Addons = new List<AddonModel>()
        };
        BookRepository.Add(bookForm);
        // return View(nameof(Index));
        // return RedirectToAction("Index", "Home");

        return Json(new { message = "Booking added!", booking = bookForm });
    }
}