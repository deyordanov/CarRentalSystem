namespace CarRentalSystem.Domain.Common;

using CarRentalSystem.Domain.Exceptions;
using System.Collections.Concurrent;
using System.Reflection;

public abstract class Enumeration : IComparable
{
    private static readonly ConcurrentDictionary<Type, IEnumerable<object>> EnumerationCache =
        new ConcurrentDictionary<Type, IEnumerable<object>>();

    protected Enumeration(int value)
    {
        this.Value = value;
        this.Name = FromValue<Enumeration>(value).Name;
    }

    protected Enumeration(int value, string name)
    {
        this.Value = value;
        this.Name = name;
    }
    
    public int Value { get; private set; }

    public string Name { get; private set; }

    public static IEnumerable<T> GetAll<T>()
        where T : Enumeration
    {
        var type = typeof(T);

        var values = EnumerationCache
            .GetOrAdd(type, _ => type
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Select(f => f.GetValue(null)!));

        return values.Cast<T>();
    }

    public static T FromValue<T>(int value)
        where T : Enumeration
        => Parse<T, int>(value, nameof(Value).ToLower(), item => item.Value == value);

    public static T FromName<T>(string name)
        where T : Enumeration
        => Parse<T, string>(name, nameof(Name).ToLower(), item => item.Name == name);
    
    private static T Parse<T, TValue>(TValue value, string description, Func<T, bool> predicate)
        where T : Enumeration 
    {
        var matchedItem = GetAll<T>().FirstOrDefault(predicate);

        if (matchedItem is null)
        {
            throw new InvalidOperationException(string.Format(ExceptionConstants.Enumeration.InvalidEnumerationExceptionMessage, value, description, typeof(T)));
        }

        return matchedItem;
    }

    public override string ToString()
        => this.Name;

    public override bool Equals(object? other)
    {
        if (!(other is Enumeration entity))
        {
            return false;
        }

        var typesMatch = this.GetType() == other.GetType();
        var valuesMatch = this.Value == entity.Value;

        return typesMatch && valuesMatch;
    }

    public override int GetHashCode()
        => (this.GetType().ToString() + this.Value).GetHashCode();

    public int CompareTo(object? other)
        => other is null 
            ? 1 
            : this.Value.CompareTo(((Enumeration)other).Value);
}