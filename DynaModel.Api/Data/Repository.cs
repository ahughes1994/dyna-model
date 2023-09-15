using DynaModel.Models;

namespace DynaModel.Api.Data
{
	public class Repository<T> : IRepository<T> where T : Entity
	{
		private readonly DataContext context;

		public Repository(DataContext context)
		{
			this.context = context;
		}

		public async Task<T?> Add (T entity)
		{
			await context.AddAsync(entity);
			await context.SaveChangesAsync();
			return entity;
		}

		public async Task Delete(T entity)
		{
			context.Remove(entity);
			await context.SaveChangesAsync();
		}

		public async Task<T?> Find (object id)
		{
			return await context.FindAsync<T>(id);			 
		}

		public async Task<T?> Update (T entity)
		{
			entity.Updated = DateTime.UtcNow;
			context.Update(entity);
			await context.SaveChangesAsync();
			return entity;
		}
	}
}
