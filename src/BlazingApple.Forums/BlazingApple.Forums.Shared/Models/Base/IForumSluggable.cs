namespace BlazingApple.Forums.Shared.Models.Base;

/// <summary>A sluggable record, e.g. a record that has it's own navigable page.</summary>
public interface IForumSluggable : IForumRecord
{
	/// <summary>The url segment for this entity.</summary>
	string Slug { get; set; }
}
