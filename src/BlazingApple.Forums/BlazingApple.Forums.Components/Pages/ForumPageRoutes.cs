using BlazingApple.Forums.Shared.Models.Posts;
using BlazingApple.Forums.Shared.Models.Communities;

namespace BlazingApple.Forums.Components.Pages;
public static class ForumPageRoutes
{
	private const string _forumBase = "forums";

	public static string ForumDetails(string forumSlug)
		=> $"{_forumBase}/{forumSlug}";

	public static string CommunityDetails(string threadSlug)
		=> $"{_forumBase}/t/{threadSlug}";

	/// <summary>Post urls are structured as /forums/{forum-slug}/{community-slug}/{post-slug}</summary>
	public static string PostDetails(string postSlug)
		=> $"{_forumBase}/p/{postSlug}";

	/// <summary>Creates a new <see cref="IPost"/></summary>
	public static string AuthorPost(string threadSlug)
		=> $"{CommunityDetails(threadSlug)}/author";

	/// <summary>Creates a new <see cref="IForumCommunity"/></summary>
	public static string CreateCommunity(string forumSlug)
		=> $"{ForumDetails(forumSlug)}/create";
}
