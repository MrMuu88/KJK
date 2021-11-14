using System.Linq;
using System.Threading.Tasks;
using KJK.Data;
using KJK.Data.Models;
using KJK.Server.Models;
using KJK.Server.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KJK.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		public KJKDbContext DbContext { get; internal set; }

		public UserController(KJKDbContext dbcontext)
		{
			DbContext = dbcontext;
		}


		[HttpPost("Register")]
		public async Task<ActionResult> Register([FromBody]UserViewModel userModel)
		{
			//Check if Email or NickName is used for another user
			var foundUsers = await DbContext.Users.Where(u => u.Email == userModel.Email || u.NickName == userModel.NickName).ToListAsync();
			if (foundUsers.Count > 0) {
				var response = new {
					EmailTaken = foundUsers.Any(u => u.Email == userModel.Email),
					NickNameTaken = foundUsers.Any(u => u.NickName == userModel.NickName)
				};
				
				return BadRequest(response);
			}

			//hash Password
			var passwordHasher = new PasswordHasher<User>();
			var user = userModel.Model as User;
			var hashedPassword = passwordHasher.HashPassword(user, userModel.Password);
			user.Password = hashedPassword;

			//TODO Save User to DB
			await DbContext.AddAsync(user);
			await DbContext.SaveChangesAsync();
			return StatusCode(StatusCodes.Status201Created);
		}


		[HttpPost("Login")]
		public async Task<ActionResult> Login([FromBody]LoginModel loginModel)
		{
			var foundUsers = await DbContext.Users.Where(u => u.Email == loginModel.LoginName || u.NickName == loginModel.LoginName).ToListAsync();
			if (foundUsers.Count > 1)
				return StatusCode(StatusCodes.Status500InternalServerError);
			if (foundUsers.Count == 0)
				return BadRequest("No such user");

			var user = foundUsers.First();
			var passwordHasher = new PasswordHasher<User>();
			var result = passwordHasher.VerifyHashedPassword(user, user.Password, loginModel.Password);
			switch (result)
			{
				case PasswordVerificationResult.Failed:
					return BadRequest("Wrong Password");

				case PasswordVerificationResult.Success:
					//Authenticated
					return Ok(new { message = "succesfully logged in " });

				case PasswordVerificationResult.SuccessRehashNeeded:
					var newHash = passwordHasher.HashPassword(user, loginModel.Password);
					user.Password = newHash;
					DbContext.Update(user);
					await DbContext.SaveChangesAsync();
					return Ok(new { message="succesfully logged in "});

				default:
					return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

	}
}