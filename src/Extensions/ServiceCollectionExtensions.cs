using MASA.Blazor.Experimental.Components;

namespace  Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMasaBlazorExperimentalComponents(this IServiceCollection services)
    {
        services.AddScoped<IPopupProvider, PopupProvider>();
        services.AddScoped<IPopupService, PopupService>();

        return services;
    }
}