using BlazingApple.Components.Shared.Interfaces.Search;
using BlazingApple.Components.Shared.Models.Search;
using BlazingApple.Forums.Shared.Models.Base;

namespace BlazingApple.Forums.Shared.Services.Base;

/// <summary>Fakes the various services</summary>
/// <typeparam name="TModel">Model to operate on.</typeparam>
internal abstract class FakeCrudServiceBase<TModel> : ICrudService<TModel>
	where TModel : class, IForumRecord
{
	protected IDictionary<Guid, TModel> EntitiesById { get; set; } = new Dictionary<Guid, TModel>();
	protected IDictionary<string, TModel> EntitiesBySlug { get; set; } = new Dictionary<string, TModel>();

	protected void AddBySlug(string slug, TModel model)
	{
		if(EntitiesBySlug.ContainsKey(slug))
			return;
		else
			EntitiesBySlug.Add(slug, model);
	}

	protected TModel TryGetBySlug(string slug, TModel model)
	{
		if(model.Id == Guid.Empty)
			model.Id = Guid.NewGuid();

		AddBySlug(slug, model);
		return EntitiesBySlug[slug];
	}

	protected TModel TryGetById(TModel model)
	{
		AddById(model);
		return EntitiesById[model.Id];
	}

	protected TModel? TryGetById(Guid id)
	{
		if(EntitiesById.ContainsKey(id))
			return EntitiesById[id];
		else
			return null;
	}

	protected TModel? TryGetById(Guid id, TModel model)
	{
		if(EntitiesById.ContainsKey(id))
			return EntitiesById[id];

		model.Id = id;
		AddById(model);

		return model;
	}

	protected void AddById(TModel model)
	{
		if(EntitiesById.ContainsKey(model.Id))
			return;
		else
			EntitiesById.Add(model.Id, model);
	}

	/// <inheritdoc />
	public virtual async Task<bool> Delete(string slug)
	{
		if(EntitiesBySlug.TryGetValue(slug, out TModel? entity))
		{
			if(EntitiesById.ContainsKey(entity.Id))
				EntitiesById.Remove(entity.Id);

			EntitiesBySlug.Remove(slug);
		}

		return true;
	}

	/// <inheritdoc />
	public virtual async Task<bool> Delete(Guid id)
	{
		if(EntitiesById.TryGetValue(id, out TModel? entity))
		{
			if(EntitiesById.ContainsKey(entity.Id))
				EntitiesById.Remove(entity.Id);
		}

		return true;
	}

	/// <inheritdoc />
	public virtual async Task<TModel> Get(string slug)
	{
		if(EntitiesBySlug.ContainsKey(slug))
			return EntitiesBySlug[slug];
		else
			return null!; // hack
	}

	/// <inheritdoc />
	public virtual async Task<List<TModel>> GetList()
		=> EntitiesById.Values.ToList();

	/// <inheritdoc />
	public virtual async Task<TModel?> Post(TModel model)
	{
		if(model.Id == Guid.Empty)
			model.Id = Guid.NewGuid();

		if(!EntitiesById.ContainsKey(model.Id))
			EntitiesById.Add(model.Id, model);

		return model;
	}

	/// <inheritdoc />
	public virtual async Task<TModel?> Put(string slug, TModel model)
	{
		if(model.Id == Guid.Empty)
			model.Id = Guid.NewGuid();

		if(!EntitiesById.ContainsKey(model.Id))
			EntitiesById.Add(model.Id, model);

		if(!EntitiesBySlug.ContainsKey(slug))
			EntitiesBySlug.Add(slug, model);

		return model;
	}

	/// <inheritdoc />
	public virtual async Task<ISearchResults<TModel>> Search<TFilter>(ISearchRequest<TFilter> request)
		where TFilter : class, IFilter, new()
		=> throw new NotImplementedException();
}
