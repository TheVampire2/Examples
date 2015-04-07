using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NorthwindCRUD
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBasicCRUDservice" in both code and config file together.
    [ServiceContract]
    public interface IBasicCRUDservice
    {
        [OperationContract]
        DataSet ListCustomers();
        
        [OperationContract]
        bool InsertCustomer(string companyName, string contactName, string city, string country);
        

        [OperationContract]
        DataSet EditCustomer(string CustomerID);

        [OperationContract]
        bool SaveCustomer(string companyName, string contactName, string city, string country, string customerID);
        
        [OperationContract]
        bool DeleteCustomer(string customerID);
        
    }
}
