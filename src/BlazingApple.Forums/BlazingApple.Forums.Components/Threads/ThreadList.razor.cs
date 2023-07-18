using BlazingApple.Forums.Shared.Models.Threads;
using Microsoft.AspNetCore.Components;

namespace BlazingApple.Forums.Components.Threads;

/// <summary>List of <see cref="IForumThread"/></summary>
public partial class ThreadList : ComponentBase
{
	/// <summary>List of threads to render.</summary>
	[Parameter, EditorRequired]
	public List<IForumThread>? Threads { get; set; }
}
