namespace BlazingApple.Forum.Shared.Threads;

/// <summary>Describes the status of a member in a <see cref="IThread"/></summary>
public enum MembershipStatus
{
	/// <summary>Participant/regular member of a thread.</summary>
	Standard,
	/// <summary>An administrator/moderator that has additional permissions.</summary>
	Moderator,
	/// <summary>This individual was <em>once</em> a member, but is no longer one as they willingly left the thread/forum.</summary>
	Departed,
	/// <summary>This individual was banned or kicked from the thread.</summary>
	Banned
}
