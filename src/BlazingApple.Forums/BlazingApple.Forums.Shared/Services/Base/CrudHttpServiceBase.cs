using System.Net.Http.Json;
using BlazingApple.Components.Shared.Interfaces.Search;
using BlazingApple.Components.Shared.Models.Search;

namespace BlazingApple.Forums.Shared.Services.Base;
internal class CrudHttpServiceBase<TModel> : ICrudService<TModel>
	where TModel : class
{
	/// <summary>Indicates an operation/endpoint is not available by this service.</summary>
	protected const string EndpointNotImplemented = "This service does not implement the requested endpoint.";

	/// <summary>Prefix for the record type. Example: "/api/committees/"</summary>
	protected string ApiPrefix { get; init; }

	/// <summary>I/O with the server.</summary>
	protected HttpClient Http { get; init; }

	/// <summary>The constructor, accepts the DI services.</summary>
	/// <param name="client">The HttpClient used to pull committees from the server.</param>
	/// <param name="apiPrefix">The route prefix for outgoing requests.</param>
	protected CrudHttpServiceBase(HttpClient client, string apiPrefix)
	{
		Http = client;
		if(string.IsNullOrEmpty(apiPrefix))
			throw new ArgumentNullException(nameof(apiPrefix));
		ApiPrefix = apiPrefix;
	}

	/// <inheritdoc/>
	public virtual async Task<bool> Delete(string slug)
	{
		HttpResponseMessage response = await Http.DeleteAsync(ApiPrefix + slug);

		return response.IsSuccessStatusCode;
	}

	/// <inheritdoc/>
	public virtual async Task<bool> Delete(Guid id)
	{
		HttpResponseMessage response = await Http.DeleteAsync(ApiPrefix + id);

		return response.IsSuccessStatusCode;
	}

	/// <inheritdoc/>
	public virtual async Task<TModel> Get(string slug)
		=> (await Http.GetFromJsonAsync<TModel>(ApiPrefix + slug))!;

	/// <inheritdoc/>
	public virtual async Task<List<TModel>> GetList()
		=> (await Http.GetFromJsonAsync<List<TModel>>(ApiPrefix)) ?? new List<TModel>();

	/// <inheritdoc/>
	public virtual async Task<TModel?> Post(TModel model)
	{
		HttpResponseMessage response = await Http.PostAsJsonAsync(ApiPrefix, model);

		if(response.IsSuccessStatusCode)
			return await response.Content.ReadFromJsonAsync<TModel>();
		else
			return default;
	}

	/// <inheritdoc/>
	public virtual async Task<TModel?> Put(string slug, TModel model)
	{
		HttpResponseMessage response = await Http.PostAsJsonAsync(ApiPrefix, model);

		if(response.IsSuccessStatusCode)
			return await response.Content.ReadFromJsonAsync<TModel>();
		else
			return default;
	}

	/// <inheritdoc/>
	public virtual async Task<ISearchResults<TModel>> Search<TFilter>(ISearchRequest<TFilter> request)
		where TFilter : class, IFilter, new()
	{
		HttpResponseMessage response = await Http.PostAsJsonAsync($"{ApiPrefix}/search", request);
		response.EnsureSuccessStatusCode();

		ISearchResults<TModel> results = (await response.Content.ReadFromJsonAsync<ISearchResults<TModel>>())!;
		return results;
	}
}
