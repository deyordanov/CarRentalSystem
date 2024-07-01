namespace CarRentalSystem.Domain.Factories.CarAds;

using CarRentalSystem.Domain.Exceptions;
using CarRentalSystem.Domain.Models.CarAds;

using static Exceptions.DomainExceptionConstants.CarAdExceptionMessages;

public class CarAdFactory : ICarAdFactory
{
    private Manufacturer manufacturer = null!;
    private string model = null!;
    private Category category = null!;
    private string image = null!;
    private decimal pricePerDay;
    private Options options = null!;

    private bool isManufacturerSet;
    private bool isCategorySet;
    private bool isOptionsSet;

    public CarAd Build()
    {
        if (!this.isManufacturerSet || !this.isCategorySet || !this.isOptionsSet)
        {
            throw new InvalidCarAdException(CarShouldShouldHaveManufacturerAndCategoryAndOptions);
        }
        
        return new CarAd(
            this.manufacturer,
            this.model,
            this.category,
            this.image,
            this.pricePerDay,
            this.options,
            true);
    }

    public ICarAdFactory WithManufacturer(
        string manufacturerNameValue)
    {
        this.manufacturer = new Manufacturer(manufacturerNameValue);
        this.isManufacturerSet = true;

        return this;
    }

    public ICarAdFactory WithManufacturer(
        Manufacturer manufacturerValue)
    {
        this.manufacturer = manufacturerValue;
        this.isManufacturerSet = true;

        return this;
    }

    public ICarAdFactory WithModel(
        string modelValue)
    {
        this.model = modelValue;

        return this;
    }

    public ICarAdFactory WithCategory(
        string categoryNameValue, 
        string categoryDescriptionValue)
    {
        this.category = new Category(categoryNameValue, categoryDescriptionValue);
        this.isCategorySet = true;

        return this;
    }

    public ICarAdFactory WithCategory(
        Category categoryValue)
    {
        this.category = categoryValue;
        this.isCategorySet = true;

        return this;
    }

    public ICarAdFactory WithImage(
        string imageValue)
    {
        this.image = imageValue;

        return this;
    }

    public ICarAdFactory WithPricePerDay(
        decimal pricePerDayValue)
    {
        this.pricePerDay = pricePerDayValue;

        return this;
    }

    public ICarAdFactory WithOptions(
        bool optionsHasClimateControlValue,
        int optionsNumberOfSeatsValue,
        TransmissionType optionsTransmissionTypeValue)
    {
        this.options = new Options(
            optionsHasClimateControlValue,
            optionsNumberOfSeatsValue,
            optionsTransmissionTypeValue);
        this.isOptionsSet = true;

        return this;
    }

    public ICarAdFactory WithOptions(
        Options optionsValue)
    {
        this.options = optionsValue;
        this.isOptionsSet = true;
        
        return this;
    }
}