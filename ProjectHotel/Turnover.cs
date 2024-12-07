using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectHotel
{
    public partial class Turnover : Form
    {
        public Turnover()
        {
            InitializeComponent();
        }

        private void Turnover_Load(object sender, EventArgs e)
        {
            label1.Text = "Choose a time period";
            button1.Text = "Za Den";
            button2.Text = "Za mesec";
            button3.Text = "Last 3 months";
            button4.Text = "Last 6 months";
            button5.Text = "Za godina";
        }
        public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
        private void button1_Click(object sender, EventArgs e)
        {//den
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    Console.WriteLine("Database connection established successfully!");
                    string query = "SELECT * FROM Reservation WHERE start_date = @inputDate AND end_date = @inputDate";
                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    sqlCommand.Parameters.AddWithValue("@inputDate", dateTimePicker1.Value.Date);
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in db: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //mesec
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    Console.WriteLine("Database connection established successfully!");
                    string query = "SELECT * FROM Reservation WHERE (MONTH(start_date) = @selectedMonth AND YEAR(start_date) = @selectedYear) AND(MONTH(end_date) = @selectedMonth AND YEAR(end_date) = @selectedYear)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@selectedMonth", dateTimePicker2.Value.Month);
                    command.Parameters.AddWithValue("@selectedYear", dateTimePicker2.Value.Year);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in db: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //3 months
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    Console.WriteLine("Database connection established successfully!");
                    string query = @"
        SELECT * 
        FROM Reservation
        WHERE 
            (start_date BETWEEN DATEADD(MONTH, -3, GETDATE()) AND GETDATE()) 
            OR 
            (end_date BETWEEN DATEADD(MONTH, -3, GETDATE()) AND GETDATE())
            OR
            (start_date <= GETDATE() AND end_date >= DATEADD(MONTH, -3, GETDATE()))";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in db: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //6months
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    Console.WriteLine("Database connection established successfully!");
                    string query = @"
        SELECT * 
        FROM Reservation
        WHERE 
            (start_date BETWEEN DATEADD(MONTH, -6, GETDATE()) AND GETDATE()) 
            OR 
            (end_date BETWEEN DATEADD(MONTH, -6, GETDATE()) AND GETDATE())
            OR
            (start_date <= GETDATE() AND end_date >= DATEADD(MONTH, -6, GETDATE()))";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in db: " + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    Console.WriteLine("Database connection established successfully!");
                    string query = @"
                    SELECT * 
                    FROM Reservation
                    WHERE 
                    (start_date BETWEEN DATEADD(MONTH, -12, GETDATE()) AND GETDATE()) 
                    OR 
                    (end_date BETWEEN DATEADD(MONTH, -12, GETDATE()) AND GETDATE())
                    OR
                    (start_date <= GETDATE() AND end_date >= DATEADD(MONTH, -12, GETDATE()))";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in db: " + ex.Message);
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
            AddReservationForm form = new AddReservationForm();
            this.Close();
            form.ShowDialog();

        }

        private void availableRoomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AvailableRooms availableRooms = new AvailableRooms();
            this.Close();
            availableRooms.ShowDialog();
        }

        private void clientInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientInformation clientInformation = new ClientInformation();
            this.Close();
            clientInformation.ShowDialog();
        }

        private void graphicalExampleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphic example = new Graphic();
            this.Close();
            example.ShowDialog();


        }
    }
}
