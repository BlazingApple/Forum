using BlazingApple.Components.Shared.Models.Reactions;
using BlazingApple.Forums.Shared.Models.Posts;
using BlazingApple.Forums.Shared.Models.Reactions;
using BlazingApple.Forums.Shared.Services.Base;

namespace BlazingApple.Forums.Shared.Services.Posts;

/// <summary>Retrieve reactions to a post.</summary>
public interface IPostReactionService : ICrudService<IPostReaction>
{
	/// <summary>Get a dictionary representing the number of reactions for a <see cref="IPost"/>.</summary>
	/// <param name="postId">The post identifier</param>
	/// <returns>See summary.</returns>
	Task<IDictionary<ReactionType, int>> GetReactionCount(Guid postId);
}
