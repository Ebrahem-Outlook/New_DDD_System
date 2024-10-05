
namespace New_DDD_System.Domain.Core.BaseType;

public abstract class Entity : IEntity, IEquatable<Entity?>
{
    public Guid Id { get; set; }

    protected Entity(Guid id)
    {
        Id = id;
    }

    protected Entity() { }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Entity);
    }

    public bool Equals(Entity? other)
    {
        return other is not null &&
               Id.Equals(other.Id);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }

    public static bool operator ==(Entity? left, Entity? right)
    {
        return EqualityComparer<Entity>.Default.Equals(left, right);
    }

    public static bool operator !=(Entity? left, Entity? right)
    {
        return !(left == right);
    }
}

public interface IEntity
{
    Guid Id { get; set; }
}
