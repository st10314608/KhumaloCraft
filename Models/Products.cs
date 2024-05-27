using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Hosting.Server;

    namespace KhumaloCraft.Models
{
    public class Products
    {

        public static string con_string = "Server=tcp:faeezareynolds.database.windows.net,1433;Initial Catalog=faeezareynolds;Persist Security Info=False;User ID=faeezareynolds;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static SqlConnection con = new SqlConnection(con_string);


        public int ProductID { get; set; }  
        public string ProductName { get; set; }     
        public string ProductDescription { get; set; }  
        public decimal Price { get; set; }  
        public string Category { get; set; }    
        public bool Availibility { get; set; }

        public static int InsertProduct(Products p)
        {

            try
            {
                string sql = "INSERT INTO Products (ProductName, ProductDescription, Price, Category, Avalibility) VALUES (@ProductName, @ProductDescription, @Price, @Category, @Avalibility";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ProductName", p.ProductName);
                cmd.Parameters.AddWithValue("@ProductDescription", p.ProductDescription);
                cmd.Parameters.AddWithValue("@Price", p.Price);
                cmd.Parameters.AddWithValue("@Category", p.Category);
                cmd.Parameters.AddWithValue("@Avalibility", p.Availibility);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

           
        }
        //Method to retrieve all products from the database

        public static List<Products> GetAllProducts()
        {
            List<Products> products = new List<Products>(); 

            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT * FROM productTable";
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();    
                while (rdr.Read())
                {
                    Products product = new Products();
                    product.ProductID = Convert.ToInt32(rdr["productID"]);
                    product.ProductName = rdr["productName"] as string;
                    product.Category = rdr["productCategory"] as string;
                    product.Availibility = Convert.ToBoolean(rdr["productAvailibility"]);

                    products.Add(product);
                }
            }
        }

                
                    
                }
            }
        

