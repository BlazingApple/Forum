using BlazingApple.Components.Shared.Interfaces.Search;
using BlazingApple.Components.Shared.Models.Search;

namespace BlazingApple.Forums.Shared.Services.Base;

/// <summary>Fakes the various services</summary>
/// <typeparam name="TModel">Model to operate on.</typeparam>
internal abstract class FakeCrudServiceBase<TModel> : ICrudService<TModel>
	where TModel : class
{

	/// <inheritdoc />
	public virtual async Task<bool> Delete(string internalSlug)
		=> true;

	/// <inheritdoc />
	public virtual async Task<TModel> Get(string internalSlug)
		=> throw new NotImplementedException();

	/// <inheritdoc />
	public virtual async Task<List<TModel>> GetList()
		=> new List<TModel>();

	/// <inheritdoc />
	public virtual async Task<TModel?> Post(TModel model)
		=> model;

	/// <inheritdoc />
	public virtual async Task<TModel?> Put(string internalSlug, TModel model)
		=> model;

	/// <inheritdoc />
	public virtual async Task<ISearchResults<TModel>> Search<TFilter>(ISearchRequest<TFilter> request)
		where TFilter : class, IFilter, new()
		=> throw new NotImplementedException();
}
