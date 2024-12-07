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
    }
}
