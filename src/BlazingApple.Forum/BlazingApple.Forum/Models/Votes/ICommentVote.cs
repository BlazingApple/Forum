using BlazingApple.Forum.Shared.Models.Posts;

namespace BlazingApple.Forum.Shared.Models.Votes;

/// <summary><see cref="IVote"/>, for <see cref="IPostComment"/></summary>
public interface ICommentVote : IVote
{
	/// <summary>FK for a <see cref="IPostComment"/></summary>
	public Guid CommentId { get; set; }

	/// <summary>The comment being voted on.</summary>
	public IPostComment? Comment { get; set; }
}
