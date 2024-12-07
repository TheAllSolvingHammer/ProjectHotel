namespace ProjectHotel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = "Info";
        }

        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddClientForm form = new AddClientForm();
            form.ShowDialog();

        }

        private void roomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddRoomForm form = new AddRoomForm();
            form.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void reservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddReservationForm form = new AddReservationForm();
            form.ShowDialog();
        }

        private void turnoverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Turnover turnover = new Turnover();
            turnover.Show();
        }

        private void clientInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientInformation clientInformation = new ClientInformation();
            clientInformation.Show();
        }

        private void graphicalExampleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphic graphic = new Graphic();
            graphic.Show();
        }

        private void availableRoomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AvailableRooms availableRooms = new AvailableRooms();
            availableRooms.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Credits to the developers "+ Environment.NewLine + "Yordan Simeonov "+ Environment.NewLine + "Lachezar Radushev");
        }
    }
}
