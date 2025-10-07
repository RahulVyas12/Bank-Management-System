using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_Management_System
{
    public partial class Deposite : Form
    {
        public Deposite()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\.net\24SOEIT13021(RAHUL)\Bank-Management-System\ATMDB.mdf;Integrated Security=True");

        int oldBalance, newBalance;
        string Acc = Login.accountNum; 
        public void getBalanceMethod()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Balance from AccountTbl where AccNum='" + Acc + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            oldBalance = Convert.ToInt32(dt.Rows[0][0].ToString());
            con.Close();
        }

        private void AddTransactionMethod()
        {
            string TransactionType = "Deposit";
            try
            {
                con.Open();
                string query = "insert into TransactionTbl values('" + Acc + "','" + TransactionType + "'," + DepositeAmtLbl.Text + ",'" + DateTime.Today.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                con.Close();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (DepositeAmtLbl.Text == "" || Convert.ToInt32(DepositeAmtLbl.Text) <= 0)
            {
                MessageBox.Show("Enter Valid Amount");
            }
            else
            {
                
                newBalance = oldBalance + Convert.ToInt32(DepositeAmtLbl.Text);
                try
                {
                    con.Open();
                    string query = "update AccountTbl set Balance=" + newBalance + " where AccNum='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Amount Deposited Successfully");
                    con.Close();
                    AddTransactionMethod();
                    Login log = new Login();
                    log.Show();
                    this.Hide();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DepositeAmtLbl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void Deposite_Load(object sender, EventArgs e)
        {
            getBalanceMethod();
        }
    }
}
