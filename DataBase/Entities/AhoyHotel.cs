using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    public class AhoyHotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid hotel_id { get; set; }
        public string Hotel_name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Availbale { get; set; }
       
    }
}
