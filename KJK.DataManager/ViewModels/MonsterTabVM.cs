using KJK.DataManager.Helpers;
using System.Collections.ObjectModel;
using KJK.Data;

namespace KJK.DataManager.ViewModels {

	public class MonsterTabVM:ViewModelBase {

		#region Fields,Properties,Events ##############################################################

		private IDataService dataService;

		public ObservableCollection<LookupItem> Items { get; set; }


		#endregion

		#region Methods, Tasks, commands ##############################################################

		public void Load() {

		}

		#endregion

		#region Ctors #################################################################################

		public MonsterTabVM() { }

		#endregion
	}//clss

}//ns
