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

		public new async Task<Parent?> Add(Parent parent)
		{
			if (context.Parents.Any(x => x.Name == parent.Name))
			{
				throw new Exception($"Parent model with name \"{parent.Name}\" already exists");
			}

			return await base.Add(parent);
		}

		public new async Task<Parent?> Update(Parent parent)
		{
			if (context.Parents.Any(x => x.Name == parent.Name))
			{
				throw new Exception($"Parent model with name \"{parent.Name}\" already exists");
			}

			return await base.Update(parent);
		}

		public async Task<Parent> FindByName(string name)
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
	}
}
