using Newtonsoft.Json;
using SurfsUp.Models;

namespace SurfsUp.Controllers;

public static class EquipmentRepository
{
  private static readonly string api_url = "https://localhost:7052/Equipment";
  private static readonly List<EquipmentModel> _equipment = [];

  static EquipmentRepository()
  {
    using HttpClient client = new();
    var response = client.GetAsync(api_url).Result;
    if (response.IsSuccessStatusCode)
    {
      var res = response.Content.ReadAsStringAsync().Result;
      _equipment = JsonConvert.DeserializeObject<List<EquipmentModel>>(res);
    }
    else
    {
      throw new HttpRequestException($"Couldn't fetch the data... {response.StatusCode}");
    }
  }

  public static List<EquipmentModel> GetEquipment() => _equipment;
}