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

namespace Skills_International
{
    public partial class view : Form
    {
        public view()
        {
            InitializeComponent();
            showdata();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            modify obj = new modify();
            obj.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            users obj = new users();
            obj.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            view obj = new view();
            obj.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure, Do you really want to logout....?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                login obj = new login();
                obj.Show();
            }
        }
        private void showdata()
        {
            SqlConnection con = new(@"Data Source=DESKTOP-ABHLIQU;Initial Catalog=student;Integrated Security=True");
            SqlCommand cmd;
            SqlDataAdapter adpt;
            DataTable dt;

            adpt = new SqlDataAdapter("select * from registration", con);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void label18_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure, Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void NOTICE_Click(object sender, EventArgs e)
        {
            this.Hide();
            landing obj = new landing();
            obj.Show();
        }
    }
}
