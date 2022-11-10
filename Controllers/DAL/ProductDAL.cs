using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Controllers.DAL
{
    public class ProductDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public ProductDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }
        public List<Product> GetAllProducts()
        {
            List<Product> list = new List<Product>();
            string str = "select * from Product";
            cmd = new SqlCommand(str, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product p = new Product();
                    p.ProductId = Convert.ToInt32(dr["ProductId"]);
                    p.Name = dr["Name"].ToString();
                    p.Price = Convert.ToDouble(dr["Price"]);
                    p.CategoryId = Convert.ToInt32(dr["CategoryId"]);
                    list.Add(p);
                }
                con.Close();
                return list;
            }
            else
            {
                con.Close();
                return list;
            }

        }
        public Product GetProductById(int id)
        {
            Product p = new Product();
            string str = "select * from Product where ProductId=@id";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    p.ProductId = Convert.ToInt32(dr["ProductId"]);
                    p.Name = dr["Name"].ToString();
                    p.Price = Convert.ToDouble(dr["Price"]);
                    p.CategoryId = Convert.ToInt32(dr["CategoryId"]);

                }
                con.Close();
                return p;
            }
            else
            {
                con.Close();
                return p;
            }

        }
    }
}
