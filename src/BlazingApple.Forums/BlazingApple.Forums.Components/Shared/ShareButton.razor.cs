using Microsoft.AspNetCore.Components;

namespace BlazingApple.Forums.Components.Shared;

/// <summary>Renders a share button</summary>
public partial class ShareButton : ComponentBase
{
	[Parameter, EditorRequired]
	public string? UrlToShare { get; set; }

	[Inject]
	private NavigationManager NavManager { get; set; } = null!;
}
