using BlazingApple.Components.Shared.Interfaces;
using BlazingApple.Forums.Shared.Models.Base;
using BlazingApple.Forums.Shared.Models.Votes;

namespace BlazingApple.Forums.Shared.Models.Posts;

public partial interface IPostComment : IForumRecord, IComment
{
	/// <summary><see cref="IPost"/> associated with this comment.</summary>
	IPost? Post { get; set; }

	/// <summary>Foreign key for <see cref="Post"/></summary>
	Guid PostId { get; set; }

	/// <summary>Set of votes associated with the comment.</summary>
	List<ICommentVote>? Votes { get; set; }

	/// <summary>Responses/Child comments</summary>
	List<IPostComment>? Children { get; set; }

	/// <summary>FK of the parent for this comment, e.g. which comment this was in reply to.</summary>
	Guid? ParentId { get; set; }

	/// <summary><see cref="ParentId"/></summary>
	IPostComment? Parent { get; set; }
}
