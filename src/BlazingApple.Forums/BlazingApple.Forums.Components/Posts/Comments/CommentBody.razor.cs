using BlazingApple.Components.Shared.Models.Reactions;
using BlazingApple.Forums.Shared.Models.Posts;
using BlazingApple.Forums.Shared.Models.Reactions;
using BlazingApple.Forums.Shared.Models.Votes;
using BlazingApple.Forums.Shared.Posts.Comments;
using BlazingApple.Forums.Shared.Services.Comments;
using Microsoft.AspNetCore.Components;

namespace BlazingApple.Forums.Components.Posts.Comments;

/// <summary>Renders the <em>actual</em> comment body content and the options associated with it.</summary>
public partial class CommentBody : ComponentBase
{
	private ICommentVote? _commentVote;
	private ICommentReaction? _commentReaction;
	private IDictionary<ReactionType, int>? _reactions;

	private IPostComment? _lastComment;

	/// <summary><see cref="IPostComment"/></summary>
	[Parameter, EditorRequired]
	public IPostComment? Comment { get; set; }

	/// <summary>
	/// The current vote for the user on this <see cref="IPostComment"/>
	/// </summary>
	[Parameter]
	public VoteType? Vote { get; set; }

	/// <summary><see cref="VoteStyle"/></summary>
	[Parameter]
	public VoteStyle VoteStyle { get; set; }

	/// <summary><see cref="CommentStyle"/></summary>
	[Parameter]
	public CommentStyle CommentStyle { get; set; }

	/// <summary>
	/// The current reaction for the user on this <see cref="IPostComment"/>
	/// </summary>
	[Parameter]
	public ReactionType? Reaction { get; set; }

	/// <summary>Triggered after the current user posts a new comment.</summary>
	[Parameter, EditorRequired]
	public EventCallback<IPostComment> AfterCommentSubmitted { get; set; }

	/// <summary>Whether or not reply is open.</summary>
	[Parameter]
	public bool ReplyOpen { get; set; }

	/// <summary>Triggered when the current user selects a reaction value.</summary>
	[Parameter]
	public EventCallback<bool> ReplyOpenChanged { get; set; }

	[Inject]
	private ICommentReactionService ReactionService { get; set; } = null!;

	/// <inheritdoc />
	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		_lastComment = Comment;

		await InitializeComment();
	}

	/// <inheritdoc />
	protected override async Task OnParametersSetAsync()
	{
		await base.OnParametersSetAsync();

		if(_lastComment != Comment)
			await InitializeComment();
	}

	private async Task InitializeComment()
	{
		_commentVote = null;

		VoteChanged(Vote);
		await ReactionChanged(Reaction);

		if(Comment is not null)
			_reactions ??= Comment.GetReactionCounts() ?? await ReactionService.GetReactionCount(Comment.Id);
	}

	private async Task ReplyOpenClicked()
	{
		ReplyOpen = !ReplyOpen;
		if(ReplyOpenChanged.HasDelegate)
			await ReplyOpenChanged.InvokeAsync(ReplyOpen);
	}

	private async Task ReactionChanged(ReactionType? reaction)
	{
		if(_commentReaction is not null)
		{
			bool success = await ReactionService.Delete(_commentReaction.Id);

			if(success)
				_commentReaction = null;
		}

		if(reaction is not null)
		{
			_commentReaction = new CommentReaction()
			{
				Id = Guid.NewGuid(),
				Type = reaction.Value,
				UserId = "abc",
				DatabaseCreationTimestamp = DateTime.Now,
				CommentId = Comment!.Id
			};

			await ReactionService.Post(_commentReaction);
			_reactions = await ReactionService.GetReactionCount(_commentReaction.CommentId);
		}
	}
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
				Id = Guid.NewGuid(),
				Type = vote.Value,
				UserId = "abc",
				DatabaseCreationTimestamp = DateTime.Now,
				CommentId = Comment!.Id
			};
		}
	}
}
