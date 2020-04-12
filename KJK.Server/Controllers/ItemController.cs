using KJK.Data;
using KJK.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace KJK.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ItemController : BaseController<Item>
	{
		public ItemController(IRepository<Item> repo) : base(repo) { }
	}
}