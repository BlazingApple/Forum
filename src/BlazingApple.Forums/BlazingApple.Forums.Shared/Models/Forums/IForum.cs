using BlazingApple.Forums.Shared.Models.Base;
using BlazingApple.Forums.Shared.Models.Threads;

namespace BlazingApple.Forums.Shared.Models.Forums;

/// <summary>The top-level entity/concept for this package. All <see cref="IForumThread"/> are grouped within a forum, and posts within <see cref="IForumThread"/>
/// </summary>
public interface IForum : IForumSluggable
{
	/// <summary>The forum name/title</summary>
	public string Title { get; set; }

	/// <summary>Forum description/reason for existing.</summary>
	public string Description { get; set; }

	/// <summary>Whether the forum is available to the public, or is private</summary>
	public bool IsPublic { get; set; }

	/// <summary>The set of <see cref="IForumThread"/> associated with this <see cref="IForum"/></summary>
	List<IForumThread>? Threads { get; set; }

	/// <summary>Indicates the list of members with access to this <see cref="IForum"/>.</summary>
	/// <remarks>If <see cref="IsPublic"/> is <em>true</em>, then this should be empty besides indicating banned users.</remarks>
	List<IForumMembership>? Members { get; set; }
}
