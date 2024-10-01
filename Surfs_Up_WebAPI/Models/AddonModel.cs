using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Surfs_Up_WebAPI.Models
{

    [Table("Addon")]
    public class AddonModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        [Required]
        public double Price { get; set; }
    }
}