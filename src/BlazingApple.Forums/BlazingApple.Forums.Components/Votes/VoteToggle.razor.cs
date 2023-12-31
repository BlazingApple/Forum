﻿using BlazingApple.Forums.Shared.Models.Votes;
using Microsoft.AspNetCore.Components;

namespace BlazingApple.Forums.Components.Votes;

/// <summary>Renders a button indicating the state of a vote.</summary>
public partial class VoteToggle : ComponentBase
{
	private int _upVotes = Random.Shared.Next(1000);
	private const string _sharedButtonClasses = "btn btn-sm btn-outline-primary d-flex align-items-center justify-content-center";
	private const string _sharedButtonStyles = "border-radius: 50%; width: 1.5rem; height: 1.5rem;";

	/// <summary>The current value of the user's vote looking at the toggles.</summary>
	[Parameter]
	public VoteType? Value { get; set; }

	/// <summary>Direction to display the arrows, aligned vertically or horizontally.</summary>
	[Parameter]
	public VoteToggleDirection Direction { get; set; } = VoteToggleDirection.Vertical;

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

	public enum VoteToggleDirection
	{
		Vertical,
		Horizontal
	}
}
