using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Bank_Management_System
{
    public partial class Account : Form
    {
        public Account()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\.net\24SOEIT13021(RAHUL)\Bank-Management-System\ATMDB.mdf;Integrated Security=True");

        private void Account_Load(object sender, EventArgs e)
        {

        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            int bal = 0;
            if (AccNumTb.Text == "" || AccNameTb.Text == "" || AccFnameTb.Text == "" || AddressTb.Text == "" || PinTb.Text == "" || OccupationTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into AccountTbl values('" + AccNumTb.Text + "','" + AccNameTb.Text + "','" + AccFnameTb.Text + "','" + DOBdate.Value.Date  + "','"+ PhoneTb.Text+"','" + AddressTb.Text + "','" + EducationCb.SelectedItem.ToString() + "','" + OccupationTb.Text + "','" + PinTb.Text + "'," +bal+")";
                    SqlCommand cmd = new SqlCommand(query,con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account Created Successfully");
                    
                    con.Close();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
