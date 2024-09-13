namespace SurfsUp.Models;

public class AddonModel
{
    public int ID  { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }
    public double Price { get; set; }
}