using BlazingApple.Forums.Shared.Models.Posts;
using Microsoft.AspNetCore.Components;

namespace BlazingApple.Forums.Components.Posts;

/// <summary>Details of <see cref="IPost"/></summary>
public partial class PostDetails : ComponentBase
{
	/// <summary><see cref="IPost"/></summary>
	[Parameter, EditorRequired]
	public IPost? Post { get; set; }

	private void AfterCommentSubmitted(IPostComment newComment)
	{
		if(Post is null)
			throw new ArgumentNullException(nameof(Post), "Unexpected null for post.");

		Post.Comments ??= new List<IPostComment>();
		Post.Comments.Insert(0, newComment);
	}
}
