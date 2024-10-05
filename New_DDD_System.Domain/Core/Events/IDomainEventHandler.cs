using MediatR;

namespace New_DDD_System.Domain.Core.Events;

public interface IDomainEventHandler<TNotification> : INotificationHandler<TNotification>
    where TNotification : IDomainEvent
{

}
