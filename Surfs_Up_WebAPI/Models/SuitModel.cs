namespace Surfs_Up_WebAPI.Models
{
    public class SuitModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Sizes { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public double Price { get; set; }
        public List<BookingModel>? Bookings { get; set; }
    }
}