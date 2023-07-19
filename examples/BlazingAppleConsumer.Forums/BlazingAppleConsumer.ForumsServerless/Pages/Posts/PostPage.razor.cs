using BlazingApple.Forums.Shared.Models.Posts;
using Microsoft.AspNetCore.Components;

namespace BlazingAppleConsumer.ForumsServerless.Pages.Posts;

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
		_post = new Post()
		{
			Slug = Slug,
			Title = "Hello word",
			Content = "I like eggs",
			UserId = "abc",
			DatabaseCreationTimestamp = DateTime.Now.AddDays(-1 * Random.Shared.Next(90)),
		};
	}
}
