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

		public PropertyController(IParentRepository parentRepository)
        {
			this.parentRepository = parentRepository;
		}

		[HttpGet]
		public async Task<Property?> Get(string name, string key)
		{
			var p = await parentRepository.FindByName(name);

			if (p.IntProperties.Any(x => x.Key == key))
			{
				return p.IntProperties.First(x => x.Key == key);
			}

			if (p.FloatProperties.Any(x => x.Key == key))
			{
				return p.FloatProperties.First(x => x.Key == key);
			}

			if (p.StringProperties.Any(x => x.Key == key))
			{
				return p.StringProperties.First(x => x.Key == key);
			}

			if (p.BoolProperties.Any(x => x.Key == key))
			{
				return p.BoolProperties.First(x => x.Key == key);
			}

			return null;
		}

		[HttpPost]
		public async Task<Parent?> Post(string name, string key, object value)
		{
			if (value == null) { throw new Exception("Value to add cannot be null"); }

			if (bool.TryParse(value.ToString(), out var b))
			{
				return await parentRepository.AddBool(name, key, b);
			}

			if (int.TryParse(value.ToString(), out var i))
			{
				return await parentRepository.AddInt(name, key, i);
			}

			if (float.TryParse(value.ToString(), out var f))
			{
				return await parentRepository.AddFloat(name, key, f);
			}

			return await parentRepository.AddString(name, key, value?.ToString() ?? string.Empty);
		}
    }
}
