using KJK.Data;
using KJK.Data.Models;
using KJK.Server.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KJK.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ItemController : BaseCRUDController<Item>
	{
		public ItemController(KJKDbContext dbcontext) : base(dbcontext) {
			VMType = typeof(ItemViewModel);
		}
	}
}