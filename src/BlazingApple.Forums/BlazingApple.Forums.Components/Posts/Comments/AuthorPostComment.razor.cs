using BlazingApple.Forums.Components.Services;
using BlazingApple.Forums.Shared.Models.Posts;
using BlazingApple.Forums.Shared.Services.Comments;
using Blazored.TextEditor;
using Microsoft.AspNetCore.Components;

namespace BlazingApple.Forums.Components.Posts.Comments;

public partial class AuthorPostComment : ComponentBase
{
	private BlazoredTextEditor? _quillHtml;
	/// <summary>
	/// The authoring user, if any. Will be disabled if null.
	/// </summary>
	[Parameter, EditorRequired]
	public string? UserId { get; set; }

	/// <summary>If this is in reply to another <see cref="IPostComment"/>, then this parameter must be provided.</summary>
	[Parameter]
	public Guid? ParentCommentId { get; set; }

	/// <summary>Post this relates to. Required even if child comment.</summary>
	[Parameter, EditorRequired]
	public Guid PostId { get; set; }

	[Parameter, EditorRequired]
	public EventCallback<IPostComment> CommentSubmitted { get; set; }

	[Inject]
	private ICommentService CommentService { get; set; } = null!;

	[Inject]
	private IToastErrorService ErrorService { get; set; } = null!;

	private async Task OnCommentSubmitted()
	{
		if(UserId is null)
			throw new InvalidOperationException("Unexpected null reference to Userid");

		string commentHtmlContents;
		string commentRawContents;

		try
		{
			if(_quillHtml is null)
				throw new InvalidOperationException("Unexpected null reference to author box");

			commentHtmlContents = await _quillHtml.GetHTML();
			commentRawContents = await _quillHtml.GetText();
		}
		catch(Exception ex)
		{
			Console.Error.WriteLine("Caught error reading from quill: {error}", ex);
			return;
		}

		if(string.IsNullOrWhiteSpace(commentRawContents))
			return;

		IPostComment comment = new PostComment()
		{
			Content = commentHtmlContents,
			UserId = UserId,
			ParentId = ParentCommentId ?? null,
			DatabaseCreationTimestamp = DateTime.Now,
			DatabaseModificationTimestamp = DateTime.Now,
			PostId = PostId,
		};

		IPostComment? newComment = await CommentService.Post(comment);

		if(newComment is null)
			ErrorService.ShowSaveError("comment");
		else if(CommentSubmitted.HasDelegate)
			await CommentSubmitted.InvokeAsync(comment);

		try
		{
			await _quillHtml.LoadHTMLContent(string.Empty);
		}
		catch(Exception ex)
		{
			Console.WriteLine($"Caught error refreshing quill: {ex}");
		}
	}
}
