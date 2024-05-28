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
    public partial class HotelSalveDashboard : Form
    {
        public HotelSalveDashboard()
        {
            InitializeComponent();
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to exit?" , "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
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
            manage_staff1.Visible = false;
            manage_rooms1.Visible = false;
            admin_client_info1.Visible = false;

            admin_dashboard adDashboard = admin_dashboard1 as admin_dashboard;

            if (adDashboard != null)
            {
                adDashboard.refreshData();
            }
        }

        private void manageroom_btn_Click(object sender, EventArgs e)
        {
            admin_dashboard1.Visible = false;
            manage_staff1.Visible = false;
            manage_rooms1.Visible = true;
            admin_client_info1.Visible = false;

            manage_rooms manageRooms = manage_rooms1 as manage_rooms;

            if (manageRooms != null)
            {
                manageRooms.refreshData();
            }
        }

        private void managestaff_btn_Click(object sender, EventArgs e)
        {
            admin_dashboard1.Visible = false;
            manage_staff1.Visible = true;
            manage_rooms1.Visible = false;
            admin_client_info1.Visible = false;

            manage_staff manageStaff = manage_staff1 as manage_staff;

            if (manageStaff != null)
            {
                manageStaff.refreshData();
            }
        }

        private void customer_btn_Click(object sender, EventArgs e)
        {
            admin_dashboard1.Visible = false;
            manage_staff1.Visible = false;
            manage_rooms1.Visible = false;
            admin_client_info1.Visible = true;

            admin_client_info clientInfo = admin_client_info1 as admin_client_info;

            if (clientInfo != null)
            {
                clientInfo.refreshData();
            }
        }

    }
}
