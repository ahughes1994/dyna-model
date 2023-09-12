using DynaModel.Models;

namespace DynaModel.Api.Data
{
	public interface IParentRepository : IRepository<Parent>
	{
		Task<Parent?> FindByName(string name);

		Task Add(Parent parent);

		Task<Parent?> AddInt(string name, string key, int value);

		Task<Parent?> AddFloat(string name, string key, float value);

		Task<Parent?> AddString(string name, string key, string value);

		Task<Parent?> AddBool(string name, string key, bool value);
	}
}