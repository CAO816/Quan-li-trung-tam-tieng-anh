namespace Project_group5.QTV
{
    partial class BieuDoSoSanh_Lop
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
            this.chartDiemLop = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartDiemLop)).BeginInit();
            this.SuspendLayout();
            // 
            // chartDiemLop
            // 
            this.chartDiemLop.BorderlineColor = System.Drawing.Color.MidnightBlue;
            this.chartDiemLop.BorderlineWidth = 2;
            chartArea1.Name = "ChartArea1";
            this.chartDiemLop.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartDiemLop.Legends.Add(legend1);
            this.chartDiemLop.Location = new System.Drawing.Point(-5, -78);
            this.chartDiemLop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartDiemLop.Name = "chartDiemLop";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Diem";
            this.chartDiemLop.Series.Add(series1);
            this.chartDiemLop.Size = new System.Drawing.Size(1102, 723);
            this.chartDiemLop.TabIndex = 0;
            this.chartDiemLop.Text = "chartDiemLop";
            title1.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.ForeColor = System.Drawing.Color.Brown;
            title1.Name = "titleDiemLop";
            this.chartDiemLop.Titles.Add(title1);
            // 
            // BieuDoSoSanh_Lop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1117, 666);
            this.Controls.Add(this.chartDiemLop);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1166, 855);
            this.Name = "BieuDoSoSanh_Lop";
            this.Text = "BieuDoSoSanh_Lop";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BieuDoSoSanh_Lop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartDiemLop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartDiemLop;
    }
}