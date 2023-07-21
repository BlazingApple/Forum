using BlazingApple.Forums.Shared.Models.Votes;
using BlazingApple.Forums.Shared.Services.Base;
using BlazingApple.Forums.Shared.Services.Posts;

namespace BlazingApple.Forums.Shared.Services;

/// <inheritdoc cref="ICrudService{TModel}"/>
internal class FakePostVoteService : FakeCrudServiceBase<IPostVote>, IPostVoteService
{
}
