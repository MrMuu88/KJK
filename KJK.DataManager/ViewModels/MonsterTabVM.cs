using System.Collections.ObjectModel;
using KJK.Data;
using KJK.Model;
using System.Linq;
using KJK.DataManager.ViewModels.ModelWrappers;
using System.Windows.Input;
using Prism.Commands;
using System.Diagnostics;

namespace KJK.DataManager.ViewModels {

	public class MonsterTabVM : ViewModelBase {

		#region Fields,Properties,Events ##############################################################

		private IDataService dataService = new AdventureDataService();



		private MonsterWrapper selected;
		private ObservableCollection<MonsterWrapper> items;

		public MonsterWrapper Selected {
			get => selected;
			set {
				selected = value;
				RaisePropertyChanged();
			}
		}

		public ObservableCollection<MonsterWrapper> Items {
			get => items;
			set {
				items = value;
				RaisePropertyChanged();
			}
		}

		public ICommand cmdAdd { get; private set; }
		public ICommand cmdRemove { get; private set; }
		public ICommand cmdSave { get; private set; }

		#endregion

		#region Methods, Tasks, commands ##############################################################

		public void Load() {
			Items = new ObservableCollection<MonsterWrapper>(
				dataService.Query<Monster>()
						   .Select(m => new MonsterWrapper(m))
						   .ToList()
			);
		}

		private void Add() {
			Debug.WriteLine("adding a new item to the collection");
			Items.Add(new MonsterWrapper(new Monster()));
		}

		private void Remove(MonsterWrapper monster) {
			Debug.WriteLine($"Removing {monster.DisplayMember}");
			monster.ShouldRemove = true;
		}

		private void Save() {
			Debug.WriteLine("Saving modifications to the repo");
			foreach (var item in Items) {
				if (item.ShouldRemove) {
					dataService.Remove(item.Model);
				} else {
					item.Presist();
					dataService.Update(item.Model);
				}
			}
			Load();
		}
		#endregion

		#region Ctors #################################################################################

		public MonsterTabVM() {
			Load();

			cmdAdd = new DelegateCommand(Add);
			cmdRemove = new DelegateCommand<MonsterWrapper>(Remove);
			cmdSave = new DelegateCommand(Save);
		}

		#endregion
	}//clss

}//ns
