using SurfsUp.Models;

public static class BookRepository
{
    private static List<BookFormModel> _bookings = new(){};

    public static void Add(BookFormModel bookForm){
      _bookings.Add(bookForm);
    }
}