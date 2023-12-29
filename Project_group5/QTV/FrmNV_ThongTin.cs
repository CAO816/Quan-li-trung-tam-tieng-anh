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
    public partial class FrmNV_ThongTin : Form
    {
        NV_DAO nvDAO = new NV_DAO();
        public FrmNV_ThongTin(string sodienthoai)
        {
            InitializeComponent();
            NhanVien nv = nvDAO.ThongTinNV(sodienthoai);
            txtHo.Text = nv.ho;
            txtLot.Text = nv.lot;
            txtTen.Text = nv.ten;
            txtMaGV.Text = nv.maNV;
            txtCMND.Text = nv.cmnd;
            txtSDT.Text = nv.sdt;
            txtEmail.Text = nv.email;
            txtNgBD.Text = nv.ngayBatDau.ToString();
            DataTable dtLop = nvDAO.layCacLop(nv.maNV);
            for (int i = 0; i < dtLop.Rows.Count; i++)
            {
                cmbLop.Items.Add(dtLop.Rows[i][0].ToString());
            }
        }

        private void FrmNV_ThongTin_Load(object sender, EventArgs e)
        {

        }

        private void cmbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            LopHoc lh = nvDAO.ThongTinLop(cmbLop.Text);
            txtNgayBD.Text = lh.ngayBatDau.ToString();
            txtNgayKT.Text = lh.ngayKetThuc.ToString();
            txtSiSo.Text = lh.siSo;
            txtMaGV.Text = lh.maGV;
            txtMaNV.Text = lh.maNV;
            KhoaHoc kh = nvDAO.ThongTinKhoaHoc(lh.maKhoaHoc);
            txtMaKhoaHoc.Text = kh.maKhoaHoc;
            txtTenKH.Text = kh.tenKhoaHoc;
            txtMoTaKH.Text = kh.moTa;
            txtThoiGianKH.Text = kh.thoiGianHoc;
            txtSoTiet.Text = kh.soTiet;
        }
    }
}
