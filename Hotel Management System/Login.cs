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
    public partial class LoginForm : Form
    {
        private string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ADMIN\Documents\HMS-database.mdf;Integrated Security=True;Connect Timeout=30";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void reg_link_Click(object sender, EventArgs e)
        {
            RegisterForm form = new RegisterForm();
            form.Show();

            this.Hide();
        }

        private void showpass_chk_CheckedChanged(object sender, EventArgs e)
        {
            loginUserPass_txt.PasswordChar = showpass_chk.Checked ? '\0' : '●';
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            if(loginUserName_txt.Text == "" || loginUserPass_txt.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection connect = new SqlConnection(conn))
                {
                    connect.Open();

                    string selectData = "SELECT * FROM users WHERE (username = @usern AND password = @pass) AND status = @status";
                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        cmd.Parameters.AddWithValue("@usern", loginUserName_txt.Text.Trim());
                        cmd.Parameters.AddWithValue("@pass", loginUserPass_txt.Text.Trim());
                        cmd.Parameters.AddWithValue("@status", "ACTIVE");

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        if(table.Rows.Count != 0)
                        {
                            MessageBox.Show("Login successfully, Welcome user!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            string selectRole = "SELECT role FROM users WHERE username = @usern AND password = @pass";
                            using(SqlCommand getRole = new SqlCommand (selectRole, connect))
                            {
                                getRole.Parameters.AddWithValue("@usern", loginUserName_txt.Text.Trim());
                                getRole.Parameters.AddWithValue("@pass", loginUserPass_txt.Text.Trim());

                                string userRole = getRole.ExecuteScalar() as string;

                                if (userRole == "ADMIN")
                                {
                                    HotelSalveDashboard dashboard = new HotelSalveDashboard();
                                    dashboard.Show();

                                    this.Hide();
                                }
                                else if (userRole == "STAFF")
                                {
                                    staff_form staffDashboard = new staff_form();
                                    staffDashboard.Show();

                                    this.Hide();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Incorrect username/password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
