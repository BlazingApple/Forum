﻿using BlazingApple.Forums.Shared.Models.Communities;
using BlazingApple.Forums.Shared.Models.Reactions;
using BlazingApple.Forums.Shared.Models.Votes;
using Humanizer;

namespace BlazingApple.Forums.Shared.Models.Posts;
public partial class Post : IPost
{
	/// <inheritdoc />
	public Guid Id { get; set; }

	/// <inheritdoc />
	public required string Title { get; set; }

	/// <inheritdoc />
	public required string Content { get; set; }

	/// <inheritdoc />
	public required string UserId { get; set; }

	/// <inheritdoc />
	public DateTime DatabaseCreationTimestamp { get; set; }

	/// <inheritdoc />
	public DateTime DatabaseModificationTimestamp { get; set; }

	/// <inheritdoc />
	public List<IPostVote>? Votes { get; set; }

	/// <inheritdoc />
	public List<IPostReaction>? Reactions { get; set; }

	/// <inheritdoc />
	public required string Slug { get; set; }

	/// <inheritdoc />
	public IForumCommunity? Community { get; set; }

	/// <inheritdoc />
	public Guid CommunityId { get; set; }

	/// <inheritdoc />
	public List<IPostComment>? Comments { get; set; }

	/// <inheritdoc />
	public string ToCreationDate() => DatabaseCreationTimestamp.Humanize();

	/// <inheritdoc />
	public string ToLastUpdatedDate() => DatabaseModificationTimestamp.Humanize();
}
