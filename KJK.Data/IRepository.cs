using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KJK.Data
{
	public interface IRepository<T> where T: class{
		Task Create(T item);
		Task<ICollection<T>> GetAll();
		Task<ICollection<T>> GetAllIncluding(params Expression<Func<T,object>>[] includes);
		Task<T> GetById(int Id);
		Task<T> GetByIdIncluding(int Id, params Expression<Func<T, object>>[] includes);
		Task<ICollection<T>> Find(Expression<Func<T, bool>> predicate);
		Task<ICollection<T>> FindIncluding(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
		void Update(T item);
		void Remove(T item);
		Task Commit();
		void RollbackChanges();

	}
}
