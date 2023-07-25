using BlazingApple.Components.Shared.Models.Reactions;
using BlazingApple.Forums.Shared.Models.Reactions;
using BlazingApple.Forums.Shared.Services.Base;
using BlazingApple.Forums.Shared.Services.Posts;

namespace BlazingApple.Forums.Shared.Services;
internal class FakePostReactionService : FakeCrudServiceBase<IPostReaction>, IPostReactionService
{

	private readonly IDictionary<Guid, IDictionary<ReactionType, int>> _reactionsByPostId = new Dictionary<Guid, IDictionary<ReactionType, int>>();

	public FakePostReactionService()
	{
	}

	/// <inheritdoc/>
	public async Task<IDictionary<ReactionType, int>> GetReactionCount(Guid postId)
	{
		if(_reactionsByPostId.ContainsKey(postId))
			return _reactionsByPostId[postId];

		Dictionary<ReactionType, int> commentDictionary = new()
		{
			{  ReactionType.Like, Random.Shared.Next(0,20) },
			{  ReactionType.Dislike, Random.Shared.Next(0,2) },
			{  ReactionType.Sad, Random.Shared.Next(0,3) },
			{  ReactionType.Anger, Random.Shared.Next(0,3) },
			{  ReactionType.Love, Random.Shared.Next(0,20) },
			{  ReactionType.Shock, Random.Shared.Next(0,10) },
		};

		_reactionsByPostId.Add(postId, commentDictionary);

		return commentDictionary;
	}

	/// <inheritdoc />
	public override async Task<IPostReaction?> Post(IPostReaction model)
	{
		IDictionary<ReactionType, int> reactions;
		if(model.Id == Guid.Empty)
			model.Id = Guid.NewGuid();

		if(_reactionsByPostId.ContainsKey(model.Id))
			reactions = _reactionsByPostId[model.Id];
		else
			reactions = new Dictionary<ReactionType, int>();

		ReactionType reactionType = model.Type;
		if(reactions.ContainsKey(reactionType))
			reactions[reactionType]++;
		else
			reactions.Add(reactionType, 1);

		return await base.Post(model);
	}
}
