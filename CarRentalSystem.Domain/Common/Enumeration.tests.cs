namespace CarRentalSystem.Domain.Common.Tests;

using CarRentalSystem.Domain.Models.CarAds;

using FluentAssertions;

using Xunit;

public class EnumerationTests
{
    private const string Test01String = "Test01";
    private const string Test02String = "Test02";
    
    [Fact]
    public void Enumeration_GetAll_Should_ReturnAllEnumerations()
    {
        // Arrange
        var expectedResult = new List<string>() { Test01String, Test02String };
        
        // Act
        var actualResult = Enumeration
            .GetAll<TestEnumeration>()
            .Select(e => e.ToString());
        
        // Assert
        actualResult.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public void Enumeration_FromValue_Should_ReturnElement_WhenFound()
    {
        // Arrange
        var expectedResult = Test01String;
        
        //Act
        var actualResult = Enumeration.FromValue<TestEnumeration>(1).ToString();
        
        //Assert
        expectedResult.Should().BeEquivalentTo(actualResult);
    }

    [Fact]
    public void Enumeration_FromValue_Should_ThrowException_WhenNotFound()
    {
        // Arrange
        var act = () => Enumeration.FromValue<TestEnumeration>(3).ToString();
        
        // Act & Assert
        act.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void Enumeration_FromName_Should_ReturnElement_WhenFound()
    {
        // Arrange
        var expectedResult = Test01String;
        
        //Act
        var actualResult = Enumeration.FromName<TestEnumeration>(Test01String).ToString();
        
        //Assert
        expectedResult.Should().BeEquivalentTo(actualResult);
    }

    [Fact]
    public void Enumeration_FromName_Should_ThrowException_WhenNotFound()
    {
        // Arrange
        var act = () => Enumeration.FromName<TestEnumeration>("Test03").ToString();
        
        // Act & Assert
        act.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void Enumerations_ShouldNot_BeEqual_IfTheyAreNotBothEnumerations()
    {
        // Arrange
        var first = Enumeration.FromName<TestEnumeration>(Test01String);
        var second = new Manufacturer(Test02String);
        
        // Act & Assert
        // ReSharper disable once SuspiciousTypeConversion.Global
        first.Equals(second).Should().BeFalse();
    }

    [Fact]
    public void Enumerations_ShouldNot_BeEqual_IfTheyAreDifferentEnumerations()
    {
        // Arrange
        var first = Enumeration.FromName<TestEnumeration>(Test01String);
        var second = Enumeration.FromName<TransmissionType>("Manual");
        
        // Act & Assert
        // ReSharper disable once SuspiciousTypeConversion.Global
        first.Equals(second).Should().BeFalse();
    }

    [Fact]
    public void Enumerations_ShouldNot_BeEqual_IfTheyHaveDifferentValues()
    {
        // Arrange
        var first = Enumeration.FromValue<TestEnumeration>(1);
        var second = Enumeration.FromValue<TestEnumeration>(2);
        
        // Act and Assert
        first.Equals(second).Should().BeFalse();
    }

    [Fact]
    public void Enumerations_Should_BeEqual_IfTheyHaveSameTypeAndValue()
    {
        // Arrange
        var first = Enumeration.FromName<TestEnumeration>(Test01String);
        var second = new TestEnumeration(1, "Test01v2");
        
        // Act and Assert
        first.Equals(second).Should().BeTrue();
    }
    private class TestEnumeration : Enumeration
    {
        public static readonly TestEnumeration Test01
            = new TestEnumeration(1, nameof(Test01));

        public static readonly TestEnumeration Test02
            = new TestEnumeration(2, nameof(Test02));
    
        public TestEnumeration(int value) 
            : base(value) { }

        public TestEnumeration(int value, string name) 
            : base(value, name) {  }
    }
}