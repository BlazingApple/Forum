using BlazingApple.Forums.Shared.Models.Votes;
using Microsoft.AspNetCore.Components;

namespace BlazingApple.Forums.Components.Votes;

/// <summary>Renders a button indicating the state of a vote.</summary>
public partial class VoteToggle : ComponentBase
{
	private int _upVotes = Random.Shared.Next(1000);
	private const string _sharedButtonClasses = "btn btn-sm btn-outline-primary d-flex align-items-center";
	[Parameter]
	public VoteType? Value { get; set; }

	/// <summary>Callback indicating a vote has changed.</summary>
	[Parameter]
	public EventCallback<VoteType?> ValueChanged { get; set; }

	private string UpButtonClasses => Value.HasValue && Value.Value == VoteType.UpVote ? $"{_sharedButtonClasses} active" : _sharedButtonClasses;
	private string DownButtonClasses => Value.HasValue && Value.Value == VoteType.DownVote ? $"{_sharedButtonClasses} active" : _sharedButtonClasses;

	private async Task UpVoteSelected()
	{
		if(Value.HasValue)
		{
			if(Value.Value == VoteType.UpVote)
				await UpdateVote(null, -1);
			else
				await UpdateVote(VoteType.UpVote, 2);
		}
		else
		{
			await UpdateVote(VoteType.UpVote, 1);
		}
	}

	private async Task DownVoteSelected()
	{
		if(Value.HasValue)
		{
			if(Value.Value == VoteType.UpVote)
				await UpdateVote(VoteType.DownVote, -2);
			else
				await UpdateVote(null, 1);
		}
		else
		{
			await UpdateVote(VoteType.DownVote, -1);
		}
	}

	private async Task UpdateVote(VoteType? newValue, int changeUpVotesByThisAmount)
	{
		if(ValueChanged.HasDelegate)
			await ValueChanged.InvokeAsync(newValue);

		_upVotes += changeUpVotesByThisAmount;
	}
}
