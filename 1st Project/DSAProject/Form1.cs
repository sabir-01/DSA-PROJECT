using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using System.Configuration;
using System.Data.SqlClient;
using DSAProject;

namespace projects
{
    public partial class Form1 : MetroForm
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
            metroTextBox2.UseSystemPasswordChar = true;
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool check = checkBox1.Checked;
            switch (check)

            {
                case true:
                    metroTextBox2.UseSystemPasswordChar = false;
                    break;
                case false:

                    metroTextBox2.UseSystemPasswordChar = true;
                    break;
            }
        }


        //private void metroTextBox2_KeyDown(object sender, KeyEventArgs e)
        //{
        //    errorProvider1.Clear();

        //    if (e.KeyCode == Keys.Enter)
        //    {
        //       // pictureBox2.PerformClick();
        //    }
        //}

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            if (metroComboBox1.SelectedItem == "ADMIN")
            {
                if (string.IsNullOrEmpty(metroTextBox1.Text) == true)
                {
                    metroTextBox1.Focus();
                    errorProvider1.SetError(this.metroTextBox1, "Please Enter Your UserName ");
                }
                else if (string.IsNullOrEmpty(metroTextBox2.Text) == true)
                {
                    errorProvider1.Clear();
                    metroTextBox2.Focus();
                    errorProvider2.SetError(this.metroTextBox2, "Please Enter Your Password");
                }
                else
                {
                    errorProvider2.Clear();
                    string userName = "";
                    string userPassword = "";
                    SqlConnection con = new SqlConnection(cs);
                    string query = "select * from loGin where username=@user and pass=@pass";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@user", metroTextBox1.Text);
                    cmd.Parameters.AddWithValue("@pass", metroTextBox2.Text);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows == true)
                    {
                        dr.Read();
                        string userNameFromDb = dr["username"].ToString();
                        string passwordFromDb = dr["pass"].ToString();
                        dr.Close();
                        if (userNameFromDb == metroTextBox1.Text && passwordFromDb == metroTextBox2.Text)
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Login Succesful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            con.Close();
                            this.Hide();
                            DASHBOARD dashboard = new DASHBOARD();
                            dashboard.Show();
                        }
                        else
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Username And Password Incorrect\nPlease Double Check Your UserName And Password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            con.Close();
                        }
                    }

                }
            }

            else if (metroComboBox1.SelectedItem == "USER")
            {
                SqlConnection con2 = new SqlConnection(cs);
                string query2 = "select * from SIGNUP where email=@email and Pass=@Pass";
                SqlCommand cmd2 = new SqlCommand(query2, con2);
                cmd2.Parameters.AddWithValue("@email", metroTextBox1.Text);
                cmd2.Parameters.AddWithValue("@Pass", metroTextBox2.Text);
                con2.Open();
                SqlDataReader rd = cmd2.ExecuteReader();
                //string userNameFromDb = rd["username"].ToString();
                //string passwordFromDb = rd["pass"].ToString();
                if (rd.HasRows == true)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Login Succesful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    DASHBOARD dashboard = new DASHBOARD();
                    dashboard.ShowDialog();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Login Failed", "faluire", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    con2.Close();

                }

            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void metroTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {
            SINGUP s = new SINGUP();
            this.Hide();
            s.Show();
        }

        private void metroLabel3_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
