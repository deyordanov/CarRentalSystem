namespace CarRentalSystem.Domain.Models.Dealers.Tests;

using CarRentalSystem.Domain.Exceptions;

using FluentAssertions;

using Xunit;

using static ModelConstants.PhoneNumber;

public class PhoneNumberTests
{
    private const string ValidPhoneNumber = "+359894567432";
    
    [Fact]
    public void PhoneNumber_ShouldNot_ThrowException_WhenCreatedWithValidData()
    {
        // Arrange
        var act = CreateValid;
        
        // Act & Assert
        act.Should().NotThrow<InvalidPhoneNumberException>();
    }

    [Fact]
    public void PhoneNumber_Should_ThrowException_WhenCreatedWithInvalidNumber()
    {
        // Arrange
        var invalidNumberUnderMinLength = new string('*', MinimumPhoneNumberLength - 1);
        var actUnderMinLength = () => Create(invalidNumberUnderMinLength);

        var invalidNumberOverMaxLength = new string('*', MaximumPhoneNumberLength + 1);
        var actOverMaxLength = () => Create(invalidNumberOverMaxLength);

        var invalidNumberPattern = "359894567432";
        var actNumberPattern = () => Create(invalidNumberPattern);
        
        // Act & Assert
        actUnderMinLength.Should().Throw<InvalidPhoneNumberException>();
        actOverMaxLength.Should().Throw<InvalidPhoneNumberException>();
        actNumberPattern.Should().Throw<InvalidPhoneNumberException>();
    }
    
    private static PhoneNumber CreateValid()
        => ValidPhoneNumber;

    private static PhoneNumber Create(string phoneNumber)
        => phoneNumber;
}
