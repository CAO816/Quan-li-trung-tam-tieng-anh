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
    public partial class FrmGV_ThongTin : Form
    {
        GiangVienDAO gvDAO = new GiangVienDAO();
        public FrmGV_ThongTin(string magv)
        {
            InitializeComponent();
            GiangVien gv = gvDAO.ThongTinGV(magv);
            lblHo.Text = gv.ho + " " + gv.lot + " " + gv.ten;
            lblMGV.Text = gv.maGV;
            btnSDT.Text = gv.sdt;
            btnEmail.Text = gv.email;
            DataTable dtLop = gvDAO.layCacLop(gv.maGV);
            for (int i = 0; i < dtLop.Rows.Count; i++)
            {
                cmbLop.Items.Add(dtLop.Rows[i][0].ToString());
            }
            cmbLop.Text = dtLop.Rows[0][0].ToString();
            hienThi();
        }

        private void cmbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            hienThi();
        }
        private void hienThi()
        {
            LopHoc lh = gvDAO.ThongTinLop(cmbLop.Text);
            lblNgayBD.Text = lh.ngayBatDau.ToString("dd/MM/yyyy");
            lblNgayKT.Text = lh.ngayKetThuc.ToString("dd/MM/yyyy");
            lblSiSo.Text = lh.siSo;
            lblMaGV.Text = lh.maGV;
            KhoaHoc kh = gvDAO.ThongTinKhoaHoc(lh.maKhoaHoc);
            lblMaKhoaHoc.Text = kh.maKhoaHoc;
            lblTenKH.Text = kh.tenKhoaHoc;
            lblMoTaKH.Text = kh.moTa;
            lblThoiGianKH.Text = kh.thoiGianHoc.ToString() + " tuần";
            lblSoTiet.Text = kh.soTiet + " tiết";
        }
    }
}
