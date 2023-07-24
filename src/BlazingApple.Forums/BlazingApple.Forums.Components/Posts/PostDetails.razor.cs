using BlazingApple.Components.Shared.Models.Reactions;
using BlazingApple.Forums.Components.Posts.Comments;
using BlazingApple.Forums.Components.Votes;
using BlazingApple.Forums.Shared.Models.Posts;
using BlazingApple.Forums.Shared.Models.Reactions;
using BlazingApple.Forums.Shared.Services.Posts;
using Microsoft.AspNetCore.Components;

namespace BlazingApple.Forums.Components.Posts;

/// <summary>Details of <see cref="IPost"/></summary>
public partial class PostDetails : ComponentBase
{
	private IPostReaction? _postReaction;
	private IDictionary<ReactionType, int>? _reactions;

	/// <summary><see cref="IPost"/></summary>
	[Parameter, EditorRequired]
	public IPost? Post { get; set; }

	/// <summary><see cref="VoteStyle"/></summary>
	[Parameter]
	public VoteStyle VoteStyle { get; set; } = VoteStyle.ReactionsOnly;

	/// <summary><see cref="VoteStyle"/></summary>
	[Parameter]
	public CommentStyle CommentStyle { get; set; } = CommentStyle.Chronological;

	/// <summary>Child content to render below the page header.</summary>
	[Parameter]
	public RenderFragment? ChildContent { get; set; }

	[Inject]
	private IPostReactionService PostReactionService { get; set; } = null!;

	private void AfterCommentSubmitted(IPostComment newComment)
	{
		if(Post is null)
			throw new ArgumentNullException(nameof(Post), "Unexpected null for post.");

		Post.Comments ??= new List<IPostComment>();
		Post.Comments.Insert(0, newComment);
	}

	/// <inheritdoc />
	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();

		if(Post is not null)
			_reactions = await PostReactionService.GetReactionCount(Post.Id);
	}

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
