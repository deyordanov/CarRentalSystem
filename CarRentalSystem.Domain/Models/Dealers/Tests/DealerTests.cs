namespace CarRentalSystem.Domain.Models.Dealers.Tests;

using CarRentalSystem.Domain.Exceptions;

using FluentAssertions;

using Xunit;

using static ModelConstants.Common;

public class DealerTests
{
    private const string ValidName = "Valid name";
    private const string ValidPhoneNumber = "+359894567432";
    
    [Fact]
    public void Dealer_ShouldNot_ThrowException_WhenCreatedWithValidData()
    {
        // Arrange
        var act = CreateValid;
        
        // Act & Assert
        act.Should().NotThrow<InvalidDealerException>();
    }

    [Fact]
    public void Dealer_Should_ThrowException_WhenCreatedWithInvalidName()
    {
        // Arrange
        var invalidNameUnderMinLength = new string('*', MinimumNameLength - 1);
        var actUnderMinLength = () => Create(invalidNameUnderMinLength, ValidPhoneNumber);

        var invalidNameOverMaxLength = new string('*', MaximumNameLength + 1);
        var actOverMaxLength = () => Create(invalidNameOverMaxLength, ValidPhoneNumber);
        
        // Act & Assert
        actUnderMinLength.Should().Throw<InvalidDealerException>();
        actOverMaxLength.Should().Throw<InvalidDealerException>();
    }

    private static Dealer CreateValid()
        => new Dealer(ValidName, ValidPhoneNumber);

    private static Dealer Create(string name, PhoneNumber phoneNumber)
        => new Dealer(name, phoneNumber);
}