using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Surfs_Up_WebAPI.Data;
using Surfs_Up_WebAPI.Models;

namespace Surfs_Up_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddonController : ControllerBase
    {
        #region Create

        [Authorize(Roles = "Admin")]
        [HttpPost(Name = "CreateAddon")]
        public IActionResult Create(string name, string type, string description, string imagePath, double price)
        {
            using DataContext dc = new();
            try
            {
                dc.Addon.Add(new AddonModel() { Name = name, Type = type, Description = description, ImagePath = imagePath, Price = price });
                dc.SaveChanges();
                return Created();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region Read

        [HttpGet(Name = "GetAddons")]
        public IActionResult GetAll()
        {
            using DataContext dc = new();
            List<AddonModel> addons = [.. dc.Addon];

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
            AddonModel? addon = dc.Addon.Find(id);

            if (addon != null)
            {
                return Ok(addon);
            }
            else
            {
                return NotFound();
            }
        }
        #endregion

        #region Update

        [HttpPut("{id}", Name = "UpdateAddon")]
        public IActionResult Update(string id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Delete

        [HttpDelete("{id}", Name = "DeleteAddon")]
        public IActionResult Delete(string id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}


