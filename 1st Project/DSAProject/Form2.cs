using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DSAProject;
using System.Configuration;
using System.Data.SqlClient;
using MetroFramework.Forms;
namespace DSAProject
{
    public partial class Form2 : MetroForm
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public Form2()
        {

            InitializeComponent();
            bingridview();
        }

      
        void bingridview()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from organization ";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
        }
        void resetcontrol()
        {
            metroTextBox1.Clear();
            metroTextBox2.Clear();
            metroTextBox3.Clear();

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            metroTextBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            metroTextBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            metroTextBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void metroTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsDigit(ch) == true)
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;

            }
        }

        private void metroTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetter(ch) == true)
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;

            }
            else if (ch == 32)
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;

            }
        }

        private void metroTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsDigit(ch) == true)
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;

            }
        }

        private void metroTextBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(metroTextBox1.Text) == true)
            {
                metroTextBox1.Focus();
                errorProvider1.SetError(this.metroTextBox1, "Plz Fill Id");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void metroTextBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(metroTextBox2.Text) == true)
            {
                metroTextBox2.Focus();
                errorProvider2.SetError(this.metroTextBox2, "Plz Fill Name");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void metroTextBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(metroTextBox3.Text) == true)
            {
                metroTextBox3.Focus();
                errorProvider3.SetError(this.metroTextBox3, "Plz Enter  Expense");
            }
            else
            {
                errorProvider3.Clear();
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query2 = "select * from organization where Id=@id  ";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            cmd2.Parameters.AddWithValue("@id", metroTextBox1.Text);
            con.Open();
            SqlDataReader dr = cmd2.ExecuteReader();

            if (dr.HasRows == true)
            {

                MessageBox.Show(metroTextBox1.Text + "Id Already Exist!!", "Faliure", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            else
            {
                con.Close();
                string query = "insert into organization values(@id,@name,@expense)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", metroTextBox1.Text);
                cmd.Parameters.AddWithValue("@name", metroTextBox2.Text);
                cmd.Parameters.AddWithValue("@expense", metroTextBox3.Text);
                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("INSERTED SUCESSFULLY  !!", "sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    bingridview();
                }
                else
                {
                    MessageBox.Show("INSERTION failed  !!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                con.Close();
                resetcontrol();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update organization set Id=@id,Name=@name,Expense=@expense where Id =@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", metroTextBox1.Text);
            cmd.Parameters.AddWithValue("@name", metroTextBox2.Text);
            cmd.Parameters.AddWithValue("@expense", metroTextBox3.Text);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Update  SUCESSFULLY  !!", "sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bingridview();
            }
            else
            {
                MessageBox.Show("update failed  !!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
            resetcontrol();

        }

            private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from organization  where Id =@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", metroTextBox1.Text);

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("DELETION  SUCESSFULLY  !!", "sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bingridview();
            }
            else
            {
                MessageBox.Show("DELETION failed  !!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
            resetcontrol();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            resetcontrol();
        }

        public void BUBBLESORT()
        {

            int temp;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = (i + 1); j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }


        }

        static int expensecount;
        static int namecount;
        static int[] arr = new int[expensecount];
        static string[] name = new string[namecount];

        void bubble()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from organization";

            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            DataSet dts = new DataSet();
            sda.Fill(dts, "Sorting");

            List<int> expenselist = new List<int>();
            List<string> namelist = new List<string>();
            foreach (DataRow row in dts.Tables["Sorting"].Rows)
            {
                expenselist.Add(Convert.ToInt32(row["Expense"].ToString()));
                namelist.Add(row["Name"].ToString());

            }
            foreach (DataRow row in dts.Tables["Sorting"].Rows)
            {
                namelist.Add(row["name"].ToString());
            }
            expensecount = expenselist.Count;
            namecount = namelist.Count;
            arr = expenselist.ToArray();
            name = namelist.ToArray();
            BUBBLESORT();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

            for (int i = 0; i < arr.Length; i++)
            {

                SqlConnection con2 = new SqlConnection(cs);
                string query2 = "select * from organization where expense ='" + arr[i] + "'";
                SqlDataAdapter sda2 = new SqlDataAdapter(query2, con2);
                DataTable dt2 = new DataTable();
                DataSet dts2 = new DataSet();
                sda2.Fill(dt2);


                foreach (DataRow row in dt2.Rows)
                {
                    if (i == 0)
                    {
                        dataGridView1.Rows.Add(row.ItemArray);

                    }
                    else if (arr[i - 1] == arr[i])
                    {
                        break;
                    }
                    else
                    {

                        dataGridView1.Rows.Add(row.ItemArray);
                    }

                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
           bubble();          
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sabirDataSet1.organization' table. You can move, or remove it, as needed.
            this.organizationTableAdapter.Fill(this.sabirDataSet1.organization);


        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form4 chart = new Form4();
            this.Hide();
            chart.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DASHBOARD D = new DASHBOARD();
            this.Hide();
            D.Show();
        }
    }
}
