using BlazingApple.Forums.Shared.Models.Forums;
using BlazingApple.Forums.Shared.Models.Threads;
using Microsoft.AspNetCore.Components;

namespace BlazingAppleConsumer.ForumsServerless.Pages.Forums;

/// <summary>Shows a list of <see cref="IForum"/></summary>
public partial class ForumListPage : ComponentBase
{
	private List<IForum>? _forums;
	/// <inheritdoc/>
	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		_forums = new List<IForum>
		{
			GetForum("Blazing Apples, Forum 1", "For blazing things"),
			GetForum("Blazing Apples, Forum 2", "For apple things")
		};
	}

	private static IForum GetForum(string title, string description)
	{
		string slug = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
		slug = slug[..^2]
			.Replace('/', '-')
			.Replace('+', '_');

		return new Forum()
		{
			Id = Guid.NewGuid(),
			Slug = slug,
			Title = title,
			Description = description,
			IsPublic = true,
			Threads = new List<IForumThread>(),
		};
	}
}
