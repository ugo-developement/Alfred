using Alfred.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


// Model for the Account of the
// User that is currently logged in

// May 19, 2019

namespace Alfred.Model
{
    public class User : INotifyPropertyChanged
    {
        private string _name, _status, _con;
        private Boolean _showloginloading;

        public string Username
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        public bool BoolLoginLoading
        {
            get { return _showloginloading; }
            set
            {
                _showloginloading = value;
                OnPropertyChanged(nameof(BoolLoginLoading));
            }
        }

        public string Connection
        {
            get { return _con; }
            set
            {
                _con = value;
                OnPropertyChanged(nameof(Connection));
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
