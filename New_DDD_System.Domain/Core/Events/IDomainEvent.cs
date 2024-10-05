using MediatR;

namespace New_DDD_System.Domain.Core.Events;

public interface IDomainEvent : INotification
{
    Guid EventId { get; }   
    DateTime OccuredOn { get; }
}
