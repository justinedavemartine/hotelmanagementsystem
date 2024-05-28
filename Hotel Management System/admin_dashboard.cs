using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hotel_Management_System
{
    public partial class admin_dashboard : UserControl
    {
        private string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ADMIN\Documents\HMS-database.mdf;Integrated Security=True;Connect Timeout=30";
        public admin_dashboard()
        {
            InitializeComponent();
            displayStaffCount();
            displayAvailableRooms();
            displayTodaysTotalProfit();
            displayTotalProfit();
            displayAllRooms();
        }
        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayStaffCount();
            displayAvailableRooms();
            displayTodaysTotalProfit();
            displayTotalProfit();
            displayAllRooms();
        }
        public void displayStaffCount()
        {
            using(SqlConnection connect = new SqlConnection(conn))
            {
                connect.Open();

                string selectData = "SELECT COUNT(id) FROM users WHERE role = 'STAFF'";

                using(SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        totalStaff_lbl.Text = result.ToString();
                    }
                }
            }
        }
        public void displayAvailableRooms()
        {
            using (SqlConnection connect = new SqlConnection(conn))
            {
                connect.Open();

                string selectData = "SELECT COUNT(id) FROM rooms WHERE status = 'AVAILABLE' OR status = 'ACTIVE'";

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        totalAvailableRooms_lbl.Text = result.ToString();
                    }
                }
            }
        }
        public void displayTodaysTotalProfit()
        {
            using( SqlConnection connect = new SqlConnection(conn))
            {
                connect.Open();

                string selectData = "SELECT SUM(price) FROM clients WHERE date_book = @dbook";

                using(SqlCommand cmd = new SqlCommand( selectData, connect))
                {
                    DateTime today  = DateTime.Today;
                    cmd.Parameters.AddWithValue("@dbook", today);

                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        totalTodayProfit.Text = "₱" + result.ToString() + ".00";
                    }
                }
            }
        }
        public void displayTotalProfit()
        {
            using (SqlConnection connect = new SqlConnection(conn))
            {
                connect.Open();

                string selectData = "SELECT SUM(price) FROM clients";

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        totalProfit_lbl.Text = "₱" + result.ToString() + ".00";
                    }
                }
            }
        }

        public void displayAllRooms()
        {
            rooms_data rData = new rooms_data();
            List<rooms_data> listData = rData.roomsDataList();

            dataGridView1.DataSource = listData;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
