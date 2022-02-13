using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCommons.MediatorCommon
{
    public abstract class BaseRequest<TResponse> : IRequest<TResponse>
          where TResponse : BaseResponse
    {
    }
}
