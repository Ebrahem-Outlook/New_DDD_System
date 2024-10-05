using New_DDD_System.Domain.Core.Events;

namespace New_DDD_System.Domain.Users.Events;

public sealed record UserUpdatedDomainEvent(User User) : DomainEvent();
