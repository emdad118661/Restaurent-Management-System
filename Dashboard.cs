using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Resturentsystem
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        MyConnection db = new MyConnection();

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

      

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customerinfo c = new Customerinfo();
            c.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            salesmaninfo s = new salesmaninfo();
            s.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Foods f = new Foods();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Managerinvoice m = new Managerinvoice();
            m.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            invoicesales i = new invoicesales();
            i.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            login l = new login();
            l.Show();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            if (MyConnection.type == "M")
            {

                button1.Visible = true;
                button6.Visible = true;
                button7.Visible = false;
                button4.Visible = true;
                button2.Visible = true;

            }
            else if (MyConnection.type == "S")
            {

                button1.Visible = false;
                button6.Visible = false;
                button7.Visible = true;
                button4.Visible = false;
                button2.Visible = true;

            }


        }

        /* private void button8_Click(object sender, EventArgs e)
         {
             this.Hide();
             RegistrationPanel s = new RegistrationPanel();
             s.Show();
         }*/
    }
}
