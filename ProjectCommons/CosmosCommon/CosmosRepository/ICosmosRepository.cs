using Microsoft.Azure.Cosmos;
using ProjectCommons.CosmosCommon.CosmosInterface;
using ProjectCommons.CosmosCommon.CosmosModels;
using ProjectCommons.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCommons.CosmosCommon.CosmosRepository
{
    public class ICosmosRepository : ICosmosInterface

    {
        public readonly Container _SettingIdContainer;


        public ICosmosRepository(Container SettingIdContainer)
        {
            _SettingIdContainer = SettingIdContainer;

        }

        #region Creating Hotel

        public async Task CreateHotel(HotelDetails hoteldetailvalue)
        {
             await _SettingIdContainer.CreateItemAsync(hoteldetailvalue);
        }
        #endregion

        #region Create the Customer

        public async Task CreateCustomer(CustomerDetails hoteldetailvalue)
        {
            await _SettingIdContainer.CreateItemAsync(hoteldetailvalue);
        }
        #endregion

        #region Get the List of Hotels

       public async Task<List<HotelDetails>> GetHotelList()
        {
            await Task.CompletedTask;

            List<HotelDetails> detail = new List<HotelDetails>();


            detail = _SettingIdContainer
                .GetItemLinqQueryable<HotelDetails>(true)
                .Where(x=>x.Type== "Hotel" )
                .ToList();
                return detail;
            }
        #endregion

        #region Get The individual Hotel
         public async Task<List<HotelDetails>> GetHotel(string hotelName, Guid? hotelId)
        {
            await Task.CompletedTask;

            List<HotelDetails> detail = new List<HotelDetails>();


            if (hotelName != null && hotelId != Guid.Empty )
            {
                detail = _SettingIdContainer
                .GetItemLinqQueryable<HotelDetails>(true)
                .Where(x => x.hotel_id == hotelId && x.Hotel_name == hotelName)
                .ToList();
            }
            else if (hotelId != Guid.Empty)
            {
                detail = _SettingIdContainer
                .GetItemLinqQueryable<HotelDetails>(true)
                .Where(x => x.hotel_id == hotelId )
                .ToList();
            }
            else if (hotelName != null) 
            {
                detail = _SettingIdContainer
                .GetItemLinqQueryable<HotelDetails>(true)
                .Where(x => x.Hotel_name == hotelName)
                .ToList();
            }
            
            
            return detail;

        }
        #endregion

        #region Delete Hotel
        public async Task DeleteHotel(string hotelName, Guid? hotelId)
        {
            await Task.CompletedTask;
            var hotel = await GetHotel(hotelName, hotelId);
            if(hotel.Count != 0)
            {
                var keyid = hotel.Select(x => x.id).FirstOrDefault();
                var sepratekey = hotel.Select(x => x.Type).FirstOrDefault();
                await _SettingIdContainer.DeleteItemStreamAsync(keyid.ToString(), new PartitionKey(sepratekey));
            }

        }
        #endregion

        #region For Update in the Hotel

        public async Task UpdateHotel(HotelDetails hoteldetailvalue)
        {
            await Task.CompletedTask;
            var hotel = await GetHotel(null, hoteldetailvalue.hotel_id);
            if(hotel.Count != 0)
            { 
                var id = hotel.Select(x => x.id).FirstOrDefault();
                await _SettingIdContainer.ReplaceItemAsync(hoteldetailvalue, id.ToString());
            }
        }
        #endregion


    }

}
