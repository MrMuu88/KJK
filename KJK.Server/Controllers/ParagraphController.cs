using AutoMapper;
using KJK.Data;
using KJK.Data.Models;
using KJK.Server.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KJK.Server.Controllers
{
	
    [Route("api/[controller]")]
    [ApiController]
	public class ParagraphController : BaseController<ParagraphViewModel,Paragraph>
	{
		public ParagraphController(KJKDbContext dbcontext,IMapper mapper) : base(dbcontext,mapper) {}
	}
}