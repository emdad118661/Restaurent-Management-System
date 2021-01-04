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
    public partial class Customerinfo : Form
    {
        public Customerinfo()
        {
            InitializeComponent();
        }

        MyConnection db = new MyConnection();
        SqlDataAdapter ab;
        DataTable dt;
        private int customerId;

        private void Form1_Load(object sender, EventArgs e)
        {
            GetCustomersRecord();
        }

        private void GetCustomersRecord()
        {
            SqlCommand cmd = new SqlCommand("select * from Customers", db.con);
            DataTable dt = new DataTable();
            db.con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            db.con.Close();
            CustomerDataGridView.DataSource = dt;

        }

        private void Customerinfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CustomerDataGridView.DataSource = dt;
        }

        private void Insert_Click(object sender, EventArgs e)
        {

            if (IsValid())
            {

                SqlCommand cmd = new SqlCommand("INSERT INTO Customers VALUES(@name,@address,@mobile)", db.con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@name", textCustomerName.Text);
                cmd.Parameters.AddWithValue("@address", textCustomerAddress.Text);
                cmd.Parameters.AddWithValue("@mobile", textCustomerMobile.Text);


                db.con.Open();
                cmd.ExecuteNonQuery();
                db.con.Close();
                MessageBox.Show("New Customer is Successfully inserterd", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);


                GetCustomersRecord();
                ResetButton();

            }

        }

        private bool IsValid()
        {
            if (textCustomerName.Text == string.Empty)
            {
                MessageBox.Show("Customer Name is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;

        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (customerId > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE Customers SET name=@name,address=@address,mobile=@mobile WHERE customerid=@customerid", db.con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@name", textCustomerName.Text);
                cmd.Parameters.AddWithValue("@address", textCustomerAddress.Text);
                cmd.Parameters.AddWithValue("@mobile", textCustomerMobile.Text);
                cmd.Parameters.AddWithValue("@customerid", this.customerId);

                db.con.Open();
                cmd.ExecuteNonQuery();
                db.con.Close();
                MessageBox.Show("Customer Information is Successfully Updated", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetCustomersRecord();
                ResetButton();


            }
            else
            {
                MessageBox.Show("please, Select to Update Customer Information", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomerDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            customerId = Convert.ToInt32(CustomerDataGridView.SelectedRows[0].Cells[0].Value);
            textCustomerName.Text = CustomerDataGridView.SelectedRows[0].Cells[1].Value.ToString();

            textCustomerAddress.Text = CustomerDataGridView.SelectedRows[0].Cells[2].Value.ToString();
           

            textCustomerMobile.Text = CustomerDataGridView.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ResetButton();

        }

        private void ResetButton()
        {
            customerId = 0;
            textCustomerName.Clear();
            textCustomerAddress.Clear();
            textCustomerMobile.Clear();

            textCustomerName.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (customerId > 0)
            {

                SqlCommand cmd = new SqlCommand("DELETE FROM Customers WHERE CustomerId=@customerid", db.con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@customerid", this.customerId);

                db.con.Open();
                cmd.ExecuteNonQuery();
                db.con.Close();
                MessageBox.Show("Customer Information is Successfully Deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetCustomersRecord();
                ResetButton();
            }
            else
            {
                MessageBox.Show("please, Select to Delete Customer Information", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Search_TextChanged(object sender, EventArgs e)
        {
            SearchData(Search.Text);
        }

        public void SearchData(string search)
        {

            db.con.Open();
            string query = "select * from Customers where Name like '%" + search + "%'";

            ab = new SqlDataAdapter(query, db.con);
            dt = new DataTable();
            ab.Fill(dt);
            CustomerDataGridView.DataSource = dt;
            db.con.Close();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard s = new Dashboard ();
            s.Show();
        }
    }
}
