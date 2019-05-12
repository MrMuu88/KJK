using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KJK.App.ViewModels {

    public class ViewModelBase: INotifyPropertyChanged {
        #region Fields,Properties,Events ##############################################################
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods, Tasks, commands ##############################################################

        public void RaisePropertyChanged([CallerMemberName] string propName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        #endregion

        #region Ctors #################################################################################

        public ViewModelBase() { }

        #endregion
    }//clss

}//ns
