using Alfred.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Alfred.ViewModels
{
    class LoginViewModel : INotifyPropertyChanged
    {
        private string _username, _password;
        private SqlConnection _connection = new SqlConnection();

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
            }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public SqlConnection Connection
        {
            get { return _connection; }
            set
            {
                _connection = value;
                OnPropertyChanged(nameof(Connection));
            }
        }

        // Login Command //

        private RelayCommand _loginCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                return _loginCommand ?? (_loginCommand = new RelayCommand(
                    () =>
                    {
                        Login(_username, _password);
                    }));

            }
        }

        public interface ICloseable
        {
            void Close();
        }

        public RelayCommand<ICloseable> CloseWindowCommand { get; private set; }
        public LoginViewModel()
        {
            this.CloseWindowCommand = new RelayCommand<ICloseable>(this.CloseWindow);
        }
        private void CloseWindow(ICloseable window)
        {
            if(window != null)
            {
                window.Close();
            }
        }

        private string _conpath;
        private SqlConnection _con;
        private void Login(string un, string pw)
        {

            try
            {
                _conpath = $"Data Source = 10.1.10.114,1434; Initial Catalog = TestDB; User ID={un}; Password={pw}";
                _con = new SqlConnection(_conpath);
                Connection = _con;
                _con.Open();

                // Opens Main Window
                MainWindow mw = new MainWindow();
                mw.InitializeComponent();
                mw.Show();
            }
            catch (Exception)
            {
                _con.Close();
            }
            finally
            {
                _con.Close();
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
