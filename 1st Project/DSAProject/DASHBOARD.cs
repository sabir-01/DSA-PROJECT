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
using MetroFramework.Forms;
using System.Configuration;
using System.Data.SqlClient;
using DSAProject;
using System.Windows.Forms;
using projects;

namespace DSAProject
{
    public partial class DASHBOARD : Form
    {
        List<Color> colors = new List<Color>();

        public DASHBOARD()
        {
            colors.Add(Color.FromArgb(0, 158, 71));
            colors.Add(Color.FromArgb(112, 191, 83));
            colors.Add(Color.FromArgb(216, 155, 40));
            colors.Add(Color.FromArgb(217, 102, 42));
            colors.Add(Color.FromArgb(217, 102, 42));
            colors.Add(Color.FromArgb(235, 83, 104));
            colors.Add(Color.FromArgb(223, 128, 255));
            colors.Add(Color.FromArgb(112, 48, 160));
            colors.Add(Color.FromArgb(107, 122, 187));
            colors.Add(Color.FromArgb(95, 136, 176));
            colors.Add(Color.FromArgb(70, 175, 227));
            colors.Add(Color.FromArgb(0, 158, 71));
            colors.Add(Color.FromArgb(0, 160, 72));
            colors.Add(Color.FromArgb(0, 159, 73));
            InitializeComponent();
        }
        int curcolor = 0;
        int loop = 0;

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {


            projects.Form3 f = new Form3();
            this.Hide();
            f.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form1 d = new Form1();
            this.Hide();
            d.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (curcolor < colors.Count - 1)
            {
                this.BackColor = Bunifu.Framework.UI.BunifuColorTransition.getColorScale(loop, colors[curcolor], colors[curcolor + 1]);
                if (loop < 100)
                {
                    loop++;
                }
                else
                {
                    loop = 0;
                    curcolor++;
                }
                timer1.Enabled = true;

            }
        }
    }
}
