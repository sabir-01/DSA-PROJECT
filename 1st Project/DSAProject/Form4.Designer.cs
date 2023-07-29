namespace DSAProject
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.organizationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sabirDataSet1 = new DSAProject.sabirDataSet1();
            this.sabirDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.sabirDataSet1BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.organizationTableAdapter = new DSAProject.sabirDataSet1TableAdapters.organizationTableAdapter();
            this.organizationBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.organizationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sabirDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sabirDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sabirDataSet1BindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.organizationBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // organizationBindingSource
            // 
            this.organizationBindingSource.DataMember = "organization";
            this.organizationBindingSource.DataSource = this.sabirDataSet1;
            // 
            // sabirDataSet1
            // 
            this.sabirDataSet1.DataSetName = "sabirDataSet1";
            this.sabirDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sabirDataSet1BindingSource
            // 
            this.sabirDataSet1BindingSource.DataSource = this.sabirDataSet1;
            this.sabirDataSet1BindingSource.Position = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(137, 461);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(283, 461);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 40);
            this.button2.TabIndex = 2;
            this.button2.Text = "GO BACK";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // sabirDataSet1BindingSource1
            // 
            this.sabirDataSet1BindingSource1.DataSource = this.sabirDataSet1;
            this.sabirDataSet1BindingSource1.Position = 0;
            // 
            // organizationTableAdapter
            // 
            this.organizationTableAdapter.ClearBeforeFill = true;
            // 
            // organizationBindingSource1
            // 
            this.organizationBindingSource1.DataMember = "organization";
            this.organizationBindingSource1.DataSource = this.sabirDataSet1BindingSource;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Snow;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.DataSource = this.organizationBindingSource1;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(10, 133);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "organization";
            series1.XValueMember = "Name";
            series1.YValueMembers = "Expense";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(591, 322);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.Normal;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DSAProject.Properties.Resources.s;
            this.pictureBox1.Location = new System.Drawing.Point(167, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(237, 135);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 511);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chart1);
            this.Name = "Form4";
            this.TransparencyKey = System.Drawing.Color.MidnightBlue;
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.organizationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sabirDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sabirDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sabirDataSet1BindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.organizationBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.BindingSource sabirDataSet1BindingSource;
        private sabirDataSet1 sabirDataSet1;
        private System.Windows.Forms.BindingSource sabirDataSet1BindingSource1;
        private System.Windows.Forms.BindingSource organizationBindingSource;
        private sabirDataSet1TableAdapters.organizationTableAdapter organizationTableAdapter;
        private System.Windows.Forms.BindingSource organizationBindingSource1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}