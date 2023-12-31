﻿using BlazingApple.Components.Shared.Interfaces;
using BlazingApple.Components.Shared.Models.Reactions;
using BlazingApple.Forums.Shared.Models.Base;
using BlazingApple.Forums.Shared.Models.Reactions;
using BlazingApple.Forums.Shared.Models.Votes;

namespace BlazingApple.Forums.Shared.Models.Posts;

public partial interface IPostComment : IForumRecord
{
	/// <summary>The string content of the comment.</summary>   
	string Content { get; set; }

	/// <summary>Author users id</summary>
	string UserId { get; set; }

	/// <summary>User that authored comment</summary>
	IUser? User { get; set; }

	/// <summary><see cref="IPost"/> associated with this comment.</summary>
	IPost? Post { get; set; }

	/// <summary>Foreign key for <see cref="Post"/></summary>
	Guid PostId { get; set; }

	/// <summary>Set of votes associated with the comment.</summary>
	List<ICommentVote>? Votes { get; set; }

	/// <summary>Set of reactions associated with the comment.</summary>
	List<ICommentReaction>? Reactions { get; set; }

	/// <summary>Responses/Child comments</summary>
	List<IPostComment>? Children { get; set; }

	/// <summary>FK of the parent for this comment, e.g. which comment this was in reply to.</summary>
	Guid? ParentId { get; set; }

	/// <summary><see cref="ParentId"/></summary>
	IPostComment? Parent { get; set; }

	/// <summary>Get the number of reactions by <see cref="ReactionType"/></summary>
	/// <returns>A dictionary representing the number of reactions by <see cref="ReactionType"/></returns>
	public virtual IDictionary<ReactionType, int>? GetReactionCounts()
		=> Reactions?.GroupBy(r => r.Type).ToDictionary(grp => grp.Key, grp => grp.Count());
}
