using System.Windows.Input;
using Xamarin.Forms;
using System.Diagnostics;
using KJK.App.Views;

namespace KJK.App.ViewModels {

    public class MainVM:ViewModelBase {
        #region Fields,Properties,Events ##############################################################
        
        public ICommand cmdNewAdventure { get; private set; }
        public ICommand cmdContinue { get; private set; }
        public ICommand cmdSettings { get; private set; }
        
        #endregion

        #region Methods, Tasks, commands ##############################################################

        private void NavToSettings(object obj) {
            Debug.WriteLine("navigating to settings page");
             Application.Current.MainPage.Navigation.PushAsync(new SettingsPage(),true);
        }

        private  void NavToContinueAdventure(object obj) {
            Debug.WriteLine("Navigating to continue");
             Application.Current.MainPage.Navigation.PushAsync(new AdventurePage(), true);
        }

        private  void NavToNewAdventureSelection(object obj) {
            Debug.WriteLine("Navigating to new Adventure");
             Application.Current.MainPage.Navigation.PushAsync(new AdventureSelectionPage(), true);
        }


        #endregion

        #region Ctors #################################################################################

        public MainVM() {
            cmdNewAdventure = new Command(NavToNewAdventureSelection);
            cmdContinue = new Command(NavToContinueAdventure);
            cmdSettings = new Command(NavToSettings);
        }


        #endregion
    }//clss

}//ns
