using System.Globalization;
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
        private string _latestId = "0000-0000";
        private string IDMaker(string? latestId = null)
        {
            // If the ID is null, assign it the latestID
            latestId ??= _latestId;

            string[] idArr = latestId.Split('-');
            int idH = int.Parse(idArr[0], NumberStyles.HexNumber);
            int idL = int.Parse(idArr[1], NumberStyles.HexNumber);

            if (idL >= 65535) { idH++; } // 65.535 == FFFF
            else { idL++; }

            string newId = _latestId = $"{idH:X4}-{idL:X4}";
            return newId;
        }

        [HttpPost(Name = "CreateBooking")]
        public IActionResult Create(BookingRequestModel bookingRequest)
        {
            if (bookingRequest.EquipmentIDs == null && bookingRequest.SuitIDs == null && bookingRequest.AddonIDs == null)
            {
                return BadRequest();
            }

            try
            {
                // Create a new instance of DataContext and ensure it is properly disposed after use
                using DataContext dc = new();

                // Pass both the bookingRequest and the DataContext for the explicit cast
                var bookingModel = (BookingModel)(bookingRequest, dc);

                var lastBooking = dc.Booking.OrderBy(b => b.ID).LastOrDefault();

                if (lastBooking != null)
                {
                    bookingModel.ID = IDMaker(lastBooking.ID);
                }
                else
                {
                    bookingModel.ID = IDMaker();
                }


                dc.Booking.Add(bookingModel);
                dc.SaveChanges();
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  // Log or return the exception for debugging
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