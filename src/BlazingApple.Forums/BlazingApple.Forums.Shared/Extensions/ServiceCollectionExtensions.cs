using BlazingApple.Forums.Shared.Services;
using BlazingApple.Forums.Shared.Services.Comments;
using BlazingApple.Forums.Shared.Services.Communities;
using BlazingApple.Forums.Shared.Services.Forums;
using BlazingApple.Forums.Shared.Services.Posts;
using Microsoft.Extensions.DependencyInjection;

namespace BlazingApple.Forums.Shared.Extensions;

/// <summary>Fake I/O services for testing.</summary>
public static class ServiceCollectionExtensions
{
	/// <summary>Add Blazor I/O forum services</summary>
	/// <param name="services">Extension</param>
	/// <returns>Fluent API</returns>
	public static IServiceCollection AddFakeForumServices(this IServiceCollection services)
	{
		services.AddScoped<ICommentService, FakeCommentService>();
		services.AddScoped<ICommentVoteService, FakeCommentVoteService>();
		services.AddScoped<IForumService, FakeForumService>();
		services.AddScoped<IPostService, FakePostService>();
		services.AddScoped<IPostVoteService, FakePostVoteService>();
		services.AddScoped<ICommunityService, FakeCommunityService>();
		services.AddScoped<IPostReactionService, FakePostReactionService>();
		services.AddScoped<ICommentReactionService, FakeCommentReactionService>();

		return services;
	}

	/// <summary>Add Blazor I/O forum services</summary>
	/// <param name="services">Extension</param>
	/// <returns>Fluent API</returns>
	public static IServiceCollection AddForumCRUDServices<TCommentService, TCommentVoteService, TCommentReactionService, TForumService, TPostService, TPostVoteService, TPostReactionService, TThreadService>(this IServiceCollection services)
		where TCommentService : class, ICommentService
		where TForumService : class, IForumService
		where TThreadService : class, ICommunityService
		where TCommentVoteService : class, ICommentVoteService
		where TCommentReactionService : class, ICommentReactionService
		where TPostService : class, IPostService
		where TPostVoteService : class, IPostVoteService
		where TPostReactionService : class, IPostReactionService
	{
		services.AddScoped<ICommentService, TCommentService>();
		services.AddScoped<ICommentVoteService, TCommentVoteService>();
		services.AddScoped<IForumService, TForumService>();
		services.AddScoped<IPostService, TPostService>();
		services.AddScoped<IPostVoteService, TPostVoteService>();
		services.AddScoped<ICommunityService, TThreadService>();

		return services;
	}
}
