using System;
using System.Data.SqlClient;
using System.IO;

namespace AlfredClassLibrary
{
    public class SQL_Server
    {
        // Anything Requiring Getting Information //
        //         From the SQL Server            //

        private string error_message;

        /*
         * Create connection to the SQL Server
         * Only opens the connection and 
         * returns the value.
         * Other functions must be sure
         * to close connection after
         * using. :)
         */

        #region Open_Connection Method
        public SqlConnection Open_Connection(string username, string password)
        {
            string conpath = $"Data Source = 10.1.10.114,1434; Initial Catalog = TestDB; User ID={username}; Password={password}";

            try
            {
                SqlConnection con = new SqlConnection(conpath);
                con.Open();
                return con;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        #endregion

        #region Get_Customer Method
        /*
         * Return CustomerBase with Values
         */

        public CustomerBase Get_Customer(string name, SqlConnection connection)
        {
            CustomerBase newCustomer = new CustomerBase();

            try
            {
                if (connection == null || connection.State == System.Data.ConnectionState.Closed)
                {
                    error_message = "Connection was closed. Trying to reopen.";
                    Console.WriteLine(error_message);
                    connection.Open();
                }

                newCustomer.Name = name;  //Get_Customer_Name(row, connection);
                newCustomer.ID = Get_Customer_ID(newCustomer.Name, connection);
                newCustomer.TotalOrders = Get_Customer_TotalOrders(newCustomer.ID, connection);
                newCustomer.PriceAvg = Get_Customer_PriceAvg(newCustomer.ID, connection);
                newCustomer.BasketAvg = Get_Customer_BasketAvg(newCustomer.ID, connection);
                return newCustomer;
            }
            catch (Exception)
            {
                error_message = "Error at Get_Customer: Exception. Returning Null.";
                Console.WriteLine(error_message);
                return null;
            }
        }
        #endregion

        #region Get_Customer_Values Members
        /*
         * 
         */
        //public string Get_Customer_Name(int row, SqlConnection connection)
        //{
        //    string name;
        //    try
        //    {
        //        string query = "SELECT CustName FROM Customer WHERE ROW_NUMBER()=@rownumber";
        //        SqlCommand command = new SqlCommand(query, connection);
        //        command.Parameters.AddWithValue("@rownumber", row);
        //        if(connection == null || connection.State == System.Data.ConnectionState.Closed)
        //        {
        //            error_message = "Connection was closed. Trying to reopen.";
        //            Console.WriteLine(error_message);
        //            connection.Open();
        //        }
        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                name = reader["CustName"].ToString();
        //                return name;
        //            }
        //        }
        //    }
        //    catch(Exception)
        //    {
        //        error_message = "Error at Get_Customer_Name: Exception. Returning Null.";
        //        Console.WriteLine(error_message);
        //        return null;
        //    }
        //    error_message = "Error at Get_Customer_Name: Nothing returned. Returning Null.";
        //    Console.WriteLine(error_message);
        //    return null;
        //}


        /*
         * Return Customer ID
         */

        public int Get_Customer_ID(string name, SqlConnection connection)
        {
            int id;
            try
            {
                string query = "SELECT CustID FROM Customer WHERE CustName=@CustName";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustName", name);
                if(connection == null || connection.State == System.Data.ConnectionState.Closed)
                {
                    error_message = "Connection was closed. Trying to reopen.";
                    Console.WriteLine(error_message);
                    connection.Open();
                }
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = (int)reader["CustId"];
                        return id;
                    }
                }
            }
            catch (Exception)
            {
                error_message = "Error at Get_Customer_ID: Exception. Returning -1.";
                Console.WriteLine(error_message);
                return -1;
            }
            error_message = "Error at Get_Customer_ID: Nothing returned. Returning -2.";
            Console.WriteLine(error_message);
            return -2;
        }

        /*
         * Return Customer TotalNoOfOrders
         */

        public int Get_Customer_TotalOrders(int id, SqlConnection connection)
        {
            int total_orders;
            try
            {
                string query = "SELECT TotalNoOfOrders FROM Customer WHERE CustID=@CustID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustID", id);
                if (connection == null || connection.State == System.Data.ConnectionState.Closed)
                {
                    error_message = "Connection was closed. Trying to reopen.";
                    Console.WriteLine(error_message);
                    connection.Open();
                }
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {                  // ??? Getting invalid cast exception someone save me please
                        total_orders = (int)reader["TotalNoOfOrders"];
                        return total_orders;
                    }
                }
            }
            catch (Exception)
            {
                error_message = "Error getting TotalOrders: Exception. Returning -1.";
                Console.WriteLine(error_message);
                return -1;
            }
            error_message = "Error getting TotalOrders: Nothing returned. Returning -2.";
            Console.WriteLine(error_message);
            return -2;
        }

        /*
         * Return Customer Average Basket Size
         */

        public double Get_Customer_BasketAvg(int id, SqlConnection connection)
        {
            double basketavg;
            try
            {
                string query = "SELECT BasketAvg FROM Customer WHERE CustID=@CustID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustID", id);
                if (connection == null || connection.State == System.Data.ConnectionState.Closed)
                {
                    error_message = "Connection was closed. Trying to reopen.";
                    Console.WriteLine(error_message);
                    connection.Open();
                }
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        basketavg = (Double)reader["TotalNoOfOrders"];
                        return basketavg;
                    }
                }
            }
            catch (Exception)
            {
                error_message = "Error getting BasketAvg: Exception. Returning -1.0.";
                Console.WriteLine(error_message);
                return -1;
            }
            error_message = "Error getting BasketAvg: Nothing returned. Returning -2.0.";
            Console.WriteLine(error_message);
            return -2;
        }

        /*
         * Return Customer PriceAvg
         */

        public double Get_Customer_PriceAvg(int id, SqlConnection connection)
        {
            double priceavg;
            try
            {
                string query = "SELECT PriceAvg FROM Customer WHERE CustID=@CustID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustID", id);
                if (connection == null || connection.State == System.Data.ConnectionState.Closed)
                {
                    error_message = "Connection was closed. Trying to reopen.";
                    Console.WriteLine(error_message);
                    connection.Open();
                }
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        priceavg = (Double)reader["TotalNoOfOrders"];
                        return priceavg;
                    }
                }
            }
            catch (Exception)
            {
                error_message = "Error getting PriceAvg: Exception. Returning -1.0.";
                Console.WriteLine(error_message);
                return -1;
            }
            error_message = "Error getting PriceAvg: Nothing returned. Returning -2.0.";
            Console.WriteLine(error_message);
            return -2;
        }
        #endregion

        #region CustomerBase Definition
        /*
         * Class to represent a Customer 
         * and their appropiate 
         * information.
         */

        public class CustomerBase
        {
            private string _name;
            private int _totalorders, _id;
            private double _pavg, _bavg;

            public int ID
            {
                get { return _id; }
                set { _id = value; }
            }
            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }
            public int TotalOrders
            {
                get { return _totalorders; }
                set { _totalorders = value; }
            }
            public double PriceAvg
            {
                get { return _pavg; }
                set { _pavg = value; }
            }
            public double BasketAvg
            {
                get { return _bavg; }
                set { _bavg = value; }
            }
        }
        #endregion
    }
}
