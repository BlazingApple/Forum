using BlazingApple.Components.Shared.Models.Reactions;
using BlazingApple.Forums.Shared.Models.Posts;
using BlazingApple.Forums.Shared.Models.Reactions;
using BlazingApple.Forums.Shared.Services.Base;

namespace BlazingApple.Forums.Shared.Services.Comments;

/// <summary>React to comments.</summary>
public interface ICommentReactionService : ICrudService<ICommentReaction>
{
	/// <summary>Get a dictionary representing the number of reactions for a <see cref="IPostComment"/>.</summary>
	/// <param name="commentId"><see cref="IPostComment"/> identifier</param>
	/// <returns>See summary.</returns>
	Task<IDictionary<ReactionType, int>> GetReactionCount(Guid commentId);
}
