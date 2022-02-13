using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCommons.CommonModels
{
    public class CustomerDetailsRequest
    {
        public string Customer_name { get; set; }
        public string Type { get; set; }
        public string Customer_MobileNumber { get; set; }
        public string Customer_EmailAddress { get; set; }
        public string Hotel_id { get; set; }
        public string Hotel_Name { get; set; }
        public DateTime Checkin_date { get; set; }
        public DateTime Checkout_date { get; set; }
    }
    public class CustomerDetails
    {
        public Guid id { get; set; }
        public string Type { get; set; }
        public Guid Customer_id { get; set; }
        public string Customer_name { get; set; }
        public string Customer_MobileNumber { get; set; }
        public string Customer_EmailAddress { get; set; }
        public string Hotel_id { get; set; }
        public string Hotel_Name { get; set; }
        public DateTime Checkin_date { get; set; }
        public DateTime Checkout_date { get; set; }
    }
}
