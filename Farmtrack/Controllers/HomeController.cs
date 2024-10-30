using Farmtrack.Models;
using Farmtrack.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Farmtrack.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ReminderService _remindersService;
        private readonly NotificationService _notificationService;

        public HomeController(ILogger<HomeController> logger, ReminderService remindersService, NotificationService notificationService)
        {
            _logger = logger;
            _notificationService = notificationService;
            _remindersService = remindersService;
        }

        public IActionResult Index()
        {
            var reminders = _remindersService.GetReminders();
            if (reminders.Any())
            {
                _notificationService.SetNotification("You have reminders for today!", "success");
                TempData["NotificationScript"] = _notificationService.GetNotificationScript();
            }
            return View();
            
        }

        public IActionResult Privacy()
        {
            return View();
        }
    

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
