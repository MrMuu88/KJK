using AutoMapper;
using KJK.Data;
using KJK.Data.Models;
using KJK.Server.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KJK.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	public class MonsterController : BaseController<MonsterViewModel,Monster>
	{
		public MonsterController(KJKDbContext dbcontext,IMapper mapper) :base(dbcontext,mapper) {
		}
	}
}