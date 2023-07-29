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
using System.Windows.Forms.DataVisualization.Charting;
using DSAProject;

namespace DSAProject
{
    public partial class Form4 : MetroForm
    {

        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updatechart();

            chart1.Series["organization"].XValueMember = "name";
            chart1.Series["organization"].XValueMember = "expense";
            chart1.Series["organization"].ChartType = SeriesChartType.Column;
          

        }
       
        private void Form4_Load(object sender, EventArgs e)
        {

            // TODO: This line of code loads data into the 'sabirDataSet1.organization' table. You can move, or remove it, as needed.
            this.organizationTableAdapter.Fill(this.sabirDataSet1.organization);
            // TODO: This line of code loads data into the 'sabirDataSet.organization' table. You can move, or remove it, as needed.

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 F2 = new Form2();
            this.Hide();
            F2.Show();
        }
        void updatechart()
        {
            //dataGridView1.Rows.Clear();
      
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from organization";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            chart1.DataSource = dt;
            chart1.Series[0].XValueMember = "name";
            chart1.Series[0].XValueMember = "expense";
            chart1.Series[0].ChartType = SeriesChartType.Column;



        }
    }

}
