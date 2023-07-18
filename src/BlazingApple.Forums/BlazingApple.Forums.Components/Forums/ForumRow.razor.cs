using BlazingApple.Forums.Shared.Models.Forums;
using Microsoft.AspNetCore.Components;

namespace BlazingApple.Forums.Components.Forums;

/// <summary>Renders a <see cref="IForum"/></summary>
public partial class ForumRow
{
	/// <summary>The forum to render.</summary>
	[Parameter, EditorRequired]
	public IForum? Forum { get; set; }
}
