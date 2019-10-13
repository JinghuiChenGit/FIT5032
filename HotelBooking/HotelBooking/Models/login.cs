using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class login
    {
        [Display(Name = "Account id")]
        [Required(AllowEmptyStrings = false)]
        public String Account_id { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false)]
        public String Password { get; set; }

        [Display(Name = "Remember me")]
        public bool Remember { get; set; }
    }
}