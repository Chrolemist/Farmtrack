using Farmtrack.Data;
using Microsoft.AspNetCore.Mvc;
using Farmtrack.Models;

namespace Farmtrack.Controllers
{
    public class RemindersController : Controller
    {
        private readonly FarmtrackContext _context;

        public RemindersController(FarmtrackContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var today = DateTime.Now;
            var reminders = new List<string>();

            var crops = _context.Crop.ToList();

            foreach (var crop in crops)
            {
                // Kontrollera vattningsfrekvens
                if (crop.WateringFrequencyDays > 0) // Kontrollera att frekvensen är större än 0
                {
                    if ((today - crop.PlantingDate).Days % crop.WateringFrequencyDays == 0)
                    {
                        reminders.Add($"It's time to water the crop {crop.Name}");
                    }
                }

                // Kontrollera gödslingsfrekvens
                if (crop.FertilizingFrequencyDays > 0) // Kontrollera att frekvensen är större än 0
                {
                    if ((today - crop.PlantingDate).Days % crop.FertilizingFrequencyDays == 0)
                    {
                        reminders.Add($"It's time to fertilize the crop {crop.Name}");
                    }
                }

                // Påminnelse för skörd
                if ((crop.HarvestDate - today).Days == 7)
                {
                    reminders.Add($"The crop {crop.Name} will be ready for harvest in 7 days");
                }
            }

            ViewBag.Reminders = reminders;

            return View();
        }
    }
}

