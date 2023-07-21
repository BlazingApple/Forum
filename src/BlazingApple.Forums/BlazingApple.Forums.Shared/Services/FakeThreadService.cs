using BlazingApple.Forums.Shared.Models.Threads;
using BlazingApple.Forums.Shared.Services.Base;
using BlazingApple.Forums.Shared.Services.Threads;

namespace BlazingApple.Forums.Shared.Services;

/// <inheritdoc cref="ICrudService{TModel}"/>
internal class FakeThreadService : FakeCrudServiceBase<IForumThread>, IThreadService
{
}
