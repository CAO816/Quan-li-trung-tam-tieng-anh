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
    public partial class FrmHV_ThongTin : Form
    {
        HV_DAO hvDAO = new HV_DAO();
        public FrmHV_ThongTin(string maHV)
        {
            InitializeComponent();
            HocVien hv = hvDAO.ThongTinHV(maHV);
            lblHo.Text = hv.ho + " " + hv.lot+ " " + hv.ten;
            lblMaHV.Text = hv.maHV;
            lblNgaySinh.Text = hv.ngaySinh.ToString("dd/MM/yyyy");
            lblDiaChi.Text = hv.diaChi;
            btnSDT.Text = hv.sdt;
            btnEmail.Text = hv.email;
            lblMaLop.Text = hv.maLop;
            LopHoc lh = hvDAO.ThongTinLop(hv.maLop);
            lblMaLop.Text = lh.maLop;
            lblNgayBD.Text = lh.ngayBatDau.ToString("dd/MM/yyyy");
            lblNgayKT.Text = lh.ngayKetThuc.ToString("dd/MM/yyyy");
            lblSiSo.Text = lh.siSo + " học viên";
            lblMaGV.Text = lh.maGV;
            KhoaHoc kh = hvDAO.ThongTinKhoaHoc(lh.maKhoaHoc);
            lblMaKhoaHoc.Text = kh.maKhoaHoc;
            lblTenKH.Text = kh.tenKhoaHoc;
            lblMoTaKH.Text = kh.moTa;
            lblThoiGianKH.Text = kh.thoiGianHoc.ToString() + " tuần";
            lblSoTiet.Text = kh.soTiet + " tiết";
        }
    }
}
