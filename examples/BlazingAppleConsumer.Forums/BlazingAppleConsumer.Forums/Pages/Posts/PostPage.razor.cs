using BlazingApple.Forums.Shared.Models.Posts;
using BlazingApple.Forums.Shared.Models.Votes;
using BlazingAppleConsumer.Forums.Pages.Forums;
using Microsoft.AspNetCore.Components;

namespace BlazingAppleConsumer.Forums.Pages.Posts;

/// <summary></summary>
public partial class PostPage : ComponentBase
{
	private IPost? _post;

	/// <summary></summary>
	[Parameter, EditorRequired]
	public string Slug { get; set; } = null!;

	/// <inheritdoc />
	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		string forumSlug = Convert.ToBase64String(Guid.NewGuid().ToByteArray());

		_post = new Post
		{
			Slug = Slug,
			Title = "Hello word",
			Content = "I like eggs",
			UserId = "abc",
			DatabaseCreationTimestamp = DateTime.Now.AddDays(-1 * Random.Shared.Next(90)),
			Comments = GetComments(),
			Thread = ForumPage.GetThread(forumSlug, "Levels of heat", "Discussing what it means to be 'Blazing'."),
		};
	}

	private static List<IPostComment> GetComments() => GetCommentsCore().ToList();

	private static IEnumerable<IPostComment> GetCommentsCore()
	{
		int commentCount = Random.Shared.Next(0, 3);

		for(int i = 0; i < commentCount; i++)
		{
			yield return GetComment();
		}
	}

	private static IPostComment GetComment()
	{
		DateTime dateTime = DateTime.Now.AddMinutes(-1 * Random.Shared.Next(0, 2500));
		return new PostComment()
		{
			Content = "Lorem Ipsum",
			UserId = "abc",
			DatabaseCreationTimestamp = dateTime,
			DatabaseModificationTimestamp = dateTime,
			Votes = new List<ICommentVote>(),
			Children = GetComments(),
		};
	}
}
