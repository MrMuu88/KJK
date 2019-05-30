using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace KJK.Data {

	public class AdventureDataService :IDataService{

		#region Methods, Tasks, commands ##############################################################
		private DbContext DB;
		#endregion

		#region Methods, Tasks, commands ##############################################################

		public void Add<T>(T item) where T:class {
				DB.Add(item);
				DB.SaveChanges();
		}

		public T GetByID<T>(int ID) where T: class {
				return DB.Set<T>().Find(ID);
		}
		
		public IQueryable<T> Query<T>() where T:class {
				return DB.Set<T>();
		}

		public void Remove<T>(T item) where T : class {
				DB.Remove(item);
				DB.SaveChanges();
		}
			

		public void Update<T>(T item) where T : class {
				DB.Update(item);
				DB.SaveChanges();
		}

		#endregion

		
		#region Ctors #################################################################################

		public AdventureDataService() {
			//TODO maybe it's should be injected?
			DB = new KJKDBContext();
		}


		#endregion
	}//clss

}//ns
