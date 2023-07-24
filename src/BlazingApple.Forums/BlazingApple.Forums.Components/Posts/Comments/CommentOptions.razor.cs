using BlazingApple.Components.Shared.Models.Reactions;
using BlazingApple.Forums.Components.Votes;
using BlazingApple.Forums.Shared.Models.Posts;
using BlazingApple.Forums.Shared.Models.Votes;
using Microsoft.AspNetCore.Components;

namespace BlazingApple.Forums.Components.Posts.Comments;

/// <summary>Renders various options for <see cref="IPostComment"/></summary>
public partial class CommentOptions : ComponentBase
{
	/// <summary><see cref="VoteStyle"/></summary>
	[Parameter]
	public VoteStyle VoteStyle { get; set; }

	/// <summary>Reactions to this comment.</summary>
	[Parameter]
	public IDictionary<ReactionType, int>? Reactions { get; set; }

	/// <summary></summary>
	[Parameter]
	public EventCallback ReplyClicked { get; set; }

	/// <summary>
	/// The current reaction for the user on this <see cref="IPostComment"/>
	/// </summary>
	[Parameter]
	public ReactionType? Reaction { get; set; }

	/// <summary>Triggered when the current user selects a reaction value.</summary>
	[Parameter]
	public EventCallback<ReactionType?> ReactionChanged { get; set; }

	/// <summary>
	/// The current vote for the user on this <see cref="IPostComment"/>
	/// </summary>
	[Parameter]
	public VoteType? Vote { get; set; }

	/// <summary>Triggered when the current user selects a <see cref="VoteType"/> value.</summary>
	[Parameter]
	public EventCallback<VoteType?> VoteChanged { get; set; }

	private async Task OnReplyClicked()
	{
		if(ReplyClicked.HasDelegate)
			await ReplyClicked.InvokeAsync();
	}

	private async Task OnReactionChanged(ReactionType? type)
	{
		if(ReactionChanged.HasDelegate)
			await ReactionChanged.InvokeAsync(type);
	}

	private async Task OnVoteChanged(VoteType? vote)
	{
		if(VoteChanged.HasDelegate)
			await VoteChanged.InvokeAsync(vote);
	}
}
