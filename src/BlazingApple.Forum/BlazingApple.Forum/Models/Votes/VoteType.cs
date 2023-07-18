using System.ComponentModel.DataAnnotations;

namespace BlazingApple.Forum.Shared.Models.Votes;

/// <summary>The "direction" of the vote (for/against, up/down, like/dislike).</summary>
public enum VoteType
{
	/// <summary>Indicates a user <em>likes</em> the topic or comment or post.</summary>
	[Display(Name = "Up")]
	UpVote,

	/// <summary>Indicates <em>dislike</em> of a topic or comment or post.</summary>
	[Display(Name = "Down")]
	DownVote
}
