using BlazingApple.Forums.Shared.Models.Communities;
using BlazingApple.Forums.Shared.Models.Posts;
using BlazingApple.Forums.Shared.Models.Votes;
using Microsoft.AspNetCore.Components;

namespace BlazingApple.Forums.Components.Communities;

/// <summary>Details about a forum.</summary>
public partial class CommunityDetails : ComponentBase
{
	/// <summary>List of threads to render.</summary>
	[Parameter, EditorRequired]
	public List<IPost>? Posts { get; set; }

	/// <summary>Forum details to render.</summary>
	[Parameter, EditorRequired]
	public IForumCommunity? Community { get; set; }

	/// <summary><see cref="VoteStyle"/></summary>
	[Parameter]
	public VoteStyle VoteStyle { get; set; } = VoteStyle.ReactionsOnly;

	/// <summary>Child content to render below the page header.</summary>
	[Parameter]
	public RenderFragment? ChildContent { get; set; }
}

