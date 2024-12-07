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
using System.Windows.Forms.DataVisualization.Charting;

namespace ProjectHotel
{
    public partial class Graphic : Form
    {
        public Graphic()
        {
            InitializeComponent();
        }
        public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

        private void Graphic_Load(object sender, EventArgs e)
        {
            button1.Text = "Visialize";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT  room, MONTH(start_date) AS Month,COUNT(*) AS ReservationCount " +
               "FROM Reservation GROUP BY room, MONTH(start_date)ORDER BY room, Month;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataTable dt = ds.Tables[0];
                chart1.DataSource = dt;
                chart1.Series.Clear();
                chart1.Series.Add("ReservationCount");

                chart1.Series["ReservationCount"].XValueMember = "Month"; // Set X values to Month
                chart1.Series["ReservationCount"].YValueMembers = "ReservationCount"; // Set Y values to ReservationCount


                chart1.ChartAreas[0].AxisX.Title = "Month";
                chart1.ChartAreas[0].AxisY.Title = "Reservation Count";

                chart1.Titles.Add("Reservations by Room and Month");
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

        private void clientInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientInformation clientInformation = new ClientInformation();
            this.Close();
            clientInformation.ShowDialog();
        }
    }
}
