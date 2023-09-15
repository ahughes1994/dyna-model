using DynaModel.Models;

namespace DynaModel.Api.Data
{
	public interface IPropertyRepository : IRepository<Property>
	{
		Task<Property> FindById(Guid id);
		Task<Parent?> AddBool(string parentName, string key, bool value);
		Task<Parent?> AddFloat(string parentName, string key, float value);
		Task<Parent?> AddInt(string parentName, string key, int value);
		Task<Parent?> AddString(string parentName, string key, string value);
		Task<Parent?> DeleteBool(string parentName, string key);
		Task<Parent?> DeleteFloat(string parentName, string key);
		Task<Parent?> DeleteInt(string parentName, string key);
		Task<Parent?> DeleteString(string parentName, string key);
		Task<Parent?> UpdateBool(string parentName, string key, bool value);
		Task<Parent?> UpdateFloat(string parentName, string key, float value);
		Task<Parent?> UpdateInt(string parentName, string key, int value);
		Task<Parent?> UpdateString(string parentName, string key, string value);
	}
}