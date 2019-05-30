using KJK.DataManager.Helpers;
using System.Collections.ObjectModel;
using KJK.Data;
using KJK.Model;
using System.Linq;
using KJK.DataManager.ViewModels.ModelWrappers;

namespace KJK.DataManager.ViewModels {

	public class MonsterTabVM : ViewModelBase {

		#region Fields,Properties,Events ##############################################################

		private IDataService dataService = new AdventureDataService();

		public MonsterWrapper ModelVM {
			get => modelVM;
			set {
				modelVM = value;
				RaisePropertyChanged();
			}
		}

		public ObservableCollection<LookupItem> Items { get; set; }

		private LookupItem selected;
		private MonsterWrapper modelVM;

		public LookupItem Selected {
			get => selected;
			set {
				selected = value;
				ModelVM = new MonsterWrapper(dataService.GetByID<Monster>(selected.ID));
				RaisePropertyChanged();
			}
		}


		#endregion

		#region Methods, Tasks, commands ##############################################################

		public void Load() {
			Items = new ObservableCollection<LookupItem>(
				dataService.Query<Monster>()
						   .Select(m => new LookupItem(m.ID, $"{m.ID} {m.Name}"))
						   .ToList()
			);
		}

		#endregion

		#region Ctors #################################################################################

		public MonsterTabVM() {
			Load();
		}

		#endregion
	}//clss

}//ns
