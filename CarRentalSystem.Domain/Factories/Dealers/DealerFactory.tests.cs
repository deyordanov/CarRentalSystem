namespace CarRentalSystem.Domain.Factories.Dealers;

using CarRentalSystem.Domain.Models.Dealers;

using FluentAssertions;

using Xunit;

public class DealerFactoryTests
{
    private const string ValidName = "Valid name";
    private const string ValidPhoneNumber = "+359894567432";

    [Fact]
    public void Build_Should_CreateValidEntity()
    {
        // Arrange & Act
        var dealer = this.CreateValid();
        
        // Assert
        dealer.Name.Should().BeEquivalentTo(ValidName);
        dealer.PhoneNumber.Number.Should().BeEquivalentTo(ValidPhoneNumber);
    }
    
    private Dealer CreateValid()
        => new DealerFactory()
            .WithName(ValidName)
            .WithPhoneNumber(ValidPhoneNumber)
            .Build();
}