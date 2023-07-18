using BlazingApple.Forums.Shared.Models.Forums;
using Microsoft.AspNetCore.Components;

namespace BlazingApple.Forums.Components.Forums;

/// <summary>Renders a list of forums to choose from.</summary>
public partial class ForumList : ComponentBase
{
	/// <summary>List of available forums.</summary>
	[Parameter, EditorRequired]
	public List<IForum>? Forums { get; set; }
}
