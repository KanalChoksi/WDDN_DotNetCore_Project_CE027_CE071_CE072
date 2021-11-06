using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Texi_Booking.Models
{
    public class TempPhoto
    {
        [Key]
        public int id { get; set; }
        public byte[] image { get; set; }
        public string taxiid { get; set; }
    }
}
