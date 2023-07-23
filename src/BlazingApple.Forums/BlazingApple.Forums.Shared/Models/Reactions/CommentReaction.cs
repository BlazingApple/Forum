using BlazingApple.Components.Shared.Interfaces;
using BlazingApple.Forums.Shared.Models.Posts;

namespace BlazingApple.Forums.Shared.Models.Reactions;

/// <summary>User reaction to a <see cref="IComment"/>.</summary>
public class CommentReaction : ReactionBase, ICommentReaction
{
	/// <inheritdoc />
	public Guid CommentId { get; set; }

	/// <inheritdoc />
	public IPostComment? Comment { get; set; }
}
