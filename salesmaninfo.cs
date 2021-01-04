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
    public partial class salesmaninfo : Form
    {
        public salesmaninfo()
        {
            InitializeComponent();
        }

        MyConnection db = new MyConnection();
        SqlDataAdapter ab;
        DataTable dt;

        public int salesmanId;

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();

        }

        private void salesmaninfo_Load(object sender, EventArgs e)
        {
            GetSalesmanRecord();
        }


        private void GetSalesmanRecord()
        {
            SqlCommand cmd = new SqlCommand("select * from login", db.con);
            DataTable dt = new DataTable();
            db.con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            db.con.Close();
            SalesmanDataGridView.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {

                SqlCommand cmd = new SqlCommand("INSERT INTO  login VALUES(@name,@username,@password,@type,@address,@mobile)", db.con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@name", textSalesmanName.Text);
                cmd.Parameters.AddWithValue("@username", textName.Text);
                cmd.Parameters.AddWithValue("@password", textPassword.Text);
                cmd.Parameters.AddWithValue("@type", textType.Text);
                cmd.Parameters.AddWithValue("@address", textSalesmanAddress.Text);
                cmd.Parameters.AddWithValue("@mobile", textSalesmanMobile.Text);
                cmd.Parameters.AddWithValue("@Id", this.salesmanId);


                db.con.Open();
                cmd.ExecuteNonQuery();
                db.con.Close();
                MessageBox.Show("New SalesMan is Successfully inserterd", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetSalesmanRecord();
                ResetButton();

            }



        }

        private bool IsValid()
        {
            if (textSalesmanName.Text == string.Empty)
            {
                MessageBox.Show("SalesMan Name is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ResetButton();
        }

        private void ResetButton()
        {
            salesmanId = 0;
            textSalesmanName.Clear();
            textName.Clear();
            textPassword.Clear();
            textSalesmanAddress.Clear();
            textSalesmanMobile.Clear();

            textSalesmanName.Focus();
        }

       

        private void SalesmanDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            salesmanId = Convert.ToInt32(SalesmanDataGridView.SelectedRows[0].Cells[0].Value);
            textSalesmanName.Text = SalesmanDataGridView.SelectedRows[0].Cells[1].Value.ToString();

            textName.Text = SalesmanDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            textPassword.Text = SalesmanDataGridView.SelectedRows[0].Cells[3].Value.ToString();
            textType.Text = SalesmanDataGridView.SelectedRows[0].Cells[4].Value.ToString();

            textSalesmanAddress.Text = SalesmanDataGridView.SelectedRows[0].Cells[5].Value.ToString();

            textSalesmanMobile.Text = SalesmanDataGridView.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (salesmanId > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE login SET name=@name,username=@username,password=@password,type=@type,address=@address,mobile=@mobile WHERE id=@id", db.con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@name", textSalesmanName.Text);
                cmd.Parameters.AddWithValue("@username", textName.Text);
                cmd.Parameters.AddWithValue("@password", textPassword.Text);
                cmd.Parameters.AddWithValue("@type", textType.Text);
                cmd.Parameters.AddWithValue("@address", textSalesmanAddress.Text);
                cmd.Parameters.AddWithValue("@mobile", textSalesmanMobile.Text);
                cmd.Parameters.AddWithValue("@id", this.salesmanId);


                db.con.Open();
                cmd.ExecuteNonQuery();
                db.con.Close();
                MessageBox.Show("SalesMan Information is Successfully Updated", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetSalesmanRecord();
                ResetButton();

            }
            else
            {
                MessageBox.Show("please, Select to Update SalesMan Information", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (salesmanId > 0)
            {

                SqlCommand cmd = new SqlCommand("DELETE FROM login WHERE id=@id", db.con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@id", this.salesmanId);

                db.con.Open();
                cmd.ExecuteNonQuery();
                db.con.Close();
                MessageBox.Show("Salesman Information is Successfully Deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetSalesmanRecord();
                ResetButton();
            }
            else
            {
                MessageBox.Show("please, Select to Delete Salesman Information", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Search_TextChanged(object sender, EventArgs e)
        {
            SearchData(Search.Text);
        }

        public void SearchData(string search)
        {

            db.con.Open();
            string query = "select * from login where Name like '%" + search + "%'";

            ab = new SqlDataAdapter(query, db.con);
            dt = new DataTable();
            ab.Fill(dt);
            SalesmanDataGridView.DataSource = dt;
            db.con.Close();



        }

        private void SalesmanDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       /* private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Foods d = new Foods();
            d.Show();

        }*/

        private void button6_Click(object sender, EventArgs e)
        {

            this.Hide();
            Dashboard s = new Dashboard();
            s.Show();

        }

      /*  private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Managerinvoice d = new Managerinvoice();
            d.Show();
        }*/
    }
}
