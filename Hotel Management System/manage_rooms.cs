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
using System.IO;

namespace Hotel_Management_System
{
    public partial class manage_rooms : UserControl
    {
        private string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ADMIN\Documents\HMS-database.mdf;Integrated Security=True;Connect Timeout=30";
        private string id; // Added a private field for id

        public manage_rooms()
        {
            InitializeComponent();
            roomid_txt.ReadOnly = true; // Disable editing for the room ID text box
            displayRoomData();
            roomid_txt.Text = GenerateNewRoomID(); // Display the initial room ID
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayRoomData();
        }

        public void displayRoomData()
        {
            rooms_data rData = new rooms_data();
            List<rooms_data> listData = rData.roomsDataList();
            dataGridView1.DataSource = listData;
        }

        public bool isEmpty()
        {
            if (string.IsNullOrEmpty(roomid_txt.Text) || string.IsNullOrEmpty(roomname_txt.Text)
                || string.IsNullOrEmpty(roomprice_txt.Text) || roomtype_combo.SelectedIndex == -1
                || roomstatus_combo.SelectedIndex == -1 || roomimage_box.Image == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string GenerateNewRoomID()
        {
            string newRoomID = "RID - 0001";
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();
                    string query = "SELECT TOP 1 room_id FROM rooms ORDER BY room_id DESC";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            string lastRoomID = result.ToString();
                            string numericPart = lastRoomID.Split('-')[1].Trim();
                            int newNumericPart = int.Parse(numericPart) + 1;
                            newRoomID = $"RID - {newNumericPart:D4}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong! " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newRoomID;
        }

        private void addroom_btn_Click(object sender, EventArgs e)
        {
            if (isEmpty())
            {
                MessageBox.Show("Please fill all the blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(conn))
                    {
                        connection.Open();
                        string newRoomID = GenerateNewRoomID();

                        string checkRoomID = "SELECT room_id FROM rooms WHERE room_id = @roomID";
                        using (SqlCommand checkRID = new SqlCommand(checkRoomID, connection))
                        {
                            checkRID.Parameters.AddWithValue("@roomID", newRoomID);

                            SqlDataAdapter adapter = new SqlDataAdapter(checkRID);
                            DataTable table = new DataTable();

                            adapter.Fill(table);

                            if (table.Rows.Count > 0)
                            {
                                MessageBox.Show(newRoomID + " is existing already", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string insertData = "INSERT INTO rooms (room_id, type, room_name, price, room_image, status, date_register)" +
                                    "VALUES(@roomID, @roomType, @roomName, @roomPrice, @roomImage, @roomStatus, @dateRegister)";

                                string path = Path.Combine(@"C:\Users\ADMIN\source\repos\Hotel Management System\rooms_directory\" + newRoomID + ".jpg");

                                string directoryPath = Path.GetDirectoryName(path);

                                if (!Directory.Exists(directoryPath))
                                {
                                    Directory.CreateDirectory(directoryPath);
                                }

                                File.Copy(roomimage_box.ImageLocation, path, true);

                                using (SqlCommand cmd = new SqlCommand(insertData, connection))
                                {
                                    cmd.Parameters.AddWithValue("@roomID", newRoomID);
                                    cmd.Parameters.AddWithValue("@roomType", roomtype_combo.SelectedItem.ToString());
                                    cmd.Parameters.AddWithValue("@roomName", roomname_txt.Text.Trim());
                                    cmd.Parameters.AddWithValue("@roomPrice", roomprice_txt.Text.Trim());
                                    cmd.Parameters.AddWithValue("@roomStatus", roomstatus_combo.SelectedItem.ToString());
                                    cmd.Parameters.AddWithValue("@roomImage", path);

                                    DateTime today = DateTime.Today;
                                    cmd.Parameters.AddWithValue("@dateRegister", today);

                                    cmd.ExecuteNonQuery();
                                    clear_fields();
                                    displayRoomData(); // Refresh DataGridView

                                    MessageBox.Show("Room created successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    roomid_txt.Text = GenerateNewRoomID(); // Set the new Room ID after adding a room
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something went wrong! " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void upload_btn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog file = new OpenFileDialog();
                string imagePath = "";

                file.Filter = "Image Files (*.jpg; *.png)|*.jpg;*.png";

                if (file.ShowDialog() == DialogResult.OK)
                {
                    imagePath = file.FileName;
                    roomimage_box.ImageLocation = imagePath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateroom_btn_Click(object sender, EventArgs e)
        {
            if (isEmpty())
            {
                MessageBox.Show("Please select an item first!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using (SqlConnection connect = new SqlConnection(conn))
                    {
                        connect.Open();
                        string updateData = "UPDATE rooms SET room_id = @roomID, type = @roomType, room_name = @roomName, price = @roomPrice, room_image = @roomImage, status = @roomStatus WHERE id = @id";

                        string path = Path.Combine(@"C:\Users\ADMIN\source\repos\Hotel Management System\rooms_directory\" + roomid_txt.Text + ".jpg");

                        string directoryPath = Path.GetDirectoryName(path);

                        if (!Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                        }

                        File.Copy(roomimage_box.ImageLocation, path, true);

                        using (SqlCommand cmd = new SqlCommand(updateData, connect))
                        {
                            cmd.Parameters.AddWithValue("@roomID", roomid_txt.Text);
                            cmd.Parameters.AddWithValue("@roomType", roomtype_combo.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@roomName", roomname_txt.Text.Trim());
                            cmd.Parameters.AddWithValue("@roomPrice", roomprice_txt.Text.Trim());
                            cmd.Parameters.AddWithValue("@roomStatus", roomstatus_combo.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@roomImage", path);
                            cmd.Parameters.AddWithValue("@id", id);

                            cmd.ExecuteNonQuery();
                            displayRoomData(); // Refresh DataGridView
                            clear_fields(false); // Pass false to not clear room ID

                            MessageBox.Show("Room updated successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something went wrong! " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void deleteroom_btn_Click(object sender, EventArgs e)
        {
            if (isEmpty())
            {
                MessageBox.Show("Please select an item first!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    if (MessageBox.Show("Are you sure you want to delete ID:" + id + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (SqlConnection connect = new SqlConnection(conn))
                        {
                            connect.Open();
                            string deleteData = "DELETE FROM rooms WHERE id = @id"; // Corrected to DELETE

                            using (SqlCommand cmd = new SqlCommand(deleteData, connect))
                            {
                                cmd.Parameters.AddWithValue("@id", id);
                                cmd.ExecuteNonQuery();
                            }

                            // Check if the table is empty after deletion
                            string checkEmpty = "SELECT COUNT(*) FROM rooms";
                            using (SqlCommand cmdCheckEmpty = new SqlCommand(checkEmpty, connect))
                            {
                                int count = (int)cmdCheckEmpty.ExecuteScalar();
                                if (count == 0)
                                {
                                    roomid_txt.Text = "RID - 0001"; // Reset Room ID to RID - 0001
                                }
                            }

                            displayRoomData(); // Refresh DataGridView
                            clear_fields(false); // Pass false to not clear room ID

                            MessageBox.Show("Room deleted successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something went wrong! " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void clear_fields(bool clearRoomID = true)
        {
            // Clear all fields except the room ID text box if clearRoomID is false
            if (clearRoomID)
            {
                roomid_txt.Text = GenerateNewRoomID(); // Set Room ID to a new generated one
            }
            roomtype_combo.SelectedIndex = -1;
            roomname_txt.Text = "";
            roomprice_txt.Text = "";
            roomimage_box.Image = null;
            roomstatus_combo.SelectedIndex = -1;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                roomid_txt.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                roomtype_combo.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                roomname_txt.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                roomprice_txt.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                roomstatus_combo.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

                if (dataGridView1.Rows[e.RowIndex].Cells[5].Value != null)
                {
                    roomimage_box.Image = Image.FromFile(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                    roomimage_box.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            clear_fields(false); // Do not clear room ID
        }
    }
}
