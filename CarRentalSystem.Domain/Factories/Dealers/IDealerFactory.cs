namespace CarRentalSystem.Domain.Factories.Dealers;

using CarRentalSystem.Domain.Models.Dealers;

public interface IDealerFactory : IFactory<Dealer>
{
    IDealerFactory WithName(string name);

    IDealerFactory WithPhoneNumber(string number);
}