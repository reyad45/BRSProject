using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BRS.Models
{
    public class Userlogin
    {
        public int id { get; set; }
        [Required]
        public string userName { get; set; }
        [Required]
        public string Password { get; set; }
        public string userRole { get; set; }

    }
}