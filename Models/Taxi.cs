using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Texi_Booking.Models
{
    public class Taxi
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Taxi Name:")]
        public string Taxiname { get; set; }
        [Required]
        [Display(Name = "Taxi Number:")]
        [RegularExpression(@"^[A-Z]{2}[ -][0-9]{1,2}(?: [A-Z])?(?: [A-Z]*)? [0-9]{4}$")]

        public string Taxinumer { get; set; }

        [Required]
        [Display(Name ="Taxi Description:")]
        [DataType(DataType.MultilineText)]
        public string TaxiDescription { get; set; }

        [Required]
        [Display(Name ="Rent Per KiloMeter:")]
        public int RentPerKm { get; set; }
        public byte[] image { get; set; }

        [Required]
        public int status { get; set; }
    }
}
