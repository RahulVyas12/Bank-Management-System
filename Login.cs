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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\.net\24SOEIT13021(RAHUL)\Bank-Management-System\ATMDB.mdf;Integrated Security=True");
        public static string accountNum;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SignUpBtn_Click(object sender, EventArgs e)
        {
            Account acc = new Account();
            acc.Show();
            this.Hide();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from AccountTbl where AccNum='" + AccNumTb.Text + "' and Pin='" + PinTb.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                accountNum = AccNumTb.Text;
               Home home = new Home();
                home.Show();
                this.Hide();
                con.Close();
            }
            else
            {
                MessageBox.Show("Wrong Account Number or Pin");
            }
            con.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
