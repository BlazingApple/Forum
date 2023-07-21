using Microsoft.AspNetCore.Components;

namespace BlazingApple.Forums.Components.Shared;
public partial class Header
{
	/// <summary>Header content</summary>
	[Parameter, EditorRequired]
	public RenderFragment? ChildContent { get; set; }

	/// <summary>additional attributes for the header container</summary>
	[Parameter(CaptureUnmatchedValues = true)]
	public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }
}
