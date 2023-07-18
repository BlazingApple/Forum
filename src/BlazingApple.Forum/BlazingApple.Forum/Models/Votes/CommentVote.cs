using BlazingApple.Forum.Shared.Models.Posts;

namespace BlazingApple.Forum.Shared.Models.Votes;

/// <summary>A <see cref="IVote"/> on a <see cref="IPostComment"/></summary>
public class CommentVote : VoteBase, ICommentVote
{
	/// <inheritdoc/>
	public Guid CommentId { get; set; }

	/// <inheritdoc/>
	public IPostComment? Comment { get; set; }
}
