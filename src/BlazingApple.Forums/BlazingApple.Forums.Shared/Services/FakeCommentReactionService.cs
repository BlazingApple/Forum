using BlazingApple.Components.Shared.Models.Reactions;
using BlazingApple.Forums.Shared.Models.Reactions;
using BlazingApple.Forums.Shared.Services.Base;
using BlazingApple.Forums.Shared.Services.Comments;

namespace BlazingApple.Forums.Shared.Services;
internal class FakeCommentReactionService : FakeCrudServiceBase<ICommentReaction>, ICommentReactionService
{
	private readonly IDictionary<Guid, IDictionary<ReactionType, int>> _reactionsByCommentId = new Dictionary<Guid, IDictionary<ReactionType, int>>();
	public FakeCommentReactionService()
	{
	}

	/// <inheritdoc/>
	public async Task<IDictionary<ReactionType, int>> GetReactionCount(Guid commentId)
	{
		if(_reactionsByCommentId.ContainsKey(commentId))
			return _reactionsByCommentId[commentId];

		Dictionary<ReactionType, int> commentDictionary = new()
		{
			{  ReactionType.Like, Random.Shared.Next(0,20) },
			{  ReactionType.Dislike, Random.Shared.Next(0,2) },
			{  ReactionType.Sad, Random.Shared.Next(0,3) },
			{  ReactionType.Anger, Random.Shared.Next(0,3) },
			{  ReactionType.Love, Random.Shared.Next(0,20) },
			{  ReactionType.Shock, Random.Shared.Next(0,10) },
		};

		_reactionsByCommentId.Add(commentId, commentDictionary);

		return commentDictionary;
	}

	/// <inheritdoc />
	public override async Task<ICommentReaction?> Post(ICommentReaction model)
	{
		IDictionary<ReactionType, int> reactions;
		if(model.Id == Guid.Empty)
			model.Id = Guid.NewGuid();

		if(_reactionsByCommentId.ContainsKey(model.Id))
			reactions = _reactionsByCommentId[model.Id];
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
