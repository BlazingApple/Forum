using BlazingApple.Components.Shared.Interfaces;
using BlazingApple.Forums.Shared.Models.Posts;
using BlazingApple.Forums.Shared.Models.Votes;
using BlazingApple.Forums.Shared.Posts.Comments;
using Microsoft.AspNetCore.Components;

namespace BlazingApple.Forums.Components.Posts.Comments;

/// <summary>Shows a list of <see cref="IComment"/>.</summary>
public partial class PostCommentList : ComponentBase
{
	/// <summary><see cref="IPostComment"/></summary>
	[Parameter, EditorRequired]
	public List<IPostComment>? Comments { get; set; }

	/// <summary><see cref="CommentStyle"/></summary>
	[Parameter]
	public CommentStyle CommentStyle { get; set; } = CommentStyle.Chronological;

	/// <summary><see cref="VoteStyle"/></summary>
	[Parameter]
	public VoteStyle VoteStyle { get; set; } = VoteStyle.ReactionsOnly;

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		base.OnInitialized();

		if(Comments is not null)
			Comments = SortComments(Comments);
	}

	private List<IPostComment> SortComments(List<IPostComment> comments)
	{
		comments = comments.OrderByDescending(c => c.DatabaseCreationTimestamp).ToList();

		if(CommentStyle is CommentStyle.Hierarchy)
		{
			foreach(IPostComment comment in comments)
			{
				if(comment.Children is null)
					continue;
				else
					comment.Children = SortComments(comment.Children);
			}
		}

		return comments;
	}

	private void AfterCommentSubmitted(IPostComment postComment)
	{
		if(Comments is null)
			throw new InvalidOperationException("Unexpected state");

		Comments.Insert(0, postComment);
		StateHasChanged();
	}
}
