using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text; 

namespace Inventory_Management
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        bool AddProduct(Product p);

        [OperationContract]
        Product UpdateProduct(Product p);
        [OperationContract]
        [FaultContract(typeof(NotFoundFolt))]
        bool DeleteProduct(int id);
        [OperationContract]
        Product GetProduct(int id);
        [OperationContract]
        DataSet GetAllProduct();

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "Inventory_Management.ContractType".
   [DataContract]
   public class NotFoundFolt
    {
        private string exception;
        
        [DataMember]
        public String Exception { get; set; }
    }
}
