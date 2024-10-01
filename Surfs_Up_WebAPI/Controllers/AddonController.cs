using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Surfs_Up_WebAPI.Data;
using Surfs_Up_WebAPI.Models;

namespace Surfs_Up_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddonController : ControllerBase
    {
        [HttpPost(Name = "CreateAddon")]
        public IActionResult Create(AddonModel addon)
        {
            using DataContext dc = new();
            try
            {
                dc.Addons.Add(addon);
                dc.SaveChanges();
                return Created();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet(Name = "GetAddons")]
        public IActionResult GetAll()
        {
            using DataContext dc = new();
            List<AddonModel> addons = [.. dc.Addons];

            if (addons != null && addons.Count > 0)
            {
                return Ok(addons);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}", Name = "GetAddon")]
        public IActionResult Get(int id)
        {
            using DataContext dc = new();
            AddonModel addon = dc.Addons.Find(id);

            if (addon != null)
            {
                return Ok(addon);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut(Name = "UpdateAddon")]
        public IActionResult Update(int id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete(Name = "DeleteAddon")]
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}

