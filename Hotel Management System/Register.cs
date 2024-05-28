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
    public partial class RegisterForm : Form
    {
        private string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ADMIN\Documents\HMS-database.mdf;Integrated Security=True;Connect Timeout=30";
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_link_Click(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm();
            form.Show();

            this.Hide();
        }

        private void showpass_chk_CheckedChanged(object sender, EventArgs e)
        {
            userPass_txt.PasswordChar = showpass_chk.Checked ? '\0' : '●';
            userConfirmPass_txt.PasswordChar = showpass_chk.Checked ? '\0' : '●';
        }

        private void reg_btn_Click(object sender, EventArgs e)
        {
            if(userName_txt.Text == "" || userPass_txt.Text == "" || userConfirmPass_txt.Text == "")
            {
                MessageBox.Show("Please fill all the blank fields" , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                using (SqlConnection connect = new SqlConnection(conn))
                {
                    connect.Open();

                    string checkUser = "SELECT username FROM users WHERE username = @usern";
                    using (SqlCommand checkU = new SqlCommand(checkUser, connect))
                    {
                        checkU.Parameters.AddWithValue("@usern" , userName_txt.Text.Trim());
                        SqlDataAdapter adapter = new SqlDataAdapter(checkU);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        
                        if(table.Rows.Count != 0)
                        {
                            string tempEmail = userName_txt.Text.Substring(0,1).ToUpper() + userName_txt.Text.Substring(1);
                            MessageBox.Show($"{tempEmail} is existing already", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }else if(userPass_txt.Text.Length < 8)
                        {
                            MessageBox.Show("Password must be 8 characters long.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }else if(userPass_txt.Text != userConfirmPass_txt.Text)
                        {
                            MessageBox.Show("Password not match", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string query = "INSERT INTO users(username, password, role, status, date_register)" +
                                "VALUES(@usern, @pass, @role, @status, @regDate)";
                            using(SqlCommand cmd = new SqlCommand(query, connect))
                            {
                                cmd.Parameters.AddWithValue("@usern", userName_txt.Text.Trim());
                                cmd.Parameters.AddWithValue("@pass", userPass_txt.Text.Trim());
                                cmd.Parameters.AddWithValue("@role", "Staff");
                                cmd.Parameters.AddWithValue("@status", "Active");

                                DateTime today = DateTime.Today;
                                cmd.Parameters.AddWithValue("@regDate", today);

                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Account created successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                LoginForm form = new LoginForm();
                                form.Show();

                                this.Hide();
                            }
                        }
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
