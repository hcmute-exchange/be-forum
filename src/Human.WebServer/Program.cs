using System.Reflection;
using FastEndpoints;
using FastEndpoints.Security;
using Human.Core.Models;
using Human.Infrastructure.Models;
using Human.WebServer.Middlewares;
using Microsoft.Extensions.Options;
using RazorLight;
using RazorLight.Extensions;

namespace Human.WebServer;

public static class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        Configure(builder.Services, builder.Configuration);

        var app = builder.Build();

        app.UseProblemDetailsExceptionHandler();
        app.UseStatusCodePages();
        app.UseAuthentication();
        app.UseMiddleware<PermissionMiddleware>();
        app.UseAuthorization();

        app.UseFastEndpoints(x =>
        {
            var options = app.Services.GetRequiredService<IOptions<ApiOptions>>().Value;
            x.Errors.UseProblemDetails();
            x.Endpoints.RoutePrefix = options.RoutePrefix;
        });

        app.Run();
    }

    private static void Configure(IServiceCollection services, IConfiguration configuration)
    {
        services.AddProblemDetails();
        services.AddFastEndpoints(x =>
        {
            x.DisableAutoDiscovery = true;
            x.Assemblies = new[]
            {
                Assembly.Load("Human.Core"),
                Assembly.Load("Human.WebServer.Api.V1"),
            };
        });

        services
            .AddOptions<ApiOptions>()
            .BindConfiguration(ApiOptions.Section)
            .ValidateOnStart()
            .ValidateDataAnnotations();

        var bearerSection = configuration.GetRequiredSection(BearerOptions.Section);
        var bearerOptions = bearerSection.Get<BearerOptions>()!;
        services
            .AddOptions<BearerOptions>()
            .Bind(bearerSection)
            .ValidateOnStart()
            .ValidateDataAnnotations();
        services.AddJWTBearerAuth(bearerOptions.Secret,
            tokenValidation: (options) =>
            {
                options.ValidateIssuerSigningKey = true;
                options.ValidateIssuer = true;
                options.ValidateAudience = true;
                options.ValidateLifetime = true;
                options.ValidateActor = false;
                options.ValidIssuer = bearerOptions.ValidIssuer;
                options.ValidAudience = null;
                options.ValidAudiences = bearerOptions.ValidAudiences;
            });
        services.AddAuthorization();

        var resourceSection = configuration.GetRequiredSection(ResourceOptions.Section);
        var resourceOptions = resourceSection.Get<ResourceOptions>()!;
        services.AddRazorLight(() => new RazorLightEngineBuilder()
            .UseEmbeddedResourcesProject(Assembly.Load(resourceOptions.EmailTemplate.AssemblyName),
                resourceOptions.EmailTemplate.RootNamespace)
            .UseMemoryCachingProvider()
            .Build());
        services
            .AddOptions<ResourceOptions>()
            .Bind(resourceSection)
            .ValidateOnStart()
            .ValidateDataAnnotations();

        services
            .AddOptions<PersistenceOptions>()
            .BindConfiguration(PersistenceOptions.Section)
            .ValidateOnStart()
            .ValidateDataAnnotations();

        services
            .AddOptions<SmtpOptions>()
            .BindConfiguration(SmtpOptions.Section)
            .ValidateOnStart()
            .ValidateDataAnnotations();

        services.AddCore();
        services.AddInfrastructure();
    }
}