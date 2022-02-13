
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectCommons.MediatorCommon
{
	/// <summary>
	/// Abstract handler responsible to provide support for inherited handlers
	/// </summary>
	/// <typeparam name="TRequest"></typeparam>
	/// <typeparam name="TResponse"></typeparam>
	public abstract class BaseHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
					 where TRequest : IRequest<TResponse>
	{



		public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);




	}
}
