using BlazingApple.Forums.Shared.Models.Posts;

namespace BlazingApple.Forums.Shared.Models.Votes;

/// <summary></summary>
public partial class PostVote : VoteBase, IPostVote
{
	/// <inheritdoc/>
	public Guid PostId { get; set; }

	/// <inheritdoc/>
	public IPost? Post { get; set; }
}
