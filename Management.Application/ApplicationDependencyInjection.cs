using Management.Application.Password;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Management.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }
}
