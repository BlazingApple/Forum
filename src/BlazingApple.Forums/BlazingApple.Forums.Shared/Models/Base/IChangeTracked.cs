namespace BlazingApple.Forums.Shared.Models.Base;

/// <summary>Used to hook into EF Core updates on records.</summary>
public interface IChangeTracked
{
	/// <summary>The date/time in which this record was created in the database</summary>
	/// <remarks>Automatically set by the context</remarks>
	DateTime DatabaseCreationTimestamp { get; set; }

	/// <summary>The date/time in which this record was last updated in the database</summary>
	/// <remarks>Automatically set by the context</remarks>
	DateTime DatabaseModificationTimestamp { get; set; }

	/// <summary>Present the entity as a string indicating how long ago it was created.</summary>
	/// <returns>String indicating how long ago it was created.</returns>
	string ToCreationDate();

	/// <summary>Present the entity as a string indicating how long ago it was updated.</summary>
	/// <returns>String indicating how long ago it was updated.</returns>
	string ToLastUpdatedDate();
}
