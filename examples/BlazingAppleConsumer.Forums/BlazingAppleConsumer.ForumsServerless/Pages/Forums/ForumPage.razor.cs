using BlazingApple.Forums.Shared.Models.Communities;
using BlazingApple.Forums.Shared.Models.Forums;
using BlazingApple.Forums.Shared.Models.Posts;
using Microsoft.AspNetCore.Components;
using ForumModel = BlazingApple.Forums.Shared.Models.Forums.Forum;
namespace BlazingAppleConsumer.ForumsServerless.Pages.Forums;

/// <summary>Page that renders details about a forum, including a list of posts.</summary>
public partial class ForumPage : ComponentBase
{
	private IForum? _forum;

	/// <summary><see cref="IForumSluggable"/></summary>
	[Parameter, EditorRequired]
	public string Slug { get; set; } = null!;

	/// <summary><see cref="IForum.Id"/></summary>
	[Parameter]
	public Guid Id { get; set; }

	/// <inheritdoc />
	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		_forum = new ForumModel()
		{
			Id = Id,
			Slug = Slug,
			Title = "BlazingApple",
			Description = "Forum for discussion of BlazingApple topics.",
			IsPublic = true,
			Members = null,
			Communities = new List<IForumCommunity>(),
		};

		_forum.Communities!.Add(GetThread(_forum.Slug, "Levels of heat", "Discussing what it means to be 'Blazing'."));
		_forum.Communities!.Add(GetThread(_forum.Slug, "Best hot sauces", "How to evaluate and decide the best sauces."));
	}

	public static IForumCommunity GetThread(string forumSlug, string title, string description)
	{
		string slug = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
		slug = slug[..^2]
			.Replace('/', '-')
			.Replace('+', '_');
		slug = $"{forumSlug}/{slug}";

		return new ForumCommunity()
		{
			Id = Guid.NewGuid(),
			Slug = slug,
			Title = title,
			Description = description,
			CreatingUserId = "abc",
			DatabaseCreationTimestamp = DateTime.Now.AddDays(-1 * Random.Shared.Next(0, 10000)),
			Posts = new List<IPost>(),
		};
	}
}
