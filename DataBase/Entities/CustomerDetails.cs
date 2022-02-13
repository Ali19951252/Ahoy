using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    public class CustomerDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Customer_id { get; set; }
        public Guid Hotel_id { get; set; }
        [ForeignKey(nameof(Hotel_id))]
        public AhoyHotel hotel_id { get; set; }
        public string Customer_name { get; set; }
        public string Customer_MobileNumber { get; set; }
        public string Customer_EmailAddress { get; set; }
        public string Hotel_Name { get; set; }
        public DateTime Checkin_date { get; set; }
        public DateTime Checkout_date { get; set; }
    }
}
