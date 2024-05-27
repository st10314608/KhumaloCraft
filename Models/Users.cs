using System;
using System.Data.SqlClient;
using System.Security.Permissions;
    namespace KhumaloCraft.Models
{
    public class Users
    {
        public static string con_string = "Server=tcp:faeezareynolds.database.windows.net,1433;Initial Catalog=faeezareynolds;Persist Security Info=False;User ID=faeezareynolds;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static SqlConnection con = new SqlConnection(con_string);


        public string Name { get; set; }
        public string Surname { get; set; } 
        public string Email {  get; set; }  
        public string Password { get; set; }    

        public static int insert_User(Users m)
        {
            try
            {
                string sql = ("INSERT INTO Users (UserName, UserSurname, UserEmail, UserPassword) VALUES (@userName, @UserSurname, @UserEmail, @UserPassword");
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@UserName", m.Name);
                cmd.Parameters.AddWithValue("@UserSurname", m.Surname);
                cmd.Parameters.AddWithValue("@UserEmail", m.Email);
                cmd.Parameters.AddWithValue("@UserPassword", m.Password);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;
            }
            catch (Exception)
            {
                throw;
            }
            }
        }
    }

