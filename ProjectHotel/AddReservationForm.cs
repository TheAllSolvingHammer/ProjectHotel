using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectHotel
{
    public partial class AddReservationForm : Form
    {
        public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
        private Dictionary<int, String> clientMap;
        public AddReservationForm()
        {
            InitializeComponent();
            clientMap = new Dictionary<int, String>();
        }

        private void displayData()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("Select r.Id,r.issue_date,c.first_name + ' ' + c.last_name as client_names ,r.room,r.start_date,r.end_date FROM Reservation r INNER JOIN Client c on c.Id=r.client ", connection);
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
            AddRoomForm form = new AddRoomForm();
            this.Close();
            form.ShowDialog();
        }

        private void reservationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AddReservationForm_Load(object sender, EventArgs e)
        {
            displayCombo();
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";
            displayCombo2();
            label1.Text = "ID";
            label2.Text = "Issue Date";
            label3.Text = "Client";
            label4.Text = "Room";
            label5.Text = "Start Date";
            label6.Text = "End Date";
            checkBox1.Text = "ID enable";
            button1.Text = "Add";
            button2.Text = "Update";
            button3.Text = "Delete";
            checkBox1.Checked = false;
            textBox1.Enabled = false;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToAddRows = false;
            displayData();

        }
        private void displayCombo()
        {
            comboBox1.Items.Clear();
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand myCommand = new SqlCommand("SELECT * from CLIENT", connection);
                myCommand.Connection.Open();
                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (myReader.Read())
                {
                    String name = (String)myReader[2] + " " + (String)myReader[3];
                    int id = (int)myReader[0];
                    clientMap.Add(id, name);
                    comboBox1.Items.Add(new KeyValuePair<int, string>(id, name));
                }
                myCommand.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void displayCombo2()
        {
            comboBox2.Items.Clear();
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand myCommand = new SqlCommand("SELECT * from ROOM", connection);
                myCommand.Connection.Open();
                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (myReader.Read())
                {

                    int id = (int)myReader[0];
                    comboBox2.Items.Add(id);

                }
                myCommand.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                label1.Enabled = true;
                textBox1.Enabled = true;
            }
            else
            {
                label1.Enabled = false;
                textBox1.Enabled = false;
                textBox1.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                MessageBox.Show("Let the application handle the creating of reservation ID");
                return;
            }
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Select combo boxes");
                return;
            }
            if (dateTimePicker1.Value > dateTimePicker2.Value && dateTimePicker2.Value > dateTimePicker3.Value)
            {
                MessageBox.Show("Error in dates ");
                return;
            }
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("Database connection established successfully!");
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO Reservation VALUES(@issue,@client,@room,@start,@end)", connection);
                sqlCommand.Parameters.AddWithValue("@issue", dateTimePicker1.Value);
                sqlCommand.Parameters.AddWithValue("@client", ((KeyValuePair<int, string>)comboBox1.SelectedItem).Key);
                sqlCommand.Parameters.AddWithValue("@room", comboBox2.SelectedItem);
                sqlCommand.Parameters.AddWithValue("@start", dateTimePicker2.Value);
                sqlCommand.Parameters.AddWithValue("@end", dateTimePicker3.Value);
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
            if (!checkBox1.Checked)
            {
                MessageBox.Show("Select Checkbox first");
                return;
            }
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Select combo boxes");
                return;
            }
            if (dateTimePicker1.Value > dateTimePicker2.Value && dateTimePicker2.Value > dateTimePicker3.Value)
            {
                MessageBox.Show("Error in dates ");
                return;
            }
            int result;
            if (!int.TryParse(textBox1.Text, out result))
            {
                MessageBox.Show("Error in obtaining the id");
            }
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("Database connection established successfully!");
                SqlCommand sqlCommand = new SqlCommand("UPDATE Reservation SET issue_date=@issue,client=@client,room=@room,start_date=@start,end_date=@end WHERE Id=@id", connection);
                sqlCommand.Parameters.AddWithValue("@Id", result);
                sqlCommand.Parameters.AddWithValue("@issue", dateTimePicker1.Value);
                sqlCommand.Parameters.AddWithValue("@client", ((KeyValuePair<int, string>)comboBox1.SelectedItem).Key);
                sqlCommand.Parameters.AddWithValue("@room", comboBox2.SelectedItem);
                sqlCommand.Parameters.AddWithValue("@start", dateTimePicker2.Value);
                sqlCommand.Parameters.AddWithValue("@end", dateTimePicker3.Value);
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                MessageBox.Show("Select Checkbox first");
                return;
            }
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Select combo boxes");
                return;
            }
            if (dateTimePicker1.Value > dateTimePicker2.Value && dateTimePicker2.Value > dateTimePicker3.Value)
            {
                MessageBox.Show("Error in dates ");
                return;
            }
            int result;
            if (!int.TryParse(textBox1.Text, out result))
            {
                MessageBox.Show("Error in obtaining the id");
            }
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("Database connection established successfully!");
                SqlCommand sqlCommand = new SqlCommand("DELETE FROM Reservation WHERE Id=@id AND issue_date=@issue AND client=@client AND room=@room AND start_date=@start AND end_date=@end", connection);
                sqlCommand.Parameters.AddWithValue("@Id", result);
                sqlCommand.Parameters.AddWithValue("@issue", dateTimePicker1.Value);
                sqlCommand.Parameters.AddWithValue("@client", ((KeyValuePair<int, string>)comboBox1.SelectedItem).Key);
                sqlCommand.Parameters.AddWithValue("@room", comboBox2.SelectedItem);
                sqlCommand.Parameters.AddWithValue("@start", dateTimePicker2.Value);
                sqlCommand.Parameters.AddWithValue("@end", dateTimePicker3.Value);
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

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int columnIndex = e.ColumnIndex;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                textBox1.Text = selectedRow.Cells[0].Value.ToString();
                dateTimePicker1.Value = DateTime.Parse(selectedRow.Cells[1].Value.ToString());
                comboBox1.SelectedIndex = comboBox1.FindString(selectedRow.Cells[2].Value.ToString());
                comboBox2.SelectedIndex = comboBox2.FindString(selectedRow.Cells[3].Value.ToString());
                dateTimePicker2.Value = DateTime.Parse(selectedRow.Cells[4].Value.ToString());
                dateTimePicker3.Value = DateTime.Parse(selectedRow.Cells[5].Value.ToString());

            }
        }

        private void availableRoomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AvailableRooms form = new AvailableRooms();
            this.Close();
            form.ShowDialog();
        }

        private void turnoverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Turnover from = new Turnover();
            this.Close();
            from.ShowDialog();
        }

        private void clientInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientInformation form = new ClientInformation();
            this.Close();
            form.ShowDialog();
        }

        private void graphicalExampleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphic example = new Graphic();
            this.Close();
            example.ShowDialog();
        }
    }
}
