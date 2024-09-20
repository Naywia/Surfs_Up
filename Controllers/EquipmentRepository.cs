using SurfsUp.Data;
using SurfsUp.Models;

namespace SurfsUp.Controllers
{
  public static class EquipmentRepository
  {
    private static readonly List<EquipmentModel> _equipment = [];

    static EquipmentRepository()
    {
      using DataContext dc = new();
      _equipment = [.. dc.Equipments];
    }

    public static List<EquipmentModel> GetEquipment() => _equipment;
  }
}