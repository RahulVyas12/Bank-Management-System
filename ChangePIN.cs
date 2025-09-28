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
    public partial class ChangePIN : Form
    {
        public ChangePIN()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\.net\24SOEIT13021(RAHUL)\Bank-Management-System\ATMDB.mdf;Integrated Security=True");
        string Acc = Login.accountNum;

        private void ChangePIN_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pin1Tb.Text == "" || pin2Tb.Text == "")
            {
                MessageBox.Show("Enter New and Comfirm Pin Number");
            }
            else if (pin1Tb.Text != pin2Tb.Text)
            {
                MessageBox.Show("New Pin and Confirm Pin are not matching");
            }
            else
            {

                //newBalance = oldBalance + Convert.ToInt32(DepositeAmtLbl.Text);
                try
                {
                    con.Open();
                    string query = "update AccountTbl set PIN=" + pin1Tb.Text + " where AccNum='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("PIn changed Successfully");
                    con.Close();
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
    }
}
