using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers{

	[ApiController]
	[Route("~/api/platforms/")]
	public class PlatformsController : ControllerBase
	{
		private readonly IPlatformRepo repo;
		private readonly IMapper mapper;

		public PlatformsController(IPlatformRepo repo, IMapper mapper)
		{
			this.repo = repo;
			this.mapper = mapper;
		}

		[HttpGet("")]
		public ActionResult<IEnumerable<PlatformReadDto>> Index(){
			var data = repo.GetAllPlatforms();
			var viewModel = mapper.Map<IEnumerable<PlatformReadDto>>(data);
			return Ok(viewModel);
		}

		[HttpGet("{id}/")]
		public ActionResult<PlatformReadDto> GetOneById(int id){
			var data = repo.GetPlatformById(id);
			var viewModel = mapper.Map<PlatformReadDto>(data);
			return Ok(viewModel);
		}

		[HttpPost("")]
		public ActionResult<PlatformReadDto> Create(PlatformCreateDto viewModel){
			var platform = mapper.Map<PlatformModel>(viewModel);
			repo.CreatePlatform(platform);
			//var viewModel = mapper.Map<PlatformReadDto>(data);
			return Ok(mapper.Map<PlatformReadDto>(viewModel));
		}

		[HttpPut("{id}/")]
		public ActionResult<PlatformReadDto> Update(PlatformCreateDto viewModel){
			var platform = mapper.Map<PlatformModel>(viewModel);
			repo.CreatePlatform(platform);
			//var viewModel = mapper.Map<PlatformReadDto>(data);
			return Ok(mapper.Map<PlatformReadDto>(viewModel));
		}
	}
}