using BlazingApple.Forums.Shared.Models.Posts;
using BlazingApple.Forums.Shared.Models.Votes;
using Microsoft.AspNetCore.Components;

namespace BlazingApple.Forums.Components.Votes;

/// <summary>Displays data about the votes on a post.</summary>
public partial class PostVoteDisplay : ComponentBase
{
	private IPostVote? _userVote;

	/// <summary>Post to render voting data for.</summary>
	[Parameter, EditorRequired]
	public IPost? Post { get; set; }

	/// <inheritdoc />
	protected override async Task OnInitializedAsync() => await base.OnInitializedAsync();

	private async Task VoteSelected(VoteType? voteType)
	{
		if(Post is null)
			throw new InvalidOperationException();

		if(voteType is null)
		{
			_userVote = null;
		}
		else if(_userVote is null)
		{
			_userVote = new PostVote()
			{
				PostId = Post.Id,
				Type = voteType.Value,
				UserId = "abc",
			};
		}
		else
		{
			_userVote.Type = voteType.Value;
			_userVote.DatabaseModificationTimestamp = DateTime.Now;
		}
	}
}
