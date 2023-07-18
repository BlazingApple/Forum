using BlazingApple.Forum.Shared.Models.Votes;

namespace BlazingApple.Forum.Shared.Models.Posts;

public partial class PostComment : IPostComment
{
	/// <inheritdoc />
	public Guid Id { get; set; }

	/// <inheritdoc />
	public required string Content { get; set; }

	/// <inheritdoc />
	public required string UserId { get; set; }

	/// <inheritdoc />
	public Guid PostId { get; set; }

	/// <inheritdoc />
	public IPost? Post { get; set; }

	/// <inheritdoc />
	public DateTime DatabaseCreationTimestamp { get; set; }

	/// <inheritdoc />
	public DateTime DatabaseModificationTimestamp { get; set; }

	/// <inheritdoc />
	public List<ICommentVote>? Votes { get; set; }
}
