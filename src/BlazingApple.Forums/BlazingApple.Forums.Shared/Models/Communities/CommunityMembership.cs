using BlazingApple.Forums.Shared.Models.Base;
using Humanizer;

namespace BlazingApple.Forums.Shared.Models.Communities;
public class CommunityMembership : MembershipBase, ICommunityMembership
{
	/// <inheritdoc />
	public Guid CommunityId { get; set; }

	/// <inheritdoc />
	public IForumCommunity? Community { get; set; }

	/// <inheritdoc />
	public new string ToCreationDate() => DatabaseCreationTimestamp.Humanize();

	/// <inheritdoc />
	public new string ToLastUpdatedDate() => DatabaseModificationTimestamp.Humanize();
}
