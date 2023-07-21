using Blazored.Toast.Services;

namespace BlazingApple.Forums.Components.Services;

/// <summary>Render toasts error popup when something fails to save.</summary>
internal class ToastErrorService : IToastErrorService
{
	private readonly IToastService _toastService;

	public ToastErrorService(IToastService toastService) => _toastService = toastService;

	/// <inheritdoc />
	public void ShowSaveError(string modelName)
		=> ShowErrorCore("save", modelName);

	/// <inheritdoc />
	public void ShowUpdateError(string modelName)
		=> ShowErrorCore("update", modelName);

	/// <inheritdoc />
	public void ShowDeleteError(string modelName)
		=> ShowErrorCore("delete", modelName);

	/// <inheritdoc />
	public void ShowGetError(string modelName)
		=> ShowErrorCore("retrieve", modelName);

	private void ShowErrorCore(string operation, string modelName)
		=> _toastService.ShowError($"Failed to {operation} {modelName}");
}
