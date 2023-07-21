using BlazingApple.Forums.Shared.Models.Posts;
using BlazingApple.Forums.Shared.Services.Base;

namespace BlazingApple.Forums.Shared.Services.Comments;

/// <summary>Crud operations for <see cref="IPostComment"/></summary>
public interface ICommentService : ICrudService<IPostComment>
{
}
