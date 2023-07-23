using BlazingApple.Components.Shared.Interfaces;
using BlazingApple.Forums.Shared.Models.Reactions;
using BlazingApple.Forums.Shared.Models.Votes;
using Humanizer;

namespace BlazingApple.Forums.Shared.Models.Posts;

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
	public IPostComment? Parent { get; set; }

	/// <inheritdoc />
	public Guid? ParentId { get; set; }

	/// <inheritdoc />
	public DateTime DatabaseCreationTimestamp { get; set; }

	/// <inheritdoc />
	public DateTime DatabaseModificationTimestamp { get; set; }

	/// <inheritdoc />
	public List<ICommentVote>? Votes { get; set; }

	/// <inheritdoc />
	public List<ICommentReaction>? Reactions { get; set; }

	/// <inheritdoc />
	public List<IPostComment>? Children { get; set; }

	/// <inheritdoc />
	public IUser? User { get; set; }

	/// <inheritdoc />
	public string ToCreationDate() => DatabaseCreationTimestamp.Humanize();

	/// <inheritdoc />
	public string ToLastUpdatedDate() => DatabaseModificationTimestamp.Humanize();
}
