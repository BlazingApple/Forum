using BlazingApple.Forums.Shared.Models.Base;
using Humanizer;

namespace BlazingApple.Forums.Shared.Models.Threads;
public class ThreadMembership : MembershipBase, IThreadMembership
{
	/// <inheritdoc />
	public Guid ThreadId { get; set; }

	/// <inheritdoc />
	public IForumThread? Thread { get; set; }

	/// <inheritdoc />
	public new string ToCreationDate() => DatabaseCreationTimestamp.Humanize();

	/// <inheritdoc />
	public new string ToLastUpdatedDate() => DatabaseModificationTimestamp.Humanize();
}
