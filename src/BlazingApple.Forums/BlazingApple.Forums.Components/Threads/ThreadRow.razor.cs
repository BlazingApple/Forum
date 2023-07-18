using BlazingApple.Forums.Shared.Models.Threads;
using Microsoft.AspNetCore.Components;

namespace BlazingApple.Forums.Components.Threads;

/// <summary></summary>
public partial class ThreadRow : ComponentBase
{
	/// <summary><see cref="IForumThread"/> to render.</summary>
	[Parameter, EditorRequired]
	public IForumThread? Thread { get; set; }
}
