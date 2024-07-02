namespace CarRentalSystem.Domain.Factories.CarAds;

using CarRentalSystem.Domain.Exceptions;
using CarRentalSystem.Domain.Models.CarAds;

using FluentAssertions;

using Xunit;

using static Exceptions.DomainExceptionConstants.CarAdExceptionMessages;

public class CarAdFactoryTests
{
    private const string ValidManufacturer = "Valid manufacturer";
    private const string ValidModel = "Valid model";
    private const string ValidCategoryName = "Valid category name";
    private const string ValidCategoryDescription = "Valid category description";
    private const string ValidImageIdentifier = "Valid image identifier";
    private const decimal ValidPricePerDay = 10M;
    private const int ValidOptionsNumberOfSeats = 5;
    
    [Fact]
    public void Build_Should_ThrowException_WhenManufacturerIsNotSet()
    {
        // Arrange
        var carAdFactory = this.SetBaseProperties();
        
        // Act
        var act = carAdFactory.Build;
        
        // Assert
        act.Should().Throw<InvalidCarAdException>();
    }

    [Fact]
    public void Build_Should_ThrowException_WhenCategoryIsNotSet()
    {
        // Arrange
        var carAdFactory = this.SetBaseProperties();
        
        // Act
        var act = carAdFactory
            .WithManufacturer(ValidManufacturer)
            .Build;
        
        // Assert
        act.Should().Throw<InvalidCarAdException>();
    }

    [Fact]
    public void Build_Should_ThrowException_WhenOptionsIsNotSet()
    {
        // Arrange
        var carAdFactory = this.SetBaseProperties();
        
        // Act
        var act = carAdFactory
            .WithManufacturer(ValidManufacturer)
            .WithCategory(ValidCategoryName, ValidCategoryDescription)
            .Build;
        
        // Assert
        act.Should().Throw<InvalidCarAdException>();
    }

    [Fact]
    public void Build_Should_NotThrowException_WhenDataIsValid()
    {
        // Arrange & Act
        var act = this.CreateValid;
        
        // Assert
        act.Should().NotThrow();
    }

    [Fact]
    public void Build_Should_CreateValidEntity()
    {
        // Arrange & Act
        var carAd = this.CreateValid();
        
        // Assert
        carAd.Manufacturer.Name.Should().BeEquivalentTo(ValidManufacturer);
        carAd.Model.Should().BeEquivalentTo(ValidModel);
        carAd.Category.Name.Should().BeEquivalentTo(ValidCategoryName);
        carAd.Category.Description.Should().BeEquivalentTo(ValidCategoryDescription);
        carAd.Image.Should().BeEquivalentTo(ValidImageIdentifier);
        carAd.PricePerDay.Should().Be(ValidPricePerDay);
        carAd.Options.HasClimateControl.Should().Be(true);
        carAd.Options.NumberOfSeats.Should().Be(ValidOptionsNumberOfSeats);
        carAd.Options.TransmissionType.Should().Be(TransmissionType.Automatic);
    }

    private CarAd CreateValid()
        => new CarAdFactory()
            .WithManufacturer(new Manufacturer(ValidManufacturer))
            .WithModel(ValidModel)
            .WithCategory(new Category(ValidCategoryName, ValidCategoryDescription))
            .WithImage(ValidImageIdentifier)
            .WithPricePerDay(ValidPricePerDay)
            .WithOptions(new Options(true, ValidOptionsNumberOfSeats, TransmissionType.Automatic))
            .Build();
    
    private ICarAdFactory SetBaseProperties()
        => new CarAdFactory()
            .WithModel(ValidModel)
            .WithImage(ValidImageIdentifier)
            .WithPricePerDay(ValidPricePerDay);

}