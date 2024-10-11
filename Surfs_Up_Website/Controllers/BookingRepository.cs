using Newtonsoft.Json;
using SurfsUp.Models;

namespace SurfsUp.Controllers
{
  public static class BookingRepository
  {

    private static readonly string api_url = "https://localhost:7052/Booking";
    private static List<BookingModel> _bookings = new() { };

    static BookingRepository()
    {
      GetBookingsFromAPI();
    }

    public static void GetBookingsFromAPI()
    {
      using HttpClient client = new();
      var response = client.GetAsync(api_url).Result;
      if (response.IsSuccessStatusCode)
      {
        var res = response.Content.ReadAsStringAsync().Result;
        _bookings = JsonConvert.DeserializeObject<List<BookingModel>>(res) ?? [];
      }
      else
      {
        throw new HttpRequestException($"Couldn't fetch the data... {response.StatusCode}");
      }
    }

    public static List<BookingModel> GetBookings() => _bookings;

    public static void Create(BookingModel booking)
    {
      using HttpClient client = new();

      var eIDs = (from e in booking.Equipment select e.ID).ToList();
      var sIDs = (from s in booking.Suits select s.ID).ToList();
      var aIDs = (from a in booking.Addons select a.ID).ToList();


      // Build the request parameters as form-urlencoded, which matches typical POST API expectations
      var parameters = new Dictionary<string, string>
      {
        { "firstName", booking.FirstName },
        { "lastName", booking.LastName },
        { "time", booking.Time.ToString() },
        { "phone", booking.Phone.ToString() },
        { "email", booking.Email },
        { "equipmentIDs", JsonConvert.SerializeObject(eIDs) },
        { "suitIDs", JsonConvert.SerializeObject(sIDs) },
        { "addonIDs", JsonConvert.SerializeObject(aIDs) }
      };

      var content = new FormUrlEncodedContent(parameters); // Use form URL encoding for the body

      var response = client.PostAsync(api_url, content).Result; // Pass the content in the POST request
      if (response.IsSuccessStatusCode)
      {
        GetBookingsFromAPI();
      }
      else
      {
        throw new HttpRequestException($"Couldn't upload the data... {response.StatusCode}");
      }
    }

    public static void Create(string firstName, string lastName, DateTime time, long phone, string email,
    List<EquipmentModel>? equipment = null, List<SuitModel>? suits = null, List<AddonModel>? addons = null)
    {
      // Initialize lists if they are null
      equipment ??= [];
      suits ??= [];
      addons ??= [];

      BookingModel booking = new()
      {
        FirstName = firstName,
        LastName = lastName,
        Time = time,
        Phone = phone,
        Email = email,
        Equipment = equipment,
        Suits = suits,
        Addons = addons
      };

      Create(booking);
    }

    public static void Remove(int id)
    {
      using HttpClient client = new();

      // Send the DELETE request
      var response = client.DeleteAsync(api_url + "/" + id).Result;

      if (response.IsSuccessStatusCode)
      {
        Console.WriteLine("Booking successfully deleted.");
      }
      else
      {
        throw new HttpRequestException($"Couldn't delete the booking... {response.StatusCode}");
      }
    }
  }
}