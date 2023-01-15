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

namespace Skills_International
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        SqlConnection con = new(@"Data Source=DESKTOP-ABHLIQU;Initial Catalog=student;Integrated Security=True");

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void login_Load_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            username.Clear();
            password.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string user = username.Text;
            string pass = password.Text;

            string query = "SELECT * FROM login WHERE username='" +user+"'AND password='" +pass+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader row = cmd.ExecuteReader();

            if (row.HasRows)
            {
                this.Hide();
                landing obj = new landing();
                obj.Show();
            }
            else
            {
                MessageBox.Show("Invalid login credentials , please check username &password and try agin!", "invalid login details", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure, Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure, Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
