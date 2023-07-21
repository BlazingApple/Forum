using BlazingApple.Forums.Shared.Models.Posts;
using BlazingApple.Forums.Shared.Services.Base;
using BlazingApple.Forums.Shared.Services.Posts;

namespace BlazingApple.Forums.Shared.Services;

/// <inheritdoc cref="ICrudService{TModel}"/>
internal class FakePostService : FakeCrudServiceBase<IPost>, IPostService
{
}
