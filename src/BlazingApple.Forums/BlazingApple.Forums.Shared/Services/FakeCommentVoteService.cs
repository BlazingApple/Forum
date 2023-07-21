using BlazingApple.Forums.Shared.Models.Votes;
using BlazingApple.Forums.Shared.Services.Base;
using BlazingApple.Forums.Shared.Services.Comments;

namespace BlazingApple.Forums.Shared.Services;

/// <inheritdoc cref="ICrudService{TModel}"/>
internal class FakeCommentVoteService : FakeCrudServiceBase<ICommentVote>, ICommentVoteService
{ }
