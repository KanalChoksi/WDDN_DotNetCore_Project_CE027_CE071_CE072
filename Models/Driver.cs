using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Texi_Booking.Models
{
    public class Driver
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public int Phone { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
