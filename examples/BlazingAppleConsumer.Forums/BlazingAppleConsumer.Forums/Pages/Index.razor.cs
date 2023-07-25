using Microsoft.AspNetCore.Components;

namespace BlazingAppleConsumer.Forums.Pages;

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
