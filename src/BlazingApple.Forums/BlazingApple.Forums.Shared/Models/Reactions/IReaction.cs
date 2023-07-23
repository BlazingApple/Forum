using BlazingApple.Components.Shared.Models.Reactions;
using BlazingApple.Forums.Shared.Models.Base;

namespace BlazingApple.Forums.Shared.Models.Reactions;
public interface IReaction : IForumRecord
{
	/// <summary><see cref="ReactionType"/></summary>
	ReactionType Type { get; set; }

	/// <summary>User associated with this vote.</summary>
	string UserId { get; set; }
}
