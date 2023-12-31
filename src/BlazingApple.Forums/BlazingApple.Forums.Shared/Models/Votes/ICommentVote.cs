﻿using BlazingApple.Forums.Shared.Models.Posts;

namespace BlazingApple.Forums.Shared.Models.Votes;

/// <summary><see cref="IVote"/>, for <see cref="IPostComment"/></summary>
public interface ICommentVote : IVote
{
	/// <summary>FK for a <see cref="IPostComment"/></summary>
	Guid CommentId { get; set; }

	/// <summary>The comment being voted on.</summary>
	IPostComment? Comment { get; set; }
}
