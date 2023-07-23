using BlazingApple.Forums.Shared.Models.Communities;
using Humanizer;

namespace BlazingApple.Forums.Shared.Models.Forums;
public class Forum : IForum
{
	/// <inheritdoc />
	public Guid Id { get; set; }

	/// <inheritdoc />
	public required string Slug { get; set; }

	/// <inheritdoc />
	public required string Title { get; set; }

	/// <inheritdoc />
	public required string Description { get; set; }

	/// <inheritdoc />
	public bool IsPublic { get; set; }

	/// <inheritdoc />
	public List<IForumCommunity>? Communities { get; set; }

	/// <inheritdoc />
	public List<IForumMembership>? Members { get; set; }

	/// <inheritdoc />
	public DateTime DatabaseCreationTimestamp { get; set; }

	/// <inheritdoc />
	public DateTime DatabaseModificationTimestamp { get; set; }

	/// <inheritdoc />
	public string ToCreationDate() => DatabaseCreationTimestamp.Humanize();

	/// <inheritdoc />
	public string ToLastUpdatedDate() => DatabaseModificationTimestamp.Humanize();
}
