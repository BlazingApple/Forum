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
	private IPost? _lastPost;
	/// <summary><see cref="IPost"/></summary>
	[Parameter, EditorRequired]
	public IPost? Post { get; set; }

	/// <summary><see cref="VoteStyle"/></summary>
	[Parameter]
	public VoteStyle VoteStyle { get; set; }

	[Inject]
	public IPostReactionService ReactionService { get; set; } = null!;

	/// <inheritdoc />
	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		_lastPost = Post;
		await InitializePost();
	}

	/// <inheritdoc />
	protected override async Task OnParametersSetAsync()
	{
		await base.OnParametersSetAsync();
		if(Post != _lastPost)
		{
			Post = _lastPost;
			await InitializePost();
		}
	}

	private async Task InitializePost()
	{
		if(Post is null)
			return;

		_reactions = await ReactionService.GetReactionCount(Post.Id);
		_postReaction = null; // TODO
	}

	private async Task ReactionChanged(ReactionType? reaction)
	{

		if(_postReaction is not null)
		{
			bool success = await ReactionService.Delete(_postReaction.Id);

			if(success)
				_postReaction = null;
		}

		if(reaction is not null)
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
