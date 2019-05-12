using KJK.App.ViewModels.AdventureVMs;
using KJK.App.Views.AdventurePages;
using System;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace KJK.App.ViewModels {

    public class AdventureVM : ViewModelBase {
        #region Fields,Properties,Events ##############################################################

        private ContentPage _DeatilPage = new ReadingPage();
        public ContentPage DetailPage {
            get => _DeatilPage;
            set { _DeatilPage = value;
                  RaisePropertyChanged();
            }
        }

        public ICommand cmdDisplayDetail { get; private set; }

        #endregion

        #region Methods, Tasks, commands ##############################################################



        #endregion

        #region Ctors #################################################################################

        public AdventureVM() {
            cmdDisplayDetail = new Command<string>(DisplayPage);
        }

        private void DisplayPage(string page) {
            switch (page) {
                case "Character":
                    Debug.WriteLine($"Displaying {page} sheet");
                    DetailPage = new CharacterPage();
                    break;
                case "Inventory":
                    Debug.WriteLine($"Displaying {page} sheet");
                    DetailPage = new InventoryPage();
                    break;
                case "Reading":
                    Debug.WriteLine($"Displaying {page} sheet");
                    DetailPage = new ReadingPage();
                    break;
                case "Map":
                    Debug.WriteLine($"Displaying {page} sheet");
                    DetailPage = new MapPage();
                    break;
                case "Rest":
                    Debug.WriteLine($"Displaying {page} sheet");
                    DetailPage = new RestPage();
                    break;
                default:
                    Debug.WriteLine($"can't display {page} unkown page");
                    break;
            }
        }

        #endregion
    }//clss

}//ns
