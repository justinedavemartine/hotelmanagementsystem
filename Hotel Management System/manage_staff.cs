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
    public partial class manage_staff : UserControl
    {
        private string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ADMIN\Documents\HMS-database.mdf;Integrated Security=True;Connect Timeout=30";
        public manage_staff()
        {
            InitializeComponent();
            displayData();
        }
        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayData();
        }
        public void displayData()
        {
            users_data userdata = new users_data();
            dataGridView1.DataSource = userdata.listUserData();

            dataGridView1.Columns[2].Visible = false;

        }

        private void addstaff_btn_Click(object sender, EventArgs e)
        {
            if (newusername_txt.Text == "" || newpassword_txt.Text == "" ||
                role_combo.SelectedIndex == -1 || status_combo.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all the blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection connect = new SqlConnection(conn))
                {
                    connect.Open();
                    string checkUser = "SELECT username FROM users WHERE username = @usern";
                    using (SqlCommand checkU = new SqlCommand(checkUser, connect))
                    {
                        checkU.Parameters.AddWithValue("@usern", newusername_txt.Text.Trim());
                        SqlDataAdapter adapter = new SqlDataAdapter(checkU);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        if (table.Rows.Count > 0)
                        {
                            string tempEmail = newusername_txt.Text.Substring(0, 1).ToUpper() + newusername_txt.Text.Substring(1);
                            MessageBox.Show($"{tempEmail} is existing already", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (newpassword_txt.Text.Length < 8)
                        {
                            MessageBox.Show("Password must be 8 characters long.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string query = "INSERT INTO users(username, password, role, status, date_register)" +
                               "VALUES(@usern, @pass, @role, @status, @regDate)";
                            using (SqlCommand cmd = new SqlCommand(query, connect))
                            {
                                cmd.Parameters.AddWithValue("@usern", newusername_txt.Text.Trim());
                                cmd.Parameters.AddWithValue("@pass", newpassword_txt.Text.Trim());
                                cmd.Parameters.AddWithValue("@role", role_combo.SelectedItem.ToString());
                                cmd.Parameters.AddWithValue("@status", status_combo.SelectedItem.ToString());

                                DateTime today = DateTime.Today;
                                cmd.Parameters.AddWithValue("@regDate", today);

                                cmd.ExecuteNonQuery();
                                clear_fields();

                                // Refresh the DataGridView after inserting new data
                                displayData();

                                MessageBox.Show("Account created successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
        }

        public void clear_fields()
        {
            newusername_txt.Text = "";
            newpassword_txt.Text = "";
            role_combo.SelectedIndex = -1;
            status_combo.SelectedIndex = -1;
        }
        private void clear_btn_Click(object sender, EventArgs e)
        {
            clear_fields();
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            if (newusername_txt.Text == "" || newpassword_txt.Text == "" ||
                role_combo.SelectedIndex == -1 || status_combo.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all the blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(MessageBox.Show("Are you sure you want to update ID:" + getID + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection connect = new SqlConnection(conn))
                    {
                        connect.Open();

                        string updateData = "UPDATE users SET password = @pass, role = @role, status = @status WHERE username = @usern";

                        using (SqlCommand cmd = new SqlCommand(updateData, connect))
                        {
                            cmd.Parameters.AddWithValue("@pass", newpassword_txt.Text.Trim());
                            cmd.Parameters.AddWithValue("@role", role_combo.Text.Trim());
                            cmd.Parameters.AddWithValue("@status", status_combo.Text.Trim());
                            cmd.Parameters.AddWithValue("@usern", newusername_txt.Text.Trim());

                            cmd.ExecuteNonQuery();
                            displayData();

                            MessageBox.Show("Update succesfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                }
            }
        }

        private int getID;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                getID = (int)row.Cells[0].Value;
                newusername_txt.Text = row.Cells[1].Value.ToString();
                //newpassword_txt.Text = row.Cells[2].Value.ToString();//
                role_combo.Text = row.Cells[3].Value.ToString();
                status_combo.Text = row.Cells[4].Value.ToString();
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            if (newusername_txt.Text == "" ||
               role_combo.SelectedIndex == -1 || status_combo.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all the blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete ID:" + getID + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection connect = new SqlConnection(conn))
                    {
                        connect.Open();

                        string updateData = "DELETE FROM users WHERE username = @usern";

                        using (SqlCommand cmd = new SqlCommand(updateData, connect))
                        {
                            cmd.Parameters.AddWithValue("@usern", newusername_txt.Text.Trim());

                            cmd.ExecuteNonQuery();
                            displayData();

                            MessageBox.Show("Delete staff successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                }
            }
        }
    }
}
