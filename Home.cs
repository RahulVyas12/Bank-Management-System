using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_Management_System
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Balance bal = new Balance();
            bal.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MiniStatement Min = new MiniStatement();
            Min.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {
            AccNumLbl.Text = "Account Number:" + Login.accountNum;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Deposite dep = new Deposite();
            dep.Show();
            this.Hide();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ChangePIN cp = new ChangePIN();
            cp.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Withdraw wd = new Withdraw();
            wd.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FastCash fc = new FastCash();
            fc.Show();
            this.Hide();
        }
    }
}
