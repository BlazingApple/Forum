using BlazingApple.Components.Shared.Interfaces;
using BlazingApple.Forums.Shared.Models.Posts;
using Microsoft.AspNetCore.Components;

namespace BlazingApple.Forums.Components.Posts.Comments;

/// <summary>Shows a list of <see cref="IComment"/>.</summary>
public partial class PostCommentList : ComponentBase
{
	/// <summary><see cref="IPostComment"/></summary>
	[Parameter, EditorRequired]
	public IReadOnlyList<IPostComment>? Comments { get; set; }
}
