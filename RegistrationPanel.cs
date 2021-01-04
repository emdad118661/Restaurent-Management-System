using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Resturentsystem
{
    public partial class RegistrationPanel : Form
    {
        public RegistrationPanel()
        {
            InitializeComponent();
        }

        MyConnection db = new MyConnection();

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void RegistrationPanel_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Customers VALUES(@name,@address,@mobile)", db.con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@name", CustomerName.Text);
                cmd.Parameters.AddWithValue("@address",CustomerAddress.Text);
                cmd.Parameters.AddWithValue("@mobile",CustomerMobile.Text);


                db.con.Open();
                cmd.ExecuteNonQuery();
                db.con.Close();
                MessageBox.Show("New Customer is Successfully inserterd", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

               
            }


        }

        private bool IsValid()
        {
            if (CustomerName.Text == string.Empty)
            {
                MessageBox.Show("Customer Name is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            ResetButton();
        }

        private void ResetButton()
        {
            CustomerName.Clear();
            CustomerAddress.Clear();
            CustomerMobile.Clear();
            CustomerName.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard s = new Dashboard();
            s.Show();
        }

    }
}
