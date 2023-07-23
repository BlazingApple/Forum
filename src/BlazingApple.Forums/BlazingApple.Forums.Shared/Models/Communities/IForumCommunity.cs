using BlazingApple.Forums.Shared.Models.Base;
using BlazingApple.Forums.Shared.Models.Forums;
using BlazingApple.Forums.Shared.Models.Posts;

namespace BlazingApple.Forums.Shared.Models.Communities;

/// <summary>A grouping of <see cref="IPost"/> under a specific topic.</summary>
public interface IForumCommunity : IForumSluggable
{
	/// <summary>The name / title of the thread.</summary>
	string Title { get; set; }

	/// <summary>A brief description explaining the purpose of the thread and/or intention of posts within it..</summary>
	string Description { get; set; }

	/// <summary>The user that created the thread</summary>
	string CreatingUserId { get; set; }

	/// <summary>FK for the forum the thread is associated with.</summary>
	Guid ForumId { get; set; }

	/// <summary>The forum the thread is associated with.</summary>
	IForum? Forum { get; set; }

	/// <summary>Posts associated with <see cref="IForumCommunity"/></summary>
	List<IPost>? Posts { get; set; }
}
