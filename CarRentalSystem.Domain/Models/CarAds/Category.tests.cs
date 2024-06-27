namespace CarRentalSystem.Domain.Models.CarAds.Tests;

using CarRentalSystem.Domain.Exceptions;

using FluentAssertions;

using Xunit;

using static ModelConstants.Common;
using static ModelConstants.Category;

public class CategoryTests
{
    private const string ValidCategoryName = "Valid category name";
    private const string ValidCategoryDescription = "Valid category description";

    [Fact]
    public void Category_ShouldNot_ThrowException_WhenCreatedWithValidData()
    {
        // Arrange
        var act = CreateValid;
        
        // Act & Assert
        act.Should().NotThrow<InvalidCarAdException>();
    }

    [Fact]
    public void Category_Should_ThrowException_WhenCreatedWithInvalidName()
    {
        // Arrange
        var invalidNameUnderMinLength = new string('*' , MinimumNameLength - 1);
        var actUnderMinLength = () => Create(invalidNameUnderMinLength, ValidCategoryDescription);
        
        var invalidNameOverMaxLength = new string('*', MaximumNameLength + 1);
        var actOverMaxLength = () => Create(invalidNameOverMaxLength, ValidCategoryDescription);
        
        // Act & Assert
        actUnderMinLength.Should().Throw<InvalidCarAdException>();
        actOverMaxLength.Should().Throw<InvalidCarAdException>();
    }
    
    [Fact]
    public void Category_Should_ThrowException_WhenCreatedWithInvalidDescription()
    {
        // Arrange
        var invalidDescriptionUnderMinLength = new string('*' , MinimumDescriptionLength - 1);
        var actUnderMinLength = () => Create(ValidCategoryName, invalidDescriptionUnderMinLength);
        
        var invalidDescriptionOverMaxLength = new string('*', MaximumDescriptionLength + 1);
        var actOverMaxLength = () => Create(ValidCategoryName, invalidDescriptionOverMaxLength);
        
        // Act & Assert
        actUnderMinLength.Should().Throw<InvalidCarAdException>();
        actOverMaxLength.Should().Throw<InvalidCarAdException>();
    }
    
    private static Category CreateValid()
        => new Category(ValidCategoryName, ValidCategoryDescription);

    private static Category Create(string name, string description)
        => new Category(name, description);
}