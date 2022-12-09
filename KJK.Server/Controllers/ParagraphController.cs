using KJK.Data;
using KJK.Data.Models;
using KJK.Server.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KJK.Server.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class ParagraphController : BaseCRUDController<Paragraph>
	{
		public ParagraphController(KJKDbContext dbcontext) : base(dbcontext) {
			VMType = typeof(ParagraphViewModel);
		}
	}
}