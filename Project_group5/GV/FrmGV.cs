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
    public partial class FrmGV : Form
    {
        public Form currentFormChild;
        FormChild formChild = new FormChild();
        GiangVien gv;
        GiangVienDAO gvDAO = new GiangVienDAO();
        public FrmGV(string maGV)
        {
            InitializeComponent();
            this.MaximumSize = new Size(1500, 798);
            this.TopMost = false;
            gv = gvDAO.ThongTinGV(maGV);
        }

        private void btnThongTinCaNhan_Click(object sender, EventArgs e)
        {
            pnlNoiDung.Controls.Clear();
            formChild.OpenFormChild(pnlNoiDung, ref currentFormChild, new FrmGV_ThongTin(gv.maGV));
        }

        private void btnTKB_Click(object sender, EventArgs e)
        {
            pnlNoiDung.Controls.Clear();
            FrmGV_TKB gV_TKB = new FrmGV_TKB(gv.maGV);
            pnlNoiDung.Controls.Add(gV_TKB);
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            pnlNoiDung.Controls.Clear();
            formChild.OpenFormChild(pnlNoiDung, ref currentFormChild, new frmGV_ThemDeKiemTra(gv.maGV));
        }
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            FrmMessageBox frmMessageBox = new FrmMessageBox("Are you sure you want to log out?", "CONFIRM");
            DialogResult result = frmMessageBox.ShowDialog();
            if (result == DialogResult.OK)
                this.Close();
        }

        private void btnNhanXet_Click(object sender, EventArgs e)
        {
            pnlNoiDung.Controls.Clear();
            formChild.OpenFormChild(pnlNoiDung, ref currentFormChild, new FrmGV_ThongBao(gv.maGV));
        }

        private void btnXemDiem_Click(object sender, EventArgs e)
        {
            pnlNoiDung.Controls.Clear();
            formChild.OpenFormChild(pnlNoiDung, ref currentFormChild, new FrmGV_XemDiem(gv.maGV));
        }
    }
}
