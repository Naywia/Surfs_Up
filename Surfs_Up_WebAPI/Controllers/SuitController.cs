using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Surfs_Up_WebAPI.Data;
using Surfs_Up_WebAPI.Models;

namespace Surfs_Up_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SuitController : ControllerBase
    {
        [HttpPost(Name = "CreateSuit")]
        public IActionResult Create(SuitModel suit)
        {
            using DataContext dc = new();
            try
            {
                dc.Suits.Add(suit);
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
            List<SuitModel> suits = [.. dc.Suits];

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
            SuitModel suit = dc.Suits.Find(id);

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
}


