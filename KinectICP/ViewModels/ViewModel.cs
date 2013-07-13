using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectICP.ViewModels
{
    class ViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            var tmp = PropertyChanged;
            if (tmp != null) tmp(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
