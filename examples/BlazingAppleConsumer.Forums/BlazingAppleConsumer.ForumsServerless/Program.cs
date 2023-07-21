using BlazingApple.Forums.Components.Extensions;
using BlazingApple.Forums.Shared.Extensions;
using BlazingAppleConsumer.ForumsServerless;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

internal class Program
{
	private static async global::System.Threading.Tasks.Task Main(string[] args)
	{
		WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
		builder.RootComponents.Add<App>("#app");
		builder.RootComponents.Add<HeadOutlet>("head::after");
		builder.Services.AddForums(builder.Configuration);
		builder.Services.AddFakeForumServices();
		builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
		await builder.Build().RunAsync();
	}
}
