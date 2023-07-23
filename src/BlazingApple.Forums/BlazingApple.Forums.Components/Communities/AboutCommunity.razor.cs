using BlazingApple.Forums.Shared.Models.Communities;
using Microsoft.AspNetCore.Components;

namespace BlazingApple.Forums.Components.Communities;

/// <summary>Renders a sidebar component showing information about the community.</summary>
public partial class AboutCommunity : ComponentBase
{
	/// <summary>The community to render the about section for.</summary>
	[Parameter, EditorRequired]
	public IForumCommunity? Community { get; set; }

	/// <summary>Additional content to show in the about community card.</summary>
	[Parameter]
	public RenderFragment? ChildContent { get; set; }

	private static async Task JoinClicked()
	{

	}
}
