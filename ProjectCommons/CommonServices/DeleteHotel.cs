
using ProjectCommons.CommonModels;
using ProjectCommons.CosmosCommon.CosmosRepository;
using ProjectCommons.MediatorCommon;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectCommons.CommonServices
{
    
	public class DeleteHotel
	{
		public class Request : BaseRequest<Response>
		{
			public Request(string hotelName, Guid hotelId)
			{
				HotelName = hotelName;
				HotelId = hotelId;

			}

			public string HotelName { get; set; }
			public Guid? HotelId { get; set; }

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
				await _cosmos.DeleteHotel(request.HotelName, request.HotelId);
				return new Response
				{
				};
			}


		}
	}
}
