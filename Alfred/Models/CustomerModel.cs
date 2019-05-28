using Alfred.ViewModels;
using AlfredClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Alfred.Models
{
    class CustomerModel
    {
        private string _name, _created;
        private double _basketaverage, _priceaverage;
        private int _totalorders, _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Created
        {
            get { return _created; }
            set { _created = value; }
        }
        public int TotalOrders
        {
            get { return _totalorders; }
            set { _totalorders = value; }
        }
        public double BasketAverage
        {
            get { return _basketaverage; }
            set { _basketaverage = value; }
        }
        public double PriceAverage
        {
            get { return _priceaverage; }
            set { _priceaverage = value; }
        }

        #region CustomerModel GetInformation
        /*
         *  Populate the Customer model
         *  with information from the
         *  sqlserver.
         *  begin is the name to start after.
         *  end is the name to end before.
         */

        public List<CustomerModel> CreateCustomerModels(int num)
        {
            List<CustomerModel> customers = new List<CustomerModel>();
            string query = $"SELECT TOP {num} CustID, CustName, Created, TotalNoOfOrders, PriceAvg, BasketAvg FROM Customer";
            SQL_Server server = new SQL_Server();
            SqlConnection connection;
            connection = server.Open_Connection("ugoadmin", "ugo-2019");

            SqlCommand command = new SqlCommand(query, connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    CustomerModel new_customer = new CustomerModel
                    {
                        Id = (int)reader["CustID"],
                        Name = reader["CustName"].ToString(),
                        Created = reader["Created"].ToString(),
                        TotalOrders = (int)reader["TotalNoOfOrders"],
                        PriceAverage = (double)reader["PriceAvg"],
                        BasketAverage = (double)reader["BasketAvg"]
                    };
                    customers.Add(new_customer);
                }
                return customers;
            }
        }
        #endregion
    }
}
