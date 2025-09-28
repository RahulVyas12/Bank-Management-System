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
            // Account number validation (numeric)
            if (!AccNumTb.Text.All(char.IsDigit))
            {
                MessageBox.Show("Account Number must be numeric.");
                return;
            }

            // Name validation (no digits)
            if (AccNameTb.Text.Any(char.IsDigit) || AccFnameTb.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Name fields must not contain digits.");
                return;
            }

            // Phone number validation
            if (PhoneTb.Text.Length != 10 || !PhoneTb.Text.All(char.IsDigit))
            {
                MessageBox.Show("Phone Number should be exactly 10 digits and numeric.");
                return;
            }

            // PIN validation
            if (PinTb.Text.Length != 6 || !PinTb.Text.All(char.IsDigit))
            {
                MessageBox.Show("PIN should be exactly 4 digits and numeric.");
                return;
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
                    Login log = new Login();
                    log.Show();
                    this.Hide();

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
