using BlazingApple.Forums.Shared.Models.Posts;

namespace BlazingApple.Forums.Shared.Models.Reactions;

/// <summary>User reactions to a <see cref="IPost"/></summary>
public class PostReaction : ReactionBase, IPostReaction
{
	/// <inheritdoc/>
	public Guid PostId { get; set; }

	/// <inheritdoc/>
	public IPost? Post { get; set; }
}
