﻿using Humanizer;

namespace BlazingApple.Forums.Shared.Models.Votes;

/// <summary>Base class for <see cref="IVote"/></summary>
public abstract class VoteBase : IVote
{
	/// <inheritdoc />
	public Guid Id { get; set; }

	/// <inheritdoc />
	public VoteType Type { get; set; }

	/// <inheritdoc />
	public required string UserId { get; set; }

	/// <inheritdoc />
	public DateTime DatabaseCreationTimestamp { get; set; }

	/// <inheritdoc />
	public DateTime DatabaseModificationTimestamp { get; set; }

	/// <inheritdoc />
	public string ToCreationDate() => DatabaseCreationTimestamp.Humanize();

	/// <inheritdoc />
	public string ToLastUpdatedDate() => DatabaseModificationTimestamp.Humanize();
}
