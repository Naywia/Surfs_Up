using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Surfs_Up_WebAPI.Data;
using Surfs_Up_WebAPI.Models;

namespace Surfs_Up_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        [HttpPost(Name = "CreateBooking")]
        public IActionResult Create(BookingModel booking)
        {
            using DataContext dc = new();
            try
            {
                dc.Booking.Add(booking);
                dc.SaveChanges();
                return Created();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet(Name = "GetBookings")]
        public IActionResult GetAll()
        {
            using DataContext dc = new();
            List<BookingModel> bookings = [.. dc.Booking];

            if (bookings != null && bookings.Count > 0)
            {
                return Ok(bookings);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}", Name = "GetBooking")]
        public IActionResult Get(int id)
        {
            using DataContext dc = new();
            BookingModel booking = dc.Booking.Find(id);

            if (booking != null)
            {
                return Ok(booking);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut(Name = "UpdateBooking")]
        public IActionResult Update(int id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete(Name = "DeleteBooking")]
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}


