using BlazingApple.Forums.Shared.Models.Base;
using BlazingApple.Forums.Shared.Models.Threads;
using BlazingApple.Forums.Shared.Models.Votes;

namespace BlazingApple.Forums.Shared.Models.Posts;

public partial interface IPost : IForumSluggable
{
	/// <summary>String content for a post.</summary>
	string Content { get; set; }

	/// <summary>The title of the post.</summary>
	string Title { get; set; }

	/// <summary>Foreign key for a User object.</summary>
	string UserId { get; set; }

	/// <summary>Set of votes associated with the post.</summary>
	List<IPostVote>? Votes { get; set; }

	/// <summary>The thread this post was posted in.</summary>
	IForumThread? Thread { get; set; }

	/// <summary>FK for the thread this post was posted in.</summary>
	Guid ThreadId { get; set; }
}
