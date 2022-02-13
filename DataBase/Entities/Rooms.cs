using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    public class Rooms
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid room_id { get; set; }
        public Guid Hotel_id { get; set; }
        [ForeignKey(nameof(Hotel_id))]
        public AhoyHotel hotel_id { get; set; }
        public string RoomSize { get; set; }
        public string Price { get; set; }
    }
}
