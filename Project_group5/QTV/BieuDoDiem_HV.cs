using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Project_group5.QTV
{
    public partial class BieuDoDiem_HV : Form
    {
        string maHV;
        string ten;
        HV_DAO hvDao = new HV_DAO();
        public BieuDoDiem_HV(string MaHV, string ten)
        {
            InitializeComponent();
            maHV = MaHV;
            this.ten = ten;
        }

        private void BieuDoDiem_HV_Load(object sender, EventArgs e)
        {
            txtTen.Text = ten;
            DataTable tb = hvDao.LayKetQuaKiemTra(maHV);
            chartDiem.ChartAreas[0].AxisY.Maximum = 1000;
            for (int i = 0; i< tb.Rows.Count; i++)
            {
                int k = int.Parse(tb.Rows[i][0].ToString());
                string label = "Lần " + (i + 1).ToString();
                chartDiem.Series["Diem"].Points.AddXY(label, k);
            }
        }
    }
}
