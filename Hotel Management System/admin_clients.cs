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
    public partial class admin_clients : Form
    {
        public admin_clients()
        {
            InitializeComponent();
            displayClientData();
        }

        public void displayClientData()
        {
            client_data client_Data = new client_data();
            List<client_data> data = new List<client_data>();

            guna2DataGridView1.DataSource = data;
        }
    }
}
