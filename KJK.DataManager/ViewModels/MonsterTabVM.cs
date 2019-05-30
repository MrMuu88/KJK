using System.Collections.ObjectModel;
using KJK.Data;
using KJK.Model;
using System.Linq;
using KJK.DataManager.ViewModels.ModelWrappers;
using System.Windows.Input;
using Prism.Commands;
using System.Diagnostics;
using System;
using System.Windows;

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
		public ICommand cmdSaveAll { get; private set; }
		public ICommand cmdResetAll { get; private set; }
		public ICommand cmdSave { get; private set; }
		public ICommand cmdReset { get; private set; }

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
			var result = MessageBox.Show("Removing an item is permanent. are your shure?", "Remove Item", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
			if (result == MessageBoxResult.OK) {
				dataService.Remove(monster.Model);
				Items.Remove(monster);
			}
			
		}

		private void SaveAll() {
			Debug.WriteLine("Saving modifications to the repo");
			foreach(var item in Items) {
				item.Presist();
				dataService.Update(item.Model);
				
			}
		}

		public void ResetAll() {
			Debug.WriteLine("Reseting all modifications");
			foreach (var item in Items) {
				item.Reset();
			}
		}
		private void Reset() {
			Debug.WriteLine("Reseting selected");
			Selected.Reset();
		}

		private void Save() {
			Debug.WriteLine("Saving selected");
				Selected.Presist();
				dataService.Update(Selected.Model);
			
		}
		#endregion

		#region Ctors #################################################################################

		public MonsterTabVM() {
			Load();

			cmdAdd = new DelegateCommand(Add);
			cmdRemove = new DelegateCommand<MonsterWrapper>(Remove);
			cmdSaveAll = new DelegateCommand(SaveAll);
			cmdResetAll = new DelegateCommand(ResetAll);
			cmdSave = new DelegateCommand(Save);
			cmdReset = new DelegateCommand(Reset);
		}


		#endregion
	}//clss

}//ns
