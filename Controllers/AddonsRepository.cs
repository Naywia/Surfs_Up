using SurfsUp.Data;
using SurfsUp.Models;

public static class AddonsRepository
{
    private static readonly List<AddonModel> _addons = [
      new AddonModel { ID=1, Name="Surf Leash – Standard", Type="Standard leash", Description="En robust leash, der findes i længderne 6', 8', og 10'. Designet til at sikre, at dit surfbræt forbliver ved din side under surf sessionen.", ImagePath="/images/addons/leash.png", Price=100.0},
      new AddonModel { ID=2, Name="Surf Voks – Koldvandsvoks", Type="Voks", Description="Specielt udviklet til at sikre et godt greb på dit surfbræt i lavere vandtemperaturer. Forhindrer, at brættet bliver glat selv i koldt vand.", ImagePath="/images/addons/cold_wax.png", Price=100.0},
      new AddonModel { ID=3, Name="Rashguard – Langærmet (Mænd)", Type="Rashguard", Description="Tilbyder beskyttelse mod UV-stråler og sand. Ideel til lange surf sessioner og giver ekstra komfort på vandet.", ImagePath="/images/addons/mens_rash_guard.png", Price=100.0},
      new AddonModel { ID=4, Name="Rashguard – Langærmet (Kvinder)", Type="Rashguard", Description="Tilbyder beskyttelse mod UV-stråler og sand. Ideel til lange surf sessioner og giver ekstra komfort på vandet.", ImagePath="/images/addons/womens_rash_guard.png", Price=100.0},
      new AddonModel { ID=5, Name="Neopren Handsker – 3mm", Type="Handsker", Description="Designet til at holde dine hænder varme i koldt vand. Fås i forskellige størrelser for at sikre en tætsiddende og komfortabel pasform.", ImagePath="/images/addons/gloves.png", Price=100.0},
      new AddonModel { ID=6, Name="Surf Voks – Varmvandsvoks", Type="Voks", Description="Tilpasset varmere vandtemperaturer, så du kan få et optimalt greb på dit bræt uden at vokse smelter eller bliver for klæbrigt.", ImagePath="/images/addons/warm_wax.png", Price=100.0},
    ];

    public static List<AddonModel> GetAddons() => _addons;

    public static void Create(AddonModel addon)
    {
      _addons.Add(addon);
      DataContext.Addons.Add(addon);
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

      _addons.Add(addon);
      DataContext.Addons.Add(addon);
    }

    public static void Remove(int id)
    {
      if (TryFindAddon(id, out var addon))
      {
        DataContext.Addons.Remove(addon);
        _addons.Remove(addon);
      }
      else
      { Console.WriteLine($"Addon with id {id} could not be found... whoops :'("); }
    }

    private static bool TryFindAddon(int id, out AddonModel addon)
    {
      addon = DataContext.Addons.Find(id);
      return addon == null;
    }
}