using SurfsUp.Models;

namespace SurfsUp.Controllers;

public static class BookingRepository
{
    private static readonly List<BookingModel> _bookings = [];

    public static void Add(BookingModel booking){
      _bookings.Add(booking);
    }
}