using System.Data;
using System.Data.SqlClient;

namespace Skills_International
{
    public partial class users : Form
    {

        public users()
        {
            InitializeComponent();
            fillcombobox();
            showdata();

        }
        // SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-ABHLIQU;Initial Catalog=student;Integrated Security=True");
        public void fillcombobox()
        {
            SqlConnection con = new(@"Data Source=DESKTOP-ABHLIQU;Initial Catalog=student;Integrated Security=True");
            string sql = "select * from login";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myreader;
            try
            {
                con.Open();
                myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    string id = myreader.GetInt32(0).ToString();
                    comboBox2.Items.Add(id);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void users_Load(object sender, EventArgs e)
        {

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
            users obj = new();
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
            var result = MessageBox.Show("Are you sure, Do you really want to ;pgout....?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                login obj = new login();
                obj.Show();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new(@"Data Source=DESKTOP-ABHLIQU;Initial Catalog=student;Integrated Security=True");
            string sql = "select * from login";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myreader;

            string yes_no = comboBox2.Text;
            if (comboBox2.Text != "New Register")
            {
                try
                {
                    con.Open();
                    myreader = cmd.ExecuteReader();
                    while (myreader.Read())
                    {
                        user_name.Text = myreader.GetString(1).ToString();
                        password.Text = myreader.GetString(2).ToString();
                        userphone.Text = myreader.GetString(3).ToString();
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                user_name.Clear();
                userphone.Clear();
                password.Clear();

            }

        }

        private void clear_Click(object sender, EventArgs e)
        {
            user_name.Clear();
            userphone.Clear();
            password.Clear();
        }

        private void add_Click(object sender, EventArgs e)
        {
            string yes = comboBox2.Text;
            if (yes == "New Register")
            {
                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ABHLIQU;Initial Catalog=student;Integrated Security=True");

                    string Username = user_name.Text;
                    string Password = password.Text;
                    string number = userphone.Text;

                    string query = "insert into login values('" + Username + "','" + Password + "','" + number + "')";
                    con.Open();
                    SqlCommand cmd = new(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Added successfully!", "Registered user", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                catch (SqlException ex)
                {
                    string msg = "insert Error";
                    msg += ex.Message;
                }
            }

        }

        private void edit_Click(object sender, EventArgs e)
        {
            string no = comboBox2.Text;

            if (no != "New Register")
            {
                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ABHLIQU;Initial Catalog=student;Integrated Security=True");
                    string Username = user_name.Text;
                    string Password = password.Text;
                    string Phone = userphone.Text;

                    string query = "UPDATE login SET username ='" + Username + "',password = '" + Password + "', phone = '" + Phone + "' WHERE uid = '" + comboBox2.Text + "' ";
                    con.Open();
                    SqlCommand cmd = new(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record updated successfully!", "Registered Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                catch (SqlException ex)
                {
                    string msg = "insert Error";
                    msg += ex.Message;
                }
            }
        }
        private void showdata()
        {
            SqlConnection con = new(@"Data Source=DESKTOP-ABHLIQU;Initial Catalog=student;Integrated Security=True");
            SqlCommand cmd;
            SqlDataAdapter adpt;
            DataTable dt;

            con.Open();
            adpt = new SqlDataAdapter("select * from login", con);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new(@"Data Source=DESKTOP-ABHLIQU;Initial Catalog=student;Integrated Security=True");
            con.Open();
            string query = "select * from login";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void NOTICE_Click(object sender, EventArgs e)
        {
            this.Hide();
             landing obj = new landing();
            obj.Show();
        }
    }
}
