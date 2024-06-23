namespace CarRentalSystem.Domain.Models.CarAds;

using CarRentalSystem.Domain.Common;
using CarRentalSystem.Domain.Exceptions;

using static ModelConstants.Common;
using static ModelConstants.CarAd;

public class CarAd : Entity<int>, IAggregateRoot
{
    public CarAd(
        Manufacturer manufacturer,
        string model,
        Category category,
        string image,
        decimal pricePerDay,
        Options options,
        bool isAvailable)
    {
        this.Validate(model, pricePerDay);
        
        this.Manufacturer = manufacturer;
        this.Model = model;
        this.Category = category;
        this.Image = image;
        this.PricePerDay = pricePerDay;
        this.Options = options;
        this.IsAvailable = isAvailable;
    }
    
    public Manufacturer Manufacturer { get; }

    public string Model { get; }

    public Category Category { get; }

    public string Image { get; }

    public decimal PricePerDay { get; }

    public Options Options { get; }

    public bool IsAvailable { get; private set; }

    public void ChangeAvailability() => this.IsAvailable = !this.IsAvailable;

    private void Validate(string model, decimal pricePerDay)
    {
        Guard.ForStringLength<InvalidCarAdException>(
            model,
            MinimumModelLength,
            MaximumModelLength,
            nameof(this.Model));
        
        Guard.AgainstOutOfRange<InvalidCarAdException>(
            pricePerDay,
            Zero,
            decimal.MaxValue,
            nameof(this.PricePerDay));
    }
}