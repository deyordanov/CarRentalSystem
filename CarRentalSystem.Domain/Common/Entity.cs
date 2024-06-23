namespace CarRentalSystem.Domain.Common;

public abstract class Entity<TId> 
    where TId : struct
{
    public TId Id { get; private set; } = default;

    public override bool Equals(object? other)
    {
        if (!(other is Entity<TId> entity))
        {
            return false;
        }

        if (ReferenceEquals(this, entity))
        {
            return true;
        }

        if (this.GetType() != entity.GetType())
        {
            return false;
        }
        
        if(this.Id.Equals(default(int)) || entity.Id.Equals(default(int)))
        {
            return false;
        }

        return this.Id.Equals(entity.Id);
    }
    
    public static bool operator ==(Entity<TId>? first, Entity<TId>? second)
    {
        if (first is null && second is null)
        {
            return true;
        }

        if (first is null || second is null)
        {
            return false;
        }

        return first.Equals(second);
    }

    public static bool operator !=(Entity<TId> first, Entity<TId> second)
        => !(first == second);

    public override int GetHashCode()
        => (this.GetType().ToString() + this.Id).GetHashCode();
}