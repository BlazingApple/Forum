using BlazingApple.Components.Shared.Models.Reactions;
using BlazingApple.Forums.Shared.Models.Posts;
using BlazingApple.Forums.Shared.Models.Reactions;
using BlazingApple.Forums.Shared.Models.Votes;
using BlazingApple.Forums.Shared.Services.Posts;
using Microsoft.AspNetCore.Components;

namespace BlazingApple.Forums.Components.Posts;

/// <summary><see cref="IPost"/></summary>
public partial class PostRow : ComponentBase
{
	private IPostReaction? _postReaction;
	private IDictionary<ReactionType, int>? _reactions;

	/// <summary><see cref="IPost"/></summary>
	[Parameter, EditorRequired]
	public IPost? Post { get; set; }

	/// <summary><see cref="VoteStyle"/></summary>
	[Parameter]
	public VoteStyle VoteStyle { get; set; }

	[Inject]
	public IPostReactionService ReactionService { get; set; } = null!;

	private async Task ReactionChanged(ReactionType? reaction)
	{
		if(reaction == null)
		{
			if(_postReaction is not null)
				await ReactionService.Delete(_postReaction.Id);

			_postReaction = null;
		}
		else
		{
			_postReaction = new PostReaction()
			{
				Id = Guid.NewGuid(),
				Type = reaction.Value,
				UserId = "abc",
				DatabaseCreationTimestamp = DateTime.Now,
				PostId = Post!.Id
			};

			await ReactionService.Post(_postReaction);
			_reactions = await ReactionService.GetReactionCount(_postReaction.PostId);
		}
	}
}
