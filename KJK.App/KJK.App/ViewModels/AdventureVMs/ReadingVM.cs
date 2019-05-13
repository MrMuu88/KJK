using KJK.App.Views.AdventurePages;
using System;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace KJK.App.ViewModels.AdventureVMs {

    public class ReadingVM {
        #region Fields,Properties,Events ##############################################################

        public ICommand cmdNavToFigth { get; private set; }
        public ICommand cmdNavToTest { get; private set; }

        #endregion
        
        #region Methods, Tasks, commands ##############################################################

        private void NavToTest(object obj) {
            Debug.WriteLine("Navigating to Test");
            Application.Current.MainPage.Navigation.PushAsync(new TestPage());
        }

        private void NavToFigth(object obj) {
            Debug.WriteLine("Navigating to Test");
            Application.Current.MainPage.Navigation.PushAsync(new FightPage());
        }
               
        #endregion

        #region Ctors #################################################################################

        public ReadingVM() {
            cmdNavToFigth = new Command(NavToFigth);
            cmdNavToTest = new Command(NavToTest);
        }


        #endregion
    }//clss

}//ns
