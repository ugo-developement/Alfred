using System;
using Alfred.Models;
using System.Collections.Generic;
using System.Data.Sql;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Alfred.ViewModels
{
    class HomeSalesTableViewModel
    {
        public static List<double> ReadData()
        {
            List<double> result;
            double resultsOne = new double(), resultsTwo = new double(), resultsThree = new double();
            using (SqlConnection db = new SqlConnection("Data Source=10.1.10.114,1434;Initial Catalog=benDover;Persist Security Info=True;User ID=ugoadmin;Password=ugo-2019"))
            {
                string query = "SELECT COUNT(Total) as TotalDay, AVG(BasketSize) as AvgBasketSize, AVG(Total) as AvgOrderTotal FROM theORDER WHERE(GETDATE() - DAY(1)) < oTimeStamp";
                SqlCommand command = new SqlCommand(query, db);
                db.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        resultsOne = double.Parse(reader.GetValue(0).ToString());
                        resultsTwo = double.Parse(reader.GetValue(1).ToString());
                        resultsThree = double.Parse(reader.GetValue(2).ToString());
                    }
                }
                finally
                {
                    reader.Close();
                }
                result = new List<double>
                {
                    resultsOne,
                    Math.Round(resultsTwo, 2),
                    Math.Round(resultsThree, 2)
                };

                return result;
            }
        }
        public static List<double> ReadDataWeek()
        {
            List<double> result;
            double resultsOne = new double(), resultsTwo = new double(), resultsThree = new double();
            using (SqlConnection db = new SqlConnection("Data Source=10.1.10.114,1434;Initial Catalog=benDover;Persist Security Info=True;User ID=ugoadmin;Password=ugo-2019"))
            {
                string query = "SELECT COUNT(Total) as TotalWeek, AVG(BasketSize) as AvgBasketSize, AVG(Total) as AvgOrderTotal FROM theORDER WHERE(GETDATE() - DAY(7)) < oTimeStamp";
                SqlCommand command = new SqlCommand(query, db);
                db.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        resultsOne = double.Parse(reader.GetValue(0).ToString());
                        resultsTwo = double.Parse(reader.GetValue(1).ToString());
                        resultsThree = double.Parse(reader.GetValue(2).ToString());
                    }
                }
                finally
                {
                    reader.Close();
                }
                result = new List<double>
                {
                    resultsOne,
                    Math.Round(resultsTwo, 2),
                    Math.Round(resultsThree, 2)
                };

                return result;
            }
        }
        public static List<double> ReadDataMonth()
        {
            List<double> result;
            double resultsOne = new double(), resultsTwo = new double(), resultsThree = new double();
            using (SqlConnection db = new SqlConnection("Data Source=10.1.10.114,1434;Initial Catalog=benDover;Persist Security Info=True;User ID=ugoadmin;Password=ugo-2019"))
            {
                string query = "SELECT COUNT(Total) as TotalWeek, AVG(BasketSize) as AvgBasketSize, AVG(Total) as AvgOrderTotal FROM theORDER WHERE(GETDATE() - DAY(30)) < oTimeStamp";
                SqlCommand command = new SqlCommand(query, db);
                db.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        resultsOne = double.Parse(reader.GetValue(0).ToString());
                        resultsTwo = double.Parse(reader.GetValue(1).ToString());
                        resultsThree = double.Parse(reader.GetValue(2).ToString());
                    }
                }
                finally
                {
                    reader.Close();
                }
                result = new List<double>
                {
                    resultsOne,
                    Math.Round(resultsTwo, 2),
                    Math.Round(resultsThree, 2)
                };

                return result;
            }
        }
        public static List<double> ReadDataYear()
        {
            List<double> result;
            double resultsOne = new double(), resultsTwo = new double(), resultsThree = new double();
            using (SqlConnection db = new SqlConnection("Data Source=10.1.10.114,1434;Initial Catalog=benDover;Persist Security Info=True;User ID=ugoadmin;Password=ugo-2019"))
            {
                string query = "SELECT COUNT(Total) as TotalWeek, AVG(BasketSize) as AvgBasketSize, AVG(Total) as AvgOrderTotal FROM theORDER WHERE(GETDATE() - YEAR(1)) < oTimeStamp";
                SqlCommand command = new SqlCommand(query, db);
                db.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        resultsOne = double.Parse(reader.GetValue(0).ToString());
                        resultsTwo = double.Parse(reader.GetValue(1).ToString());
                        resultsThree = double.Parse(reader.GetValue(2).ToString());
                    }
                }
                finally
                {
                    reader.Close();
                }
                result = new List<double>
                {
                    resultsOne,
                    Math.Round(resultsTwo, 2),
                    Math.Round(resultsThree, 2)
                };

                return result;
            }
        }
    }
}
