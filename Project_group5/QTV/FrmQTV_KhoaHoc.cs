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
    public partial class FrmQTV_KhoaHoc : UserControl
    {
        KhoaHoc_DAO khDao = new KhoaHoc_DAO();
        public FrmQTV_KhoaHoc()
        {
            InitializeComponent();
        }

        private void FrmQTV_KhoaHoc1_Load(object sender, EventArgs e)
        {
            hienThiKhoaHoc();
            clearTxt();
        }
        private void hienThiKhoaHoc()
        {
            gvKhoaHoc.DataSource = khDao.LayDanhSachKhoaHoc();
            gvKhoaHoc.Columns[0].HeaderText = "Tên khóa học";
            gvKhoaHoc.Columns[1].HeaderText = "Mã khóa học";
            gvKhoaHoc.Columns[2].HeaderText = "Số tiết";
        }

        private void gvKH_doubleClick(object sender, EventArgs e)
        {
            string maKH = gvKhoaHoc.CurrentRow.Cells[1].Value.ToString();
            KhoaHoc kh = khDao.LayThongTinKhoaHoc(maKH);
            txtMaKh.Text = kh.maKhoaHoc;
            txtTenKH.Text = kh.tenKhoaHoc;
            txtMoTa.Text = kh.moTa;
            txtSoTiet.Text = kh.soTiet;
            txtThoiGian.Text = kh.thoiGianHoc.ToString() + " tuần";
            gvLop.DataSource = khDao.LayDanhSachLop(maKH);
            gvLop.Columns[0].HeaderText = "Mã lớp";
            gvLop.Columns[1].HeaderText = "Ngày bắt đầu";
            gvLop.Columns[2].HeaderText = "Ngày kết thúc";
            gvLop.Columns[3].HeaderText = "Tên giảng viên";
        }

        private void pbLamSach_Click(object sender, EventArgs e)
        {
            clearTxt();
        }
        private void clearTxt()
        {
            txtMaKh.Clear();
            txtTenKH.Clear();
            txtMoTa.Clear();
            txtSoTiet.Clear();
            txtThoiGian.Clear();
        }

        private void pbThem_Click(object sender, EventArgs e)
        {
            if(kiemTra())
            {
                try
                {
                    int soTiet = int.Parse(txtSoTiet.Text);
                    KhoaHoc kh = TaoKhoaHoc();
                    khDao.Them(kh);
                    FrmQTV_KhoaHoc1_Load(sender, e);
                }
                catch
                {
                    MessageBox.Show("Số tiết phải là số nguyên", "Lỗi số tiết", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }    
        }

        private void pbXoa_Click(object sender, EventArgs e)
        {
            if (kiemTra())
            {
                KhoaHoc kh = TaoKhoaHoc();
                khDao.Xoa(kh);
                FrmQTV_KhoaHoc1_Load(sender, e);
            } 
                
        }

        private void pbSua_Click(object sender, EventArgs e)
        {
            if (kiemTra())
            {
                KhoaHoc kh = TaoKhoaHoc();
                khDao.Sua(kh);
                FrmQTV_KhoaHoc1_Load(sender, e);
            }
        }
        private KhoaHoc TaoKhoaHoc()
        {
            string thoiGianHoc = txtThoiGian.Text;
            thoiGianHoc = thoiGianHoc.Trim();
            thoiGianHoc += " tuần";
            int time = int.Parse(thoiGianHoc.Substring(0, thoiGianHoc.IndexOf(' ')));
            return new KhoaHoc(txtMaKh.Text, txtTenKH.Text, txtSoTiet.Text, txtMoTa.Text, time);
        }
        private bool kiemTra()
        {
            if (txtMaKh.Text == "" || txtTenKH.Text == "" || txtSoTiet.Text == "" || txtThoiGian.Text == "" || txtMoTa.Text == "")
            {
                FrmMessageBox messageBox = new FrmMessageBox("The information is not valid", "WARMNING");
                messageBox.ShowDialog();
                return false;
            }
            else return true;
        }
    }
}
