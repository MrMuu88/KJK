using AutoMapper;
using KJK.Data;
using KJK.Data.Models;
using KJK.Server.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KJK.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ItemController : BaseController<ItemViewModel,Item>
	{
		public ItemController(KJKDbContext dbcontext,IMapper mapper) : base(dbcontext,mapper) {}
	}
}