using BlazingApple.Components.Shared.Models.Reactions;
using BlazingApple.Forums.Shared.Models.Posts;
using BlazingApple.Forums.Shared.Models.Reactions;
using BlazingApple.Forums.Shared.Models.Votes;
using BlazingApple.Forums.Shared.Posts.Comments;
using BlazingApple.Forums.Shared.Services.Comments;
using BlazingApple.Forums.Shared.Services.Posts;
using Microsoft.AspNetCore.Components;

namespace BlazingApple.Forums.Components.Posts;

/// <summary>Details of <see cref="IPost"/></summary>
public partial class PostDetails : ComponentBase
{
	private IPostReaction? _postReaction;
	private IDictionary<ReactionType, int>? _reactions;
	private IList<IPostComment>? _comments;
	private IPost? _lastPost;

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
	private IPostReactionService ReactionService { get; set; } = null!;

	[Inject]
	private ICommentService CommentsService { get; set; } = null!;

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
		_lastPost = Post;

		if(Post is not null)
			await InitializePostData();
	}

	/// <inheritdoc />
	protected override async Task OnParametersSetAsync()
	{
		await base.OnParametersSetAsync();

		if(Post != _lastPost && Post is not null)
			await InitializePostData();
	}

	private async Task InitializePostData()
	{
		_reactions = await ReactionService.GetReactionCount(Post!.Id);
		_comments = await CommentsService.GetCommentsForPost(Post.Id, CommentStyle);
	}

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
				Type = reaction.Value,
				UserId = "abc",
				DatabaseCreationTimestamp = DateTime.Now,
				PostId = Post!.Id
			};

			await ReactionService.Post(_postReaction);
			_reactions = await ReactionService.GetReactionCount(_postReaction.PostId);
		}
	}

	private async Task RefreshComments()
	{
		if(Post is null)
			return;

		Post.Comments = await CommentsService.GetCommentsForPost(Post.Id, CommentStyle);
	}
}
