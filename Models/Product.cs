using Microsoft.Data.SqlClient;
using System.Data;
namespace Machine_proj.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

         public string ProductCode { get; set; }

        public Category DeleteFlag { get; set; }


        public static int InsertProduct(Product prod)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=KTjune23;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Insert into Product (ProductName, ProductCode, ProductPrice) Values (@ProductName, @ProductCode, @ProductPrice)";

                cmd.Parameters.AddWithValue("@ProductName", prod.ProductName);
                cmd.Parameters.AddWithValue("@ProductCode", prod.ProductCode);
                cmd.Parameters.AddWithValue("@ProductPrice", prod.ProductPrice);

                int cnt = cmd.ExecuteNonQuery();

                if(cnt > 0)
                {
                    return 1;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
            return 0;
        }

        public static List<Product> GetAllProduct()
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
                cmd.CommandText = "Select * from Product";

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Product p = new Product();
                    p.ProductId = dr.GetInt32("ProductId");
                    p.ProductName = dr.GetString("ProductName");
                    p.ProductCode = dr.GetString("ProductCode");
                    p.ProductPrice = dr.GetDecimal("ProductPrice");


                    lstprod.Add(p);
                }
                dr.Close();
            }
            catch(Exception e)
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
