namespace CarRentalSystem.Domain.Factories.Dealers;

using CarRentalSystem.Domain.Models.Dealers;

public class DealerFactory : IDealerFactory
{
    private string name = null!;
    private PhoneNumber number = null!;

    public Dealer Build(string nameValue, string numberValue)
        => this
            .WithName(nameValue)
            .WithPhoneNumber(numberValue)
            .Build();
    
    public Dealer Build()
        => new Dealer(this.name, this.number);

    public IDealerFactory WithName(string nameValue)
    {
        this.name = nameValue;

        return this;
    }

    public IDealerFactory WithPhoneNumber(string numberValue)
    {
        this.number = numberValue;

        return this;
    }
}