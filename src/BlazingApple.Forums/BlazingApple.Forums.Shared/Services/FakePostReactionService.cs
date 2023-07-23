using BlazingApple.Components.Shared.Models.Reactions;
using BlazingApple.Forums.Shared.Models.Reactions;
using BlazingApple.Forums.Shared.Services.Base;
using BlazingApple.Forums.Shared.Services.Posts;

namespace BlazingApple.Forums.Shared.Services;
internal class FakePostReactionService : FakeCrudServiceBase<IPostReaction>, IPostReactionService
{
	/// <inheritdoc/>
	public async Task<IDictionary<ReactionType, int>> GetReactionCount(Guid postId)
	{
		return new Dictionary<ReactionType, int>()
		{
			{ ReactionType.Like, Random.Shared.Next(0, 20) },
			{ ReactionType.Dislike, Random.Shared.Next(0, 2) },
			{ ReactionType.Sad, Random.Shared.Next(0, 3) },
			{ ReactionType.Anger, Random.Shared.Next(0, 3) },
			{ ReactionType.Love, Random.Shared.Next(0, 20) },
			{ ReactionType.Shock, Random.Shared.Next(0, 10) },
		};
	}
}
