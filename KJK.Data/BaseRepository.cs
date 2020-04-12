using KJK.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KJK.Data {

	public class BaseRepository<T> :IRepository<T> where T:BaseModel{
		internal KJKDbContext DbContext { get; set; }

		public async Task Create(T item) => await DbContext.Set<T>().AddAsync(item);
		public async Task<ICollection<T>> GetAll() => await DbContext.Set<T>().ToListAsync();
		public async Task<ICollection<T>> GetAllIncluding(params Expression<Func<T, object>>[] includes) {
			IQueryable<T> query = DbContext.Set<T>();
			query = ApplyIncludes(query, includes);
			return await query.ToListAsync();
		}
		public async Task<T> GetById(int Id) => await DbContext.Set<T>().Where(bm => bm.Id == Id).FirstOrDefaultAsync();
		public async Task<T> GetByIdIncluding(int Id, params Expression<Func<T, object>>[] includes) {
			IQueryable<T> query = DbContext.Set<T>().Where(bm => bm.Id == Id);
			query = ApplyIncludes(query, includes);
			return await query.FirstOrDefaultAsync();
		}
		public async Task<ICollection<T>> Find(Expression<Func<T, bool>> predicate) => await DbContext.Set<T>().Where(predicate).ToListAsync();
		public async Task<ICollection<T>> FindIncluding(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
		{
			IQueryable<T> query = DbContext.Set<T>();
			query = ApplyIncludes(query,includes);
			return await query.Where(predicate).ToListAsync();
		}
		public void Update(T item) => DbContext.Set<T>().Update(item);
		public void Remove(T item) => DbContext.Set<T>().Remove(item);

		public async Task Commit() => await DbContext.SaveChangesAsync();
		public void RollbackChanges() {
			var changed = DbContext.ChangeTracker.Entries<T>().Where(x => x.State != EntityState.Unchanged).ToList();
			foreach (var entry in changed)
			{
				switch (entry.State)
				{
					case EntityState.Modified:
						entry.CurrentValues.SetValues(entry.OriginalValues);
						entry.State = EntityState.Unchanged;
						break;
					case EntityState.Added:
						entry.State = EntityState.Detached;
						break;
					case EntityState.Deleted:
						entry.State = EntityState.Unchanged;
						break;
				}
			}
		}

		protected virtual IQueryable<T> ApplyIncludes(IQueryable<T> query, IEnumerable<Expression<Func<T, object>>> includes) {
			if (includes != null || includes?.Count() > 0)
			{
				foreach (var expression in includes)
				{
					query = query.Include(expression);
				}
			}
			return query;
		}

		public BaseRepository(KJKDbContext dbContext) {
			DbContext = dbContext;
		}
	}//clss

}//ns
