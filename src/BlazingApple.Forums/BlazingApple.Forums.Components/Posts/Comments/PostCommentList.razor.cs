using BlazingApple.Components.Shared.Interfaces;
using BlazingApple.Forums.Shared.Models.Posts;
using Microsoft.AspNetCore.Components;

namespace BlazingApple.Forums.Components.Posts.Comments;

/// <summary>Shows a list of <see cref="IComment"/>.</summary>
public partial class PostCommentList : ComponentBase
{
	/// <summary><see cref="IPostComment"/></summary>
	[Parameter, EditorRequired]
	public List<IPostComment>? Comments { get; set; }

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		base.OnInitialized();

		if(Comments is not null)
			Comments = SortComments(Comments);
	}

	private static List<IPostComment> SortComments(List<IPostComment> comments)
	{
		comments = comments.OrderByDescending(c => c.DatabaseCreationTimestamp).ToList();

		foreach(IPostComment comment in comments)
		{
			if(comment.Children is null)
				continue;
			else
				comment.Children = SortComments(comment.Children);
		}

		return comments;
	}
}
