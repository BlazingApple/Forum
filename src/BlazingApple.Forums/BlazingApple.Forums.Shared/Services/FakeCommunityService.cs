using BlazingApple.Forums.Shared.Models.Communities;
using BlazingApple.Forums.Shared.Services.Base;
using BlazingApple.Forums.Shared.Services.Communities;

namespace BlazingApple.Forums.Shared.Services;

/// <inheritdoc cref="ICrudService{TModel}"/>
internal class FakeCommunityService : FakeCrudServiceBase<IForumCommunity>, ICommunityService
{
}
