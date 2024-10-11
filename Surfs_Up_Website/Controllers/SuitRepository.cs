using Newtonsoft.Json;
using SurfsUp.Data;
using SurfsUp.Models;

namespace SurfsUp.Controllers;

public static class SuitRepository
{
  private static readonly string api_url = "https://localhost:7052/Suit";

  private static List<SuitModel> _addons = [];

  static SuitRepository()
  {
    GetSuitsFromAPI();
  }

  public static void GetSuitsFromAPI()
  {
    using HttpClient client = new();
    var response = client.GetAsync(api_url).Result;
    if (response.IsSuccessStatusCode)
    {
      var res = response.Content.ReadAsStringAsync().Result;
      _addons = JsonConvert.DeserializeObject<List<SuitModel>>(res) ?? [];
    }
    else
    {
      throw new HttpRequestException($"Couldn't fetch the data... {response.StatusCode}");
    }
  }

  public static List<SuitModel> GetSuits() => _addons;

  public static void Create(SuitModel suit)
  {
    using HttpClient client = new();

    // Build the request parameters as form-urlencoded, which matches typical POST API expectations
    var parameters = new Dictionary<string, string>
      {
        { "name", suit.Name },
        { "type", suit.Type },
        { "description", suit.Description },
        { "imagePath", suit.ImagePath },
        { "price", suit.Price.ToString() }
      };

    var content = new FormUrlEncodedContent(parameters); // Use form URL encoding for the body

    var response = client.PostAsync(api_url, content).Result; // Pass the content in the POST request
    if (response.IsSuccessStatusCode)
    {
      GetSuitsFromAPI();
    }
    else
    {
      throw new HttpRequestException($"Couldn't upload the data... {response.StatusCode}");
    }
  }

  public static void Create(string name, string type, double price, string? imagePath = null, string? description = null)
  {
    SuitModel suit = new()
    {
      Name = name,
      Type = type,
      Price = price,
      Description = description ?? string.Empty,
      ImagePath = imagePath ?? string.Empty
    };

    Create(suit);
  }

  public static void Remove(int id)
  {
    using HttpClient client = new();

    // Send the DELETE request
    var response = client.DeleteAsync(api_url + "/" + id).Result;

    if (response.IsSuccessStatusCode)
    {
      Console.WriteLine("Suit successfully deleted.");
    }
    else
    {
      throw new HttpRequestException($"Couldn't delete the suit... {response.StatusCode}");
    }
  }

  private static bool TryFindSuit(int id, out SuitModel? suit)
  {
    using DataContext dc = new();
    suit = dc.Suits.Find(id);
    return suit == null;
  }
}