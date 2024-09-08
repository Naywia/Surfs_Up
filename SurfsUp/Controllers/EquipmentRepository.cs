using SurfsUp.Models;

public static class EquipmentRepository
{
    private static List<EquipmentModel> _equipment = new(){
      new EquipmentModel { ID=1,  Name="The Minilog", Length=6, Width=21, Thickness=2.75, Volume=38.8, Type="Shortboard", Price=565, Equipment="", ImagePath="/images/boards/shortboard_1.png"},
      new EquipmentModel { ID=2,  Name="The Wide Glider", Length=7.1, Width=21.75, Thickness=44.16, Volume=38.8, Type="Funboard", Price=685, Equipment="", ImagePath="/images/boards/funboard_1.png"},
      new EquipmentModel { ID=3,  Name="The Golden Ratio", Length=6.3, Width=21.85, Thickness=43.22, Volume=38.8, Type="Funboard", Price=695, Equipment="", ImagePath="/images/boards/funboard_2.png"},
      new EquipmentModel { ID=4,  Name="Mahi Mahi", Length=5.4, Width=20.75, Thickness=2.3, Volume=29.39, Type="Fish", Price=645, Equipment="", ImagePath="/images/boards/fish_1.png"},
      new EquipmentModel { ID=5,  Name="The Emerald Glider", Length=9.2, Width=22.8, Thickness=65.4, Volume=38.8, Type="Longboard", Price=895, Equipment="", ImagePath="/images/boards/longboard_1.png"},
      new EquipmentModel { ID=6,  Name="The Bomb", Length=5.5, Width=21, Thickness=2.5, Volume=33.7, Type="Shortboard", Price=645, Equipment="", ImagePath="/images/boards/shortboard_2.png"},
      new EquipmentModel { ID=7,  Name="Walden Magic", Length=9.6, Width=19.4, Thickness=3, Volume=80, Type="Longboard", Price=1025, Equipment="", ImagePath="/images/boards/longboard_2.png"},
      new EquipmentModel { ID=8,  Name="Naish One", Length=12.6, Width=30, Thickness=6, Volume=301, Type="SUP", Price=854, Equipment="Paddle", ImagePath="/images/boards/sup_1.png"},
      new EquipmentModel { ID=9,  Name="Six Tourer", Length=11.6, Width=32, Thickness=6, Volume=270, Type="SUP", Price=611, Equipment="Fin, Paddle, Pump, Leash", ImagePath="/images/boards/sup_2.png"},
      new EquipmentModel { ID=10,  Name="Naish Maliko", Length=14, Width=25, Thickness=6, Volume=330, Type="SUP", Price=1304, Equipment="Fin, Paddle, Pump, Leash", ImagePath="/images/boards/sup_3.png"}
    };

    public static List<EquipmentModel> GetEquipment() => _equipment;
}