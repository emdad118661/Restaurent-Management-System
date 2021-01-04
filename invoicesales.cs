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
    public partial class invoicesales : Form
    {
        public invoicesales()
        {
            InitializeComponent();
        }

        MyConnection db = new MyConnection();
        DataTable dt;
        SqlDataAdapter ab;
        public int foodId;

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void invoicesales_Load(object sender, EventArgs e)
        {
            GetFoodList();
            GetorderList();
        }

        private void GetorderList()
        {
            SqlCommand cmd = new SqlCommand("select * from invoicetable", db.con);

            DataTable dt = new DataTable();

            db.con.Open();



            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            db.con.Close();

            invoicedataGridView1.DataSource = dt;
        }

        private void GetFoodList()
        {

            SqlCommand cmd = new SqlCommand("select * from foods", db.con);

            DataTable dt = new DataTable();

            db.con.Open();



            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            db.con.Close();

            FoodListDataGridView.DataSource = dt;
        }

        private void FoodListDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foodId = Convert.ToInt32(FoodListDataGridView.SelectedRows[0].Cells[0].Value);
            textFoodName.Text = FoodListDataGridView.SelectedRows[0].Cells[1].Value.ToString();

            textFoodPrice.Text = FoodListDataGridView.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void invoicedataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foodId = Convert.ToInt32(invoicedataGridView1.SelectedRows[0].Cells[0].Value);
            textFoodName.Text = invoicedataGridView1.SelectedRows[0].Cells[1].Value.ToString();

            textFoodPrice.Text = invoicedataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textFoodQuantity.Text = invoicedataGridView1.SelectedRows[0].Cells[3].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {

                int price, quantity, total, discount, nettotal, subtotal;

                quantity = int.Parse(textFoodQuantity.Text);
                price = int.Parse(textFoodPrice.Text);
                discount = int.Parse(textDiscount.Text);
                subtotal = int.Parse(textsubtotal.Text);
                total = quantity * price;
                textTotal.Text = "" + total;
                nettotal = total - discount;
                textnettotal.Text = "" + nettotal;
                subtotal = subtotal + nettotal;
                textsubtotal.Text = "" + subtotal;

                SqlCommand cmd = new SqlCommand("INSERT INTO invoicetable VALUES(@foodnames,@foodprice,@quantity,@totalprice,@discount,@after_discount)", db.con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@foodnames", textFoodName.Text);
                cmd.Parameters.AddWithValue("@foodprice", textFoodPrice.Text);
                cmd.Parameters.AddWithValue("@quantity", textFoodQuantity.Text);

                cmd.Parameters.AddWithValue("@totalprice", textTotal.Text);
                cmd.Parameters.AddWithValue("@discount", textDiscount.Text);
                cmd.Parameters.AddWithValue("@after_discount", textnettotal.Text);





                db.con.Open();
                cmd.ExecuteNonQuery();
                db.con.Close();
                MessageBox.Show("New food is Successfully inserterd", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetorderList();
                ResetButton();
            }
        }

        private void ResetButton()
        {
            foodId = 0;
            textFoodName.Clear();
            textFoodPrice.Clear();
            textFoodQuantity.Clear();
            textTotal.Clear();
            textnettotal.Clear();
            textDiscount.Clear();

            textFoodName.Focus();

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

        private void button2_Click(object sender, EventArgs e)
        {

            if (foodId > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE invoicetable SET foodnames=@foodnames,quantity=@quantity WHERE id=@id", db.con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@foodnames", textFoodName.Text);
                cmd.Parameters.AddWithValue("@quantity", textFoodQuantity.Text);
                cmd.Parameters.AddWithValue("@id", this.foodId);




                db.con.Open();
                cmd.ExecuteNonQuery();
                db.con.Close();
                MessageBox.Show("New food is Successfully Updated", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetorderList();
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

                SqlCommand cmd = new SqlCommand("DELETE FROM invoicetable WHERE id=@id", db.con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@id", this.foodId);

                db.con.Open();
                cmd.ExecuteNonQuery();
                db.con.Close();
                MessageBox.Show("Food  Information is Successfully Deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetorderList();
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
            FoodListDataGridView.DataSource = dt;
            db.con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ResetButton();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textsubtotal.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard s = new Dashboard();
            s.Show();
        }
    }
}
