using BlazingApple.Forums.Shared.Models.Communities;
using Microsoft.AspNetCore.Components;

namespace BlazingApple.Forums.Components.Communities;

/// <summary></summary>
public partial class CommunityRow : ComponentBase
{
	/// <summary><see cref="IForumCommunity"/> to render.</summary>
	[Parameter, EditorRequired]
	public IForumCommunity? Community { get; set; }
}
