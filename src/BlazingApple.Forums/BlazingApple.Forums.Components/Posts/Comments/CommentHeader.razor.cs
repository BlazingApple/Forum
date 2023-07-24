using BlazingApple.Forums.Shared.Models.Posts;
using Microsoft.AspNetCore.Components;

namespace BlazingApple.Forums.Components.Posts.Comments;

/// <summary>Renders header information for a <see cref="IPostComment"/>, like username and date created, etc.</summary>
public partial class CommentHeader : ComponentBase
{
	/// <summary><see cref="IPostComment"/></summary>
	[Parameter, EditorRequired]
	public IPostComment? Comment { get; set; }

	/// <summary>Rendered below the name, if present</summary>
	[Parameter]
	public RenderFragment? ChildContent { get; set; }
}
