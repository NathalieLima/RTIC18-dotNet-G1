using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application.Services;

public static class ServiceExtensions
{
    public static void ConfigureApplicationApp(this IServiceCollection services){
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
