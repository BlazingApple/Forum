using BlazingApple.Components.Shared.Models.Reactions;
using BlazingApple.Forums.Shared.Models.Posts;
using BlazingApple.Forums.Shared.Models.Reactions;
using BlazingApple.Forums.Shared.Models.Votes;
using BlazingAppleConsumer.Forums.Pages.Forums;
using Microsoft.AspNetCore.Components;

namespace BlazingAppleConsumer.Forums.Pages.Posts;

/// <summary></summary>
public partial class PostPage : ComponentBase
{
	private IPost? _post;

	/// <summary></summary>
	[Parameter, EditorRequired]
	public string Slug { get; set; } = null!;

	/// <inheritdoc />
	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		string forumSlug = Convert.ToBase64String(Guid.NewGuid().ToByteArray());

		_post = new Post
		{
			Slug = Slug,
			Title = "Hello word",
			Content = "I like eggs",
			UserId = "abc",
			DatabaseCreationTimestamp = DateTime.Now.AddDays(-1 * Random.Shared.Next(90)),
			Comments = GetComments(),
			Community = ForumPage.GetCommunity(forumSlug, "Levels of heat", "Discussing what it means to be 'Blazing'."),
			Reactions = GetReactions(),
		};
	}

	private static List<IPostComment> GetComments() => GetCommentsCore().ToList();

	private static IEnumerable<IPostComment> GetCommentsCore()
	{
		int commentCount = Random.Shared.Next(0, 3);

		for(int i = 0; i < commentCount; i++)
		{
			yield return GetComment();
		}
	}

	private static IPostComment GetComment()
	{
		DateTime dateTime = DateTime.Now.AddMinutes(-1 * Random.Shared.Next(0, 2500));
		return new PostComment()
		{
			Id = Guid.NewGuid(),
			Content = "Lorem Ipsum",
			UserId = "abc",
			DatabaseCreationTimestamp = dateTime,
			DatabaseModificationTimestamp = dateTime,
			Votes = new List<ICommentVote>(),
			Children = GetComments(),
			Reactions = GetCommentReactions(),
		};
	}

	public static List<ICommentReaction> GetCommentReactions()
	{
		List<ICommentReaction> reactions = new();
		int reactionCount = Random.Shared.Next(0, 50);
		int reactionOptions = Enum.GetValues<ReactionType>().Length;
		for(int i = 0; i < reactionCount; i++)
		{
			ICommentReaction reaction = new CommentReaction()
			{
				Type = Enum.GetValues<ReactionType>()[Random.Shared.Next(0, reactionOptions - 1)],
				DatabaseCreationTimestamp = DateTime.Now.AddDays(-12),
				UserId = "abc",
				CommentId = Guid.NewGuid(),
			};

			reactions.Add(reaction);
		}

		return reactions;
	}

	public static List<IPostReaction> GetReactions()
	{
		List<IPostReaction> reactions = new();
		int reactionCount = Random.Shared.Next(0, 50);
		int reactionOptions = Enum.GetValues<ReactionType>().Length;
		for(int i = 0; i < reactionCount; i++)
		{
			IPostReaction reaction = new PostReaction()
			{
				Type = Enum.GetValues<ReactionType>()[Random.Shared.Next(0, reactionOptions - 1)],
				DatabaseCreationTimestamp = DateTime.Now.AddDays(-12),
				UserId = "abc",
				PostId = Guid.NewGuid(),
			};

			reactions.Add(reaction);
		}

		return reactions;
	}
}
