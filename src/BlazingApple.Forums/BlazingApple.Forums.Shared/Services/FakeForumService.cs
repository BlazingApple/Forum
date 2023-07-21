using BlazingApple.Forums.Shared.Models.Forums;
using BlazingApple.Forums.Shared.Services.Base;
using BlazingApple.Forums.Shared.Services.Forums;

namespace BlazingApple.Forums.Shared.Services;

/// <inheritdoc cref="ICrudService{TModel}"/>
internal class FakeForumService : FakeCrudServiceBase<IForum>, IForumService
{ }
