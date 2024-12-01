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
            button1.Text = "Add Client";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("Database connection established successfully!");
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO client VALUES(@egn,@fname,@lname,@adres,@idnum)",connection);


                sqlCommand.Parameters.AddWithValue("@egn", textBox1.Text);
                sqlCommand.Parameters.AddWithValue("@fname", textBox2.Text);
                sqlCommand.Parameters.AddWithValue("@lname", textBox3.Text);
                sqlCommand.Parameters.AddWithValue("@adres", textBox4.Text);
                sqlCommand.Parameters.AddWithValue("@idnum", textBox5.Text);
                int rows = sqlCommand.ExecuteNonQuery();
                if (rows>0)
                {
                    MessageBox.Show("Data added successfully");
                }
                else
                    MessageBox.Show("Error in inserting");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in db: "+ex.Message);
            }
            

        }
    }
}
