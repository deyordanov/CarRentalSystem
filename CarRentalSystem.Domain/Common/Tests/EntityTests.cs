namespace CarRentalSystem.Domain.Common.Tests;

using CarRentalSystem.Domain.Models.CarAds;

using FluentAssertions;

using Xunit;

public class EntityTests
{
    private const string First = "First";
    private const string Second = "Second";

    [Fact]
    public void Entities_ShouldNot_BeEqual_IfTheyAreNotBothEntities()
    {
        // Arrange
        var first = TransmissionType.Automatic;
        var second = new Manufacturer(Second);
        
        // Act & Assert
        // ReSharper disable once SuspiciousTypeConversion.Global
        first.Equals(second).Should().BeFalse();
    }
    
    [Fact]
    public void Entities_Should_BeEqual_IfTheyHaveTheSameReference()
    {
        // Arrange
        var first = new Manufacturer(First);
        
        // Act & Assert
        // ReSharper disable once EqualExpressionComparison
        first.Equals(first).Should().BeTrue();
    }
    
    [Fact]
    public void Entities_ShouldNot_BeEqual_IfTheyAreFromDifferentTypes()
    {
        // Arrange
        var first = new Category(First, "Valid category description").SetId(1);
        var second = new Manufacturer(Second).SetId(1);
        
        // Act & Assert
        first.Equals(second).Should().BeFalse();
    }

    [Fact]
    public void Entities_ShouldNot_BeEqual_IfAnyIdHasDefaultValue()
    {
        // Arrange
        var first = new Manufacturer(First);
        var second = new Manufacturer(Second);
        
        // Act & Assert
        first.Equals(second).Should().BeFalse();
    }
    
    [Fact]
    public void Entities_Should_BeEqual_WithSameIds()
    {
        // Arrange
        var first = new Manufacturer(First).SetId(1);
        var second = new Manufacturer(Second).SetId(1);
        
        // Act & Assert
        first.Equals(second).Should().BeTrue();
        (first == second).Should().BeTrue();
        (first != second).Should().BeFalse();
    }

    [Fact]
    public void Entities_ShouldNot_BeEqual_WithDifferentIds()
    {
        // Arrange
        var first = new Manufacturer(First).SetId(1);
        var second = new Manufacturer(Second).SetId(2);
        
        // Act & Assert
        first.Equals(second).Should().BeFalse();
        (first == second).Should().BeFalse();
        (first != second).Should().BeTrue();
    }

    [Fact]
    public void Entities_ShouldNot_BeEqual_IfOneIsNull()
    {
        // Arrange
        var first = new Manufacturer(First);
        
        // Act & Assert
        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
        (first == null).Should().BeFalse();
    }
}

internal static class EntityExtensions
{
    public static Entity<T> SetId<T>(this Entity<T> entity, int id)
        where T : struct
    {
        entity
            .GetType()
            .BaseType!
            .GetProperty(nameof(Entity<T>.Id))!
            .GetSetMethod(true)!
            .Invoke(entity, new object[] { id });

        return entity;
    }
}