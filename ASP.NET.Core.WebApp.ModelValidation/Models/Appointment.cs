using System;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET.Core.WebApp.ModelValidation.Models
{
    public class Appointment
    {
        [Required]
        [Display(Name ="name")]
        public string ClientName { get; set; }

        [UIHint("Date")]
        [Required(ErrorMessage ="Please enter the date")]
        public DateTime? Date { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the terms"]
        public bool TermsAccepted { get; set; }
    }
}
