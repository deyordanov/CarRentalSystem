namespace CarRentalSystem.Web.Features;

using CarRentalSystem.Application.Contracts;
using CarRentalSystem.Domain.Models.CarAds;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class CarAdsController
{
    private readonly IRepository<CarAd> carAds;

    public CarAdsController(IRepository<CarAd> carAds)
        => this.carAds = carAds;

    [HttpGet]
    public IEnumerable<CarAd> GetAll()
        => this.carAds
            .GetAll()
            .Where(c => c.IsAvailable);
}