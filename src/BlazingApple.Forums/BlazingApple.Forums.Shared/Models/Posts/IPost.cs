using BlazingApple.Components.Shared.Models.Reactions;
using BlazingApple.Forums.Shared.Models.Base;
using BlazingApple.Forums.Shared.Models.Communities;
using BlazingApple.Forums.Shared.Models.Reactions;
using BlazingApple.Forums.Shared.Models.Votes;

namespace BlazingApple.Forums.Shared.Models.Posts;

public partial interface IPost : IForumSluggable
{
	/// <summary>String content for a post.</summary>
	string Content { get; set; }

	/// <summary>The title of the post.</summary>
	string Title { get; set; }

	/// <summary>Foreign key for a User object.</summary>
	string UserId { get; set; }

	/// <summary>Set of votes associated with the post.</summary>
	List<IPostVote>? Votes { get; set; }

	/// <summary>Set of reactions associated with the post.</summary>
	List<IPostReaction>? Reactions { get; set; }

	/// <summary>Set of comments associated with the post.</summary>
	List<IPostComment>? Comments { get; set; }

	/// <summary>The thread this post was posted in.</summary>
	IForumCommunity? Community { get; set; }

	/// <summary>FK for the thread this post was posted in.</summary>
	Guid CommunityId { get; set; }

	/// <summary>Get the number of reactions by <see cref="ReactionType"/></summary>
	/// <returns>A dictionary representing the number of reactions by <see cref="ReactionType"/></returns>
	public virtual IDictionary<ReactionType, int>? GetReactionCounts()
		=> Reactions?.GroupBy(r => r.Type).ToDictionary(grp => grp.Key, grp => grp.Count());
}
