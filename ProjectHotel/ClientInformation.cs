using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectHotel
{
    public partial class ClientInformation : Form
    {
        public ClientInformation()
        {
            InitializeComponent();
        }

        private void ClientInformation_Load(object sender, EventArgs e)
        {
            button1.Text = "Check";
        }
        public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    Console.WriteLine("Database connection established successfully!");
                    string query = @"
                    SELECT first_name,last_name,ucn,id_number
                    FROM Reservation
                    JOIN Client on reservation.client=client.id
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

        private void turnoverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Turnover turnover = new Turnover();
            this.Close();
            turnover.ShowDialog();
        }

        private void graphicalExampleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphic example = new Graphic();
            this.Close();
            example.ShowDialog();
        }
    }
}
