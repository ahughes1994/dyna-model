using DynaModel.Models;
using Microsoft.EntityFrameworkCore;

namespace DynaModel.Api.Data
{
	public class ParentRepository : Repository<Parent>, IParentRepository
	{
		private readonly DataContext context;

		public ParentRepository(DataContext context) : base(context)
		{
			this.context = context;
		}

		public new async Task Add (Parent parent)
		{
			if (context.Parents.Any(x => x.Name == parent.Name))
			{
				return;
			}

			await base.Add (parent);
		}

		public async Task<Parent?> FindByName(string name)
		{
			var p = await context.Parents
				.Where(x => x.Name == name)
				.Include(x => x.StringProperties)
				.Include(x => x.FloatProperties)
				.Include(x => x.IntProperties)
				.Include(x => x.BoolProperties)
				.FirstOrDefaultAsync();

			if (p == null)
			{
				throw new Exception($"Cannot find parent model with name: {name}");
			}

			return p;
		}

		public async Task<Parent?> AddInt(string name, string key, int value)
		{
			var p = await FindByName(name);
			if (p == null)
			{
				throw new Exception($"Cannot find parent model with name: {name}");
			}

			if (p.IntProperties.Any(x => x.Key == key))
			{
				throw new Exception($"An integer property with key \"{key}\" already exists on parent \"{name}\"");
			}

			p.IntProperties.Add(new() { Key = key, Value = value });
			await context.SaveChangesAsync();

			return p;
		}

		public async Task<Parent?> AddFloat(string name, string key, float value)
		{
			var p = await FindByName(name);
			if (p == null)
			{
				throw new Exception($"Cannot find parent model with name: {name}");
			}

			if (p.FloatProperties.Any(x => x.Key == key))
			{
				throw new Exception($"A float property with key \"{key}\" already exists on parent \"{name}\"");
			}

			p.FloatProperties.Add(new() { Key = key, Value = value });
			await context.SaveChangesAsync();

			return p;
		}

		public async Task<Parent?> AddString(string name, string key, string value)
		{
			var p = await FindByName(name);
			if (p == null)
			{
				throw new Exception($"Cannot find parent model with name: {name}");
			}

			if (p.StringProperties.Any(x => x.Key == key))
			{
				throw new Exception($"A string property with key \"{key}\" already exists on parent \"{name}\"");
			}

			p.StringProperties.Add(new() { Key = key, Value = value });
			await context.SaveChangesAsync();

			return p;
		}

		public async Task<Parent?> AddBool(string name, string key, bool value)
		{
			var p = await FindByName(name);
			if (p == null) 
			{ 
				throw new Exception ($"Cannot find parent model with name: {name}"); 
			}

			if (p.BoolProperties.Any(x => x.Key == key)) 
			{ 
				throw new Exception ($"A boolean property with key \"{key}\" already exists on parent \"{name}\""); 
			}

			p.BoolProperties.Add(new() { Key = key, Value = value });
			await context.SaveChangesAsync();

			return p;
		}
	}
}
