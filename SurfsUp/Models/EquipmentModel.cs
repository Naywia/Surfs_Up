using System.ComponentModel.DataAnnotations;

namespace SurfsUp.Models;

public class EquipmentModel
{
    public string Name { get; internal set; }
    public double Length { get; internal set; }
    public double Width { get; internal set; }
    public double Thickness { get; internal set; }
    public double Volume { get; internal set; }
    public string Type { get; internal set; }
    public double Price { get; internal set; }
    public string Equipment { get; internal set; }
    public string ImagePath { get; internal set; }
}