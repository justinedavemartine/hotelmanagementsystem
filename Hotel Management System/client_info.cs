using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management_System
{
    public partial class client_info : Form
    {
        private string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ADMIN\Documents\HMS-database.mdf;Integrated Security=True;Connect Timeout=30";

        public client_info()
        {
            InitializeComponent();
            displayBookId();
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
            }
        }

        private void book_id_Click(object sender, EventArgs e)
        {

        }

        public void displayBookId()
        {
            using(SqlConnection connect = new SqlConnection(conn))
            {
                connect.Open();
                int getBookId = 0;

                string selectID = "SELECT COUNT(id) FROM clients";

                using(SqlCommand cmd = new SqlCommand(selectID, connect))
                {
                    getBookId = (Convert.ToInt32(cmd.ExecuteScalar()));

                    if (getBookId == 0)
                    {
                        getBookId += 1;
                    }
                    else
                    {
                        getBookId += 1;
                    }
                }
                book_id.Text = $"BID-{getBookId}";
            }
        }

        private void booknow_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to book now?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (client_name.Text == "" || email_add.Text == "" || address.Text == "" || gender_combo.SelectedIndex == -1 || contact_num.Text == "" || hotel_data.roomID == "")
                {
                    MessageBox.Show("Please fill all the blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    using (SqlConnection connect = new SqlConnection(conn))
                    {
                        connect.Open();

                        string insertData = "INSERT INTO clients " +
                            "(book_id, client_name, email, contact, gender, address, price, status_payment, status" +
                            ", date_from, date_to, date_book)" +
                            "VALUES(@bookID, @name, @email, @contact, @gender, @address, @price, @statuspayment" +
                            ", @status, @datefrom, @dateto, @dateBook)";

                        using (SqlCommand cmd = new SqlCommand(insertData, connect))
                        {
                            cmd.Parameters.AddWithValue("@bookID", book_id.Text);
                            cmd.Parameters.AddWithValue("@name", client_name.Text);
                            cmd.Parameters.AddWithValue("@email", email_add.Text);
                            cmd.Parameters.AddWithValue("@contact", contact_num.Text);
                            cmd.Parameters.AddWithValue("@gender", gender_combo.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@address", address.Text);
                            cmd.Parameters.AddWithValue("@price", hotel_data.price);
                            cmd.Parameters.AddWithValue("@statuspayment", "PAID");
                            cmd.Parameters.AddWithValue("@status", "CHECKED IN");
                            cmd.Parameters.AddWithValue("@datefrom", hotel_data.fromDate);
                            cmd.Parameters.AddWithValue("@dateto", hotel_data.toDate);
                            DateTime today = DateTime.Today;

                            cmd.Parameters.AddWithValue("@datebook", today);

                            cmd.ExecuteNonQuery();
                            updateRoomStatus();

                            MessageBox.Show("Booked successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Hide();
                        }
                    }
                }
            }
        }

        public void updateRoomStatus()
        {
            using (SqlConnection connect = new SqlConnection(conn))
            {
                connect.Open();
                string updatedStatus = "UPDATE rooms SET status = @status WHERE room_id = @roomID";

                using(SqlCommand cmd = new SqlCommand(updatedStatus, connect))
                {
                    cmd.Parameters.AddWithValue("@status", "UNAVAILABLE");
                    cmd.Parameters.AddWithValue("@roomID", hotel_data.roomID);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            client_name.Text = "";
            email_add.Text = "";
            contact_num.Text = "";
            gender_combo.SelectedIndex = -1;
            address.Text = "";
        }
    }
}
