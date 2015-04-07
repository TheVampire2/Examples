using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NorthwindCRUD
{
    public class BasicCRUDservice : IBasicCRUDservice
    {
        /// <summary>
        /// List Customers
        /// </summary>
        /// <returns></returns>
        public System.Data.DataSet ListCustomers()
        {
            return DatabaseAccess.ListCustomers();
        }
        /// <summary>
        /// Insert Customer
        /// </summary>
        /// <param name="companyName"></param>
        /// <param name="contactName"></param>
        /// <param name="city"></param>
        /// <param name="country"></param>
        /// <returns></returns>
        public bool InsertCustomer(string companyName, string contactName, string city, string country)
        {
            return DatabaseAccess.InsertCustomer(companyName,contactName,city, country);
        }
        /// <summary>
        /// Edit Customer 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DataSet EditCustomer(string customerID)
        {   
            return DatabaseAccess.EditCustomer(customerID);
        }
       
       /// <summary>
       /// Save Customer
       /// </summary>
       /// <param name="productName"></param>
       /// <param name="productPrice"></param>
       /// <param name="productReordered"></param>
       /// <returns></returns>
        public bool SaveCustomer(string CompanyName, string contactName, string City, string Country, string customerID)
        {
            return DatabaseAccess.SaveCustomer(CompanyName,contactName,City,Country,customerID);
        }
        /// <summary>
        /// Delete Customer
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool DeleteCustomer(string customerID)
        {
            return DatabaseAccess.DeleteCustomer(customerID);
        }


      
    }
}
