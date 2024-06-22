namespace CarRentalSystem.Domain.Common;

using System.Reflection;

public abstract class ValueObject
{
    private readonly BindingFlags bindingFlags
        = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;

    public override bool Equals(object? other)
    {
        if (other is null)
        {
            return false;
        }

        var thisType = this.GetType();
        var otherType = other.GetType();

        if (thisType != otherType)
        {
            return false;
        }

        var fields = thisType.GetFields(this.bindingFlags);

        foreach (var field in fields)
        {
            var thisValue = field.GetValue(this);
            var otherValue = field.GetValue(other);

            if (thisValue is null)
            {
                if (otherValue is not null)
                {
                    return false;
                }
            }
            else if (!thisValue.Equals(otherValue))
            {
                return false;
            }
        }

        return true;
    }

    private IEnumerable<FieldInfo> GetFields()
    {
        var type = this.GetType();

        var fields = new List<FieldInfo>();

        while (type != typeof(object) && type is not null)
        {
            fields.AddRange(type.GetFields(this.bindingFlags));
            
            type = type.BaseType;
        }

        return fields;
    }

    public override int GetHashCode()
    {
        var fields = this.GetFields();

        const int startValue = 17;
        const int multiplier = 59;

        return fields
            .Select(field => field.GetValue(this))
            .Where(value => value != null)
            .Aggregate(startValue, (current, value) => current * multiplier + value!.GetHashCode());
    }
    
    public static bool operator ==(ValueObject first, ValueObject second) => first.Equals(second);

    public static bool operator !=(ValueObject first, ValueObject second) => !(first == second);
}