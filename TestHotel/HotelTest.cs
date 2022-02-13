using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Project1.Controllers;
using ProjectCommons.CommonModels;
using ProjectCommons.CommonServices;
using ProjectCommons.CosmosCommon.CosmosInterface;
using ProjectCommons.CosmosCommon.CosmosRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace TestHotel
{
    public class HotelTest
    {
        private static Container _SettingIdContainer;

        ICosmosInterface into = new ICosmosRepository(_SettingIdContainer);


        [Fact]
        public void listOfHotels()
        {
            var result = into.GetHotelList();
            result.Should().NotBeNull();
           }

        [Fact]
        public void indivHotel()
        {
            Guid hotel_id = new Guid("c922ff90-d1b2-4f5b-9354-d1d0595c526e");
            var result = into.GetHotel("Montoliza12", hotel_id);
            result.Should().NotBeNull();

        }

        [Fact]
        public void bookingHotel()
        {
            DateTime dateforfuture = new DateTime(2015, 12, 31, 5, 10, 20);
            var bookingTestModel = new CustomerDetails
            {
                id = Guid.NewGuid(),
                Customer_id = Guid.NewGuid(),
                Type = "Customer",
                Customer_name = "Ali",
                Customer_MobileNumber = "05278412225",
                Customer_EmailAddress = "ahmed.ali@halza.com",
                Hotel_id = "c922ff90-d1b2-4f5b-9354-d1d0595c526e",
                Hotel_Name = "Montoliza12",
                Checkin_date = DateTime.Now,
                Checkout_date = dateforfuture
            };
            var result = into.CreateCustomer(bookingTestModel).IsCompleted;
             result.Equals(true);

        }

    }
}
