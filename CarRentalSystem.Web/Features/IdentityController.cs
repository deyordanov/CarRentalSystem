namespace CarRentalSystem.Web.Features;

using CarRentalSystem.Application.Contracts;
using CarRentalSystem.Application.Features.Identity;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class IdentityController(
    IIdentity identity) 
    : BaseController
{
    [HttpPost(nameof(Register))]
    public async Task<IActionResult> Register([FromBody] UserInputModel model)
    {
        var result = await identity.Register(model);

        if (!result.Succeeded)
        {
            return this.BadRequest(result.Errors);
        }

        return this.Ok();
    }

    [HttpPost()]
    public async Task<IActionResult> Login([FromBody] UserInputModel model)
    {
        var result = await identity.Login(model);

        if (!result.Succeeded)
        {
            return this.BadRequest(result.Errors);
        }

        return this.Ok(result.Data);
    }
    
    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return this.Ok(this.User.Identity?.Name);
    }
}