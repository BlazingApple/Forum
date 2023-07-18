using BlazingApple.Forums.Shared.Models.Forums;
using BlazingApple.Forums.Shared.Models.Posts;
using Humanizer;

namespace BlazingApple.Forums.Shared.Models.Threads;
public class ForumThread : IForumThread
{
	/// <inheritdoc />
	public Guid Id { get; set; }

	/// <inheritdoc />
	public required string Title { get; set; }

	/// <inheritdoc />
	public required string Description { get; set; }

	/// <inheritdoc />
	public required string CreatingUserId { get; set; }

	/// <inheritdoc />
	public Guid ForumId { get; set; }

	/// <inheritdoc />
	public IForum? Forum { get; set; }

	/// <inheritdoc />
	public List<IPost>? Posts { get; set; }

	/// <inheritdoc />
	public DateTime DatabaseCreationTimestamp { get; set; }

	/// <inheritdoc />
	public DateTime DatabaseModificationTimestamp { get; set; }

	/// <inheritdoc />
	public required string Slug { get; set; }

	/// <inheritdoc />
	public string ToCreationDate() => DatabaseCreationTimestamp.Humanize();

	/// <inheritdoc />
	public string ToLastUpdatedDate() => DatabaseModificationTimestamp.Humanize();
}
