using BlazingApple.Forum.Shared.Models.Base;

namespace BlazingApple.Forum.Shared.Threads;
public class ThreadMembership : MembershipBase, IThreadMembership
{
	/// <inheritdoc />
	public Guid ThreadId { get; set; }

	/// <inheritdoc />
	public IThread? Thread { get; set; }
}
