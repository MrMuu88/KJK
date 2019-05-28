using System.Collections.Generic;
using System.Linq;

namespace KJK.Data {
	public interface IDataService {
		//Create
		void Add<T>(T item) where T : class;
		
		//Read
		IQueryable<T> Query<T> () where T : class;
		T GetByID<T>(int ID) where T : class;
		
		//Update
		void Update<T>(T item) where T : class;

		//Delete
		void Remove<T>(T item) where T : class;

	}
}
