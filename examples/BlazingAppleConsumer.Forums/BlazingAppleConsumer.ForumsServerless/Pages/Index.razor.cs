using Microsoft.AspNetCore.Components;

namespace BlazingAppleConsumer.ForumsServerless.Pages;

/// <summary>Initial page.</summary>
public partial class Index : ComponentBase
{
	[Inject]
	public NavigationManager NavManager { get; set; } = null!;

	/// <inheritdoc	/>
	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		NavManager.NavigateTo("/forums");
	}
}
