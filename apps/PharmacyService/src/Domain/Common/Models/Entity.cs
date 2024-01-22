namespace OrderService.Domain.Common.Models;

public abstract class Entity<TId> : IEquatable<Entity<TId>>
    where TId : notnull
{
    public TId Id {get; protected set;}

    protected Entity(TId id)
    {
        // if (object.Equals(id, default(TId)))
        // {
        //     throw new ArgumentException("The ID cannot be the default value.", "id");
        // }

        Id = id;
        // this.id = id;
    }

    // public TId Id
    // {
    //     get { return this.id; }
    // }

    public override bool Equals(object obj)
    {
        var entity = obj as Entity<TId>;
        if (entity != null)
        {
            return this.Equals(entity);
        }
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }

    #region IEquatable<Entity> Members

    public bool Equals(Entity<TId> other)
    {
        if (other == null)
        {
            return false;
        }
        return this.Id.Equals(other.Id);
    }

    public static bool operator ==(Entity<TId> left, Entity<TId> right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Entity<TId> left, Entity<TId> right)
    {
        return !Equals(left, right);
    }

    // what is this
    #endregion
}