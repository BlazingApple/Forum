using BlazingApple.Forums.Shared.Models.Base;
using BlazingApple.Forums.Shared.Models.Threads;

namespace BlazingApple.Forums.Shared.Models.Forums;

/// <summary></summary>
public interface IForumMembership : IForumRecord
{
	/// <inheritdoc cref="MembershipStatus"/>
	MembershipStatus Status { get; set; }

	/// <summary>User that this membership reflects.</summary>
	string UserId { get; set; }

	/// <summary>FK for the relevant <see cref="IForum"/>.</summary>
	Guid ForumId { get; set; }

	/// <summary><em>Private forum</em> that the user is a member of.</summary>
	IForum? Forum { get; set; }
}
