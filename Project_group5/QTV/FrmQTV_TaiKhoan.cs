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
    public partial class FrmQTV_TaiKhoan : UserControl
    {
        TaiKhoanDAO tkDao = new TaiKhoanDAO();
        public FrmQTV_TaiKhoan()
        {
            InitializeComponent();
        }

        private void FrmQTV_TaiKhoan1_Load(object sender, EventArgs e)
        {
            this.gvGV.DataSource = tkDao.LayDanhSachTaiKhoanGiangVien();
            gvGV.Columns[0].HeaderText = "Tài khoản";
            gvGV.Columns[1].HeaderText = "Họ và tên";
            gvGV.Columns[2].HeaderText = "Số điện thoại";
            this.gvHV.DataSource = tkDao.LayDanhSachTaiKhoanHocVien();
            gvHV.Columns[0].HeaderText = "Tài khoản";
            gvHV.Columns[1].HeaderText = "Họ và tên";
            gvHV.Columns[2].HeaderText = "Số điện thoại";
        }

        private void gvGV_click(object sender, EventArgs e)
        {
            string maGV = gvGV.CurrentRow.Cells[0].Value.ToString();
            DataRow dr = tkDao.ThongTinGV(maGV);
            txtMaSo.Text = dr[0].ToString();
            txtTenUser.Text = dr[1].ToString();
            txtMK.Text = dr[2].ToString();
            txtEmail.Text = dr[3].ToString();
            txtSDT.Text = dr[4].ToString();
            txtViTri.Text = "Giảng viên";
            txtMK.Visible = false;
        }

        private void lblMK_Click(object sender, EventArgs e)
        {
            txtMK.Visible = true;
        }

        private void gvHV_doubleClick(object sender, EventArgs e)
        {
            string maHV = gvHV.CurrentRow.Cells[0].Value.ToString();
            DataRow dr = tkDao.ThongTinHV(maHV);
            txtMaSo.Text = dr[0].ToString();
            txtTenUser.Text = dr[1].ToString();
            txtMK.Text = dr[2].ToString();
            txtEmail.Text = dr[3].ToString();
            txtSDT.Text = dr[4].ToString();
            txtViTri.Text = "Học viên";
            txtMK.Visible = false;
        }

        private void pbLamSach_Click(object sender, EventArgs e)
        {
            txtTenUser.Clear();
            txtEmail.Clear();
            txtMK.Clear();
            txtMaSo.Clear();
            txtViTri.Clear();
            txtMK.Clear();
            txtSDT.Clear();
        }

        private void pbHide_Click(object sender, EventArgs e)
        {
            txtMK.Visible = true;
        }

        private void pbTimKiem_Click(object sender, EventArgs e)
        {
            gvGV.DataSource = tkDao.TimKiemGV(txtTimKiem.Text);
            gvHV.DataSource = tkDao.TimKiemHV(txtTimKiem.Text);
        }

        private void txtTimKiem_textChange(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "")
            {
                gvGV.DataSource = tkDao.LayDanhSachTaiKhoanGiangVien();
                gvHV.DataSource = tkDao.LayDanhSachTaiKhoanHocVien();
            }
        }
    }
}
