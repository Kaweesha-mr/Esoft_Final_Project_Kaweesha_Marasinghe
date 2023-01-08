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
    public partial class modify : Form
    {
        public modify()
        {
            InitializeComponent();
            fillcombobox();
        }

        public void fillcombobox()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ABHLIQU;Initial Catalog=student;Integrated Security=True");
            string sql = "select * from registration";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myreader;
            try
            {
                con.Open();
                myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    string id = myreader.GetInt32(0).ToString();
                    comboBox1.Items.Add(id);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ABHLIQU;Initial Catalog=student;Integrated Security=True");
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

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            modify obj = new modify();
            obj.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure, Do you really want to exit....?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ABHLIQU;Initial Catalog=student;Integrated Security=True");
            string sql = "select * from registration";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myreader;

            string yes_no = comboBox1.Text;
            if(comboBox1.Text != "New Register")
            {
                try
                {
                    con.Open();
                    myreader = cmd.ExecuteReader();
                    while (myreader.Read())
                    {
                        fname.Text = myreader.GetString(1).ToString();
                        lname.Text = myreader.GetString(2).ToString();

                        if(myreader.GetString(4) == "Male")
                        {
                            rbmale.Checked = true;
                            rbfemale.Checked = false;
                        }
                        else
                        {
                            rbmale.Checked = false;
                            rbfemale.Checked = true;
                        }
                        address.Text = myreader.GetString(5).ToString();
                        email.Text = myreader.GetString(6).ToString();
                        mobile.Text = myreader.GetInt32(7).ToString();
                        home.Text = myreader.GetInt32(8).ToString();
                        pname.Text = myreader.GetString(9).ToString();
                        nic.Text = myreader.GetString(10).ToString();
                        pnum.Text = myreader.GetInt32(11).ToString();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                comboBox1.Text = "";
                fname.Text = "";
                lname.Text = "";
                dob.Format = DateTimePickerFormat.Custom;
                dob.CustomFormat = "yyyy/MM/dd";
                DateTime thisDay = DateTime.Today;
                dob.Text = thisDay.ToString();
                rbfemale.Checked = false;
                rbmale.Checked = false;
                address.Text = "";
                email.Text = "";
                mobile.Text = "";
                home.Text = "";
                pname.Text = "";
                nic.Text = "";
                pnum.Text = "";

            }
        }
            

        private void button2_Click(object sender, EventArgs e)
        {
             try
            {
                string firstname = fname.Text;
                string lastname = lname.Text;
                dob.Format = DateTimePickerFormat.Custom;
                dob.CustomFormat = "yyyy/MM/dd";

                string gender;

                if (rbfemale.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                string Address = address.Text;
                string Email = email.Text;
                int Mobile = int.Parse(mobile.Text);
                int Home = int.Parse(home.Text);
                string PName = pname.Text;
                string Nic = nic.Text;
                string Pnum = pnum.Text;

                string query = "insert into registration values('" + firstname + "','" + lastname + "','" +dob.Text+ "','" + gender + "','" + Address + "','" + Email + "','" + Mobile + "','" + Home + "','" + PName + "','" + Nic + "','" + Pnum + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Added successfully!", "Registered Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            catch(SqlException ex)
            {
                string msg = "insert Error";
                msg += ex.Message;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string no = comboBox1.Text;

            if(no != "New Register")
            {
                try
                {
                    string firstname = fname.Text;
                    string lastname = lname.Text;
                    dob.Format = DateTimePickerFormat.Custom;
                    dob.CustomFormat = "yyyy/MM/dd";

                    string gender;

                    if (rbfemale.Checked)
                    {
                        gender = "Male";
                    }
                    else
                    {
                        gender = "Female";
                    }
                    string Address = address.Text;
                    string Email = email.Text;
                    int Mobile = int.Parse(mobile.Text);
                    int Home = int.Parse(home.Text);
                    string PName = pname.Text;
                    string Nic = nic.Text;
                    string Pnum = pnum.Text;

                    string query = "UPDATE registration SET firstName ='" + firstname + "',lastName = '" + lastname + "',dateOfBirth = '" + dob.Text + "',gender = '" + gender + "',address = '" + Address + "',email = '" + Email + "',mobilePhone = '" + Mobile + "',homePhone = '" + Home + "',parentName = '" + PName + "',nic = '" + Nic + "',contactNo = '" + Pnum + "' WHERE regNo = '" + comboBox1.Text + "' ";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
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

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            fname.Text = "";
            lname.Text = "";
            dob.Format = DateTimePickerFormat.Custom;
            dob.CustomFormat = "yyyy/MM/dd";
            DateTime thisDay = DateTime.Today;
            dob.Text = thisDay.ToString();
            rbfemale.Checked = false;
            rbmale.Checked = false;
            address.Text = "";
            email.Text = "";
            mobile.Text = "";
            home.Text = "";
            pname.Text = "";
            nic.Text = "";
            pnum.Text = "";


        }

        private void button3_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to Delete this record", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(result == DialogResult.Yes)
            {
                string no = comboBox1.Text;

                string query = "DELETE FROM registration WHERE regNo = " + no + "";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Record Deleted successfullt!", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
;            }
            else
            {
                this.Close();
            }
        }
    }
}
