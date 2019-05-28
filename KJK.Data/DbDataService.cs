using System.Linq;

namespace KJK.Data {

	public class DbDataService :IDataService{

		#region Methods, Tasks, commands ##############################################################

		public void Add<T>(T item) where T:class {
			using (var DB = new KJKDBContext()) {
				DB.Add(item);
				DB.SaveChanges();
			}
		}

		public T GetByID<T>(int ID) where T: class {
			using (var DB = new KJKDBContext()) {
				return DB.Set<T>().Find(ID);
			}
		}
		
		public IQueryable<T> Query<T>() where T:class {
			using (var DB = new KJKDBContext()) {
				return DB.Set<T>();
			}
		}

		public void Remove<T>(T item) where T : class {
			using (var DB = new KJKDBContext()) {
				DB.Remove(item);
				DB.SaveChanges();
			}
		}
			

		public void Update<T>(T item) where T : class {
			using (var DB = new KJKDBContext()) {
				DB.Update(item);
				DB.SaveChanges();
			}
		}

		#endregion

		
		#region Ctors #################################################################################

		public DbDataService() { }


		#endregion
	}//clss

}//ns
