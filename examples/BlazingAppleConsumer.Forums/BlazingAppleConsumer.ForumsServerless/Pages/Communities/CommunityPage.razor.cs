using BlazingApple.Forums.Components.Votes;
using BlazingApple.Forums.Shared.Models.Base;
using BlazingApple.Forums.Shared.Models.Communities;
using BlazingApple.Forums.Shared.Models.Posts;
using BlazingAppleConsumer.ForumsServerless.Pages.Posts;
using Microsoft.AspNetCore.Components;

namespace BlazingAppleConsumer.ForumsServerless.Pages.Communities;

/// <summary>Renders a <see cref="IForumCommunity"/></summary>
public partial class CommunityPage : ComponentBase
{
	private IForumCommunity? _community;
	private VoteStyle _voteStyle = VoteStyle.ReactionsOnly;

	/// <summary><see cref="IForumSluggable"/></summary>
	[Parameter, EditorRequired]
	public string Slug { get; set; } = null!;

	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		_community = new ForumCommunity()
		{
			Title = "Blazing Heat",
			Slug = Slug,
			CreatingUserId = "abc",
			Description = "All about hot sauce",
			ForumId = Guid.NewGuid(),
			Posts = new List<IPost>()
		};

		_community.Posts!.Add(GetPost("Best Sauces from Each Country", "I love them all"));
		_community.Posts!.Add(GetPost("Best Sauces from Each City", "Louisiana does it best"));
		_community.Posts!.Add(GetPost("How to recover your tongue from a sauce burn", "hot hot hot"));
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
			Reactions = PostPage.GetReactions(),
		};
	}
}
