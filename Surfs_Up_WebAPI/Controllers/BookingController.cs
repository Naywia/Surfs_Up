using Microsoft.AspNetCore.Mvc;
using Surfs_Up_WebAPI.Data;
using Surfs_Up_WebAPI.Models;

namespace Surfs_Up_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        #region Create

        [HttpPost(Name = "CreateBooking")]
        public IActionResult Create(string firstName, string lastName, DateTime pickupTime, long phone, string email) // , List<EquipmentModel>? equipment = null, List<SuitModel>? suits = null, List<AddonModel>? addons = null
        {
            // if (equipment == null && suits == null && addons == null)
            // {
            //     return BadRequest();
            // }

            BookingModel booking = new()
            {
                FirstName = firstName,
                LastName = lastName,
                Time = pickupTime,
                Phone = phone,
                Email = email
            };

            // if (equipment != null)
            // {
            //     booking.Equipment = equipment;
            // }
            // if (suits != null)
            // {
            //     booking.Suits = suits;
            // }
            // if (addons != null)
            // {
            //     booking.Addons = addons;
            // }

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
        #endregion

        #region Read

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
        #endregion

        #region Update

        [HttpPut(Name = "UpdateBooking")]
        public IActionResult Update(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Delete

        [HttpDelete(Name = "DeleteBooking")]
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}