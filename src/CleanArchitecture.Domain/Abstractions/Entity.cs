using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Abstractions;
public abstract class Entity<T>
{
    private readonly List<IDomainEvent> _domainEvents = [];

    protected Entity(T id)
    {
        Id = id;
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected Entity()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }

    public T Id { get; init; }

    [NotMapped]
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected void Raise(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    protected void RemoveDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Remove(domainEvent);
    }

    protected void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}
