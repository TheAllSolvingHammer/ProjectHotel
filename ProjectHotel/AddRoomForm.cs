using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectHotel
{
    public partial class AddRoomForm : Form
    {
        public AddRoomForm()
        {
            InitializeComponent();
        }
        public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
        private void displayData()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("Select r.number,t.room_type,r.floor,r.bed_count,r.bed_price FROM Room r INNER JOIN Type t on t.Id=r.room_type", connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                dataGridView1.DataSource = table;

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void displayCombo()
        {
            comboBox1.Items.Clear();
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand myCommand = new SqlCommand("SELECT * from TYPE", connection);
                myCommand.Connection.Open();
                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                int i = 0;
                while (myReader.Read())
                {

                    comboBox1.Items.Add((myReader[1]));


                }


                myCommand.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddClientForm form = new AddClientForm();
            this.Close();
            form.ShowDialog();
        }

        private void roomToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddReservationForm form = new AddReservationForm();
            this.Close();
            form.ShowDialog();
        }

        private void AddRoomForm_Load(object sender, EventArgs e)
        {
            label1.Text = "Room Number";
            label2.Text = "Room type";
            label3.Text = "Floor";
            label4.Text = "Number of beds";
            label5.Text = "Price";
            button1.Text = "Add";
            button2.Text = "Update";
            button3.Text = "Delete";
            displayData();
            displayCombo();
            comboBox1.SelectedIndex = 0;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.MultiSelect = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!validateDataInput())
            {
                return;
            }
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("Database connection established successfully!");
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO room VALUES(@number,@roomtype,@floor,@beds,@price)", connection);
                sqlCommand.Parameters.AddWithValue("@number", textBox1.Text);
                sqlCommand.Parameters.AddWithValue("@roomtype", comboBox1.SelectedIndex + 1);

                sqlCommand.Parameters.AddWithValue("@floor", textBox2.Text);
                sqlCommand.Parameters.AddWithValue("@beds", textBox3.Text);
                sqlCommand.Parameters.AddWithValue("@price", textBox4.Text);
                int rows = sqlCommand.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Data added successfully");
                }
                else
                    MessageBox.Show("Error in inserting");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in db: " + ex.Message);
            }

            displayData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!validateDataInput())
            {
                return;
            }
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("Database connection established successfully!");
                SqlCommand sqlCommand = new SqlCommand("UPDATE room SET room_type=@roomtype, floor=@floor, bed_count=@beds, bed_price=@price WHERE number=@number", connection);
                sqlCommand.Parameters.AddWithValue("@number", textBox1.Text);
                sqlCommand.Parameters.AddWithValue("@roomtype", comboBox1.SelectedIndex + 1);

                sqlCommand.Parameters.AddWithValue("@floor", textBox2.Text);
                sqlCommand.Parameters.AddWithValue("@beds", textBox3.Text);
                sqlCommand.Parameters.AddWithValue("@price", textBox4.Text);
                int rows = sqlCommand.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Data updated successfully");
                }
                else
                    MessageBox.Show("Error in Updating");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in db: " + ex.Message);
            }

            displayData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!validateDataInput())
            {
                return;
            }
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("Database connection established successfully!");
                SqlCommand sqlCommand = new SqlCommand("DELETE FROM room WHERE number=@number AND room_type=@roomtype AND floor=@floor AND bed_count=@beds AND bed_price=@price", connection);
                sqlCommand.Parameters.AddWithValue("@number", textBox1.Text);
                sqlCommand.Parameters.AddWithValue("@roomtype", comboBox1.SelectedIndex + 1);

                sqlCommand.Parameters.AddWithValue("@floor", textBox2.Text);
                sqlCommand.Parameters.AddWithValue("@beds", textBox3.Text);
                sqlCommand.Parameters.AddWithValue("@price", textBox4.Text);
                int rows = sqlCommand.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Data deleted successfully");
                }
                else
                    MessageBox.Show("Error in Deleting");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in db: " + ex.Message);
            }

            displayData();
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int columnIndex = e.ColumnIndex;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                textBox1.Text = selectedRow.Cells[0].Value.ToString();
                comboBox1.SelectedIndex = comboBox1.FindString(selectedRow.Cells[1].Value.ToString());
                textBox2.Text = selectedRow.Cells[2].Value.ToString();
                textBox3.Text = selectedRow.Cells[3].Value.ToString();
                textBox4.Text = selectedRow.Cells[4].Value.ToString();

            }
        }
        private bool validateDataInput()
        {
            bool flag = true;
            string patternNumber = @"^\d{3}$";
            string patternType = @"^[1-4]{1}$";
            string patternFloorAndCount = @"^\d+$";
            string patternPrice = @"^\d+$";

          
            errorProvider1.Clear();
            if (!Regex.IsMatch(textBox1.Text, patternNumber))
            {
                errorProvider1.SetError(textBox2, "Wrong input");
                flag = false;
            }

            if (!Regex.IsMatch(textBox2.Text, patternType))
            {
                errorProvider1.SetError(textBox3, "Wrong input");
                flag = false;
            }

            if (!Regex.IsMatch(textBox3.Text, patternFloorAndCount))
            {
                errorProvider1.SetError(textBox1, "Wrong input");
                flag = false;
            }

            if (!Regex.IsMatch(textBox4.Text, patternPrice))
            {
                errorProvider1.SetError(textBox4, "Wrong Input");
                flag = false;
            }

            return flag;
        }
    }
}
