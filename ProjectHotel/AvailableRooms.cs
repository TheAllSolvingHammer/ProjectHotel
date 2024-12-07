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
    public partial class AvailableRooms : Form
    {
        public AvailableRooms()
        {
            InitializeComponent();
        }
        public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

        private void AvailableRooms_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT r.number, r.room_type FROM Room r WHERE NOT EXISTS (SELECT 1  FROM Reservation res WHERE res.room = r.number AND (GETDATE() BETWEEN res.start_date AND res.end_date))ORDER BY r.room_type;";
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
            Graphic example = new Graphic();
            this.Close();
            example.ShowDialog();
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
    }
}
