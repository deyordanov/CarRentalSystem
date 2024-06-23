namespace CarRentalSystem.Domain.Models.CarAds.Tests;

using CarRentalSystem.Domain.Exceptions;

using FluentAssertions;

using Xunit;

using static ModelConstants.CarAd;

public class CarAdTests()
{
    private const string ValidManufacturer = "Valid manufacturer";
    private const string ValidModel = "Valid model";
    private const string ValidCategoryName = "Valid category name";
    private const string ValidCategoryDescription = "Valid category description";
    private const string ValidImageIdentifier = "Valid image identifier";
    private const decimal ValidPricePerDay = 10M;
    private const int ValidOptionsNumberOfSeats = 5;

    [Fact]
    public void CarAd_ShouldNot_ThrowException_WhenCreatedWithValidData()
    {
        // Arrange
        var act = CreateValid;
        
        // Act & Assert
        act.Should().NotThrow<InvalidCarAdException>();
    }

    [Fact]
    public void CarAd_Should_ThrowException_WhenCreatedWithInvalidName()
    {
        // Arrange
        var invalidModelUnderMinLength = new string('*', MinimumModelLength - 1);
        var actUnderMinLength = () => Create(invalidModelUnderMinLength, ValidPricePerDay);

        var invalidModelOverMaxLength = new string('*', MaximumModelLength + 1);
        var actOverMaxLength = () => Create(invalidModelOverMaxLength, ValidPricePerDay);
        
        // Act & Assert
        actUnderMinLength.Should().Throw<InvalidCarAdException>();
        actOverMaxLength.Should().Throw<InvalidCarAdException>();
    }

    [Fact]
    public void CarAd_Should_ThrowException_WhenCreatedWithInvalidPricePerDay()
    {
        //  Arrange
        var invalidPricePerDay = -1M;
        var act = () => Create(ValidModel, invalidPricePerDay);
        
        // Act & Assert
        act.Should().Throw<InvalidCarAdException>();
    }
    
    [Fact]
    public void CarAd_ChangeAvailability_Should_MutateIsAvailable()
    {
        // Arrange
        var carAd = CreateValid();
            
        // Act
        carAd.ChangeAvailability();
            
        // Assert
        carAd.IsAvailable.Should().BeFalse();
    }
        
    private static CarAd CreateValid()
        => new CarAd(
            new Manufacturer(ValidManufacturer),
            ValidModel,
            new Category(ValidCategoryName, ValidCategoryDescription),
            ValidImageIdentifier,
            ValidPricePerDay,
            new Options(true, ValidOptionsNumberOfSeats, TransmissionType.Automatic),
            true);
    
    private static CarAd Create(string model, decimal pricePerDay)
        => new CarAd(
            new Manufacturer(ValidManufacturer),
            model,
            new Category(ValidCategoryName, ValidCategoryDescription),
            ValidImageIdentifier,
            pricePerDay,
            new Options(true, ValidOptionsNumberOfSeats, TransmissionType.Automatic),
            true);
}