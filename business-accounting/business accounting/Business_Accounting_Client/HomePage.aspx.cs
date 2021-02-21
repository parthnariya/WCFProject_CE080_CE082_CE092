using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Windows.Forms;
using System.Text;
using System.ComponentModel;
using System.Web.UI.WebControls;
using Inventory_Management_Client.ServiceReference1;

namespace Inventory_Management_Client
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "WELCOME TO OUR SHOP!!";
            if (!IsPostBack)
            {
                
                BindData();

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Addp.aspx");
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindData();
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindData();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Inventory_Management_Client.ServiceReference1.Service1Client pr = new Inventory_Management_Client.ServiceReference1.Service1Client("BasicHttpBinding_IService1");

            int ID = (int)e.Keys["Id"];
            Product p = new Product();
            string name = (string)e.NewValues["name"];
            int quantity = int.Parse((string)e.NewValues["quantity"]);
            string brand = (string)e.NewValues["brand"];
            string cb = (string)e.NewValues["checkBy"];
            double price = double.Parse((string)e.NewValues["price"]);
            DateTime dar=DateTime.Parse((string)e.NewValues["dateOfArrival"]);
            Label1.Text = name;
            p.ID = ID;
            p.Name = name;
            p.Quantity = quantity;
            p.Price = price;
            p.CheckBy = cb;
            p.DateOfArrival = dar;
            p.Brand = brand;
            pr.UpdateProduct(p);
            GridView1.EditIndex = -1;
            BindData();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Inventory_Management_Client.ServiceReference1.Service1Client pr = new Inventory_Management_Client.ServiceReference1.Service1Client("BasicHttpBinding_IService1");

            int ID = (int)e.Keys["Id"];
            pr.DeleteProduct(ID);
    // Delete here the database record for the selected patientID

            BindData();
        }
        private void BindData()
        {
            Inventory_Management_Client.ServiceReference1.Service1Client pr = new Inventory_Management_Client.ServiceReference1.Service1Client("BasicHttpBinding_IService1");

            DataSet ds = pr.GetAllProduct();
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

    }
}