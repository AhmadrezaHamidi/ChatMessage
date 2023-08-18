using System;
namespace Domain.Base
{
    public abstract class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot
    {
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();

        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents = _domainEvents ?? new List<IDomainEvent>();
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        private List<IDomainEvent> _domainEvents;
    }
    public class BusinessRuleException : Exception
    {
        public BusinessRuleException(string message) : base(message)
        {

        }
    }
    public abstract class Entity<TKey>
    {
        public TKey Id { get; protected set; }


        //p1.Equals(p2)
        public override bool Equals(object obj)
        {
            var entity = obj as Entity<TKey>;
            return entity != null &&
                GetType() == entity.GetType() &&
                EqualityComparer<TKey>.Default.Equals(Id, entity.Id);
        }

        public static bool operator ==(Entity<TKey> a, Entity<TKey> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<TKey> a, Entity<TKey> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(GetType(), Id);
        }
    }
    public interface IAggregateRoot
    {
        IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
        void ClearDomainEvents();
    }
    public interface IDomainEvent
    {
    }
}
public abstract class StronglyTypedId<T> : ValueObject<StronglyTypedId<T>>
{
    private Guid _id;

    public Guid Value
    {
        get { return _id; }
        private set
        {
            if (value == Guid.Empty)
                throw new BusinessRuleException("A valid id must be provided.");

            _id = value;
        }
    }

    protected StronglyTypedId(Guid value)
    {
        Value = value;
    }

    protected override bool EqualsCore(StronglyTypedId<T> other)
    {
        return Value == other.Value;
    }

    protected override int GetHashCodeCore()
    {
        unchecked
        {
            return Value.GetHashCode();
        }
    }
}
public abstract class ValueObject<T>
  where T : ValueObject<T>
{
    public override bool Equals(object obj)
    {
        var valueObject = obj as T;

        if (ReferenceEquals(valueObject, null))
            return false;

        return EqualsCore(valueObject);
    }

    public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return true;

        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
    {
        return !(a == b);
    }

    public override int GetHashCode()
    {
        return GetHashCodeCore();
    }

    protected abstract bool EqualsCore(T other);
    protected abstract int GetHashCodeCore();
}

