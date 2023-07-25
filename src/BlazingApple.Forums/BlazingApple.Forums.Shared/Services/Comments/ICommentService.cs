using BlazingApple.Forums.Shared.Models.Posts;
using BlazingApple.Forums.Shared.Posts.Comments;
using BlazingApple.Forums.Shared.Services.Base;

namespace BlazingApple.Forums.Shared.Services.Comments;

/// <summary>Crud operations for <see cref="IPostComment"/></summary>
public interface ICommentService : ICrudService<IPostComment>
{
	/// <summary>Get the <see cref="IPostComment"/> for a given <see cref="IPost"/></summary>
	/// <param name="postId">The post to get comments for.</param>
	/// <param name="commentStyle">Determines how to return the comments, as a hierarchy or chronologically.</param>
	/// <returns>See above.</returns>
	Task<List<IPostComment>> GetCommentsForPost(Guid postId, CommentStyle commentStyle);
}
