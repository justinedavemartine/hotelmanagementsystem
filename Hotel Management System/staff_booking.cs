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
    public partial class staff_booking : UserControl
    {
        public staff_booking()
        {
            InitializeComponent();
            displayRooms();
        }
        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayRooms();
        }

        public void displayRooms()
        {
            rooms_data roomData = new rooms_data();
            List<rooms_data> listData = roomData.roomsDataList();

            dataGridView1.DataSource = listData;
        }
        private int getID = 0;
        private decimal roomprice = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                getID = (int)row.Cells[0].Value;
                room_id.Text = row.Cells[1].Value.ToString();
                room_type.Text = row.Cells[2].Value.ToString();
                room_name.Text = row.Cells[3].Value.ToString();
                room_price.Text = (Convert.ToInt32(row.Cells[4].Value)).ToString("0.00");
                roomprice = Convert.ToDecimal(row.Cells[4].Value);

                room_image.ImageLocation = row.Cells[5].Value.ToString();

                room_status.Text = row.Cells[6].Value.ToString();

            }
        }

        private void setschedule_btn_Click(object sender, EventArgs e)
        {
            DateTime fromDate = from_datepicker.Value;
            DateTime toDate = to_datepicker.Value;

            TimeSpan countDays = toDate - fromDate;
            int days = countDays.Days;
            
            decimal totalPrice = (days * roomprice);

            if (totalPrice < 0)
            {
                MessageBox.Show("Something went wrong!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                total_price.Text = "0.00";
            }else if(totalPrice == 0)
            {
                MessageBox.Show("Something went wrong!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                total_price.Text = roomprice.ToString("0.00");
            }
            else
            {
                total_price.Text = (days * roomprice).ToString("0.00");
            }
        }

        private void bookroom_btn_Click(object sender, EventArgs e)
        {
            if (roomprice == 0 || total_price.Text == "0.00") 
            {
                MessageBox.Show("Please fill all info correctly!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (room_status.Text != "AVAILABLE")
            {
                MessageBox.Show("The room is not available!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                hotel_data.roomID = room_id.Text;
                hotel_data.fromDate = from_datepicker.Value;
                hotel_data.toDate = to_datepicker.Value;
                hotel_data.price = total_price.Text;

                Form formbg = new Form();

                try
                {
                    using (client_info ciForm = new client_info())
                    {
                        ciForm.Owner = formbg;
                        ciForm.ShowDialog();

                        formbg.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    formbg.Dispose();
                }
            }
        }

        public void clearFields()
        {
            room_id.Text = "-----------------------";
            room_name.Text = "-----------------------";
            room_type.Text = "-----------------------";
            room_status.Text = "-----------------------";
            room_price.Text = "-----------------------";
            total_price.Text = "0.00";
            room_price.Text = "0.00";

            room_image.Image = null;
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            clearFields();
        }
    }
}
