using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIFI.Sisharp.Training.WPF.ViewModel;

namespace WIFI.Sisharp.Training.WPF.Model
{
    public class Person : INotifyPropertyChanged
    {

        string _FirstName;
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                if (_FirstName != value)
                {
                    _FirstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }

        string _LastName;
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                if (_LastName != value)
                {
                    _LastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }

        int _Age;
        public int Age
        {
            get
            {
                return _Age;
            }
            set
            {
                if (_Age != value)
                {
                    _Age = value;
                    OnPropertyChanged("Age");
                }
            }
        }


        

        void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
