using MediatR;

namespace New_DDD_System.Application.Core.CQRS;

public interface IQuery<TResponse> : IRequest<TResponse>
    where TResponse : class
{

}
