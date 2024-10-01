using SurfsUp.Data;
using SurfsUp.Models;

namespace SurfsUp.Controllers
{
  public static class AddonsRepository
  {
    private static readonly List<AddonModel> _addons = [];

    static AddonsRepository()
    {
      using DataContext dc = new();
      _addons = [.. dc.Addons];
    }

    public static List<AddonModel> GetAddons() => _addons;

    public static void Create(AddonModel addon)
    {
      using DataContext dc = new();
      dc.Addons.Add(addon);
      dc.SaveChanges();
      _addons.Add(addon);
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

      using DataContext dc = new();
      dc.Addons.Add(addon);
      dc.SaveChanges();
      _addons.Add(addon);
    }

    public static void Remove(int id)
    {
      if (TryFindAddon(id, out var addon))
      {
        //DataContext.Addons.Remove(addon);
        using DataContext dc = new();
        dc.Remove(addon);
        dc.SaveChanges();        
        _addons.Remove(addon);
      }
      else
      { Console.WriteLine($"Addon with id {id} could not be found... whoops :'("); }
    }

    private static bool TryFindAddon(int id, out AddonModel addon)
    {
      using DataContext dc = new();
      addon = dc.Addons.Find(id);
      return addon == null;
    }
  }
}