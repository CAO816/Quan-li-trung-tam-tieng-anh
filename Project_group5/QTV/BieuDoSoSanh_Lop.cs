using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_group5.QTV
{
    public partial class BieuDoSoSanh_Lop : Form
    {
        LopHocDAO lopDao = new LopHocDAO();
        public BieuDoSoSanh_Lop()
        {
            InitializeComponent();
        }

        private void BieuDoSoSanh_Lop_Load(object sender, EventArgs e)
        {
            DataTable tb = lopDao.DiemTrungBinhTheoLop();
            chartDiemLop.ChartAreas[0].AxisY.Maximum = 1000;
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                int k = int.Parse(tb.Rows[i][1].ToString());
                string label = "Lớp " + tb.Rows[i][0].ToString();
                chartDiemLop.Series["Diem"].Points.AddXY(label, k);
            }
        }
    }
}
