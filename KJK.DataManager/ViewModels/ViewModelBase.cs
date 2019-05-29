using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace KJK.DataManager.ViewModels {
	public class ViewModelBase:INotifyPropertyChanged {
		public event PropertyChangedEventHandler PropertyChanged;

		protected void RaisePropertyChanged([CallerMemberName] string PropertyName = null) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
		}

	}
}