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
    public partial class Foods : Form
    {
        public Foods()
        {
            InitializeComponent();
        }

        MyConnection db = new MyConnection();
        SqlDataAdapter ab;
        DataTable dt;

        public int foodId;

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Foods_Load(object sender, EventArgs e)
        {
            GetFoodList();
        }

        private void GetFoodList()
        {
            SqlCommand cmd = new SqlCommand("select * from foods", db.con);

            DataTable dt = new DataTable();

            db.con.Open();



            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            db.con.Close();

            FoodsGridView.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO foods VALUES(@foodname,@price)", db.con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@foodname", textFoodName.Text);
                cmd.Parameters.AddWithValue("@price", textFoodPrice.Text);



                db.con.Open();
                cmd.ExecuteNonQuery();
                db.con.Close();
                MessageBox.Show("New food is Successfully inserterd", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetFoodList();
                ResetButton();
            }

        }

        private bool IsValid()
        {
            if (textFoodName.Text == string.Empty)
            {
                MessageBox.Show("Food Name is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            foodId = 0;
            textFoodName.Clear();
            textFoodPrice.Clear();


            textFoodName.Focus();
        }

        private void FoodsGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foodId = Convert.ToInt32(FoodsGridView.SelectedRows[0].Cells[0].Value);
            textFoodName.Text = FoodsGridView.SelectedRows[0].Cells[1].Value.ToString();

            textFoodPrice.Text = FoodsGridView.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (foodId > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE foods SET foodname=@foodname,price=@price WHERE foodid=@foodid", db.con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@foodname", textFoodName.Text);
                cmd.Parameters.AddWithValue("@price", textFoodPrice.Text);
                cmd.Parameters.AddWithValue("@foodid", this.foodId);



                db.con.Open();
                cmd.ExecuteNonQuery();
                db.con.Close();
                MessageBox.Show("New food is Successfully Updated", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetFoodList();
                ResetButton();

            }
            else
            {
                MessageBox.Show("please, Select to Update food Information", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (foodId > 0)
            {

                SqlCommand cmd = new SqlCommand("DELETE FROM foods WHERE foodid=@foodid", db.con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@foodid", this.foodId);

                db.con.Open();
                cmd.ExecuteNonQuery();
                db.con.Close();
                MessageBox.Show("Food-item Information is Successfully Deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetFoodList();
                ResetButton();
            }
            else
            {
                MessageBox.Show("please, Select to Delete Food-item Information", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Search_TextChanged(object sender, EventArgs e)
        {
            SearchData(Search.Text);
        }

        private void SearchData(string search)
        {

            db.con.Open();
            string query = "select * from foods where foodname like '%" + search + "%'";

            ab = new SqlDataAdapter(query, db.con);
            dt = new DataTable();
            ab.Fill(dt);
            FoodsGridView.DataSource = dt;
            db.con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard s = new Dashboard();
            s.Show();
        }
    }

}
