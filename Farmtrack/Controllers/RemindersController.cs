using Farmtrack.Data;
using Microsoft.AspNetCore.Mvc;
using Farmtrack.Models;
using Microsoft.AspNetCore.Authorization;

namespace Farmtrack.Controllers
{
    [Authorize]
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
                
                if (crop.WateringFrequencyDays > 0) 
                {
                    if ((today - crop.PlantingDate).Days % crop.WateringFrequencyDays == 0)
                    {
                        reminders.Add($"It's time to water the crop {crop.Name}");
                    }
                }

                
                if (crop.FertilizingFrequencyDays > 0)
                {
                    if ((today - crop.PlantingDate).Days % crop.FertilizingFrequencyDays == 0)
                    {
                        reminders.Add($"It's time to fertilize the crop {crop.Name}");
                        
                    }
                }

                
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

