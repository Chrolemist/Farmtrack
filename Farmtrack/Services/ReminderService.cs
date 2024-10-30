using Farmtrack.Data;

namespace Farmtrack.Services
{
    public class ReminderService
    {
        private readonly FarmtrackContext _context;

        public ReminderService(FarmtrackContext context)
        {
            _context = context;
        }

        public List<string> GetReminders()
        {
            var today = DateTime.Now;
            var reminders = new List<string>();
            var crops = _context.Crop.ToList();

            foreach (var crop in crops)
            {
                if (crop.WateringFrequencyDays > 0 && (today - crop.PlantingDate).Days % crop.WateringFrequencyDays == 0)
                    reminders.Add($"It's time to water the crop {crop.Name}");

                if (crop.FertilizingFrequencyDays > 0 && (today - crop.PlantingDate).Days % crop.FertilizingFrequencyDays == 0)
                    reminders.Add($"It's time to fertilize the crop {crop.Name}");

                if ((crop.HarvestDate - today).Days == 7)
                    reminders.Add($"The crop {crop.Name} will be ready for harvest in 7 days");
            }

            return reminders;
        }
    }
}
