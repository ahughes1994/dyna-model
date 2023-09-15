using DynaModel.Api.Data;
using DynaModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace DynaModel.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PropertyController : ControllerBase
	{
		private readonly IParentRepository parentRepository;
		private readonly IPropertyRepository propertyRepository;

		public PropertyController(IParentRepository parentRepository, IPropertyRepository propertyRepository)
        {
			this.parentRepository = parentRepository;
			this.propertyRepository = propertyRepository;
		}

		[HttpGet]
		public async Task<IEnumerable<Property>> Get(string parentName, string key)
		{
			var p = await parentRepository.FindByName(parentName);
			if (p == null)
			{
				throw new Exception($"Cannot find parent model with name: {parentName}");
			}

			var props = new List<Property>();

			if (p.IntProperties.Any(x => x.Key == key))
			{
				props.Add(p.IntProperties.First(x => x.Key == key));
			}

			if (p.FloatProperties.Any(x => x.Key == key))
			{
				props.Add(p.FloatProperties.First(x => x.Key == key));
			}

			if (p.StringProperties.Any(x => x.Key == key))
			{
				props.Add(p.StringProperties.First(x => x.Key == key));
			}

			if (p.BoolProperties.Any(x => x.Key == key))
			{
				props.Add(p.BoolProperties.First(x => x.Key == key));
			}

			return props;
		}

		[HttpGet("FindById")]
		public async Task<Property> FindById(Guid id)
		{
			var prop = await propertyRepository.FindById(id);
			if (prop == null)
			{
				throw new Exception($"Cannot find Property with ID: {id}");
			}

			return prop;
		}

		[HttpPost]
		public async Task<Parent?> Post(string parentName, string key, object value)
		{
			if (value == null) { throw new Exception("Value to add cannot be null"); }

			if (bool.TryParse(value.ToString(), out var b))
			{
				return await propertyRepository.AddBool(parentName, key, b);
			}

			if (int.TryParse(value.ToString(), out var i))
			{
				return await propertyRepository.AddInt(parentName, key, i);
			}

			if (float.TryParse(value.ToString(), out var f))
			{
				return await propertyRepository.AddFloat(parentName, key, f);
			}

			return await propertyRepository.AddString(parentName, key, value?.ToString() ?? string.Empty);
		}

		[HttpPatch]
		public async Task<Parent?> Patch(string parentName, string key, object value)
		{
			if (value == null) { throw new Exception("Value to patch cannot be null"); }

			if (bool.TryParse(value.ToString(), out var b))
			{
				return await propertyRepository.UpdateBool(parentName, key, b);
			}

			if (int.TryParse(value.ToString(), out var i))
			{
				return await propertyRepository.UpdateInt(parentName, key, i);
			}

			if (float.TryParse(value.ToString(), out var f))
			{
				return await propertyRepository.UpdateFloat(parentName, key, f);
			}

			return await propertyRepository.UpdateString(parentName, key, value?.ToString() ?? string.Empty);
		}

		[HttpDelete]
		public async Task Delete(string parentName, string key)
		{
			try
			{
				await propertyRepository.DeleteBool(parentName, key);
			}
			catch { }

			try
			{
				await propertyRepository.DeleteInt(parentName, key);
			}
			catch { }

			try
			{
				await propertyRepository.DeleteFloat(parentName, key);
			}
			catch { }

			try
			{
				await propertyRepository.DeleteString(parentName, key);
			}
			catch
			{
				throw new Exception($"No properties found with key \"{key}\" on parent: {parentName}");
			}
		}
    }
}
