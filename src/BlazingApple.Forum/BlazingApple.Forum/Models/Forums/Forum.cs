using BlazingApple.Forum.Shared.Models.Base;
using BlazingApple.Forum.Shared.Threads;

namespace BlazingApple.Forum.Shared.Models.Forums;
public class Forum : IForumRecord
{
	/// <inheritdoc />
	public Guid Id { get; set; }

	/// <inheritdoc />
	public required string Title { get; set; }

	/// <inheritdoc />
	public required string Description { get; set; }

	/// <inheritdoc />
	public bool IsPublic { get; set; }

	/// <inheritdoc />
	public List<IThread>? Threads { get; set; }

	/// <inheritdoc />
	public List<IForumMembership>? Members { get; set; }

	/// <inheritdoc />
	public DateTime DatabaseCreationTimestamp { get; set; }

	/// <inheritdoc />
	public DateTime DatabaseModificationTimestamp { get; set; }
}
