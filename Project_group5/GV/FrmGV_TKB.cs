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

namespace Project_group5.GV
{
    public partial class FrmGV_TKB : UserControl
    {
        GiangVienDAO gvDAO = new GiangVienDAO();
        public FrmGV_TKB(string maGV)
        {
            InitializeComponent();
            DataTable dt = gvDAO.layTuanHoc();
            for (int i = 0; i < dt.Rows.Count; i++)
                cmbTuanHoc.Items.Add(dt.Rows[i][0].ToString());
            DataTable dsLop = gvDAO.layCacLop(maGV);
            for (int i = 0; i < dsLop.Rows.Count; i++)
            {
                cmbLop.Items.Add(dsLop.Rows[i][0].ToString());
                cmbMalop.Items.Add(dsLop.Rows[i][0].ToString());
            }
            cmbLop.Text = dsLop.Rows[0][0].ToString();
            cmbMalop.Text = dsLop.Rows[0][0].ToString();
            hienThiLop();
            UC_Lich uc = new UC_Lich();
            pnlLich.Controls.Add(uc);
            for (int i = 0; i < gvTKB.ColumnCount; i++)
                if (i != 2 && i != 3) gvTKB.Columns[i].ReadOnly = true;
        }

        private void FrmGV_TKB1_Load(object sender, EventArgs e)
        {

        }
        private void hienThiLop()
        {
            cmbTuan.Items.Clear();
            DataTable dsTuan = gvDAO.layTuanHoc(cmbLop.Text);
            for (int i = 0; i < dsTuan.Rows.Count; i++)
                cmbTuan.Items.Add(dsTuan.Rows[i][0].ToString());
            cmbTuan.Text = dsTuan.Rows[0][0].ToString();
            gvTKB.DataSource = gvDAO.LayTKB(cmbTuan.Text, cmbLop.Text);
        }
        private void cmbLop_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            hienThiLop();
            if(cmbTuan.Text!=null) gvTKB.DataSource = gvDAO.LayTKB(cmbTuan.Text, cmbLop.Text);
        }

        private void cmbTuan_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            gvTKB.DataSource = gvDAO.LayTKB(cmbTuan.Text, cmbLop.Text);
        }

        private void cmbTuanHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            hienTKB();
        }

        private void pbCapNhat_Click(object sender, EventArgs e)
        {
            FrmMessageBox frmMessageBox = new FrmMessageBox("Schedule has been updated", "ANNOUNCEMENT");
            DialogResult result = frmMessageBox.ShowDialog();
            if (result == DialogResult.OK)
            {
                for (int i = 0; i < gvTKB.Rows.Count - 1; i++)
                {
                    BuoiHoc_Lop buoiHoc = new BuoiHoc_Lop(gvTKB.Rows[i].Cells[0].Value.ToString(),
                                                          gvTKB.Rows[i].Cells[1].Value.ToString(),
                                                          gvTKB.Rows[i].Cells[2].Value.ToString(),
                                                          gvTKB.Rows[i].Cells[3].Value.ToString(),
                                                          DateTime.Parse(gvTKB.Rows[i].Cells[4].Value.ToString()),
                                                          DateTime.Parse(gvTKB.Rows[i].Cells[5].Value.ToString()));
                    gvDAO.SuaTKB(buoiHoc);
                }
            }
        }

        private void cmbMalop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTuanHoc.Text != "")
                hienTKB();
        }
        private void hienTKB()
        {
            flpTBK.Controls.Clear();
            for (int i = 2; i <= 8; i++)
            {
                UC_TKB uc = new UC_TKB(cmbTuan.Text, cmbMalop.Text, i);
                flpTBK.Controls.Add(uc);
            }
        }
    }
}
