using Microsoft.Data.SqlClient;
using System.Data;

namespace Machine_proj.Models
{
    public class Category
    {
        public int CategoryId { set; get; }
        public string CategoryName { set; get; }

        public string CategoryCode { set; get; }

        public static int InsertCategory(Category cat)
        {
            SqlConnection con = new SqlConnection();

            con.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=KTjune23;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Insert into Category (CategoryName, CategoryCode) Values (@CategoryName, @CategoryCode)";

                
                cmd.Parameters.AddWithValue("@CategoryName", cat.CategoryName);
                cmd.Parameters.AddWithValue("@CategoryCode", cat.CategoryCode);

                int cnt = cmd.ExecuteNonQuery();

                if(cnt > 0)
                {
                    return 1;
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { con.Close(); }

            return 0;
            
        }

        public static List<Category> GetAllCategory()
        {
            List<Category> lst = new List<Category>();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=KTjune23;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            
            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from Category";

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Category c = new Category();
                    c.CategoryId = dr.GetInt32("CategoryId");
                    c.CategoryName = dr.GetString("CategoryName");
                    c.CategoryCode = dr.GetString("CategoryCode");

                    lst.Add(c);
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

            return lst;
        }

    }
}
