using System;
using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Persistence.Context;
using CleanArchitecture.Persistence.Repositories;
using Microsoft.Extensions.Configuration;



namespace CleanArchitecture.Persistence;
public static class ServiceExtensions{

    public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration){
        var connectionString = configuration.GetConnectionString("MySql");
        services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
  
}
