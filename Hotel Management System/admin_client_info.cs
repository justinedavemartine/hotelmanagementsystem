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
    public partial class admin_client_info : UserControl
    {
        public admin_client_info()
        {
            InitializeComponent();
            displayClientData();
        }
        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayClientData();
        }
        public void displayClientData()
        {
            client_data client_Data = new client_data();
            List<client_data> data = client_Data.clientListData();

            dataGridView1.DataSource = data;
        }
    }
}
