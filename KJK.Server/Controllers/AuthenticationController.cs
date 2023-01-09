using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KJK.Data;
using KJK.Data.Models;
using KJK.Server.Configurations;
using KJK.Server.Models;
using KJK.Server.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace KJK.Server.Controllers
{

    //based on https://www.infoworld.com/article/3669188/how-to-implement-jwt-authentication-in-aspnet-core-6.html

    [AllowAnonymous]
    [Route("api/[controller]")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		public KJKDbContext DbContext { get; private set; }
		public IMapper Mapper { get; }
		public JwtConfiguration JwtConfiguration { get; private set; }

		public AuthenticationController(KJKDbContext dbcontext, IOptions<JwtConfiguration> config,IMapper mapper)
		{
			DbContext = dbcontext;
			Mapper = mapper;
			JwtConfiguration = config.Value ?? new JwtConfiguration();
		}


		[HttpPost("Register")]
		public async Task<ActionResult> Register([FromBody]UserViewModel vm)
		{
			//Check if Email or NickName is used for another user
			var foundUsers = await DbContext.Users.Where(u => u.Email == vm.Email || u.NickName == vm.NickName).ToListAsync();
			if (foundUsers.Count > 0) {
				var response = new {
					EmailTaken = foundUsers.Any(u => u.Email == vm.Email),
					NickNameTaken = foundUsers.Any(u => u.NickName == vm.NickName)
				};
				
				return BadRequest(response);
			}

			//hash Password
			var passwordHasher = new PasswordHasher<User>();
			var user = Mapper.Map<User>(vm);
			var hashedPassword = passwordHasher.HashPassword(user, vm.Password);
			user.Password = hashedPassword;

			//TODO Save User to DB
			await DbContext.AddAsync(user);
			await DbContext.SaveChangesAsync();
			return StatusCode(StatusCodes.Status201Created);
		}

		[HttpPost("Login")]
		public async Task<ActionResult<string>> Login([FromBody]LoginModel loginModel)
		{
			var foundUsers = await DbContext.Users
				.Where(u => u.Email == loginModel.LoginName || u.NickName == loginModel.LoginName)
				.ToListAsync();

			if (foundUsers.Count > 1)
				return StatusCode(StatusCodes.Status500InternalServerError);
			if (foundUsers.Count == 0)
				return Unauthorized("No such user or wrong Password");

			var user = foundUsers.First();
			var passwordHasher = new PasswordHasher<User>();
			var result = passwordHasher.VerifyHashedPassword(user, user.Password, loginModel.Password);

			if(result == PasswordVerificationResult.Failed)
				return Unauthorized("No such user or wrong Password");


            if (result == PasswordVerificationResult.SuccessRehashNeeded) { 
				var newHash = passwordHasher.HashPassword(user, loginModel.Password);
				user.Password = newHash;
				DbContext.Update(user);
				await DbContext.SaveChangesAsync();
			}

			var securityDescriptor = GetDescriptor(loginModel);
            var tokenHandler = new JwtSecurityTokenHandler();
			var token = tokenHandler.CreateToken(securityDescriptor);
			return Ok(tokenHandler.WriteToken(token));

		}

		private SecurityTokenDescriptor GetDescriptor(LoginModel login) {
			
			var claims = new[] {
				new Claim("Id",$"{Guid.NewGuid()}"),
				new Claim(JwtRegisteredClaimNames.Sub,login.LoginName),
				new Claim(JwtRegisteredClaimNames.Jti,$"{Guid.NewGuid()}")
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConfiguration.Key));

			return new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.Now.AddMinutes(JwtConfiguration.TokenLifeTime),
				Issuer = JwtConfiguration.Issuer,
				Audience = JwtConfiguration.Audience,
				SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature),
			};
		}
			
	}
}