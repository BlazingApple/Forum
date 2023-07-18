using BlazingApple.Forums.Shared.Models.Threads;
using Humanizer;

namespace BlazingApple.Forums.Shared.Models.Base;

/// <summary>Base class indicating membership to a particular concept/entity/forum</summary>
public abstract class MembershipBase : IForumRecord
{
	/// <inheritdoc />
	public Guid Id { get; set; }

	/// <inheritdoc />
	public DateTime DatabaseCreationTimestamp { get; set; }

	/// <inheritdoc />
	public DateTime DatabaseModificationTimestamp { get; set; }

	/// <inheritdoc />
	public MembershipStatus Status { get; set; }

	/// <inheritdoc />
	public required string UserId { get; set; }

	/// <inheritdoc />
	public string ToCreationDate() => DatabaseCreationTimestamp.Humanize();

	/// <inheritdoc />
	public string ToLastUpdatedDate() => DatabaseModificationTimestamp.Humanize();
}
