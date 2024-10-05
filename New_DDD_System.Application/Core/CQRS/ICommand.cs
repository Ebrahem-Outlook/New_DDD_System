using MediatR;

namespace New_DDD_System.Application.Core.CQRS;

public interface ICommand : IRequest
{

}

public interface ICommand<out TResponse>: IRequest<TResponse>
    where TResponse : class
{

}
