using Application;
using Infrastructure;
using System.Text.Json.Serialization;

namespace Api.Extensions;

public static class DependencyInjection
{
    public const string CorsPolicyName = "AllowFrontend";

    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers()
            .AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        var allowedOrigins = configuration
            .GetSection("Cors:AllowedOrigins")
            .Get<string[]>();

        services.AddCors(options =>
        {
            options.AddPolicy(CorsPolicyName, policy =>
            {
                if (allowedOrigins is { Length: > 0 })
                    policy.WithOrigins(allowedOrigins);
                else
                    policy.WithOrigins(
                        "http://localhost:3000",
                        "http://localhost:5173"
                    );

                policy
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

        services.AddApplication();
        services.AddInfrastructure(configuration);

        return services;
    }
}
