using System;
using System.Collections.Generic;


namespace ProjectCommons.CommonModels
{
    public class HotelDetails
    {
        public Guid id { get; set; }
        public string Type { get; set; }
        public Guid hotel_id { get; set; }
        public string Hotel_name { get; set; }
        public List<Facilities> Facilities { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Availbale { get; set; }
        public List<Rooms> Rooms { get; set; }

    }
    public class HotelDetailsRequest
    {
        public string Hotel_name { get; set; }
        public string Type { get; set; }
        public List<Facilities> Facilities { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Availbale { get; set; }
        public List<Rooms> Rooms { get; set; }

    }
    public class HotelDetailsRequestPut
    {
        public Guid hotel_id { get; set; }
        public string Hotel_name { get; set; }
        public string Type { get; set; }
        public List<Facilities> Facilities { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Availbale { get; set; }
        public List<Rooms> Rooms { get; set; }

    }
    public class Facilities
    {
        public bool? BreakFast { get; set; } = false;
        public bool? Wifi { get; set; } = false;
        public bool? Parking { get; set; } = false;
        public bool? Spa { get; set; } = false;
    }
    public class Rooms
    {
        public string RoomSize { get; set; }
        public string Price { get; set; }
    }
    public class listHotel
    {
        public IEnumerable<HotelDetails> hotelDetailList { get; set; }
    }
}
