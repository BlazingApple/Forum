using BlazingApple.Forum.Shared.Models.Base;
using BlazingApple.Forum.Shared.Models.Votes;

namespace BlazingApple.Forum.Shared.Models.Posts;

public partial interface IPost : IForumRecord
{
	/// <summary>String content for a post.</summary>
	string Content { get; set; }

	/// <summary>The title of the post.</summary>
	string Title { get; set; }

	/// <summary>Foreign key for a User object.</summary>
	string UserId { get; set; }

	/// <summary>Set of votes associated with the post.</summary>
	List<IPostVote>? Votes { get; set; }
}
