using New_DDD_System.Domain.Core.BaseType;
using New_DDD_System.Domain.Users.Events;

namespace New_DDD_System.Domain.Users;

public sealed class User : AggregateRoot
{
    private User(string firstName, string lastName, string email, string password)
        : base(Guid.NewGuid())
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    private User() : base() { }

    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
    public string Email { get; private set; } = default!;
    public string Password { get; private set; } = default!;

    public static User Create(string firstName, string lastName, string email, string password)
    {
        User user = new User(firstName, lastName, email, password);

        user.RaiseDomainEvent(new UserCreatedDomainEvent(user));

        return user; 
    }


    public void UpdateUser(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;

        RaiseDomainEvent(new UserUpdatedDomainEvent(this));
    }

    public void UpdateEmail(string email)
    {
        Email = email;

        RaiseDomainEvent(new UserEmailUpdatedDomainEvent(this));
    }

    public void UpdatePassword(string password) 
    {
        Password = password;

        RaiseDomainEvent(new UserPasswordUpdatedDomainEvent(this));
    }
}
