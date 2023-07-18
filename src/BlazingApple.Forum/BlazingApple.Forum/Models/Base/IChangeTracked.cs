namespace BlazingApple.Forum.Shared.Models.Base;

/// <summary>Used to hook into EF Core updates on records.</summary>
public interface IChangeTracked
{
	/// <summary>The date/time in which this record was created in the database</summary>
	/// <remarks>Automatically set by the context</remarks>
	DateTime DatabaseCreationTimestamp { get; set; }

	/// <summary>The date/time in which this record was last updated in the database</summary>
	/// <remarks>Automatically set by the context</remarks>
	DateTime DatabaseModificationTimestamp { get; set; }
}
