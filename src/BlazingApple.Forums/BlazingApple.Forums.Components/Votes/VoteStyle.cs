using System.ComponentModel.DataAnnotations;

namespace BlazingApple.Forums.Components.Votes;

/// <summary>Describes the type of reactions to display.</summary>
public enum VoteStyle
{
	[Display(Name = "Votes only")]
	VotesOnly,

	[Display(Name = "Reactions only")]
	ReactionsOnly,

	[Display(Name = "Reactions and votes")]
	ReactionsAndVotes
}
