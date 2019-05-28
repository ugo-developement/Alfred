using Alfred.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfred.ViewModels
{
    class CustomerViewModel : ViewModelBase
    {
        private ObservableCollection<CustomerModel> _customerDataGrid = new ObservableCollection<CustomerModel>();
        public ObservableCollection<CustomerModel> CustomerDataGrid
        {
            get { return _customerDataGrid; }
            set { SetProperty(ref _customerDataGrid, value); }
        }

        private int _numshow;
        public int NumShow
        {
            get { return _numshow; }
            set { SetProperty(ref _numshow, value); }
        }

        private RelayCommand _createDataGrid;
        public RelayCommand CreateDataGrid
        {
            get
            {
                return _createDataGrid ?? (_createDataGrid = new RelayCommand(
                    () =>
                    {
                        DoCreateDataGrid();
                    }));
            }
        }


        public void DoCreateDataGrid()
        {
            CustomerModel model = new CustomerModel();
            List<CustomerModel> customers;
            customers = model.CreateCustomerModels(10);
            this.CustomerDataGrid = null;
            foreach (CustomerModel customer in customers)
            {
                _customerDataGrid.Add(customer);
            }
        }
    }
}
