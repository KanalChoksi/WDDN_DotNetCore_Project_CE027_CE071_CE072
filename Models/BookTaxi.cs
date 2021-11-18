using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Texi_Booking.Models
{
    public class BookTaxi
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name ="Select PickUp City")]
        public string Source { get; set; }
        [Required]
        [Display(Name = "Select Drop City")]
        public string Destination { get; set; }
        [Required]
        [Display(Name = "Select Car")]
        public string Carname { get; set; }
        [Required]
        [Display(Name = "PickUp Date")]
        public DateTime Date { get; set; }
        [Required]
        [Display(Name = "PickUp Time")]
        public TimeSpan Time { get; set; }
    }
}
