using Microsoft.AspNetCore.Mvc;
using Surfs_Up_WebAPI.Data;
using Surfs_Up_WebAPI.Models;

namespace Surfs_Up_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EquipmentController : ControllerBase
    {
        [HttpPost(Name = "CreateEquipment")]
        public IActionResult Create(string name, double length, double width, double thickness, double volume, string type, double price, string equipment, string imagePath)
        {
            using DataContext dc = new();
            try
            {
                dc.Equipment.Add(new EquipmentModel() { Name = name, Length = length, Width = width, Thickness = thickness, Volume = volume, Type = type, Price = price, Equipment = equipment, ImagePath = imagePath });
                dc.SaveChanges();
                return Created();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet(Name = "GetEquipments")]
        public IActionResult GetAll()
        {
            using DataContext dc = new();
            List<EquipmentModel> equipments = [.. dc.Equipment];

            if (equipments != null && equipments.Count > 0)
            {
                return Ok(equipments);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}", Name = "GetEquipment")]
        public IActionResult Get(int id)
        {
            using DataContext dc = new();
            EquipmentModel? equipment = dc.Equipment.Find(id);

            if (equipment != null)
            {
                return Ok(equipment);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut(Name = "UpdateEquipment")]
        public IActionResult Update(int id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete(Name = "DeleteEquipment")]
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}


