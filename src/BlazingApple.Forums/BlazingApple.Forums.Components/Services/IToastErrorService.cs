namespace BlazingApple.Forums.Components.Services;

/// <summary>Shows error toast messages.</summary>
internal interface IToastErrorService
{
	/// <summary>Failed to delete something toast.</summary>
	/// <param name="modelName">Unit to display, like "comment" or "thread".</param>
	void ShowDeleteError(string modelName);

	/// <summary>Failed to retrieve something toast.</summary>
	/// <param name="modelName">Unit to display, like "comment" or "thread".</param>
	void ShowGetError(string modelName);

	/// <summary>Failed to post/save something toast.</summary>
	/// <param name="modelName">Unit to display, like "comment" or "thread".</param>
	void ShowSaveError(string modelName);

	/// <summary>Failed to update something toast.</summary>
	/// <param name="modelName">Unit to display, like "comment" or "thread".</param>
	void ShowUpdateError(string modelName);
}
