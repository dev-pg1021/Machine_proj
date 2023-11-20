using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Machine_proj.Models
{
    public class ProductList
    {
        public ProductList() {
            CategoryList = new List<SelectListItem>();
        }
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<SelectListItem> CategoryList { get; set; }

       

        public static List <ProductList> GetAllProduct()
        {
            List<ProductList> lstprod = new List<ProductList>();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=KTjune23;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select ProductId.Product, ProductName.Product, CategoryId.Category, CategoryName.Category from Product , Category where CategoryCode.Category = ProductCode.Product" ;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                   

                    ProductList pl = new ProductList();
                    pl.ProductId = Convert.ToInt32("ProductId");
                    pl.CategoryId = Convert.ToInt32("CategoryId");
                    pl.ProductName = Convert.ToString("ProductName");
                    pl.CategoryName = Convert.ToString("CategoryName");


                    lstprod.Add(pl);
                }
                dr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }

            return lstprod;
        }


        public static List<Product> GetAllProductByCategory(String code)
        {
            List<Product> lstprod = new List<Product>();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=KTjune23;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from Product where ProductCode = @code";

                cmd.Parameters.AddWithValue("@code", code);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {


                    Product pl = new Product();
                    pl.ProductId = Convert.ToInt32("ProductId");
                    pl.ProductName = Convert.ToString("ProductName");
                    lstprod.Add(pl);
                }
                dr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }

            return lstprod;
        }

    }
}
