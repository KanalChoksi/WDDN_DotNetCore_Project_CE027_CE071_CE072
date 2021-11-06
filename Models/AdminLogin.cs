using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Texi_Booking.Models
{
    public class AdminLogin
    {
        [Key]
        public int id { get; set; }
        [Required]
       [Display(Name ="UserName")]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string Password { get; set; }
    }
}
