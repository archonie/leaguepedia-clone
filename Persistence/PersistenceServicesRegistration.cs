using System.Text;
using Application.Contracts.Persistence;
using Application.Contracts.Persistence.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServicesRegistration
{
    public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<LeagueDbContext>(opt => opt.UseSqlServer(
            configuration.GetConnectionString("Default"),
            b => b.MigrationsAssembly("Persistence")));
        
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
            };
        });
       
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IAppUserRepository, AppUserRepository>();
        services.AddScoped<IRegionRepository, RegionRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<ILeagueRepository, LeagueRepostiory>();
        services.AddScoped<ITeamRepository, TeamRepository>();
        services.AddScoped<IPersonRepository, PersonRepository>();
        return services;
    }
}