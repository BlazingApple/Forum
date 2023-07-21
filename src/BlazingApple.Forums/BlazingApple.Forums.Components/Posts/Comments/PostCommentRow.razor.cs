using BlazingApple.Forums.Shared.Models.Posts;
using BlazingApple.Forums.Shared.Models.Votes;
using Microsoft.AspNetCore.Components;

namespace BlazingApple.Forums.Components.Posts.Comments;

/// <summary>Renders a single comment</summary>
public partial class PostCommentRow : ComponentBase
{
	private bool _replyOpen;
	private bool _isExpanded = true;
	private ICommentVote? _commentVote;

	/// <summary><see cref="IPostComment"/></summary>
	[Parameter, EditorRequired]
	public IPostComment? Comment { get; set; }

	/// <summary>Rendered below the name, if present</summary>
	[Parameter]
	public RenderFragment? ChildContent { get; set; }

	private async Task ReplyClicked() => _replyOpen = !_replyOpen;

	private void VoteChanged(VoteType? vote)
	{
		if(vote == null)
		{
			_commentVote = null;
		}
		else
		{
			_commentVote = new CommentVote()
			{
				Type = vote.Value,
				UserId = "abc",
				DatabaseCreationTimestamp = DateTime.Now,
				CommentId = Comment!.Id
			};
		}
	}

	private void AfterCommentSubmitted(IPostComment newComment)
	{
		if(Comment is null)
			throw new ArgumentNullException(nameof(Comment), "Unexpected null for comment.");

		Comment.Children ??= new List<IPostComment>();
		Comment.Children.Insert(0, newComment);
		_replyOpen = false;
	}

	private void ExpandToggle() => _isExpanded = !_isExpanded;
}
