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
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("Database connection established successfully!");
                SqlCommand sqlCommand = new SqlCommand("DELETE from client WHERE id=@id", connection);

                sqlCommand.Parameters.AddWithValue("@id", textBox6.Text);
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
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("Database connection established successfully!");
                SqlCommand sqlCommand = new SqlCommand("UPDATE client Set ucn=@egn, first_name=@fname, last_name=@lname, address=@adres, id_number=@idnum WHERE id=@id;", connection);

                sqlCommand.Parameters.AddWithValue("@id", textBox6.Text);
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
    }
}
