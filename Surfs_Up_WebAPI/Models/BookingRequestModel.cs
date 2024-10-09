using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Surfs_Up_WebAPI.Models
{
    [NotMapped]
    public class BookingRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Time { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
        public List<int>? EquipmentIDs { get; set; } = null;
        public List<int>? SuitIDs { get; set; } = null;
        public List<int>? AddonIDs { get; set; } = null;
    }
}