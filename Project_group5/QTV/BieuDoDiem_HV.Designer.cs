namespace Project_group5.QTV
{
    partial class BieuDoDiem_HV
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BieuDoDiem_HV));
            this.chartDiem = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblTen = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartDiem)).BeginInit();
            this.SuspendLayout();
            // 
            // chartDiem
            // 
            this.chartDiem.BorderlineColor = System.Drawing.Color.MidnightBlue;
            this.chartDiem.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chartDiem.BorderlineWidth = 2;
            chartArea1.Name = "ChartArea1";
            this.chartDiem.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartDiem.Legends.Add(legend1);
            this.chartDiem.Location = new System.Drawing.Point(12, 40);
            this.chartDiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartDiem.Name = "chartDiem";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "Diem";
            this.chartDiem.Series.Add(series1);
            this.chartDiem.Size = new System.Drawing.Size(398, 262);
            this.chartDiem.TabIndex = 0;
            this.chartDiem.Text = "Biểu đồ điểm";
            title1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.ForeColor = System.Drawing.Color.DarkRed;
            title1.Name = "titleDiem";
            title1.Text = "Biểu đồ điểm";
            this.chartDiem.Titles.Add(title1);
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTen.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTen.Location = new System.Drawing.Point(7, 11);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(108, 23);
            this.lblTen.TabIndex = 1;
            this.lblTen.Text = "Tên học viên";
            // 
            // txtTen
            // 
            this.txtTen.BackColor = System.Drawing.Color.White;
            this.txtTen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTen.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtTen.Location = new System.Drawing.Point(156, 11);
            this.txtTen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTen.Name = "txtTen";
            this.txtTen.ReadOnly = true;
            this.txtTen.Size = new System.Drawing.Size(264, 25);
            this.txtTen.TabIndex = 2;
            // 
            // BieuDoDiem_HV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(422, 322);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.lblTen);
            this.Controls.Add(this.chartDiem);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(968, 707);
            this.Name = "BieuDoDiem_HV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BieuDoDiem_HV";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BieuDoDiem_HV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartDiem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartDiem;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.TextBox txtTen;
    }
}