namespace CarRentalSystem.Infrastructure.Identity;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using CarRentalSystem.Application;
using CarRentalSystem.Application.Contracts;
using CarRentalSystem.Application.Features.Identity;

using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

public class IdentityService(ApplicationSettings applicationSettings, UserManager<User> userManager)
    : IIdentity
{
    private const string InvalidLoginErrorMessage = "Invalid login credentials";

    private readonly UserManager<User> userManager = userManager;
    private readonly ApplicationSettings applicationSettings = applicationSettings;
    
    public async Task<Result> Register(UserInputModel model)
    {
        var user = new User(model.Email);

        var identityResult = await this.userManager.CreateAsync(user, model.Password);

        var errors = identityResult.Errors.Select(e => e.Description);

        return identityResult.Succeeded
            ? Result.Success 
            : Result.Failure(errors);
    }

    public async Task<Result<LoginOutputModel>> Login(UserInputModel model)
    {
        var user = await this.userManager.FindByEmailAsync(model.Email);

        if (user is null)
        {
            return InvalidLoginErrorMessage;
        }

        var isPasswordValid = await this.userManager.CheckPasswordAsync(user, model.Password);

        if (!isPasswordValid)
        {
            return InvalidLoginErrorMessage;
        }

        var token = this.GenerateJwt(user.Id, user.Email!);

        return new LoginOutputModel(token);
    }

    private string GenerateJwt(string userId, string email)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(this.applicationSettings.Secret);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, email),
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var encryptedToken = tokenHandler.WriteToken(token);

        return encryptedToken;
    }
}