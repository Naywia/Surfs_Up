namespace Surfs_Up_WebAPI.Models
{
    public class EquipmentModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Thickness { get; set; }
        public double Volume { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public string Equipment { get; set; }
        public string ImagePath { get; set; }
    }
}