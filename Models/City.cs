using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Texi_Booking.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Add City")]
        public string Cities { get; set; }
    }
}
