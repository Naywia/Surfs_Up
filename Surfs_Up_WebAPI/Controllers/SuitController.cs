using Microsoft.AspNetCore.Mvc;
using Surfs_Up_WebAPI.Data;
using Surfs_Up_WebAPI.Models;

namespace Surfs_Up_WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SuitController : ControllerBase
{
    [HttpPost(Name = "CreateSuit")]
    public IActionResult Create(string name, string sizes, string type, string description, string imagePath, double price)
    {
        using DataContext dc = new();
        try
        {
            dc.Suit.Add(new SuitModel() { Name = name, Sizes = sizes, Type = type, Description = description, ImagePath = imagePath, Price = price });
            dc.SaveChanges();
            return Created();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpGet(Name = "GetSuits")]
    public IActionResult GetAll()
    {
        using DataContext dc = new();
        List<SuitModel> suits = [.. dc.Suit];

        if (suits != null && suits.Count > 0)
        {
            return Ok(suits);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpGet("{id}", Name = "GetSuit")]
    public IActionResult Get(int id)
    {
        using DataContext dc = new();
        SuitModel? suit = dc.Suit.Find(id);

        if (suit != null)
        {
            return Ok(suit);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPut(Name = "UpdateSuit")]
    public IActionResult Update(int id)
    {
        throw new NotImplementedException();
    }

    [HttpDelete(Name = "DeleteSuit")]
    public IActionResult Delete(int id)
    {
        throw new NotImplementedException();
    }
}