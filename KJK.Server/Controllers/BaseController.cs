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

namespace KJK.Server.Controllers
{
	public abstract class BaseController<T> : ControllerBase where T:BaseModel
	{
		protected Type VMType { get; set; }

		internal IRepository<T> Repo { get; set; }

		[HttpGet]
		public virtual async Task<ActionResult<IEnumerable<T>>> GetAll()
		{
			try
			{
				
				var items = await Repo.GetAll();
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
		
		[HttpGet("{Id}")]
		public virtual async Task<ActionResult<T>> GetById(int id)
		{
			try
			{
				var item = await Repo.GetById(id);
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
				await Repo.Create(VM.Model);
				await Repo.Commit();
				return Created(VM.Model.Id.ToString(), VM);
			}
			catch (Exception ex)
			{
				Repo.RollbackChanges();
				return StatusCode(StatusCodes.Status500InternalServerError, new { Error = ex.GetType().Name, Message = ex.Message });
			}
		}
		
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
				Repo.Update(VM.Model);
				await Repo.Commit();
				return Ok(VM);
			}
			catch (Exception ex)
			{
				Repo.RollbackChanges();
				return StatusCode(StatusCodes.Status500InternalServerError, new { Error = ex.GetType().Name, Message = ex.Message });
			}
		}

		[HttpDelete("{id}")]
		public virtual async Task<ActionResult<T>> Delete(int id)
		{
			try
			{
				var shouldDelete = await Repo.GetById(id);
				Repo.Remove(shouldDelete);
				await Repo.Commit();
				return Ok(shouldDelete);
			}
			catch (Exception ex)
			{
				Repo.RollbackChanges();
				return StatusCode(StatusCodes.Status500InternalServerError, new { Error = ex.GetType().Name, Message = ex.Message });
			}
		}

		public BaseController(IRepository<T> repo)
		{
			Repo = repo;
		}
	}
}
