using Project_group5.HV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_group5
{
    public partial class FrmGV_XemDiem : Form
    {
        GiangVienDAO gvDao = new GiangVienDAO();
        public FrmGV_XemDiem(string MaGV)
        {
            InitializeComponent();
            DataTable dsLop = gvDao.layCacLop(MaGV);
            for (int i = 0; i < dsLop.Rows.Count; i++)
                cmbLop.Items.Add(dsLop.Rows[i][0].ToString());
            cmbLop.Text = dsLop.Rows[0][0].ToString();
            hienThiLop();
            cmbHV.Text = "Tất cả";
            gvBangDiem.Columns[1].Width = 220;
        }

        private void FrmGV_XemDiem_Load(object sender, EventArgs e)
        {

        }

        private void cmbLop_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            hienThiLop();
        }
        private void hienThiLop()
        {
            List<HienThiTen> dsTenHV = new List<HienThiTen>();
            dsTenHV.Add(new HienThiTen("%", "Tất cả"));
            DataTable dsHV = gvDao.layHVTheoLop(cmbLop.Text);
            if (dsHV.Rows.Count > 0)
            {
                for (int i = 0; i < dsHV.Rows.Count; i++)
                {
                    dsTenHV.Add(new HienThiTen(dsHV.Rows[i][0].ToString(), dsHV.Rows[i][1].ToString() + " " + dsHV.Rows[i][2].ToString() + " " + dsHV.Rows[i][3].ToString()));
                }
                cmbHV.DataSource = dsTenHV;
                cmbHV.DisplayMember = "Ten";
                cmbHV.ValueMember = "Ma";
            }
            else
            {
                FrmMessageBox frmMessageBox = new FrmMessageBox("This information is not available", "WARNING");
                DialogResult result = frmMessageBox.ShowDialog();
            }
        }
        private void cmbHV_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            HienThiTen hvDuocChon = (HienThiTen)cmbHV.SelectedItem;
            gvBangDiem.DataSource = gvDao.LayDiemTheoLop(cmbLop.Text, hvDuocChon.Ma);
        }
    }
}
