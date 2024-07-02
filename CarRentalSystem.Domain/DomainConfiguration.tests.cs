namespace CarRentalSystem.Domain;

using CarRentalSystem.Domain.Factories.CarAds;
using CarRentalSystem.Domain.Factories.Dealers;

using FluentAssertions;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

public class DomainConfigurationTests
{
    [Fact]
    public void AddDomain_Should_RegisterFactories()
    {
        // Arrange
        var serviceCollection = new ServiceCollection();
        
        // Act
        var services = serviceCollection
            .AddDomain()
            .BuildServiceProvider();
        
        // Assert
        services
            .GetService<IDealerFactory>()
            .Should()
            .NotBeNull();

        services
            .GetService<ICarAdFactory>()
            .Should()
            .NotBeNull();
    }
}