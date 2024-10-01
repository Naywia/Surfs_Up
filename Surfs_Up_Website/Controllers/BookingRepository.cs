using System.ComponentModel;
using SurfsUp.Models;

public static class BookingRepository
{
    private static List<BookingModel> _bookings = new(){};

    public static void Add(BookingModel booking){
      _bookings.Add(booking);
    }
}