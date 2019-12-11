using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BRS.Models
{
    public class BusticketViewModel
    {

        public int busTicketId { get; set; }

        [Display(Name = "From")]
        [Required]
        public string sourceStation { get; set; }
        [Display(Name = "To")]
        [Required]
        public string desStation { get; set; }
        [Display(Name = "Date of Journey")]
        [Required]
        public string Jdate { get; set; }

        [Display(Name = "Date of Return (Optional)")]
        public string rdate { get; set; }
        public bool rdates { get; set; } 
    }
}