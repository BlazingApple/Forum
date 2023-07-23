using BlazingApple.Components.Shared.Models.Reactions;
using Humanizer;

namespace BlazingApple.Forums.Shared.Models.Reactions;

/// <summary>Reaction model.</summary>
public abstract class ReactionBase : IReaction
{
	/// <inheritdoc />
	public Guid Id { get; set; }

	/// <inheritdoc />
	public ReactionType Type { get; set; }

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
