using KJK.App.Views;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace KJK.App.ViewModels {

    public class AdventureSelectionVM:ViewModelBase {
        #region Fields,Properties,Events ##############################################################
        public ICommand cmdNewCharacter { get; private set; }
        public ICommand cmdStartAdventure { get; private set; }


        #endregion

        #region Methods, Tasks, commands ##############################################################

        private void NavToAdventurePage(object obj) {
            Debug.WriteLine("Navigating to AdventurePage");
            Application.Current.MainPage.Navigation.PopToRootAsync();
            Application.Current.MainPage.Navigation.PushAsync(new AdventurePage(),true);
        }

        private void NavToNewCharacterPage(object obj) {
            Debug.WriteLine("Navigating to Character page");
            Application.Current.MainPage.Navigation.PushAsync(new CharacterCreationPage(),true);
            
        }


        #endregion

        #region Ctors #################################################################################

        public AdventureSelectionVM() {
            cmdNewCharacter = new Command(NavToNewCharacterPage);
            cmdStartAdventure = new Command(NavToAdventurePage);
        }

        #endregion
    }//clss

}//ns
