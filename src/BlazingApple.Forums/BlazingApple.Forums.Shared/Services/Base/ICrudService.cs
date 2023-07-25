using BlazingApple.Components.Shared.Interfaces.Search;
using BlazingApple.Components.Shared.Models.Search;

namespace BlazingApple.Forums.Shared.Services.Base;

public interface ICrudService<TModel> where TModel : class
{
	/// <summary>Deletes the record from the database</summary>
	/// <param name="internalSlug">The record's slug or identifier used to identify the record on the server.</param>
	/// <returns>An HttpResponseMessage indicating whether or not the request succeeded.</returns>
	Task<bool> Delete(string internalSlug);

	/// <summary>Deletes the record from the database</summary>
	/// <param name="id">Delete via the id.</param>
	/// <returns>An HttpResponseMessage indicating whether or not the request succeeded.</returns>
	Task<bool> Delete(Guid id);

	/// <summary>Retrieves a record from the database</summary>
	/// <param name="internalSlug">The record's slug or identifier used to identify the record on the server.</param>
	/// <returns>The deserialized object (if exists).</returns>
	Task<TModel> Get(string internalSlug);

	/// <summary>Gets the default/complete list of models available to this user on the database.</summary>
	/// <returns>A list of models, or empty list if none received.</returns>
	Task<List<TModel>> GetList();

	/// <summary>Saves a new model to the database.</summary>
	/// <param name="model">The object to save.</param>
	/// <returns><typeparamref name="TModel"/></returns>
	Task<TModel?> Post(TModel model);

	/// <summary>Saves a new model to the database.</summary>
	/// <param name="internalSlug">The record's slug or identifier used to identify the record on the server.</param>
	/// <param name="model">The object to save.</param>
	/// <returns><see cref="HttpResponseMessage" /></returns>
	Task<TModel?> Put(string internalSlug, TModel model);

	/// <summary>
	/// Search for <typeparamref name="TModel"/>
	/// </summary>
	/// <typeparam name="TFilter">Type of <see cref="IFilter"/></typeparam>
	/// <param name="request">The search request</param>
	/// <returns><see cref="ISearchResults{T}"/></returns>
	Task<ISearchResults<TModel>> Search<TFilter>(ISearchRequest<TFilter> request)
		where TFilter : class, IFilter, new();
}
