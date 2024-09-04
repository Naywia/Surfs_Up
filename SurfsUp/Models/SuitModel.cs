using System.ComponentModel.DataAnnotations;

namespace SurfsUp.Models;

public class SuitModel
{
    public string Name { get; internal set; }
    public string Sizes { get; internal set; }
    public string Type { get; internal set; }
    public string Description { get; internal set; }
}
