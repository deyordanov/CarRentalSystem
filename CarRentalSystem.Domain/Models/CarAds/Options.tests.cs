namespace CarRentalSystem.Domain.Models.CarAds.Tests;

using CarRentalSystem.Domain.Exceptions;

using FluentAssertions;

using Xunit;

using static ModelConstants.Options;

public class OptionsTests
{
    private const int ValidOptionsNumberOfSeats = 5;
    
    [Fact]
    public void Options_ShouldNot_ThrowException_WhenCreatedWithValidData()
    {
        // Arrange
        var act = CreateValid;
        
        // Act & Assert
        act.Should().NotThrow<InvalidCarAdException>();
    }

    [Fact]
    public void Options_Should_ThrowException_WhenCreatedWithInvalidNumberOfSeats()
    {
        // Arrange
        var invalidNumberOfSeatsUnderMinRange = MinimumNumberOfSeats - 1;
        var actInvalidUnderMinRange = () => Create(invalidNumberOfSeatsUnderMinRange);

        var invalidNumberOfSeatsOverMaxRange = MaximumNumberOfSeats + 1;
        var actInvalidOverMaxRange = () => Create(invalidNumberOfSeatsOverMaxRange);
        
        // Act & Assert
        actInvalidUnderMinRange.Should().Throw<InvalidOptionsException>();
        actInvalidOverMaxRange.Should().Throw<InvalidOptionsException>();
    }

    private static Options CreateValid()
        => new Options(
            true,
            ValidOptionsNumberOfSeats,
            TransmissionType.Automatic);

    private static Options Create(int numberOfSeats)
        => new Options(
            true,
            numberOfSeats,
            TransmissionType.Automatic);
}