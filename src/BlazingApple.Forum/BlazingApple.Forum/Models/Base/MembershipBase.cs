using BlazingApple.Forum.Shared.Threads;

namespace BlazingApple.Forum.Shared.Models.Base;

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
}
