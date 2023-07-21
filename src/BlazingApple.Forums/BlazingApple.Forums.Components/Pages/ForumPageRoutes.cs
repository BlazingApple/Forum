using BlazingApple.Forums.Shared.Models.Posts;
using BlazingApple.Forums.Shared.Models.Threads;

namespace BlazingApple.Forums.Components.Pages;
public static class ForumPageRoutes
{
	private const string _forumBase = "forums";

	public static string ForumDetails(string forumSlug)
		=> $"{_forumBase}/{forumSlug}";

	public static string ThreadDetails(string threadSlug)
		=> $"{_forumBase}/t/{threadSlug}";

	/// <summary>Post urls are structured as /forums/{forum-slug}/{thread-slug}/{post-slug}</summary>
	public static string PostDetails(string postSlug)
		=> $"{_forumBase}/p/{postSlug}";

	/// <summary>Creates a new <see cref="IPost"/></summary>
	public static string AuthorPost(string threadSlug)
		=> $"{ThreadDetails(threadSlug)}/author";

	/// <summary>Creates a new <see cref="IForumThread"/></summary>
	public static string CreateThread(string forumSlug)
		=> $"{ForumDetails(forumSlug)}/create";
}
