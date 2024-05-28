using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Hotel_Management_System
{
    internal class users_data
    {
        private string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ADMIN\Documents\HMS-database.mdf;Integrated Security=True;Connect Timeout=30";
        public int ID { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public string Role { set; get; }
        public string Status { set; get; }
        public string DateReg { set; get; }

        public List<users_data> listUserData()
        {
            List<users_data> ListData = new List<users_data>();
            using (SqlConnection connect = new SqlConnection(conn))
            {
                connect.Open();

                // Modify the query to exclude the password column
                string selectData = "SELECT ID, username, password, role, status, date_register FROM users";
                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        users_data users_Data = new users_data();

                        users_Data.ID = (int)reader["id"];
                        users_Data.UserName = reader["username"].ToString();
                        // Exclude password by skipping this line
                        users_Data.Password = reader["password"].ToString();
                        users_Data.Role = reader["role"].ToString();
                        users_Data.Status = reader["status"].ToString();
                        users_Data.DateReg = reader["date_register"].ToString();

                        ListData.Add(users_Data);
                    }
                }
            }
            return ListData;
        }
    }
}
