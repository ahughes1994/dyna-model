using DynaModel.Models;

namespace DynaModel.Api.Data
{
	public class PropertyRepository : Repository<Property>, IPropertyRepository
	{
		private readonly DataContext context;
		private readonly IParentRepository parentRepo;

		public PropertyRepository(DataContext context, IParentRepository parentRepo) : base(context)
		{
			this.context = context;
			this.parentRepo = parentRepo;
		}

		public async Task<Property?> FindById(Guid id)
		{
			if (context.IntProperty.Any(x => x.Id == id))
			{
				return await context.IntProperty.FindAsync(id);
			}
			if (context.FloatProperty.Any(x => x.Id == id))
			{
				return await context.FloatProperty.FindAsync(id);
			}
			if (context.StringProperty.Any(x => x.Id == id))
			{
				return await context.StringProperty.FindAsync(id);
			}
			if (context.BoolProperty.Any(x => x.Id == id))
			{
				return await context.BoolProperty.FindAsync(id);
			}

			throw new Exception($"Cannot find any properties with ID: {id}");
		}

		public async Task<Parent?> AddInt(string parentName, string key, int value)
		{
			var p = await parentRepo.FindByName(parentName);
			if (p == null)
			{
				throw new Exception($"Cannot find parent model with name: {parentName}");
			}

			if (p.IntProperties.Any(x => x.Key == key))
			{
				throw new Exception($"An integer property with key \"{key}\" already exists on parent \"{parentName}\"");
			}

			p.IntProperties.Add(new() { Key = key, Value = value });
			p.Updated = DateTime.UtcNow;
			await context.SaveChangesAsync();

			return p;
		}

		public async Task<Parent?> AddFloat(string parentName, string key, float value)
		{
			var p = await parentRepo.FindByName(parentName);
			if (p == null)
			{
				throw new Exception($"Cannot find parent model with name: {parentName}");
			}

			if (p.FloatProperties.Any(x => x.Key == key))
			{
				throw new Exception($"A float property with key \"{key}\" already exists on parent \"{parentName}\"");
			}

			p.FloatProperties.Add(new() { Key = key, Value = value });
			p.Updated = DateTime.UtcNow;
			await context.SaveChangesAsync();

			return p;
		}

		public async Task<Parent?> AddString(string parentName, string key, string value)
		{
			var p = await parentRepo.FindByName(parentName);
			if (p == null)
			{
				throw new Exception($"Cannot find parent model with name: {parentName}");
			}

			if (p.StringProperties.Any(x => x.Key == key))
			{
				throw new Exception($"A string property with key \"{key}\" already exists on parent \"{parentName}\"");
			}

			p.StringProperties.Add(new() { Key = key, Value = value });
			p.Updated = DateTime.UtcNow;
			await context.SaveChangesAsync();

			return p;
		}

		public async Task<Parent?> AddBool(string parentName, string key, bool value)
		{
			var p = await parentRepo.FindByName(parentName);
			if (p == null)
			{
				throw new Exception($"Cannot find parent model with name: {parentName}");
			}

			if (p.BoolProperties.Any(x => x.Key == key))
			{
				throw new Exception($"A boolean property with key \"{key}\" already exists on parent \"{parentName}\"");
			}

			p.BoolProperties.Add(new() { Key = key, Value = value });
			p.Updated = DateTime.UtcNow;
			await context.SaveChangesAsync();

			return p;
		}

		public async Task<Parent?> UpdateInt(string parentName, string key, int value)
		{
			var p = await parentRepo.FindByName(parentName);
			if (p == null)
			{
				throw new Exception($"Cannot find parent model with name: {parentName}");
			}

			if (!p.IntProperties.Any(x => x.Key == key))
			{
				throw new Exception($"An integer property with key \"{key}\" does not exist on parent \"{parentName}\"");
			}

			p.IntProperties.First(x => x.Key == key).Value = value;
			p.IntProperties.First(x => x.Key == key).Updated = DateTime.UtcNow;
			p.Updated = DateTime.UtcNow;
			await context.SaveChangesAsync();

			return p;
		}

		public async Task<Parent?> UpdateFloat(string parentName, string key, float value)
		{
			var p = await parentRepo.FindByName(parentName);
			if (p == null)
			{
				throw new Exception($"Cannot find parent model with name: {parentName}");
			}

			if (!p.FloatProperties.Any(x => x.Key == key))
			{
				throw new Exception($"A float property with key \"{key}\" does not exist on parent \"{parentName}\"");
			}

			p.FloatProperties.First(x => x.Key == key).Value = value;
			p.FloatProperties.First(x => x.Key == key).Updated = DateTime.UtcNow;
			p.Updated = DateTime.UtcNow;
			await context.SaveChangesAsync();

			return p;
		}

		public async Task<Parent?> UpdateString(string parentName, string key, string value)
		{
			var p = await parentRepo.FindByName(parentName);
			if (p == null)
			{
				throw new Exception($"Cannot find parent model with name: {parentName}");
			}

			if (!p.StringProperties.Any(x => x.Key == key))
			{
				throw new Exception($"A string property with key \"{key}\" does not exist on parent \"{parentName}\"");
			}

			p.StringProperties.First(x => x.Key == key).Value = value;
			p.StringProperties.First(x => x.Key == key).Updated = DateTime.UtcNow;
			p.Updated = DateTime.UtcNow;
			await context.SaveChangesAsync();

			return p;
		}

		public async Task<Parent?> UpdateBool(string parentName, string key, bool value)
		{
			var p = await parentRepo.FindByName(parentName);
			if (p == null)
			{
				throw new Exception($"Cannot find parent model with name: {parentName}");
			}

			if (!p.BoolProperties.Any(x => x.Key == key))
			{
				throw new Exception($"A boolean property with key \"{key}\" does not exist on parent \"{parentName}\"");
			}

			p.BoolProperties.First(x => x.Key == key).Value = value;
			p.BoolProperties.First(x => x.Key == key).Updated = DateTime.UtcNow;
			p.Updated = DateTime.UtcNow;
			await context.SaveChangesAsync();

			return p;
		}

		public async Task<Parent?> DeleteInt(string parentName, string key)
		{
			var p = await parentRepo.FindByName(parentName);
			if (p == null)
			{
				throw new Exception($"Cannot find parent model with name: {parentName}");
			}

			if (!p.IntProperties.Any(x => x.Key == key))
			{
				throw new Exception($"An integer property with key \"{key}\" does not exist on parent \"{parentName}\"");
			}

			await Delete(p.IntProperties.First(x => x.Key == key));
			p.Updated = DateTime.UtcNow;
			await context.SaveChangesAsync();

			return p;
		}

		public async Task<Parent?> DeleteFloat(string parentName, string key)
		{
			var p = await parentRepo.FindByName(parentName);
			if (p == null)
			{
				throw new Exception($"Cannot find parent model with name: {parentName}");
			}

			if (!p.FloatProperties.Any(x => x.Key == key))
			{
				throw new Exception($"A float property with key \"{key}\" does not exist on parent \"{parentName}\"");
			}

			await Delete(p.FloatProperties.First(x => x.Key == key));
			p.Updated = DateTime.UtcNow;
			await context.SaveChangesAsync();

			return p;
		}

		public async Task<Parent?> DeleteString(string parentName, string key)
		{
			var p = await parentRepo.FindByName(parentName);
			if (p == null)
			{
				throw new Exception($"Cannot find parent model with name: {parentName}");
			}

			if (!p.StringProperties.Any(x => x.Key == key))
			{
				throw new Exception($"A string property with key \"{key}\" does not exist on parent \"{parentName}\"");
			}

			await Delete(p.StringProperties.First(x => x.Key == key));
			p.Updated = DateTime.UtcNow;
			await context.SaveChangesAsync();

			return p;
		}

		public async Task<Parent?> DeleteBool(string parentName, string key)
		{
			var p = await parentRepo.FindByName(parentName);
			if (p == null)
			{
				throw new Exception($"Cannot find parent model with name: {parentName}");
			}

			if (!p.BoolProperties.Any(x => x.Key == key))
			{
				throw new Exception($"A boolean property with key \"{key}\" does not exist on parent \"{parentName}\"");
			}

			await Delete(p.BoolProperties.First(x => x.Key == key));
			p.Updated = DateTime.UtcNow;
			await context.SaveChangesAsync();

			return p;
		}
	}
}
