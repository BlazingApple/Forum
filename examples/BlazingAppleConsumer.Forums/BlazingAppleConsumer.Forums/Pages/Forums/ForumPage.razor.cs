using BlazingApple.Forums.Shared.Models.Forums;
using BlazingApple.Forums.Shared.Models.Posts;
using BlazingApple.Forums.Shared.Models.Threads;
using Microsoft.AspNetCore.Components;
using ForumModel = BlazingApple.Forums.Shared.Models.Forums.Forum;
namespace BlazingAppleConsumer.Forums.Pages.Forums;

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
			Threads = new List<IForumThread>(),
		};

		_forum.Threads!.Add(GetThread("Levels of heat", "Discussing what it means to be 'Blazing'."));
		_forum.Threads!.Add(GetThread("Best hot sauces", "How to evaluate and decide the best sauces."));
	}

	private IForumThread GetThread(string title, string description)
	{
		if(_forum is null)
			throw new InvalidOperationException();

		string slug = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
		slug = slug[..^2]
			.Replace('/', '-')
			.Replace('+', '_');
		slug = $"{_forum.Slug}/{slug}";

		return new ForumThread()
		{
			Id = Guid.NewGuid(),
			Slug = slug,
			Title = title,
			Description = description,
			CreatingUserId = "abc",
			Posts = new List<IPost>(),
		};
	}
}
