using DynaModel.Api.Data;
using DynaModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace DynaModel.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ParentController : ControllerBase
	{
		private readonly IParentRepository parentRepo;

		public ParentController(IParentRepository parentRepo)
        {
			this.parentRepo = parentRepo;
		}

		[HttpGet]
		public async Task<Parent?> Get(string parentName)
		{
			return await parentRepo.FindByName(parentName);
		}

		[HttpPost]
		public async Task<Parent?> Post(Parent entity)
		{
			return await parentRepo.Add(entity);
		}

		[HttpPatch]
		public async Task<Parent?> Patch(Parent entity)
		{
			return await parentRepo.Update(entity);
		}

		[HttpDelete]
		public async Task Delete(Parent entity)
		{
			await parentRepo.Delete(entity);
		}
	}
}
