using System.ComponentModel.DataAnnotations;

namespace PropManageX.DTOs.PropertyDTOs.Property
{
    public class UpdatePropertyDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Location { get; set; }

        public int TotalUnits { get; set; }

        public string Status { get; set; }
    }
}
