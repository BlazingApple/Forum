namespace BlazingApple.Forums.Components.Posts.Comments;

/// <summary>Indicates whether the comment style should use a hierarchy, like Reddit, or replies, like MS Teams (or many other messaging apps)</summary>
public enum CommentStyle
{
	/// <summary>In the <see cref="Hierarchy"/> style, a reply will be embedded <em>underneath</em> its parent comment.</summary>
	Hierarchy,

	/// <summary>In the <see cref="Chronological"/> style, a reply from a parent will show a reference to the parent, but otherwise be listed in chronlogical order of the conversation.</summary>
	Chronological
}
