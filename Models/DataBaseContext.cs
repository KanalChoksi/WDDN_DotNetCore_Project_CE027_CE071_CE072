using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Texi_Booking.Models;

namespace Texi_Booking.Models
{
    public class DataBaseContext:DbContext
    {
        public DataBaseContext()
        {
        }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        public DbSet<Taxi> Taxi { get; set; }
        public DbSet<TempPhoto> Photo { get; set; }
    }
}
