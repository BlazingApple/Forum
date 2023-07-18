using BlazingApple.Forum.Shared.Models.Forums;
using BlazingApple.Forum.Shared.Models.Posts;

namespace BlazingApple.Forum.Shared.Threads;
public class Thread : IThread
{
	/// <inheritdoc />
	public required string Title { get; set; }

	/// <inheritdoc />
	public required string Description { get; set; }

	/// <inheritdoc />
	public required string CreatingUserId { get; set; }

	/// <inheritdoc />
	public Guid ForumId { get; set; }

	/// <inheritdoc />
	public required IForum Forum { get; set; }

	/// <inheritdoc />
	public required IReadOnlyList<IPost> Posts { get; set; }

	/// <inheritdoc />
	public Guid Id { get; set; }
	public DateTime DatabaseCreationTimestamp { get; set; }
	public DateTime DatabaseModificationTimestamp { get; set; }
}
