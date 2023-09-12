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
		public async Task<Parent?> Get(string name)
		{
			return await parentRepo.FindByName(name);
		}

		[HttpPost]
		public async Task Post(Parent entity)
		{
			await parentRepo.Add(entity);
		}
	}
}
