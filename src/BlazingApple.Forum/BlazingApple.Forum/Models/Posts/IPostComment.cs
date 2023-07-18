using BlazingApple.Forum.Shared.Models.Base;
using BlazingApple.Forum.Shared.Models.Votes;

namespace BlazingApple.Forum.Shared.Models.Posts;

public partial interface IPostComment : IForumRecord
{
	/// <summary>The user that authored this comment.</summary>
	string UserId { get; set; }

	/// <summary>The content of the comment.</summary>
	string Content { get; set; }

	/// <summary><see cref="IPost"/> associated with this comment.</summary>
	IPost? Post { get; set; }

	/// <summary>Foreign key for <see cref="Post"/></summary>
	Guid PostId { get; set; }

	/// <summary>Set of votes associated with the comment.</summary>
	List<ICommentVote>? Votes { get; set; }
}
