using Farmtrack.Validation;
using System.ComponentModel.DataAnnotations;

namespace Farmtrack.Models
{
    public class Crop
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage ="Description can't be longer than 500 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Planting date is required")]
        [DataType(DataType.Date)]
        public DateTime PlantingDate { get; set; }
        [Required(ErrorMessage = "Harvest date is required")]
        [DataType(DataType.Date)]
        [DataGreaterThan("PlantingDate")]
        public DateTime HarvestDate { get; set; }

    }
}
