using System.Windows.Controls;
using System.Windows.Input;

namespace KJK.DataManager.Views {
	/// <summary>
	/// Interaction logic for MonsterTab.xaml
	/// </summary>
	public partial class MonsterTab : UserControl {
		public MonsterTab() {
			InitializeComponent();
		}

		private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e) {
			e.Handled=((TextBox)sender).Text.Length >=2 || !int.TryParse(e.Text, out var val);
		}
	}
}
