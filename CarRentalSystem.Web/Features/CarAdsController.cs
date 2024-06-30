namespace CarRentalSystem.Web.Features;

using CarRentalSystem.Application;
using CarRentalSystem.Application.Contracts;
using CarRentalSystem.Domain.Models.CarAds;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

[ApiController]
[Route("[controller]")]
public class CarAdsController(
    IRepository<CarAd> carAds,
    IOptions<ApplicationSettings> settings)
{
    [HttpGet]
    public object GetAll()
        => new
        {
            Settings = settings,
            CarAds = carAds
                .GetAll()
                .Where(c => c.IsAvailable),
        };
}