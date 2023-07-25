using BlazingApple.Forums.Shared.Models.Posts;
using BlazingApple.Forums.Shared.Models.Votes;
using BlazingApple.Forums.Shared.Posts.Comments;
using Microsoft.AspNetCore.Components;

namespace BlazingApple.Forums.Components.Posts.Comments;

/// <summary>Renders a single comment</summary>
public partial class PostCommentRow : ComponentBase
{
	private bool _replyOpen;
	private bool _isExpanded = true;

	/// <summary><see cref="IPostComment"/></summary>
	[Parameter, EditorRequired]
	public IPostComment? Comment { get; set; }

	/// <summary><see cref="VoteStyle"/></summary>
	[Parameter]
	public VoteStyle VoteStyle { get; set; }

	/// <summary><see cref="BlazingApple.Forums.Shared.Posts.Comments.CommentStyle"/></summary>
	[Parameter]
	public CommentStyle CommentStyle { get; set; }

	/// <summary>Rendered below the name, if present</summary>
	[Parameter]
	public RenderFragment? UserBadgeContent { get; set; }

	/// <summary>Rendered below the name, if present</summary>
	[Parameter, EditorRequired]
	public EventCallback<IPostComment> AfterCommentSubmitted { get; set; }

	private async Task AfterCommentSubmittedInternal(IPostComment newComment)
	{
		if(Comment is null)
			throw new ArgumentNullException(nameof(Comment), "Unexpected null for comment.");

		if(CommentStyle == CommentStyle.Hierarchy)
		{
			Comment.Children ??= new List<IPostComment>();
			Comment.Children.Insert(0, newComment);
		}
		else if(AfterCommentSubmitted.HasDelegate)
		{
			await AfterCommentSubmitted.InvokeAsync(newComment);
		}

		_replyOpen = false;
	}

	private void ExpandToggle() => _isExpanded = !_isExpanded;
}
