﻿using KJK.Data;
using KJK.Data.Models;
using KJK.Server.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KJK.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MonsterController : BaseController<Monster>
	{
		public MonsterController(IRepository<Monster> repo):base(repo) {
			VMType = typeof(MonsterViewModel);
		}
	}
}