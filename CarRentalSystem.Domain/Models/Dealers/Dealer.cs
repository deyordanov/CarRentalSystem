namespace CarRentalSystem.Domain.Models.Dealers;

using CarRentalSystem.Domain.Common;
using CarRentalSystem.Domain.Exceptions;
using CarRentalSystem.Domain.Models.CarAds;

using static ModelConstants.Common;

public class Dealer : Entity<int>, IAggregateRoot
{
    private readonly HashSet<CarAd> carAds;

    private Dealer(
        string name)
    {
        this.Name = name;
        
        this.PhoneNumber = null!;

        this.carAds = new HashSet<CarAd>();
    }
    
    internal Dealer(
        string name,
        string phoneNumber)
    {
        this.Validate(name);

        this.Name = name;
        this.PhoneNumber = phoneNumber;

        this.carAds = new HashSet<CarAd>();
    }
    
    public string Name { get; }

    public PhoneNumber PhoneNumber { get; }

    public IReadOnlyCollection<CarAd> CarAds
        => this.carAds.ToList().AsReadOnly();

    public void AddCarAdd(CarAd carAdd)
        => this.carAds.Add(carAdd);

    private void Validate(string name)
        => Guard.ForStringLength<InvalidDealerException>(
            name,
            MinimumNameLength,
            MaximumNameLength,
            nameof(this.Name));
}