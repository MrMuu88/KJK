using System;
using System.Linq;
using System.Threading.Tasks;
using KJK.Data;
using KJK.Data.Models;
using KJK.Server.Models;
using KJK.Server.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KJK.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		public IRepository<User> Repository { get; internal set; }

		public UserController(IRepository<User> repo)
		{
			Repository = repo;
		}


		[HttpPost("Register")]
		public async Task<ActionResult> Register([FromBody]UserViewModel userModel)
		{
			try
			{
				//Check if Email or NickName is used for another user
				var foundUsers = await Repository.Find(u => u.Email == userModel.Email || u.NickName == userModel.NickName);
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
				await Repository.Create(user);
				await Repository.Commit();
				return StatusCode(StatusCodes.Status201Created);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}


		[HttpPost("Login")]
		public async Task<ActionResult> Login([FromBody]LoginModel loginModel)
		{
			try
			{
				var foundUsers = await Repository.Find(u => u.Email == loginModel.LoginName || u.NickName == loginModel.LoginName);
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
						Repository.Update(user);
						await Repository.Commit();
						return Ok(new { message="succesfully logged in "});

					default:
						return StatusCode(StatusCodes.Status500InternalServerError);
				}
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

	}
}