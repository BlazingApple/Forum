using BlazingApple.Forums.Shared.Models.Posts;
using BlazingApple.Forums.Shared.Models.Threads;
using Microsoft.AspNetCore.Components;

namespace BlazingApple.Forums.Components.Threads;

/// <summary>Details about a forum.</summary>
public partial class ThreadDetails : ComponentBase
{
	/// <summary>List of threads to render.</summary>
	[Parameter, EditorRequired]
	public List<IPost>? Posts { get; set; }

	/// <summary>Forum details to render.</summary>
	[Parameter, EditorRequired]
	public IForumThread? Thread { get; set; }
}

