
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
 
	public class PostCustome
	{
		public class Request : BaseRequest<Response>
		{
            public Request(CustomerDetailsRequest customerDetails)
            {
				CustomerDetails = customerDetails;

            }

            public CustomerDetailsRequest CustomerDetails { get; set; }

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

				var customerdetailrequest = new CustomerDetails
				{
					id= Guid.NewGuid(),
					Customer_id = Guid.NewGuid(),
					Type = request.CustomerDetails.Type,
					Customer_name = request.CustomerDetails.Customer_name,
					Customer_MobileNumber = request.CustomerDetails.Customer_MobileNumber,
					Customer_EmailAddress = request.CustomerDetails.Customer_EmailAddress,
					Hotel_id = request.CustomerDetails.Hotel_id,
					Hotel_Name = request.CustomerDetails.Hotel_Name,
					Checkin_date = request.CustomerDetails.Checkin_date,
					Checkout_date = request.CustomerDetails.Checkout_date


				};
				await _cosmos.CreateCustomer(customerdetailrequest);


				return new Response
				{
				};
			}


		}
	}

}
