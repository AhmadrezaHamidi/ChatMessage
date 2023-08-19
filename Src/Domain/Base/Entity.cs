namespace Domain.Base;

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
