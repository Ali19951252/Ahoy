using ProjectCommons.CommonModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectCommons.CosmosCommon.CosmosInterface
{
    public interface ICosmosInterface
    {
        public Task CreateHotel(HotelDetails vaalue);
        public Task CreateCustomer(CustomerDetails vaalue);
        public  Task<List<HotelDetails>> GetHotelList();
        public  Task<List<HotelDetails>> GetHotel(string type, Guid? hotelId);
        public Task DeleteHotel(string hotelName, Guid? hotelId);
        public Task UpdateHotel(HotelDetails hoteldetailvalue);
    }
}
