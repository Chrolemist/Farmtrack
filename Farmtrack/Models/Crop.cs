using Farmtrack.Validation;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

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

        [Required(ErrorMessage = "Watering frequency is required")]
        public int WateringFrequencyDays { get; set; }
        [Required(ErrorMessage = "Fertilizing frequency is required")]
        public int FertilizingFrequencyDays { get; set; }

        [Required(ErrorMessage = "Growth stage is required")]
        [Range(0, 5, ErrorMessage = "Growth stage must be between 1 and 5")]
        public int GrowthStage { get; set; }



        

    }
}
