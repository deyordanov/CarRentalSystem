namespace CarRentalSystem.Infrastructure.Identity;

using CarRentalSystem.Domain.Exceptions;
using CarRentalSystem.Domain.Models.Dealers;

using Microsoft.AspNetCore.Identity;

using static Domain.Exceptions.DomainExceptionConstants.DealerExceptionMessages;

public sealed class User : IdentityUser
{
    internal User(string email)
        : base(email)
        => this.Email = email;

    public Dealer? Dealer { get; private set; }

    public void BecomeDealer(Dealer dealer)
    {
        if (this.Dealer is not null)
        {
            throw new InvalidDealerException(string.Format(UserIsAlreadyADealer, this.UserName));
        }

        this.Dealer = dealer;
    }
}