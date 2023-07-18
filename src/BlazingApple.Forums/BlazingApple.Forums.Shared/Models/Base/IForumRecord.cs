namespace BlazingApple.Forums.Shared.Models.Base;

/// <summary>An entity to be saved in a database.</summary>
public interface IForumRecord : IChangeTracked
{
	/// <summary>Primary identifier</summary>
	Guid Id { get; set; }
}
