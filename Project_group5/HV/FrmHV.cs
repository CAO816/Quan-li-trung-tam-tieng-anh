using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_group5.HV
{
    public partial class FrmHV : Form
    {
        public Form currentFormChild;
        FormChild formChild = new FormChild();
        HocVien hv;
        HV_DAO hV_DAO = new HV_DAO();
        public FrmHV(string maHV)
        {
            InitializeComponent();
            this.MaximumSize = new Size(1500, 798);
            this.TopMost = false;
            hv = hV_DAO.ThongTinHV(maHV);
        }
        private void btnKiemTra_Click(object sender, EventArgs e)
        {

            pnlNoiDung.Controls.Clear();
            FrmHV_BaiKiemTra frmHV_Bai = new FrmHV_BaiKiemTra(hv.maHV);
            pnlNoiDung.Controls.Add(frmHV_Bai);
            
        }
        private void btnTKB_Click(object sender, EventArgs e)
        {
            pnlNoiDung.Controls.Clear();
            FrmHV_TKB frmHV_TKB = new FrmHV_TKB(hv.maLop, hv.sdt, hv.maHV);
            pnlNoiDung.Controls.Add(frmHV_TKB);
        }
        private void btnThongTinCaNhan_Click(object sender, EventArgs e)
        {
            pnlNoiDung.Controls.Clear();
            formChild.OpenFormChild(pnlNoiDung, ref currentFormChild, new FrmHV_ThongTin(hv.maHV));
        }
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            FrmMessageBox frmMessageBox = new FrmMessageBox("Are you sure you want to log out?", "CONFIRM");
            DialogResult result = frmMessageBox.ShowDialog();
            if (result == DialogResult.OK)
                this.Close();
        }
        private void btnKetQua_Click(object sender, EventArgs e)
        {
            pnlNoiDung.Controls.Clear();
            FrmHV_KQHT frm = new FrmHV_KQHT(hv.maHV);
            pnlNoiDung.Controls.Add(frm);
        }
        private void btnNhanXet_Click(object sender, EventArgs e)
        {
            pnlNoiDung.Controls.Clear();
            FrmHV_DanhGia danhGia = new FrmHV_DanhGia(hv.maHV,hv.maLop);
            pnlNoiDung.Controls.Add(danhGia);
        }
        private void pbTrangChu_Click(object sender, EventArgs e)
        {
            pnlNoiDung.Controls.Clear();
            FrmTrangChu trangChu = new FrmTrangChu();
            pnlNoiDung.Controls.Add(trangChu);
        }
    }
}
