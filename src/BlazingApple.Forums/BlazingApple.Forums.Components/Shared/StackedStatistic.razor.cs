using Microsoft.AspNetCore.Components;

namespace BlazingApple.Forums.Components.Shared;

/// <summary>Renders an interesting statistic in a consistent fashion.</summary>
public partial class StackedStatistic : ComponentBase
{
	/// <summary>The statistical value.</summary>
	[Parameter, EditorRequired]
	public object? Statistic { get; set; }

	/// <summary>The statistical unit.</summary>
	[Parameter, EditorRequired]
	public string? Unit { get; set; }
}
