using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;

namespace ProjectHotel
{
    public partial class AddClientForm : Form
    {
        public AddClientForm()
        {
            InitializeComponent();
        }
        public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
        private void AddClientForm_Load(object sender, EventArgs e)
        {
            label1.Text = "EGN";
            label2.Text = "First Name";
            label3.Text = "Last Name";
            label4.Text = "Address";
            label5.Text = "ID Number";
            button1.Text = "Add";
            button2.Text = "Update";
            button3.Text = "Delete";
            label6.Text = "ID";
            label6.Enabled = false;
            textBox6.Enabled = false;
            checkBox1.Text = "Show ID's";
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToAddRows = false;
            displayData();
        }
        private void displayData()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from client", connection);
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
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO client VALUES(@egn,@fname,@lname,@adres,@idnum)", connection);


                sqlCommand.Parameters.AddWithValue("@egn", textBox1.Text);
                sqlCommand.Parameters.AddWithValue("@fname", textBox2.Text);
                sqlCommand.Parameters.AddWithValue("@lname", textBox3.Text);
                sqlCommand.Parameters.AddWithValue("@adres", textBox4.Text);
                sqlCommand.Parameters.AddWithValue("@idnum", textBox5.Text);
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



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                label6.Enabled = true;
                textBox6.Enabled = true;
            }
            else
            {
                label6.Enabled = false;
                textBox6.Enabled = false;
                textBox6.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                MessageBox.Show("Select checkbox first");
                return;
            }
            if (!validateDataInput())
            {
                return;
            }
            int result;
            if (!int.TryParse(textBox6.Text, out result))
            {
                return;
            }
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("Database connection established successfully!");
                SqlCommand sqlCommand = new SqlCommand("DELETE from client WHERE id=@id AND ucn=@egn AND first_name=@fname AND last_name=@lname AND address=@adres AND id_number=@idnum", connection);

                sqlCommand.Parameters.AddWithValue("@id", textBox6.Text);
                sqlCommand.Parameters.AddWithValue("@egn", textBox1.Text);
                sqlCommand.Parameters.AddWithValue("@fname", textBox2.Text);
                sqlCommand.Parameters.AddWithValue("@lname", textBox3.Text);
                sqlCommand.Parameters.AddWithValue("@adres", textBox4.Text);
                sqlCommand.Parameters.AddWithValue("@idnum", textBox5.Text);
                int rows = sqlCommand.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Data deleted successfully");
                }
                else
                    MessageBox.Show("Error in deleting");
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
            if (!checkBox1.Checked)
            {
                MessageBox.Show("Select checkbox first");
                return;
            }
            if (!validateDataInput())
            {
                return;
            }
            int result;
            if (!int.TryParse(textBox6.Text, out result))
            {
                return;
            }
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("Database connection established successfully!");
                SqlCommand sqlCommand = new SqlCommand("UPDATE client Set ucn=@egn, first_name=@fname, last_name=@lname, address=@adres, id_number=@idnum WHERE id=@id;", connection);

                sqlCommand.Parameters.AddWithValue("@id", result);
                sqlCommand.Parameters.AddWithValue("@egn", textBox1.Text);
                sqlCommand.Parameters.AddWithValue("@fname", textBox2.Text);
                sqlCommand.Parameters.AddWithValue("@lname", textBox3.Text);
                sqlCommand.Parameters.AddWithValue("@adres", textBox4.Text);
                sqlCommand.Parameters.AddWithValue("@idnum", textBox5.Text);
                int rows = sqlCommand.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Data updated successfully");
                }
                else
                    MessageBox.Show("Error in updating");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in db: " + ex.Message);
            }

            displayData();
        }

        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void roomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddRoomForm form = new AddRoomForm();
            this.Close();
            form.ShowDialog();
        }

        private void reservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddReservationForm form = new AddReservationForm();
            this.Close();
            form.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int columnIndex = e.ColumnIndex;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                textBox6.Text = selectedRow.Cells[0].Value.ToString();
                textBox1.Text = selectedRow.Cells[1].Value.ToString();
                textBox2.Text = selectedRow.Cells[2].Value.ToString();
                textBox3.Text = selectedRow.Cells[3].Value.ToString();
                textBox4.Text = selectedRow.Cells[4].Value.ToString();
                textBox5.Text = selectedRow.Cells[5].Value.ToString();

            }
        }
        private bool validateDataInput()
        {
            bool flag = true;
            string patternEgn = @"^\d{10}$";
            string patternID = @"^\d{9}$";
            string patternStreet = @"^[A-Za-z0-9.,\s]{1,60}$";

            string patternName = @"^[A-Z][a-z.,]{0,29}$";
            errorProvider1.Clear();
            if (!Regex.IsMatch(textBox2.Text, patternName))
            {
                errorProvider1.SetError(textBox2, "Wrong input");
                flag = false;
            }

            if (!Regex.IsMatch(textBox3.Text, patternName))
            {
                errorProvider1.SetError(textBox3, "Wrong input");
                flag = false;
            }

            if (!Regex.IsMatch(textBox1.Text, patternEgn))
            {
                errorProvider1.SetError(textBox1, "Wrong input");
                flag = false;
            }

            if (!Regex.IsMatch(textBox4.Text, patternStreet))
            {
                errorProvider1.SetError(textBox4, "Wrong Input");
                flag = false;
            }

            if (!Regex.IsMatch(textBox5.Text, patternID))
            {
                errorProvider1.SetError(textBox5, "Wrong Input");
                flag = false;
            }

            return flag;
        }

        private void availableRoomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AvailableRooms availableRooms = new AvailableRooms();
            this.Close();
            availableRooms.ShowDialog();
        }

        private void turnoverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Turnover turnover = new Turnover(); 
            this.Close();
            turnover.ShowDialog();

        }

        private void clientInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientInformation clientInformation = new ClientInformation();
            this.Close();
            clientInformation.ShowDialog();
        }

        private void graphicalExampleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphic graphic = new Graphic();
            this.Close();
            graphic.ShowDialog();
        }
    }
}
