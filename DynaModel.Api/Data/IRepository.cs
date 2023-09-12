using DynaModel.Models;

namespace DynaModel.Api.Data
{
	public interface IRepository<T> where T : Entity
	{
		Task Add (T entity);

		Task Delete (T entity);

		Task<T?> Find (object id);

		Task Update (T entity);
	}
}