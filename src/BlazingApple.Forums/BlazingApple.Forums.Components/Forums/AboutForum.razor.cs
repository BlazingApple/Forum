using BlazingApple.Forums.Shared.Models.Forums;
using Microsoft.AspNetCore.Components;

namespace BlazingApple.Forums.Components.Forums;

/// <summary>Details about this forum, typically rendered as a sidebar.</summary>
public partial class AboutForum : ComponentBase
{
	/// <summary><see cref="IForum"/></summary>
	[Parameter, EditorRequired]
	public IForum? Forum { get; set; }
}
