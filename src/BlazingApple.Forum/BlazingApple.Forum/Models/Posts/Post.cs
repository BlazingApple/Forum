using BlazingApple.Forum.Shared.Models.Votes;

namespace BlazingApple.Forum.Shared.Models.Posts;
public partial class Post : IPost
{
	/// <inheritdoc />
	public Guid Id { get; set; }

	/// <inheritdoc />
	public required string Title { get; set; }

	/// <inheritdoc />
	public required string Content { get; set; }

	/// <inheritdoc />
	public required string UserId { get; set; }

	/// <inheritdoc />
	public DateTime DatabaseCreationTimestamp { get; set; }

	/// <inheritdoc />
	public DateTime DatabaseModificationTimestamp { get; set; }

	/// <inheritdoc />
	public List<IPostVote>? Votes { get; set; }
}
