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

namespace Project_group5.QTV
{
   
    public partial class FrmQTV : Form
    {
        private Form currentFormChild;
        FormChild formChild = new FormChild();
        public FrmQTV()
        {
            InitializeComponent();
        }

        private void btnHocVien_Click(object sender, EventArgs e)
        {
            pnlNoiDung.Controls.Clear();
            FrmQTV_HV frmQTV = new FrmQTV_HV();
            pnlNoiDung.Controls.Add(frmQTV);
        }

        private void btnGiaoVien_Click(object sender, EventArgs e)
        {
            formChild.OpenFormChild(pnlNoiDung, ref currentFormChild, new FrmQTV_GV());
        }

        private void btnKhoaHoc_Click(object sender, EventArgs e)
        {
            pnlNoiDung.Controls.Clear();
            FrmQTV_KhoaHoc frmQTV = new FrmQTV_KhoaHoc();
            pnlNoiDung.Controls.Add(frmQTV);
            
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            pnlNoiDung.Controls.Clear();
            FrmQTV_TaiKhoan frmQTV = new FrmQTV_TaiKhoan();
            pnlNoiDung.Controls.Add(frmQTV);
        }

        private void btnLop_Click(object sender, EventArgs e)
        {
            pnlNoiDung.Controls.Clear();
            FrmQTV_Lop frmQTV = new FrmQTV_Lop();
            pnlNoiDung.Controls.Add(frmQTV);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            FrmMessageBox frmMessageBox = new FrmMessageBox("Are you sure you want to log out?", "CONFIRM");
            DialogResult result = frmMessageBox.ShowDialog();
            if (result == DialogResult.OK)
                this.Close();
        }
    }
}
