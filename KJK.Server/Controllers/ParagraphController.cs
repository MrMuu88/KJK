using KJK.Data;
using KJK.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace KJK.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParagraphController : BaseController<Paragraph>
    {
        public ParagraphController(IRepository<Paragraph> repo) : base(repo) { }
    }
}