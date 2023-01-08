using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skills_International
{
    public partial class landing : Form
    {
        public landing()
        {
            InitializeComponent();
        }

        private void landing_Load(object sender, EventArgs e)
        {

        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
;
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
            var result = MessageBox.Show("Are you sure, Do you really want to exit....?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
