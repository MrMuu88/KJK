using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KJK.Data;
using KJK.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KJK.Server.Controllers
{
	public abstract class BaseController<T> : ControllerBase where T:BaseModel
	{
		internal IRepository<T> Repo { get; set; }

		[HttpGet]
		public virtual async Task<ActionResult<IEnumerable<T>>> GetAll()
		{
			try
			{
				var items = await Repo.GetAll();
				return Ok(items);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError,ex);
			}
		}
		
		[HttpGet("{Id}")]
		public virtual async Task<ActionResult<T>> GetById(int id)
		{
			try
			{
				var item = await Repo.GetById(id);
				if (item != null)
					return Ok(item);
				else
					return NotFound();
				
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError,ex);
			}
		}


		[HttpPost]
		public virtual async Task<ActionResult<T>> Post([FromBody]T model)
		{
			try
			{
				await Repo.Create(model);
				await Repo.Commit();
				return Created(model.Id.ToString(),model);
			}
			catch (Exception ex)
			{
				Repo.RollbackChanges();
				return StatusCode(StatusCodes.Status500InternalServerError,ex);
			}
		}
		
		[HttpPut]
		public virtual async Task<ActionResult<T>> Put([FromBody]T model)
		{
			try
			{
				await Repo.Create(model);
				await Repo.Commit();
				return Ok(model);
			}
			catch (Exception ex)
			{
				Repo.RollbackChanges();
				return StatusCode(StatusCodes.Status500InternalServerError,ex);
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
				return StatusCode(StatusCodes.Status500InternalServerError,ex);
			}
		}

		public BaseController(IRepository<T> repo)
		{
			Repo = repo;
		}
	}
}
