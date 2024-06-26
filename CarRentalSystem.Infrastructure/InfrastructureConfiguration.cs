﻿namespace CarRentalSystem.Infrastructure;

using System.Text;

using CarRentalSystem.Application;
using CarRentalSystem.Application.Contracts;
using CarRentalSystem.Infrastructure.Identity;
using CarRentalSystem.Infrastructure.Persistance;
using CarRentalSystem.Infrastructure.Persistence;
using CarRentalSystem.Infrastructure.Persistence.Repositories;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddDatabase(configuration)
            .AddIdentity(configuration);
    
    private static IServiceCollection AddDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddDbContext<CarRentalDbContext>(options => options
                .UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(
                        typeof(CarRentalDbContext).Assembly.FullName)))
            .AddTransient(typeof(IRepository<>), typeof(DataRepository<>))
            .AddTransient<IInitializer, CarRentalDbInitializer>();

    private static IServiceCollection AddIdentity(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddIdentityCore<User>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<CarRentalDbContext>();

        var secret = configuration
            .GetSection(nameof(ApplicationSettings))
            .GetValue<string>(nameof(ApplicationSettings.Secret));

        var key = Encoding.ASCII.GetBytes(secret!);

        services
            .AddAuthentication(authentication =>
            {
                authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(bearer =>
            {
                // TODO: In production the setting should be changed and a valid secret should be used.
                bearer.RequireHttpsMetadata = false;
                bearer.SaveToken = true;
                bearer.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

        services.AddTransient<IIdentity, IdentityService>();
            
        return services;
    }
    
}