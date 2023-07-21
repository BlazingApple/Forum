using BlazingApple.Components.Configuration;
using Blazored.Toast;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlazingApple.Forums.Components.Extensions;

/// <summary>Extension methods for <see cref="BlazingApple.Forums"/></summary>
public static class ServiceCollectionExtensions
{
	/// <summary>Add Blazor Wasm Client services</summary>
	/// <param name="services">Extension</param>
	/// <param name="configRoot"><see cref="IConfiguration"/></param>
	/// <returns>Fluent API</returns>
	public static IServiceCollection AddForums(this IServiceCollection services, IConfiguration configRoot)
	{
		services.AddBlazingAppleComponents(configRoot);
		services.AddBlazoredToast();
		return services;
	}
}
