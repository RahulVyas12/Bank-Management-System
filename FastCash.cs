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

namespace Bank_Management_System
{
    public partial class FastCash : Form
    {
        public FastCash()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\.net\24SOEIT13021(RAHUL)\Bank-Management-System\ATMDB.mdf;Integrated Security=True");
        string Acc = Login.accountNum;
        int balance, newBalance;

        public void getBalance()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Balance from AccountTbl where AccNum='" + Acc + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            BalanceLbl.Text = "Balance RS: " + dt.Rows[0][0].ToString();
            balance = Convert.ToInt32(dt.Rows[0][0].ToString());
            con.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (balance < 100)
            {
                MessageBox.Show("Insufficient Balance");
            }
            else
            {
                newBalance = balance - 100;
                try
                {
                    con.Open();
                    string query = "update AccountTbl set Balance=" + newBalance + " where AccNum='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Amount Withdraw successfully");
                    con.Close();
                    Login log = new Login();
                    log.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (balance < 500)
            {
                MessageBox.Show("Insufficient Balance");
            }
            else
            {
                newBalance = balance - 500;
                try
                {
                    con.Open();
                    string query = "update AccountTbl set Balance=" + newBalance + " where AccNum='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Amount Withdraw successfully");
                    con.Close();
                    Login log = new Login();
                    log.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (balance < 1000)
            {
                MessageBox.Show("Insufficient Balance");
            }
            else
            {
                newBalance = balance - 1000;
                try
                {
                    con.Open();
                    string query = "update AccountTbl set Balance=" + newBalance + " where AccNum='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Amount Withdraw successfully");
                    con.Close();
                    Login log = new Login();
                    log.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (balance < 2000)
            {
                MessageBox.Show("Insufficient Balance");
            }
            else
            {
                newBalance = balance - 2000;
                try
                {
                    con.Open();
                    string query = "update AccountTbl set Balance=" + newBalance + " where AccNum='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Amount Withdraw successfully");
                    con.Close();
                    Login log = new Login();
                    log.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (balance < 5000)
            {
                MessageBox.Show("Insufficient Balance");
            }
            else
            {
                newBalance = balance - 5000;
                try
                {
                    con.Open();
                    string query = "update AccountTbl set Balance=" + newBalance + " where AccNum='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Amount Withdraw successfully");
                    con.Close();
                    Login log = new Login();
                    log.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (balance < 10000)
            {
                MessageBox.Show("Insufficient Balance");
            }
            else
            {
                newBalance = balance - 10000;
                try
                {
                    con.Open();
                    string query = "update AccountTbl set Balance=" + newBalance + " where AccNum='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Amount Withdraw successfully");
                    con.Close();
                    Login log = new Login();
                    log.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void FastCash_Load(object sender, EventArgs e)
        {
            getBalance();
        }
    }
}
