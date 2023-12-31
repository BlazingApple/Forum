﻿using BlazingApple.Forums.Shared.Models.Posts;

namespace BlazingApple.Forums.Shared.Models.Votes;

/// <summary><see cref="IVote"/>, for <see cref="IPost"/></summary>
public interface IPostVote : IVote
{
	/// <summary>FK for voted on <see cref="IPost"/></summary>
	Guid PostId { get; set; }

	/// <summary><see cref="IPost"/> being voted on.</summary>
	IPost? Post { get; set; }
}
