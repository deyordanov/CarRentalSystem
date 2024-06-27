namespace CarRentalSystem.Web.Features;

using CarRentalSystem.Domain.Models.CarAds;
using CarRentalSystem.Domain.Models.Dealers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class CarAdsController
{
    private static readonly Dealer Dealer
        = new Dealer("Dealer", "+359893742569");

    [HttpGet]
    public IEnumerable<CarAd> Get()
        => Dealer
            .CarAds
            .Where(c => c.IsAvailable);
}