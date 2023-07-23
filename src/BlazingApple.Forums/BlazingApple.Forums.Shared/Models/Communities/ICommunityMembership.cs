using BlazingApple.Forums.Shared.Models.Base;

namespace BlazingApple.Forums.Shared.Models.Communities;

/// <summary>
/// Indicates membership in a thread, as well as the user's role within the thread.
/// </summary>
public interface ICommunityMembership : IForumRecord
{
	/// <inheritdoc cref="MembershipStatus"/>
	MembershipStatus Status { get; set; }

	/// <summary>User that this membership reflects.</summary>
	string UserId { get; set; }

	/// <summary>FK for the relevant Thread.</summary>
	Guid CommunityId { get; set; }

	/// <summary>Thread the user is a member of.</summary>
	IForumCommunity? Community { get; set; }
}
