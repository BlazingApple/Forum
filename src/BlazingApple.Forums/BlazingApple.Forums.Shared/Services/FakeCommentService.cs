using BlazingApple.Components.Shared.Models.Reactions;
using BlazingApple.Forums.Shared.Models.Posts;
using BlazingApple.Forums.Shared.Models.Reactions;
using BlazingApple.Forums.Shared.Models.Votes;
using BlazingApple.Forums.Shared.Posts.Comments;
using BlazingApple.Forums.Shared.Services.Base;
using BlazingApple.Forums.Shared.Services.Comments;

namespace BlazingApple.Forums.Shared.Services;

/// <inheritdoc cref="ICrudService{TModel}"/>
internal class FakeCommentService : FakeCrudServiceBase<IPostComment>, ICommentService
{
	private readonly IDictionary<Guid, List<IPostComment>> _commentsByPostId = new Dictionary<Guid, List<IPostComment>>();

	/// <inheritdoc />
	public override async Task<IPostComment> Get(string internalSlug)
	{
		IPostComment comment = GetComment();
		return TryGetBySlug(internalSlug, comment);
	}

	/// <inheritdoc />
	public async Task<List<IPostComment>> GetCommentsForPost(Guid postId, CommentStyle commentStyle)
	{
		List<IPostComment> comments = GetCommentHierarchyForPost(postId);
		if(commentStyle is CommentStyle.Hierarchy)
			return comments;

		List<IPostComment> postCommentsFlattened = new();
		FlattenComments(comments, postCommentsFlattened);

		return postCommentsFlattened;
	}

	/// <inheritdoc />
	public override async Task<IPostComment?> Post(IPostComment model)
	{
		IPostComment newModel = await base.Post(model) ?? model;
		if(_commentsByPostId.ContainsKey(model.PostId))
		{
			if(model.Parent is null && model.ParentId is null)
			{
				_commentsByPostId[model.PostId].Add(model);
			}
			else if(model.ParentId.HasValue && EntitiesById.ContainsKey(model.ParentId.Value!))
			{
				//EntitiesById[model.ParentId.Value].Children ??= new List<IPostComment>();
				//EntitiesById[model.ParentId.Value].Children!.Add(model);
			}
		}
		else
		{
			_commentsByPostId.Add(model.PostId, new List<IPostComment>() { model });
		}

		return newModel;
	}

	private void FlattenComments(List<IPostComment>? commentsToSearch, List<IPostComment> flattenedComments)
	{
		if(commentsToSearch is null)
			return;

		foreach(IPostComment comment in commentsToSearch)
		{
			flattenedComments.Add(comment);
			FlattenComments(comment.Children, flattenedComments);
		}
	}

	private List<IPostComment> GetCommentHierarchyForPost(Guid postId)
	{
		if(_commentsByPostId.ContainsKey(postId))
			return _commentsByPostId[postId];

		List<IPostComment> comments = GetComments();
		_commentsByPostId.Add(postId, comments);

		return comments;
	}
	private static List<IPostComment> GetComments() => GetCommentsCore().ToList();

	private static IEnumerable<IPostComment> GetCommentsCore()
	{
		int totalComments = 0;
		int commentCount = Random.Shared.Next(0, 3);
		for(int i = 0; i < commentCount; i++)
		{
			yield return GetComment(ref totalComments);
		}
	}

	private static IPostComment GetComment()
	{
		int totalComments = 0;
		return GetComment(ref totalComments);
	}

	private static IPostComment GetComment(ref int totalComments)
	{
		totalComments++;
		DateTime dateTime = DateTime.Now.AddMinutes(-1 * Random.Shared.Next(0, 2500));
		PostComment newComment = new()
		{
			Content = "Lorem Ipsum",
			UserId = "abc",
			DatabaseCreationTimestamp = dateTime,
			DatabaseModificationTimestamp = dateTime,
			Votes = new List<ICommentVote>(),
			Children = totalComments <= 50 ? GetComments() : new List<IPostComment>(),
			Reactions = GetCommentReactions(),
		};

		totalComments += newComment.Children.Count;

		return newComment;
	}

	public static List<ICommentReaction> GetCommentReactions()
	{
		List<ICommentReaction> reactions = new();
		int reactionCount = Random.Shared.Next(0, 50);
		int reactionOptions = Enum.GetValues<ReactionType>().Length;
		for(int i = 0; i < reactionCount; i++)
		{
			ICommentReaction reaction = new CommentReaction()
			{
				Type = Enum.GetValues<ReactionType>()[Random.Shared.Next(0, reactionOptions - 1)],
				DatabaseCreationTimestamp = DateTime.Now.AddDays(-12),
				UserId = "abc",
				CommentId = Guid.NewGuid(),
			};

			reactions.Add(reaction);
		}

		return reactions;
	}
}
