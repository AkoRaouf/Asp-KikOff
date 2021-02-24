using ASP.NET.Core.WebApp.ModelValidation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;

namespace ASP.NET.Core.WebApp.ModelValidation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() =>
                         View("MakeBooking", new Appointment { Date = DateTime.Now });

        [HttpPost]
        public ViewResult MakeBooking(Appointment appt)
        {
            if (string.IsNullOrEmpty(appt.ClientName))
            {
                ModelState.AddModelError(nameof(appt.ClientName),
                "Please enter your name");
            }
            if (ModelState.GetValidationState("Date")== ModelValidationState.Valid && DateTime.Now > appt.Date)
            {
                ModelState.AddModelError(nameof(appt.Date),
                "Please enter a date in the future");
            }
            if (!appt.TermsAccepted)
            {
                ModelState.AddModelError(nameof(appt.TermsAccepted),
                "You must accept the terms");
            }
            if (ModelState.GetValidationState(nameof(appt.Date))
                    == ModelValidationState.Valid
                    && ModelState.GetValidationState(nameof(appt.ClientName))
                    == ModelValidationState.Valid
                    && appt.ClientName.Equals("Joe", StringComparison.OrdinalIgnoreCase)
                    && appt.Date.Value.DayOfWeek == DayOfWeek.Monday)
            {
                ModelState.AddModelError("",
                "Joe cannot book appointments on Mondays");
            }
            if (ModelState.IsValid)
            {
                return View("Completed", appt);
            }
            else
            {
                return View();
            }
        }

        public JsonResult ValidateDate(string Date)
        {
            if (!DateTime.TryParse(Date, out DateTime parssedDateTime))
            {
                return Json("Please enter a valid date (mm/dd/yyyy)");
            }
            else if (DateTime.Now > parssedDateTime)
            {
                return Json("Please enter a date in the future");
            }
            else
            {
                return Json(true);
            }
        }
    }
}
