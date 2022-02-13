using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
   public class HotelDbContext :  DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options) { }

        public DbSet<AhoyHotel> AhoyHotel { get; set; }
        public DbSet<Facilities> Facilities { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<CustomerDetails> CustomerDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=.;database=group;Integrated Security=SSPI;");
        }


    }
}
