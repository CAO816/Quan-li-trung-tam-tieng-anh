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
    public partial class FrmQTV_HV : UserControl
    {
        HV_DAO hvDao = new HV_DAO();
        public Form currentFormChild;
        FormChild formChild = new FormChild();
        public FrmQTV_HV()
        {
            InitializeComponent();
        }

        private void FrmQTV_HV2_Load(object sender, EventArgs e)
        {
            DataTable dsLop = hvDao.LayDSLop();
            cmbMaLop.DataSource = dsLop;
            cmbMaLop.ValueMember = "MaLop";
            cmbMaLop.DisplayMember = "MaLop";
            hienThiHV();
            gvCoLop.DataSource = hvDao.LayDSHocVien();
        }

        private void cmbMaLop_selectedIndexChanged(object sender, EventArgs e)
        {
            hienThiHV();
        }
        private void hienThiHV()
        {
            string maKH = hvDao.ThongTinLop(cmbMaLop.Text).maKhoaHoc;
            DataTable tb = hvDao.LayHocVienDangKyTheoMaKhoaHoc(maKH);
            tb.Columns.Add("STT");
            
            for (int i = 0; i < tb.Rows.Count; i++)
                tb.Rows[i]["STT"] = i + 1;
            gvChuaLop.DataSource = tb;
            gvChuaLop.Columns["STT"].DisplayIndex = 0;
        }

        private void pbClear_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtMaHV.Clear();
            txtNgaySinh.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtCMND.Clear();
        }

        private void pbXoa_Click(object sender, EventArgs e)
        {
            DialogResult que = MessageBox.Show("Bạn chắc chắn muốn XÓA học viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (que == DialogResult.Yes)
            {
                HocVien hv = hvDao.LayThongTinHocVien(txtMaHV.Text);
                if (hv != null)
                {
                    hvDao.Xoa(hv);
                    FrmQTV_HV2_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Học viên này không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void pbTimKiem_Click(object sender, EventArgs e)
        {
            gvCoLop.DataSource = hvDao.LayDSTimKiem(txtTimKiem.Text);
        }

        private void gvChuaLop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && gvChuaLop.Columns[e.ColumnIndex] is DataGridViewImageColumn)
            {
                HocVien hv = hvDao.ThongTinHocVienDangKy(gvChuaLop.Rows[e.RowIndex].Cells[2].Value.ToString(), cmbMaLop.Text);
                if (hv != null)
                {
                    hvDao.Them(hv);
                    FrmQTV_HV2_Load(sender, e);
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "") gvCoLop.DataSource = hvDao.LayDSHocVien();
        }

        private void gvCoLop_doubleClick(object sender, EventArgs e)
        {
            string maHV = gvCoLop.CurrentRow.Cells[0].Value.ToString();
            HocVien hv = hvDao.LayThongTinHocVien(maHV);
            txtHoTen.Text = hv.ho + " " + hv.lot + " " + hv.ten;
            txtMaHV.Text = hv.maHV;
            txtNgaySinh.Text = hv.ngaySinh.Date.ToShortDateString();
            txtSDT.Text = hv.sdt;
            txtDiaChi.Text = hv.diaChi;
            txtCMND.Text = hv.cmnd;
            txtEmail.Text = hv.email;
            txtMaLop.Text = hv.maLop;
            if (hv != null)
            {
                pnlChart.Controls.Clear();
                formChild.OpenFormChild(pnlChart, ref currentFormChild, new BieuDoDiem_HV(hv.maHV, hv.ho + " " + hv.lot + " " + hv.ten));
            }
            else
            {
                MessageBox.Show("Học viên này không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pbSua_Click(object sender, EventArgs e)
        {
            string hoten = txtHoTen.Text;
            hoten = hoten.Trim();
            string ho = hoten.Substring(0, hoten.IndexOf(' '));
            string td = hoten.Substring(hoten.IndexOf(' ') + 1, hoten.LastIndexOf(' ') - ho.Length - 1);
            string ten = hoten.Substring(hoten.LastIndexOf(' ') + 1);
            HocVien hv = new HocVien(txtMaHV.Text, ho, td, ten, DateTime.Parse(txtNgaySinh.Text), txtCMND.Text, txtDiaChi.Text, txtSDT.Text, txtEmail.Text, txtMaLop.Text);
            hvDao.Sua(hv);
            FrmQTV_HV2_Load(sender, e);
        }
    }
}
