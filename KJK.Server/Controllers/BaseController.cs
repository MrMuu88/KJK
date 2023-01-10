using AutoMapper;
using KJK.Data;
using KJK.Data.Models;
using KJK.Server.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KJK.Server.Controllers
{
    [Authorize]
    public class BaseController<VM,M>:ControllerBase where VM : BaseViewModel, new() where M : BaseModel,new()
    {
        public KJKDbContext DbContext { get; }
        public IMapper Mapper { get; }

        public BaseController(KJKDbContext dbContext,IMapper mapper)
        {
            DbContext = dbContext;
            Mapper = mapper;
        }

        /// <summary>
        /// Creates a new Entity in the database
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<ActionResult<VM>> Create([FromBody] VM vm)
        {
            vm.Id = 0; // ignore the Id in the vm
            M model = Mapper.Map<M>(vm);
            DbContext.Add(model);
            await DbContext.SaveChangesAsync();

            vm = Mapper.Map<VM>(model);
            return Created(vm.Id.ToString(), vm);
        }

        /// <summary>
        /// get the id list of the existing entities
        /// </summary>
        /// <returns>an array of ids</returns>
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<int>>> Read() {
            var ids = await DbContext.Set<M>().Select(m => m.Id).ToListAsync();
            return Ok(ids);
        }

        /// <summary>
        /// returns the entity with the given id
        /// </summary>
        /// <param name="id">entity identifier</param>
        /// <returns>the entity</returns>
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<VM>> Read([FromRoute]int id) {
            M model = await DbContext.Set<M>().FirstOrDefaultAsync(m => m.Id == id);
            
            if(model == null) 
                return NotFound();

            VM vm = Mapper.Map<VM>(model);
            return Ok(vm);
        }

        /// <summary>
        /// return a list of entities within the given id array
        /// </summary>
        /// <param name="ids">the indentifiers of the requested entites</param>
        /// <returns>list of entitites</returns>
        [HttpPost("GetBatch")]
        public virtual async Task<ActionResult<List<VM>>> ReadBatch([FromBody]int[] ids) {
            List<M> models = await DbContext.Set<M>().Where(m=> ids.Contains(m.Id)).ToListAsync();
            List<VM> vms = Mapper.Map<List<VM>>(models);

            return Ok(vms);
        }

        /// <summary>
        /// Updates an  existing new entity
        /// </summary>
        /// <param name="vm">the entity to create</param>
        /// <returns>the created entity</returns>
        [HttpPut("{id}")]
        public virtual async Task<ActionResult<VM>> Update([FromBody] VM vm,[FromQuery]int id) {
            vm.Id = id; // Ignore the Id value in the VM
            M model = await DbContext.Set<M>().FirstOrDefaultAsync(m => m.Id == id);
            if (model == null) return NotFound();
            model = Mapper.Map(vm,model);

            await DbContext.SaveChangesAsync();

            vm = Mapper.Map<VM>(model);
            return Created(vm.Id.ToString(), vm);
        }

        /// <summary>
        /// deletes entity with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public virtual async Task<ActionResult> Delete(int id) {
            var model = new M { Id = id};
            DbContext.Remove(model);
            await DbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
