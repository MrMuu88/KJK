using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KJK.Data;
using KJK.Data.Models;
using KJK.Server.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KJK.Server.Controllers
{
	public abstract class BaseController<T> : ControllerBase where T:BaseModel
	{
		protected Type VMType { get; set; }
		public KJKDbContext DbContext { get; private set; }

		public BaseController(KJKDbContext dbcontext)
		{
			DbContext = dbcontext;
		}

		/// <summary>
		/// get a list of all entries from the database 
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public virtual async Task<ActionResult<IEnumerable<T>>> GetAll()
		{
			try
			{

				var items = await DbContext.Set<T>().ToListAsync();
				return Ok(
					items.Select(i => Activator.CreateInstance(VMType, i))
					.ToList()
				);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { Error = ex.GetType().Name, Message = ex.Message });
			}
		}
		
		/// <summary>
		/// get an entry with the provided Id from the DB
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("{Id}")]
		public virtual async Task<ActionResult<T>> GetById(int id)
		{
			try
			{
				var item = await DbContext.Set<T>().Where(i => i.Id == id).FirstOrDefaultAsync();
				if (item != null)
					return Ok(
						Activator.CreateInstance(VMType,item)
					);
				else
					return NotFound();
				
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { Error = ex.GetType().Name, Message = ex.Message });
			}
		}

		/// <summary>
		/// create a new entry in the database
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		public virtual async Task<ActionResult<T>> Post()
		{
			try
			{
				var rawBody = "";
				using (var sreader = new StreamReader(Request.Body, Encoding.UTF8)) {
					rawBody = await sreader.ReadToEndAsync();
				}
				var VM = Newtonsoft.Json.JsonConvert.DeserializeObject(rawBody,VMType) as BaseViewModel<T>;
				await DbContext.AddAsync(VM.Model);
				await DbContext.SaveChangesAsync();
				return Created(VM.Model.Id.ToString(), VM);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { Error = ex.GetType().Name, Message = ex.Message });
			}
		}
		
		/// <summary>
		/// update the entry in the database
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		[HttpPut("{Id}")]
		public virtual async Task<ActionResult<T>> Put(int Id)
		{
			try
			{
				var rawBody = "";
				using (var sreader = new StreamReader(Request.Body, Encoding.UTF8))
				{
					rawBody = await sreader.ReadToEndAsync();
				}

				var VM = Newtonsoft.Json.JsonConvert.DeserializeObject(rawBody,VMType) as BaseViewModel<T>;
				VM.Model.Id = Id; 
				DbContext.Update(VM.Model);
				await DbContext.SaveChangesAsync();
				return Ok(VM);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { Error = ex.GetType().Name, Message = ex.Message });
			}
		}

		/// <summary>
		/// delete the given entry from the Database
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete("{id}")]
		public virtual async Task<ActionResult<T>> Delete(int id)
		{
			try
			{
				var shouldDelete = await DbContext.FindAsync<T>(id);
				DbContext.Remove(shouldDelete);
				await DbContext.SaveChangesAsync();
				return Ok(shouldDelete);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { Error = ex.GetType().Name, Message = ex.Message });
			}
		}

	}
}
