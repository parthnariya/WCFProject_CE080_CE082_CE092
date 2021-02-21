using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Inventory_Management
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        bool IService1.AddProduct(Product p)
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SOCproject;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "insert into products(name,quantity,brand,price,checkBy,dateOfArrival) values (@name,@quantity,@brand,@price,@checkBy,@dateOfArrival)";
            SqlParameter para = new SqlParameter("@name", p.Name);
            SqlParameter para1 = new SqlParameter("@quantity", p.Quantity);
            SqlParameter para2 = new SqlParameter("@brand", p.Brand);
            SqlParameter para3 = new SqlParameter("@price", p.Price);
            SqlParameter para4 = new SqlParameter("@checkBy", p.CheckBy);
            SqlParameter para5 = new SqlParameter("@dateOfArrival", p.DateOfArrival);     

            cmd.Parameters.Add(para);
            cmd.Parameters.Add(para1);
            cmd.Parameters.Add(para2);
            cmd.Parameters.Add(para3);
            cmd.Parameters.Add(para4);
            cmd.Parameters.Add(para5);
            cnn.Open();
            int reader = cmd.ExecuteNonQuery();           
            cnn.Close();
            if (reader == 0)
            {
                return false;
            }
            return true;            
        }

        bool IService1.DeleteProduct(int id)
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SOCproject;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "delete from products where id=@id";
            SqlParameter para = new SqlParameter("@id", id);

            cmd.Parameters.Add(para);
            cnn.Open();
            int reader = cmd.ExecuteNonQuery();
            cnn.Close();
            if (reader == 0)
            {
                NotFoundFolt nf = new NotFoundFolt();
                nf.Exception = "No record found with given ID";
                throw new FaultException<NotFoundFolt>(nf);
            }
            return true;
        }

        DataSet IService1.GetAllProduct()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from products",
               @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SOCproject;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            DataSet ds = new DataSet();
            da.Fill(ds, "products");
            return ds;
        }

        Product IService1.GetProduct(int id)
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SOCproject;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "select * from products where id=@id";
            SqlParameter p = new SqlParameter("@id", id);
            cmd.Parameters.Add(p);
            cnn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Product pr = new Product();
            if (reader.Read())
            {
                pr.ID = reader.GetInt32(0);
                pr.Name = reader.GetString(1);
                pr.Quantity = reader.GetInt32(2);
                pr.Brand = reader.GetString(3);
                pr.Price = reader.GetDouble(4);
                pr.CheckBy = reader.GetString(5);
                pr.DateOfArrival = reader.GetDateTime(6);

            }
            else
            {
                NotFoundFolt nf = new NotFoundFolt();
                nf.Exception = "No record found with given ID";
                throw new FaultException<NotFoundFolt>(nf);
            }
            reader.Close();
            cnn.Close();
            return pr;
        }

        Product IService1.UpdateProduct(Product p)
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SOCproject;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "update products set name=@name,quantity=@quantity,brand=@brand,price=@price,checkBy=@checkBy,dateOfArrival=@dateOfArrival where id=@id";
            SqlParameter para6 = new SqlParameter("@id", p.ID);
            SqlParameter para = new SqlParameter("@name", p.Name);
            SqlParameter para1 = new SqlParameter("@quantity", p.Quantity);
            SqlParameter para2 = new SqlParameter("@brand", p.Brand);
            SqlParameter para3 = new SqlParameter("@price", p.Price);
            SqlParameter para4 = new SqlParameter("@checkBy", p.CheckBy);
            SqlParameter para5 = new SqlParameter("@dateOfArrival", p.DateOfArrival);

            cmd.Parameters.Add(para);
            cmd.Parameters.Add(para1);
            cmd.Parameters.Add(para2);
            cmd.Parameters.Add(para3);
            cmd.Parameters.Add(para4);
            cmd.Parameters.Add(para5);
            cmd.Parameters.Add(para6);
            cnn.Open();
            int reader = cmd.ExecuteNonQuery();
            cnn.Close();
            if (reader == 0)
            {
                NotFoundFolt nf = new NotFoundFolt();
                nf.Exception = "Some issue found in updating the product please try after some time!!";
                throw new FaultException<NotFoundFolt>(nf);
            }
            return p;
        }
    }
}
