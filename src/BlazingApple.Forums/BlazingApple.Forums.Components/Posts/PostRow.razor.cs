using BlazingApple.Forums.Shared.Models.Posts;
using Microsoft.AspNetCore.Components;

namespace BlazingApple.Forums.Components.Posts;

/// <summary><see cref="IPost"/></summary>
public partial class PostRow : ComponentBase
{
	/// <summary><see cref="IPost"/></summary>
	[Parameter, EditorRequired]
	public IPost? Post { get; set; }
}
