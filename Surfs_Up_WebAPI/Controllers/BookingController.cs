using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Surfs_Up_WebAPI.Data;
using Surfs_Up_WebAPI.Models;

namespace Surfs_Up_WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BookingController : ControllerBase
{
    #region Create

    // Initialize the latest ID to a default value
    private string _latestID = "0000-0000";

    private string IDMaker(string? latestID = null)
    {
        /// Generates a new ID based on the latest ID or a specified latest ID.
        /// <returns>A new ID in the format "HHHH-LLLL".</returns>

        // If the provided latestID is null, use the class's _latestID
        latestID ??= _latestID;

        // Split the latestID into two parts: high (HHHH) and low (LLLL) components
        string[] idArr = latestID.Split('-');

        // Parse the high and low parts of the ID from hexadecimal to integers
        int idH = int.Parse(idArr[0], NumberStyles.HexNumber);
        int idL = int.Parse(idArr[1], NumberStyles.HexNumber);

        // Increment the ID, rolling over to the next high value if necessary
        if (idL >= 65535) // Check if the low part has reached its maximum value (FFFF)
        {
            // Increment the high part
            idH++;
        }
        else
        {
            // Otherwise, just increment the low part
            idL++;
        }

        // Create the new ID, format it as "HHHH-LLLL", and update _latestId
        string newId = _latestID = $"{idH:X4}-{idL:X4}";

        // Return the newly generated ID
        return newId;
    }

    [HttpPost(Name = "CreateBooking")]
    public IActionResult Create(BookingRequestModel bookingRequest)
    {
        // Check if the booking request has no selected equipment, suits, or addons
        if (bookingRequest.EquipmentIDs == null && bookingRequest.SuitIDs == null && bookingRequest.AddonIDs == null)
        {
            // Return a 400 Bad Request response if no items are selected
            return BadRequest();
        }

        try
        {
            // Create a new instance of DataContext to interact with the database
            // The using statement ensures proper disposal of the DataContext after use
            using DataContext dc = new();

            // Cast the bookingRequest to BookingModel while passing the DataContext for explicit conversion
            var bookingModel = (BookingModel)(bookingRequest, dc);

            // Retrieve the last booking entry from the database to generate a new ID
            var lastBooking = dc.Booking.OrderBy(b => b.ID).LastOrDefault();

            // If there is a last booking, generate a new ID based on it
            if (lastBooking != null)
            {
                // Generate a new ID based on the last booking's ID
                bookingModel.ID = IDMaker(lastBooking.ID);
            }
            else
            {
                // If there are no previous bookings, create a new ID using the default method
                bookingModel.ID = IDMaker();
            }

            // Add the new booking model to the context and save changes to the database
            dc.Booking.Add(bookingModel);
            dc.SaveChanges();

            // Return a 201 Created response indicating the booking was successfully created
            return Created();
        }
        catch (Exception ex)
        {
            // Return a 400 Bad Request response with the exception message for debugging
            return BadRequest(ex.Message);  // Log or return the exception for debugging
        }
    }

    #endregion

    #region Read

    [HttpGet(Name = "GetBookings")]
    public IActionResult GetAll()
    {
        // Create a new instance of DataContext to interact with the database
        using DataContext dc = new();

        // Retrieve a list of all bookings from the database, including related Equipment, Suits, and Addons
        List<BookingModel> bookings = [.. dc.Booking
                             .Include(b => b.Equipment) // Include related Equipment
                             .Include(b => b.Suits)     // Include related Suits
                             .Include(b => b.Addons)];  // Include related Addons

        // Check if any bookings were retrieved
        if (bookings != null && bookings.Count > 0)
        {
            // Return a 200 OK response with the list of bookings
            return Ok(bookings);
        }
        else
        {
            // Return a 404 Not Found response if no bookings are found
            return NotFound();
        }
    }

    [HttpGet("{id}", Name = "GetBooking")]
    public IActionResult Get(string id)
    {
        // Create a new instance of DataContext to interact with the database
        using DataContext dc = new();

        // Retrieve booking by ID from the database, including related Equipment, Suits, and Addons
        var booking = dc.Booking
                        .Include(b => b.Addons)
                        .Include(b => b.Suits)
                        .Include(b => b.Equipment)
                        .FirstOrDefault(b => b.ID == id.ToString());

        if (booking == null)
        {
            return NotFound(); // Return 404 if the booking does not exist
        }

        return Ok(booking); // Return 200 with the booking details
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