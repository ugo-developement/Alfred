using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfred.ViewModels
{
    class CustomerDataViewModel
    {
        public static double TotalCustActive()
        {
            double result = new double();
            using (SqlConnection db = new SqlConnection("Data Source=10.1.10.114,1434;Initial Catalog=benDover;Persist Security Info=True;User ID=ugoadmin;Password=ugo-2019"))
            {
                string query = @"SELECT COUNT (*) FROM Customer WHERE CustStatus = 'ACTIVE'";
                SqlCommand command = new SqlCommand(query, db);
                db.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        result = double.Parse(reader.GetValue(0).ToString());
                    }
                }
                finally
                {
                    reader.Close();
                }
                return result;
            }
        }
        public static double TotalCustDormant()
        {
            double result = new double();
            using (SqlConnection db = new SqlConnection("Data Source=10.1.10.114,1434;Initial Catalog=benDover;Persist Security Info=True;User ID=ugoadmin;Password=ugo-2019"))
            {
                string query = @"SELECT COUNT (*) FROM Customer WHERE CustStatus = 'DORMANT'";
                SqlCommand command = new SqlCommand(query, db);
                db.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        result = double.Parse(reader.GetValue(0).ToString());
                    }
                }
                finally
                {
                    reader.Close();
                }
                return result;
            }
        }
        public static double TotalCustTotal()
        {
            double result = new double();
            using (SqlConnection db = new SqlConnection("Data Source=10.1.10.114,1434;Initial Catalog=benDover;Persist Security Info=True;User ID=ugoadmin;Password=ugo-2019"))
            {
                string query = @"SELECT COUNT (*) FROM Customer WHERE CustStatus != 'TEST'";
                SqlCommand command = new SqlCommand(query, db);
                db.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        result = double.Parse(reader.GetValue(0).ToString());
                    }
                }
                finally
                {
                    reader.Close();
                }
                return result;
            }
        }

        // NEW CUSTOMER DATA

        public static double NewCustToday()
        {
            double result = new double();
            using (SqlConnection db = new SqlConnection("Data Source=10.1.10.114,1434;Initial Catalog=benDover;Persist Security Info=True;User ID=ugoadmin;Password=ugo-2019"))
            {
                string query = @"SELECT COUNT(*) FROM Customer WHERE JoinDate > DATEADD(DAY,-1, GETDATE())";
                SqlCommand command = new SqlCommand(query, db);
                db.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        result = double.Parse(reader.GetValue(0).ToString());
                    }
                }
                finally
                {
                    reader.Close();
                }
                return result;
            }
        }
        public static double NewCustWeek()
        {
            double result = new double();
            using (SqlConnection db = new SqlConnection("Data Source=10.1.10.114,1434;Initial Catalog=benDover;Persist Security Info=True;User ID=ugoadmin;Password=ugo-2019"))
            {
                string query = @"SELECT COUNT(*) FROM Customer WHERE JoinDate > DATEADD(DAY,-7, GETDATE())";
                SqlCommand command = new SqlCommand(query, db);
                db.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        result = double.Parse(reader.GetValue(0).ToString());
                    }
                }
                finally
                {
                    reader.Close();
                }
                return result;
            }
        }
        public static double NewCustMonth()
        {
            double result = new double();
            using (SqlConnection db = new SqlConnection("Data Source=10.1.10.114,1434;Initial Catalog=benDover;Persist Security Info=True;User ID=ugoadmin;Password=ugo-2019"))
            {
                string query = @"SELECT COUNT(*) FROM Customer WHERE JoinDate > DATEADD(DAY,-30, GETDATE())";
                SqlCommand command = new SqlCommand(query, db);
                db.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        result = double.Parse(reader.GetValue(0).ToString());
                    }
                }
                finally
                {
                    reader.Close();
                }
                return result;
            }
        }
        public static double NewCustYear()
        {
            double result = new double();
            using (SqlConnection db = new SqlConnection("Data Source=10.1.10.114,1434;Initial Catalog=benDover;Persist Security Info=True;User ID=ugoadmin;Password=ugo-2019"))
            {
                string query = @"SELECT COUNT(*) FROM Customer WHERE YEAR(JoinDate) = YEAR(GETDATE())";
                SqlCommand command = new SqlCommand(query, db);
                db.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        result = double.Parse(reader.GetValue(0).ToString());
                    }
                }
                finally
                {
                    reader.Close();
                }
                return result;
            }
        }

        // CUSTOMER LIFESPAN DATA

        public static double LifeSpanActive()
        {
            double result = new double();
            using (SqlConnection db = new SqlConnection("Data Source=10.1.10.114,1434;Initial Catalog=benDover;Persist Security Info=True;User ID=ugoadmin;Password=ugo-2019"))
            {
                string query = @"SELECT AVG(DATEDIFF(WEEK,t.JoinDate, t.recent)) AS lifeSpanInWeeks, COUNT(*) AS sampleSize
FROM (SELECT MAX(o.oTimeStamp) AS recent, c.JoinDate as JoinDate, c.CustID as tempCustID, c.CustStatus as CustStatus FROM Customer c, theORDER o WHERE o.CustID = c.CustID GROUP BY JoinDate, c.CustID, c.CustStatus) t
WHERE (YEAR(t.JoinDate) = 2019 OR YEAR(t.JoinDate) = 2018) AND t.CustStatus = 'ACTIVE'";
                SqlCommand command = new SqlCommand(query, db);
                db.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        result = double.Parse(reader.GetValue(0).ToString());
                    }
                }
                finally
                {
                    reader.Close();
                }
                return result;
            }
        }
        public static double LifeSpanDormant()
        {
            double result = new double();
            using (SqlConnection db = new SqlConnection("Data Source=10.1.10.114,1434;Initial Catalog=benDover;Persist Security Info=True;User ID=ugoadmin;Password=ugo-2019"))
            {
                string query = @"SELECT AVG(DATEDIFF(WEEK,t.JoinDate, t.recent)) AS lifeSpanInWeeks, COUNT(*) AS sampleSize
FROM (SELECT MAX(o.oTimeStamp) AS recent, c.JoinDate as JoinDate, c.CustID as tempCustID, c.CustStatus as CustStatus FROM Customer c, theORDER o WHERE o.CustID = c.CustID GROUP BY JoinDate, c.CustID, c.CustStatus) t
WHERE (YEAR(t.JoinDate) = 2019 OR YEAR(t.JoinDate) = 2018) AND t.CustStatus = 'DORMANT'";
                SqlCommand command = new SqlCommand(query, db);
                db.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        result = double.Parse(reader.GetValue(0).ToString());
                    }
                }
                finally
                {
                    reader.Close();
                }
                return result;
            }
        }
        public static double LifeSpanTotal()
        {
            double result = new double();
            using (SqlConnection db = new SqlConnection("Data Source=10.1.10.114,1434;Initial Catalog=benDover;Persist Security Info=True;User ID=ugoadmin;Password=ugo-2019"))
            {
                string query = @"SELECT AVG(DATEDIFF(WEEK,t.JoinDate, t.recent)) AS lifeSpanInWeeks, COUNT(*) AS sampleSize
FROM (SELECT MAX(o.oTimeStamp) AS recent, c.JoinDate as JoinDate, c.CustID as tempCustID, c.CustStatus as CustStatus FROM Customer c, theORDER o WHERE o.CustID = c.CustID GROUP BY JoinDate, c.CustID, c.CustStatus) t
WHERE (YEAR(t.JoinDate) = 2019 OR YEAR(t.JoinDate) = 2018)";
                SqlCommand command = new SqlCommand(query, db);
                db.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        result = double.Parse(reader.GetValue(0).ToString());
                    }
                }
                finally
                {
                    reader.Close();
                }
                return result;
            }
        }
    }
}