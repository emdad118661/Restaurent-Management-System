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
    public partial class Managerinvoice : Form
    {
        public Managerinvoice()
        {
            InitializeComponent();
        }
        MyConnection db = new MyConnection();
        SqlDataAdapter ab;
        DataTable dt;

        private void Managerinvoice_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Managerinvoice_Load(object sender, EventArgs e)
        {
            GetInvoiceRecord();
        }

        private void GetInvoiceRecord()
        {
            SqlCommand cmd = new SqlCommand("select * from invoicetable", db.con);

            DataTable dt = new DataTable();

            db.con.Open();



            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            db.con.Close();

            ManagerinvoiceGridView.DataSource = dt;

        }

        private void ManagerinvoiceGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Search_TextChanged(object sender, EventArgs e)
        {
            SearchData(Search.Text);
        }

        private void SearchData(string search)
        {
            db.con.Open();
            string query = "select * from invoicetable where foodnames like '%" + search + "%'";

            ab = new SqlDataAdapter(query, db.con);
            dt = new DataTable();
            ab.Fill(dt);
            ManagerinvoiceGridView.DataSource = dt;
            db.con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard s = new Dashboard();
            s.Show();
        }
    }
}
