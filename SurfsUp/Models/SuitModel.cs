using System.ComponentModel.DataAnnotations;

namespace SurfsUp.Models;

public class SuitModel
{
    public int ID  { get; set; }
    public string Name { get; set; }
    public string Sizes { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }
}
