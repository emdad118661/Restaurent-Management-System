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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        MyConnection db = new MyConnection();
        private void login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (db.con)
                {
                    SqlCommand cmd = new SqlCommand("sp_resturent_login", db.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    db.con.Open();
                    cmd.Parameters.AddWithValue("@uname", textName.Text);
                    cmd.Parameters.AddWithValue("@upass", textPassword.Text);
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        rd.Read();
                        if (rd[4].ToString() == "Manager")
                        {
                            MyConnection.type = "M";
                        }
                        else if (rd[4].ToString() == "Salesman")
                        {
                            MyConnection.type = "S";
                        }
                        Dashboard d = new Dashboard();
                        d.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Error Login");
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid input..Please enter your valid username & password");
            }
        }

        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
