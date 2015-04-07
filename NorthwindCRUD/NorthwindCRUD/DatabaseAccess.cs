using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NorthwindCRUD
{
    public static class DatabaseAccess
    {
       
        public static bool InsertCustomer(string CompanyName, string contactName, string City, string Country)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "INSERT INTO Customers (CompanyName,ContactName,City,Country) VALUES ('" + CompanyName + "','" + contactName + "','" + City + "','" + Country + "');";

            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
            return true;
        }
        
        public static  DataSet ListCustomers()
        {

            DataSet ds;
            SqlDataAdapter daCustomers;



            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
            {
                connection.Open();

                ds = new DataSet();
                daCustomers = new SqlDataAdapter("SELECT CustomerID as id,ContactName as name,City as city,Country as country,Phone as phone FROM Customers", connection);
                daCustomers.Fill(ds, "Customers");
            }


            return ds;
        }

        public static DataSet EditCustomer(string CustomerID)
        {
            DataSet ds;
            SqlDataAdapter daCustomers;



            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString))
            {
                connection.Open();

                ds = new DataSet();
                daCustomers = new SqlDataAdapter("SELECT CustomerID,ContactName as name,City as city,Country as country,Phone as phone FROM Customers WHERE CustomerID='" + CustomerID + "'", connection);

                daCustomers.Fill(ds, "Customers");
            }


            return ds;
        }
        public static bool SaveCustomer(string CompanyName, string contactName, string City, string Country,string CustomerID)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "UPDATE  Customers SET CompanyName='" + CompanyName +  "', ContactName='" + contactName + "',City='" + City + "',Country='" + Country +"' WHERE CustomerID='" + CustomerID + "';";

            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
            return true;
        }

        public static bool DeleteCustomer(string  CustomerID)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "DELETE FROM Customers WHERE CustomerID='" + CustomerID + "';";
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
            return true;
        }

     
    }
}