using Inventory_Management_Client.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inventory_Management_Client
{
    public partial class Addp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Inventory_Management_Client.ServiceReference1.Service1Client pr = new Inventory_Management_Client.ServiceReference1.Service1Client("BasicHttpBinding_IService1");
            Product p = new Product();
            p.Name = TextBox1.Text;
            p.Price = float.Parse(TextBox4.Text);
            p.Quantity = int.Parse(TextBox2.Text);
            p.Brand = TextBox3.Text;
            p.CheckBy = TextBox5.Text;
            p.DateOfArrival = DateTime.Parse(TextBox6.Text);

            pr.AddProduct(p);
            Response.Redirect("HomePage.aspx");
        }
    }
}