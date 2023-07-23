using BlazingApple.Forums.Shared.Models.Communities;
using Microsoft.AspNetCore.Components;

namespace BlazingApple.Forums.Components.Communities;

/// <summary>List of <see cref="IForumCommunity"/></summary>
public partial class CommunityList : ComponentBase
{
	/// <summary>List of threads to render.</summary>
	[Parameter, EditorRequired]
	public List<IForumCommunity>? Communities { get; set; }
}
