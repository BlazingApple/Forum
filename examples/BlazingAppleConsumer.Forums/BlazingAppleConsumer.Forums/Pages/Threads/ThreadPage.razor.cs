using BlazingApple.Forums.Shared.Models.Base;
using BlazingApple.Forums.Shared.Models.Posts;
using BlazingApple.Forums.Shared.Models.Threads;
using Microsoft.AspNetCore.Components;

namespace BlazingAppleConsumer.Forums.Pages.Threads;

/// <summary>Renders a <see cref="IForumThread"/></summary>
public partial class ThreadPage : ComponentBase
{
	private IForumThread? _thread;

	/// <summary><see cref="IForumSluggable"/></summary>
	[Parameter, EditorRequired]
	public string Slug { get; set; } = null!;

	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		_thread = new ForumThread()
		{
			Title = "Blazing Heat",
			Slug = Slug,
			CreatingUserId = "abc",
			Description = "All about hot sauce",
			ForumId = Guid.NewGuid(),
			Posts = new List<IPost>()
		};

		_thread.Posts!.Add(GetPost("Best Sauces from Each Country", "I love them all"));
		_thread.Posts!.Add(GetPost("Best Sauces from Each City", "Louisiana does it best"));
		_thread.Posts!.Add(GetPost("How to recover your tongue from a sauce burn", "hot hot hot"));
	}

	private IPost GetPost(string title, string content)
	{
		string slug = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
		slug = slug[..^2]
			.Replace('/', '-')
			.Replace('+', '_');
		slug = $"{Slug}/{slug}";

		return new Post()
		{
			Id = Guid.NewGuid(),
			Slug = slug,
			Title = title,
			Content = content,
			UserId = "abc",
		};
	}
}
