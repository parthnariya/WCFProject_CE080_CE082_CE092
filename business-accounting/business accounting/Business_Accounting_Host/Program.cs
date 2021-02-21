using Inventory_Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Type t = typeof(Service1);
            Uri http = new Uri("http://localhost:8001/Inventory_Management");
            ServiceHost host = new ServiceHost(t, http);
            host.Open();
            Console.WriteLine("host running");
            Console.ReadLine();
            host.Close();
        }
    }
}
