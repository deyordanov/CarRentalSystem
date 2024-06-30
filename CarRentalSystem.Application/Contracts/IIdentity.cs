namespace CarRentalSystem.Application.Contracts;

using CarRentalSystem.Application.Features.Identity;

public interface IIdentity
{
    Task<Result> Register(UserInputModel model);

    Task<Result<LoginOutputModel>> Login(UserInputModel model);
}