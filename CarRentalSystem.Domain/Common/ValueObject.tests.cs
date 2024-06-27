namespace CarRentalSystem.Domain.Common.Tests;

using CarRentalSystem.Domain.Models.CarAds;
using CarRentalSystem.Domain.Models.Dealers;

using FluentAssertions;

using Xunit;

public class ValueObjectTests
{
    private const string PhoneNumber = "+359894567432";
    
    [Fact]
    public void ValueObjects_ShouldNot_BeEqual_OtherIsNull()
    {
        // Arrange
        var valueObject = new PhoneNumber(PhoneNumber);
        
        // Act & Assert
        valueObject.Equals(null).Should().BeFalse();
    }

    [Fact]
    public void ValueObjects_ShouldNot_BeEqual_IfNotSameType()
    {
        // Arrange
        var first = new PhoneNumber(PhoneNumber);
        var second = new Manufacturer("Manufacturer");
        
        // Act & Assert
        // ReSharper disable once SuspiciousTypeConversion.Global
        first.Equals(second).Should().BeFalse();
    }

    [Fact]
    public void ValueObjects_Should_BeEqual_IfSameTypeAndPropertyValues()
    {
        // Arrange
        var first = new PhoneNumber(PhoneNumber);
        var second = new PhoneNumber(PhoneNumber);
        
        // Act & Assert
        first.Equals(second).Should().BeTrue();
    }

    [Fact]
    public void ValueObjects_ShouldNot_BeEqual_IfSameTypeAndNotPropertyValues()
    {
        // Arrange
        var first = new PhoneNumber(PhoneNumber);
        var second = new PhoneNumber("+359894745324");
        
        // Act & Assert
        first.Equals(second).Should().BeFalse();
    }
}