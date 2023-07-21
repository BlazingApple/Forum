using Blazored.TextEditor;
using Microsoft.AspNetCore.Components;

namespace BlazingApple.Forums.Components.Posts.Comments;

public partial class AuthorPostComment : ComponentBase
{
	private BlazoredTextEditor? _quillHtml;
	private string? _quillHTMLContent;
	private DateTime _commentDate;
	/// <summary>
	/// The authoring user, if any. Will be disabled if null.
	/// </summary>
	[Parameter, EditorRequired]
	public string? UserId { get; set; }

	public async void GetHTML()
	{
		if(_quillHtml is null)
			return;

		_commentDate = DateTime.Now;
		_quillHTMLContent = await _quillHtml.GetHTML();
		StateHasChanged();
	}
}
