using DynaModel.Models;

namespace DynaModel.Api.Data
{
	public interface IParentRepository : IRepository<Parent>
	{
		Task<Parent> FindByName(string name);

		new Task<Parent?> Add(Parent parent);

		new Task<Parent?> Update(Parent parent);
	}
}