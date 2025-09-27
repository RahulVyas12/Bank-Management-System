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
                    Home home = new Home();
                    home.Show();
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

        private void Deposite_Load(object sender, EventArgs e)
        {
            getBalanceMethod();
        }
    }
}
