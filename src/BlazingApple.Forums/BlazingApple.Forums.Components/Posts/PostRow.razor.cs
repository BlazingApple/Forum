using BlazingApple.Components.Shared.Models.Reactions;
using BlazingApple.Forums.Components.Votes;
using BlazingApple.Forums.Shared.Models.Posts;
using BlazingApple.Forums.Shared.Models.Reactions;
using Microsoft.AspNetCore.Components;

namespace BlazingApple.Forums.Components.Posts;

/// <summary><see cref="IPost"/></summary>
public partial class PostRow : ComponentBase
{
	private IPostReaction? _postReaction;
	private readonly IDictionary<ReactionType, int>? _reactions;

	/// <summary><see cref="IPost"/></summary>
	[Parameter, EditorRequired]
	public IPost? Post { get; set; }

	/// <summary><see cref="VoteStyle"/></summary>
	[Parameter]
	public VoteStyle? VoteStyle { get; set; } = Votes.VoteStyle.ReactionsOnly;

	private void ReactionChanged(ReactionType? reaction)
	{
		if(reaction == null)
		{
			_postReaction = null;
		}
		else
		{
			_postReaction = new PostReaction()
			{
				Type = reaction.Value,
				UserId = "abc",
				DatabaseCreationTimestamp = DateTime.Now,
				PostId = Post!.Id
			};
		}
	}
}
