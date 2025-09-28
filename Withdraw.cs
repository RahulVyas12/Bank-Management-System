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
    public partial class Withdraw : Form
    {
        public Withdraw()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\.net\24SOEIT13021(RAHUL)\Bank-Management-System\ATMDB.mdf;Integrated Security=True");
        string Acc = Login.accountNum;
        int balance;     
        int newBalance;
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

        private void AddTransactionMethod()
        {
            string TransactionType = "Withdraw";
            try
            {
                con.Open();
                string query = "insert into TransactionTbl values('" + Acc + "','" + TransactionType + "'," + withdrawAmtTb.Text + ",'" + DateTime.Today.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                con.Close();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void Withdraw_Load(object sender, EventArgs e)
        {
            getBalance();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (withdrawAmtTb.Text == "")
            {
                MessageBox.Show("Missing Amount");
            }
            else if (Convert.ToInt32(withdrawAmtTb.Text) <= 0)
            {
                MessageBox.Show("Enter Valid Amount");
            }
            else if (Convert.ToInt32(withdrawAmtTb.Text) > balance)
            {
                MessageBox.Show("Balance is Insufficient");
            }
            else
            {
                newBalance = balance - Convert.ToInt32(withdrawAmtTb.Text);
                try
                {
                    con.Open();
                    string query = "update AccountTbl set Balance=" + newBalance + " where AccNum='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Amount Withdraw Successful");
                    con.Close();
                    AddTransactionMethod();
                    Login login = new Login();
                    login.Show();
                    this.Hide();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
