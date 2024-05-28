using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management_System
{
    public partial class staff_form : Form
    {
        public staff_form()
        {
            InitializeComponent();
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoginForm login = new LoginForm();
                login.Show();

                this.Hide();
            }
        }

        private void dashboard_btn_Click(object sender, EventArgs e)
        {
            admin_dashboard1.Visible = true;
            staff_booking1.Visible = false;
            admin_client_info1.Visible = false;

            admin_dashboard adDashboard = admin_dashboard1 as admin_dashboard;

            if (adDashboard != null)
            {
                adDashboard.refreshData();
            }
        }

        private void bookroom_btn_Click(object sender, EventArgs e)
        {
            admin_dashboard1.Visible = false;
            staff_booking1.Visible = true;
            admin_client_info1.Visible = false;

            staff_booking staffbooking = staff_booking1 as staff_booking;

            if (staffbooking != null)
            {
                staffbooking.refreshData();
            }
        }

        private void customer_btn_Click(object sender, EventArgs e)
        {
            admin_dashboard1.Visible = false;
            staff_booking1.Visible = false;
            admin_client_info1.Visible = true;

            admin_client_info clientInfo = admin_client_info1 as admin_client_info;

            if (clientInfo != null)
            {
                clientInfo.refreshData();
            }
        }
    }
}
