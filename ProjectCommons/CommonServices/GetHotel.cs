
using ProjectCommons.CommonModels;
using ProjectCommons.CosmosCommon.CosmosRepository;
using ProjectCommons.MediatorCommon;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectCommons.CommonServices
{
    
	public class GetHotel
	{
		public class Request : BaseRequest<Response>
		{

		}

		public class Response : BaseResponse
		{
			public IEnumerable<HotelDetails> hotelDetailList { get; set; }
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
				var result= await _cosmos.GetHotelList();
				return new Response
				{
					hotelDetailList=result
				};
			}


		}
	}
}
