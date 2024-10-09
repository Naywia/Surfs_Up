using System.Diagnostics;
using Newtonsoft.Json;
using SurfsUp.Data;
using SurfsUp.Models;

namespace SurfsUp.Controllers
{
  public static class AddonsRepository
  {
    private static readonly string api_url = "https://localhost:7052/Addon";

    private static List<AddonModel> _addons = [];

    static AddonsRepository()
    {
      GetAddonsFromAPI();
    }

    public static void GetAddonsFromAPI()
    {
      using HttpClient client = new();
      var response = client.GetAsync(api_url).Result;
      if (response.IsSuccessStatusCode)
      {
        var res = response.Content.ReadAsStringAsync().Result;
        _addons = JsonConvert.DeserializeObject<List<AddonModel>>(res) ?? [];
      }
      else
      {
        throw new HttpRequestException($"Couldn't fetch the data... {response.StatusCode}");
      }
    }

    public static List<AddonModel> GetAddons() => _addons;

    public static void Create(AddonModel addon)
    {
      using HttpClient client = new();

      // Build the request parameters as form-urlencoded, which matches typical POST API expectations
      var parameters = new Dictionary<string, string>
      {
        { "name", addon.Name },
        { "type", addon.Type },
        { "description", addon.Description },
        { "imagePath", addon.ImagePath },
        { "price", addon.Price.ToString() }
      };

      var content = new FormUrlEncodedContent(parameters); // Use form URL encoding for the body

      var response = client.PostAsync(api_url, content).Result; // Pass the content in the POST request
      if (response.IsSuccessStatusCode)
      {
        GetAddonsFromAPI();
      }
      else
      {
        throw new HttpRequestException($"Couldn't upload the data... {response.StatusCode}");
      }
    }

    public static void Create(string name, string type, double price, string? imagePath = null, string? description = null)
    {
      AddonModel addon = new()
      {
        Name = name,
        Type = type,
        Price = price,
        Description = description ?? string.Empty,
        ImagePath = imagePath ?? string.Empty
      };

      Create(addon);
    }

    public static void Remove(int id)
    {
      using HttpClient client = new();

      // Send the DELETE request
      var response = client.DeleteAsync(api_url + "/" + id).Result;

      if (response.IsSuccessStatusCode)
      {
        Console.WriteLine("Addon successfully deleted.");
      }
      else
      {
        throw new HttpRequestException($"Couldn't delete the addon... {response.StatusCode}");
      }
    }

    private static bool TryFindAddon(int id, out AddonModel addon)
    {
      using DataContext dc = new();
      addon = dc.Addons.Find(id);
      return addon == null;
    }
  }
}