using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    public class Facilities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid facilities_id { get; set; }
        public Guid Hotel_id { get; set; }
        [ForeignKey(nameof(Hotel_id))]
        public AhoyHotel hotel_id { get; set; }
        public bool? BreakFast { get; set; } = false;
        public bool? Wifi { get; set; } = false;
        public bool? Parking { get; set; } = false;
        public bool? Spa { get; set; } = false;
    }
}
