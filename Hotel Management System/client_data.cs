using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Runtime.Remoting.Messaging;

namespace Hotel_Management_System
{
    internal class client_data
    {
        private string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ADMIN\Documents\HMS-database.mdf;Integrated Security=True;Connect Timeout=30";

        public int ID { set; get; }
        public string BookID { set; get; }
        public string ClientName { set; get; }
        public string Email { set; get; }
        public string ContactNum { set; get; }
        public string Gender { set; get; }
        public string Address { set; get; }
        public string RoomID { set; get; }
        public string Price { set; get; }
        public string StatusPayment { set; get; }
        public string Status {  set; get; }
        public string CheckIn { set; get; }
        public string CheckOut { set; get; }
        public string BookDate { set; get; }
        public List<client_data> clientListData()
        {
            List<client_data> client_Data = new List<client_data>();

            using(SqlConnection connect = new SqlConnection(conn))
            {
                connect.Open();
                string selectData = "SELECT * FROM clients";

                using(SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        client_data cData = new client_data();

                        cData.ID = (int)reader["id"];
                        cData.BookID = reader["book_id"].ToString();
                        cData.ClientName = reader["client_name"].ToString();
                        cData.Email = reader["email"].ToString();
                        cData.ContactNum = reader["contact"].ToString();
                        cData.Gender = reader["gender"].ToString();
                        cData.Address = reader["address"].ToString();
                        cData.RoomID = reader["room_id"].ToString();
                        cData.Price = reader["price"].ToString();
                        cData.StatusPayment = reader["status_payment"].ToString();
                        cData.Status = reader["status"].ToString();
                        cData.CheckIn = reader["date_from"].ToString();
                        cData.CheckOut = reader["date_to"].ToString();
                        cData.BookDate = reader["date_book"].ToString();

                        client_Data.Add(cData);
                    }
                }
            }
            return client_Data;
        }
    }
}
