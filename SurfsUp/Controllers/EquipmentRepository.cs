using SurfsUp.Models;

public static class EquipmentRepository
{
    private static List<EquipmentModel> _equipment = new(){
      new EquipmentModel { Name="The Minilog", Length=6, Width=21, Thickness=2.75, Volume=38.8, Type="Shortboard", Price=565, Equipment=""},
      new EquipmentModel { Name="The Wide Glider", Length=7.1, Width=21.75, Thickness=44.16, Volume=38.8, Type="Funboard", Price=685, Equipment=""},
      new EquipmentModel { Name="The Golden Ratio", Length=6.3, Width=21.85, Thickness=43.22, Volume=38.8, Type="Funboard", Price=695, Equipment=""},
      new EquipmentModel { Name="Mahi Mahi", Length=5.4, Width=20.75, Thickness=2.3, Volume=29.39, Type="Fish", Price=645, Equipment=""},
      new EquipmentModel { Name="The Emerald Glider", Length=9.2, Width=22.8, Thickness=65.4, Volume=38.8, Type="Longboard", Price=895, Equipment=""},
      new EquipmentModel { Name="The Bomb", Length=5.5, Width=21, Thickness=2.5, Volume=33.7, Type="Shortboard", Price=645, Equipment=""},
      new EquipmentModel { Name="Walden Magic", Length=9.6, Width=19.4, Thickness=3, Volume=80, Type="Longboard", Price=1025, Equipment=""},
      new EquipmentModel { Name="Naish One", Length=12.6, Width=30, Thickness=6, Volume=301, Type="SUP", Price=854, Equipment="Paddle"},
      new EquipmentModel { Name="Six Tourer", Length=11.6, Width=32, Thickness=6, Volume=270, Type="SUP", Price=611, Equipment="Fin, Paddle, Pump, Leash"},
      new EquipmentModel { Name="Naish Maliko", Length=14, Width=25, Thickness=6, Volume=330, Type="SUP", Price=1304, Equipment="Fin, Paddle, Pump, Leash"}
    };

    public static List<EquipmentModel> GetEquipment() => _equipment;
}