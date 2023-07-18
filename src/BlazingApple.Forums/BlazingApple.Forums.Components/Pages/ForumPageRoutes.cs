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
}
