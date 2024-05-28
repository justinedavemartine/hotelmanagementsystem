using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Hotel_Management_System
{
    internal class rooms_data
    {
        private string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ADMIN\Documents\HMS-database.mdf;Integrated Security=True;Connect Timeout=30";
        
        public int ID { get; set; } //0
        public string RoomID { get; set; } //1
        public string RoomType { get; set; } //2
        public string RoomName { get; set; } //3
        public string Price { get; set; } //4
        public string Image { get; set; } //5
        public string Status { get; set; } //6
        public string Date { get; set; } //7


        public List<rooms_data> roomsDataList()
        {
            List<rooms_data> listData = new List<rooms_data>();

            using(SqlConnection connect = new SqlConnection(conn))
            {
                connect.Open();

                string selectData = "SELECT * FROM rooms WHERE date_delete IS NULL";

                using(SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        rooms_data data = new rooms_data();

                        data.ID = (int)reader["ID"];
                        data.RoomID = reader["room_id"].ToString();
                        data.RoomType = reader["type"].ToString();
                        data.RoomName = reader["room_name"].ToString();
                        data.Price = reader["price"].ToString();
                        data.Image = reader["room_image"].ToString();
                        data.Status = reader["status"].ToString();
                        data.Date = reader["date_register"].ToString();

                        listData.Add(data);
                    }
                }
            }
            return listData;
        }
    }
}
