
using ProjectCommons.CosmosCommon.CosmosRepository;
using ProjectCommons.MediatorCommon;
using ProjectCommons.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectCommons.CommonServices
{
 
	public class PutHotel
	{
		public class Request : BaseRequest<Response>
		{
            public Request(HotelDetailsRequestPut hotelDetails)
            {
                HotelDetails = hotelDetails;

            }

            public HotelDetailsRequestPut HotelDetails { get; set; }

		}

		public class Response : BaseResponse
		{

		}
		public class Handler : BaseHandler<Request, Response>
		{
			private readonly ICosmosRepository _cosmos;

			public Handler(ICosmosRepository cosmossetting)
			{
				_cosmos = cosmossetting;
			}

			public override async Task<Response> Handle(Request request, CancellationToken cancellationToken)
			{

				var hoteldetailrequest = new HotelDetails
				{
					id= Guid.NewGuid(),
					hotel_id = request.HotelDetails.hotel_id,
					Type = request.HotelDetails.Type,
					Hotel_name=request.HotelDetails.Hotel_name,
					Facilities = request.HotelDetails.Facilities,
					Description = request.HotelDetails.Description,
					Location = request.HotelDetails.Location,
					Availbale = request.HotelDetails.Availbale,
					Rooms = request.HotelDetails.Rooms
					

				};
				await _cosmos.UpdateHotel(hoteldetailrequest);


				return new Response
				{
				};
			}


		}
	}

}
