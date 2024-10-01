using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Surfs_Up_WebAPI.Data;
using Surfs_Up_WebAPI.Models;

namespace Surfs_Up_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EquipmentController : ControllerBase
    {
        [HttpPost(Name = "CreateEquipment")]
        public IActionResult Create(EquipmentModel equipment)
        {
            using DataContext dc = new();
            try
            {
                dc.Equipments.Add(equipment);
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
            List<EquipmentModel> equipments = [.. dc.Equipments];

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
            EquipmentModel equipment = dc.Equipments.Find(id);

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


