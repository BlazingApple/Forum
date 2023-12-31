﻿using BlazingApple.Forums.Shared.Models.Base;

namespace BlazingApple.Forums.Shared.Models.Forums;
internal class ForumMembership : MembershipBase, IForumMembership
{
	/// <summary>FK for the <see cref="IForum"/> the user is a member of.</summary>
	public Guid ForumId { get; set; }

	/// <summary>The forum the user is a member of.</summary>
	public IForum? Forum { get; set; }
}
