using BlazingApple.Forums.Shared.Models.Base;

namespace BlazingApple.Forums.Shared.Models.Votes;
public interface IVote : IForumRecord
{
	/// <summary><see cref="VoteType"/></summary>
	VoteType Type { get; set; }

	/// <summary>User associated with this vote.</summary>
	string UserId { get; set; }
}
