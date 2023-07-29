using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using MetroFramework.Forms;
using DSAProject;
using System.Windows.Forms.DataVisualization.Charting;

namespace projects
{
    public partial class Form3 : MetroForm
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public Form3()
        {
            
            InitializeComponent();
            bingridview();

        }
        public static int getMax(int[] arr, int n)
        {
            int mx = arr[0];
            for (int i = 1; i < n; i++)
                if (arr[i] > mx)
                    mx = arr[i];
            return mx;
        }
        public static void countSort(int[] arr, int n, int exp)
        {
            int[] output = new int[n];
            int i;
            int[] count = new int[10];
            for (i = 0; i < 10; i++)
                count[i] = 0;
            for (i = 0; i < n; i++)
                count[(arr[i] / exp) % 10]++;
            for (i = 1; i < 10; i++)
                count[i] += count[i - 1];
            for (i = n - 1; i >= 0; i--)
            {
                output[count[(arr[i] / exp) % 10] - 1] = arr[i];
                count[(arr[i] / exp) % 10]--;
            }
            for (i = 0; i < n; i++)
                arr[i] = output[i];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query2 = "select * from Department_tbl where Id=@id  ";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            cmd2.Parameters.AddWithValue("@id", textBox1.Text);
            con.Open();
            SqlDataReader dr = cmd2.ExecuteReader();

            if (dr.HasRows == true)
            {

                MessageBox.Show(textBox1.Text + " :ID Already Exist!!", "Faliure", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            else
            {
                con.Close();
                string query = "insert into Department_tbl values(@id,@name,@expense)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", textBox1.Text);
                cmd.Parameters.AddWithValue("@name", textBox2.Text);
                cmd.Parameters.AddWithValue("@expense", textBox3.Text);
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
        void bingridview()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Department_tbl ";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update Department_tbl set Id=@id,Name=@name,Expenses=@expense where Id =@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@expense", textBox3.Text);
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
            string query = "delete from Department_tbl  where Id =@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);

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
        void resetcontrol()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            resetcontrol();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }



        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Plz Fill Id");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "Plz Fill Name");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text) == true)
            {
                textBox3.Focus();
                errorProvider3.SetError(this.textBox3, "Plz Enter  Expense");
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            redixsort();
        }


        void bindgridview()
        {
            dataGridView1.Rows.Clear();
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Department_tbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                dataGridView1.Rows.Add(row.ItemArray);
            }

        }
        public static void radixsort(int[] arr, int n)
        {
            int m = getMax(arr, n);

            for (int exp = 1; m / exp > 0; exp *= 10)
                countSort(arr, n, exp);
        }
        static int expensecount;
        static int namecount;
        static int[] arr = new int[expensecount];
        static string[] name = new string[namecount];
        void redixsort()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Department_tbl";

            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            DataSet dts = new DataSet();
            sda.Fill(dts, "Sorting");

            List<int> expenselist = new List<int>();
            List<string> namelist = new List<string>();
            foreach (DataRow row in dts.Tables["Sorting"].Rows)
            {
                expenselist.Add(Convert.ToInt32(row["Expenses"].ToString()));
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

            radixsort(arr, arr.Length);

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

            for (int i = 0; i < arr.Length; i++)
            {

                SqlConnection con2 = new SqlConnection(cs);
                string query2 = "select * from Department_tbl where expenses ='" + arr[i] + "'";
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




     

        private void button7_Click(object sender, EventArgs e)
        {
            DASHBOARD d = new DASHBOARD();
            this.Hide();
            d.ShowDialog();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sabirDataSet.Department_tbl' table. You can move, or remove it, as needed.
            this.department_tblTableAdapter.Fill(this.sabirDataSet.Department_tbl);

        }
        
        private void button8_Click(object sender, EventArgs e)
        {

            updatechart();
            chart1.Update();
            chart1.Series[0].XValueMember = "name";
            chart1.Series[0].XValueMember = "expenses";
            chart1.Series[0].ChartType = SeriesChartType.Column;

        }
        void updatechart()
        {
             // dataGridView1.Rows.Clear();
           // #region old
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Department_tbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            chart1.DataSource = dt;
            chart1.Series[0].XValueMember = "name";
            chart1.Series[0].XValueMember = "expenses";
            //chart1.Series[0].XValueMember = "expenses";
            chart1.Series[0].ChartType = SeriesChartType.Column;
            


        }
    }
}