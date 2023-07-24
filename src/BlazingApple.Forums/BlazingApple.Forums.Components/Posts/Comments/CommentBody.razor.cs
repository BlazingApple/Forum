using BlazingApple.Components.Shared.Models.Reactions;
using BlazingApple.Forums.Components.Votes;
using BlazingApple.Forums.Shared.Models.Posts;
using BlazingApple.Forums.Shared.Models.Votes;
using Microsoft.AspNetCore.Components;

namespace BlazingApple.Forums.Components.Posts.Comments;

/// <summary>Renders the <em>actual</em> comment body content and the options associated with it.</summary>
public partial class CommentBody : ComponentBase
{
	/// <summary><see cref="IPostComment"/></summary>
	[Parameter, EditorRequired]
	public IPostComment? Comment { get; set; }

	/// <summary>
	/// The current vote for the user on this <see cref="IPostComment"/>
	/// </summary>
	[Parameter]
	public VoteType? Vote { get; set; }

	/// <summary>Triggered when the current user selects a <see cref="VoteType"/> value.</summary>
	[Parameter]
	public EventCallback<VoteType?> VoteChanged { get; set; }

	/// <summary><see cref="VoteStyle"/></summary>
	[Parameter]
	public VoteStyle VoteStyle { get; set; }

	/// <summary><see cref="Comments.CommentStyle"/></summary>
	[Parameter]
	public CommentStyle CommentStyle { get; set; }

	/// <summary>
	/// The current reaction for the user on this <see cref="IPostComment"/>
	/// </summary>
	[Parameter]
	public ReactionType? Reaction { get; set; }

	/// <summary>Triggered when the current user selects a reaction value.</summary>
	[Parameter]
	public EventCallback<ReactionType?> ReactionChanged { get; set; }

	/// <summary>Triggered after the current user posts a new comment.</summary>
	[Parameter, EditorRequired]
	public EventCallback<IPostComment> AfterCommentSubmitted { get; set; }

	/// <summary>Whether or not reply is open.</summary>
	[Parameter]
	public bool ReplyOpen { get; set; }

	/// <summary>Triggered when the current user selects a reaction value.</summary>
	[Parameter]
	public EventCallback<bool> ReplyOpenChanged { get; set; }

	private async Task ReplyOpenClicked()
	{
		ReplyOpen = !ReplyOpen;
		if(ReplyOpenChanged.HasDelegate)
			await ReplyOpenChanged.InvokeAsync(ReplyOpen);
	}
}
