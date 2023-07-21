using BlazingApple.Forums.Shared.Models.Posts;
using BlazingApple.Forums.Shared.Services.Base;
using BlazingApple.Forums.Shared.Services.Comments;

namespace BlazingApple.Forums.Shared.Services;

/// <inheritdoc cref="ICrudService{TModel}"/>
internal class FakeCommentService : FakeCrudServiceBase<IPostComment>, ICommentService
{
}
