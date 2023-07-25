﻿using BlazingApple.Components.Shared.Models.Reactions;
using BlazingApple.Forums.Shared.Models.Posts;
using BlazingApple.Forums.Shared.Models.Reactions;
using BlazingApple.Forums.Shared.Models.Votes;
using BlazingApple.Forums.Shared.Posts.Comments;
using BlazingApple.Forums.Shared.Services.Comments;
using BlazingAppleConsumer.ForumsServerless.Pages.Forums;
using Microsoft.AspNetCore.Components;

namespace BlazingAppleConsumer.ForumsServerless.Pages.Posts;

/// <summary></summary>
public partial class PostPage : ComponentBase
{
	private IPost? _post;
	private VoteStyle _voteStyle = VoteStyle.ReactionsOnly;
	private CommentStyle _commentStyle = CommentStyle.Chronological;

	/// <summary></summary>
	[Parameter, EditorRequired]
	public string Slug { get; set; } = null!;

	[Inject]
	private ICommentService CommentService { get; set; } = null!;

	/// <inheritdoc />
	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		string forumSlug = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
		Guid postId = Guid.NewGuid();
		List<IPostComment> comments = await CommentService.GetCommentsForPost(postId, _commentStyle);

		_post = new Post
		{
			Slug = Slug,
			Title = "Hello word",
			Content = "I like eggs",
			UserId = "abc",
			DatabaseCreationTimestamp = DateTime.Now.AddDays(-1 * Random.Shared.Next(90)),
			Comments = comments,
			Community = ForumPage.GetThread(forumSlug, "Levels of heat", "Discussing what it means to be 'Blazing'."),
			Reactions = GetReactions(),
		};
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
