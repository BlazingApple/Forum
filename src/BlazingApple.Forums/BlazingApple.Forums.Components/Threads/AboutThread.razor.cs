using BlazingApple.Forums.Shared.Models.Threads;
using Microsoft.AspNetCore.Components;

namespace BlazingApple.Forums.Components.Threads;

/// <summary>Renders a sidebar component showing information about the thread.</summary>
public partial class AboutThread : ComponentBase
{
	/// <summary>The thread to render the about section for.</summary>
	[Parameter, EditorRequired]
	public IForumThread? Thread { get; set; }

	/// <summary>Additional content to show in the about thread card.</summary>
	[Parameter]
	public RenderFragment? ChildContent { get; set; }

	private async Task JoinClicked()
	{

	}
}
