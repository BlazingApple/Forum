using BlazingApple.Forums.Shared.Models.Posts;

namespace BlazingApple.Forums.Shared.Models.Reactions;
public interface IPostReaction : IReaction
{
	/// <summary><see cref="IPost"/> being reacted to.</summary>
	IPost? Post { get; set; }

	/// <summary>FK for reacted to <see cref="IPost"/></summary>
	Guid PostId { get; set; }
}
