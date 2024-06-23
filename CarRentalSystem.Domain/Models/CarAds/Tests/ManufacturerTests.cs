namespace CarRentalSystem.Domain.Models.CarAds.Tests;

using CarRentalSystem.Domain.Exceptions;

using FluentAssertions;

using Xunit;

using static ModelConstants.Common;

public class ManufacturerTests
{
    private const string ValidManufacturer = "Valid manufacturer";

    [Fact]
    public void Manufacturer_ShouldNot_ThrowException_WhenCreatedWithValidData()
    {
        // Arrange
        var act = CreateValid;
        
        // Act & Assert
        act.Should().NotThrow<InvalidCarAdException>();
    }

    [Fact]
    public void Manufacturer_Should_ThrowException_WhenCreatedWithInvalidName()
    {
        // Arrange
        var invalidNameUnderMinLength = new string('*', MinimumNameLength - 1);
        var actUnderMinLength = () => Create(invalidNameUnderMinLength);

        var invalidNameOverMaxLength = new string('*', MaximumNameLength + 1);
        var actOverMaxLength = () => Create(invalidNameOverMaxLength);
        
        // Act & Assert
        actUnderMinLength.Should().Throw<InvalidCarAdException>();
        actOverMaxLength.Should().Throw<InvalidCarAdException>();
    }
    
    private static Manufacturer CreateValid()
        => new Manufacturer(ValidManufacturer);

    private static Manufacturer Create(string manufacturer)
        => new Manufacturer(manufacturer);
}