using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Inventory_Management
{
    [DataContract]
    public class Product
    {
        int id;
        string name;
        int quantity;
        string brand;
        double price;
        DateTime dateOfArrival;
        string checkBy;

        [DataMember]
        public int ID {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        [DataMember]
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }
        [DataMember]
        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        [DataMember]
        public string CheckBy
        {
            get { return checkBy; }
            set { checkBy = value; }
        }
        [DataMember]
        public DateTime DateOfArrival
        {
            get { return dateOfArrival; }
            set { dateOfArrival = value; }
        }

    }
}
