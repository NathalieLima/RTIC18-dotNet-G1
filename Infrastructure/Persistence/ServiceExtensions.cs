using System;
using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Persistence.Context;
using CleanArchitecture.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



namespace CleanArchitecture.Persistence;
public static class ServiceExtensions{

    public static void ConfigurePersistenceApp(this IServiceCollection services, IConfiguration configuration){
        var connectionString = configuration.GetConnectionString("MySql");
        services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        services.AddScoped<IUnitOfWork, UnitOfWord>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
  
}
