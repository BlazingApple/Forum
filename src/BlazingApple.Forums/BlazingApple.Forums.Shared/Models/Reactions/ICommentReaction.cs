using BlazingApple.Forums.Shared.Models.Posts;

namespace BlazingApple.Forums.Shared.Models.Reactions;
public interface ICommentReaction : IReaction
{
	/// <summary>FK for a <see cref="IPostComment"/></summary>
	Guid CommentId { get; set; }

	/// <summary>The comment being reacted to.</summary>
	IPostComment? Comment { get; set; }
}
