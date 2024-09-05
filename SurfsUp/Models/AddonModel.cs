using System.ComponentModel.DataAnnotations;

namespace SurfsUp.Models;

public class AddonModel
{
    public string Name { get; internal set; }
    public string Type { get; internal set; }
    public string Description { get; internal set; }
    public string ImagePath { get; internal set; }
}