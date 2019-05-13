using KJK.App.Helpers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KJK.App.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdventurePage : MasterDetailPage {
        public AdventurePage() {
            InitializeComponent();

            MasterView.lstNavigation.ItemSelected += LstNavigation_ItemSelected;
        }

        private void LstNavigation_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
            if (e.SelectedItem is MasterDetailNavigationItem item) {
                Detail = (Page)Activator.CreateInstance(item.TargetType);
                MasterView.lstNavigation.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}