using BlazingApple.Forums.Shared.Models.Posts;
using Microsoft.AspNetCore.Components;

namespace BlazingApple.Forums.Components.Posts;

/// <summary>List of <see cref="IPost"/></summary>
public partial class PostList : ComponentBase
{
	/// <summary>List of <see cref="Post"/></summary>
	[Parameter, EditorRequired]
	public List<IPost>? Posts { get; set; }
}
