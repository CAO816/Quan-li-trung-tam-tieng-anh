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
    public partial class FrmQTV_Lop : UserControl
    {
        public Form currentFormChild;
        FormChild formChild = new FormChild();
        LopHocDAO lopDao = new LopHocDAO();
        public FrmQTV_Lop()
        {
            InitializeComponent();
        }
        private void valueNgayKT_change(object sender, EventArgs e)
        {
            int time = lopDao.LayThongTinKhoaHoc(cmbMaKH.Text).thoiGianHoc;
            int ngay = time * 7 + 7;
            DateTime dt = dtNgayBD.Value.Date;
            dt = dt.AddDays(ngay);
            dtNgayKT.Value = dt;
        }
        private void cmbMaLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvLop.DataSource = lopDao.LayDanhSachHocVien(cmbMaLop.Text);    
            txtTenGV.Text = lopDao.TenGiangVienTheoLop(cmbMaLop.Text);
            LopHoc lop = lopDao.LayThongTinLopHoc(cmbMaLop.Text);
            string tenGV = lopDao.TenGiangVienTheoLop(cmbMaLop.Text);
            Load_cmbMaGV();
            Load_cmbKhoaHoc();
            txtLop.Text = lop.maLop;
            cmbMaKH.Text = lop.maKhoaHoc;
            txtKH.Text = lopDao.TenKhoaHoc(cmbMaKH.Text);
            dtNgayBD.Value = lop.ngayBatDau;
            dtNgayKT.Value = lop.ngayKetThuc;
            txtHocPhi.Text = lop.triGia;
            txtSoHV.Text = lop.siSo;
            cmbMaGV.Text = lop.maGV;
            txtTenGV.Text = tenGV;
            txtDiaDiem.Text = lopDao.LayDiaDiem(txtLop.Text);
            txtGioBD.Text = lopDao.LayGioBatDau(txtLop.Text);
            if (lop.ngayBatDau <= DateTime.Now)
            {
                dtNgayBD.Enabled = false;
            }
            else
            {
                dtNgayBD.Enabled = true;
            }
        }
        private void Load_cmbMaGV()
        {
            DataTable tb = lopDao.LayDanhSachGiangVien();
            this.cmbMaGV.DataSource = tb.Copy();
            this.cmbMaGV.DisplayMember = "MaGV";
            this.cmbMaGV.ValueMember = "MaGV";
        }
        
        private void Load_cmbKhoaHoc()
        {
            DataTable tb = lopDao.LayDanhSachKhoaHoc();
            this.cmbMaKH.DataSource = tb.Copy();
            this.cmbMaKH.DisplayMember = "MaKH";
            this.cmbMaKH.ValueMember = "MaKH";
        }
        private void cmbMaGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTGV.Text = lopDao.TenGiangVienTheoMaGV(cmbMaGV.Text);
        }

        private void itemThem_Click(object sender, EventArgs e)
        {
            int ngay;
            if (cmbLichHoc.Text == "Thứ 2, Thứ 4, Thứ 6")
                ngay = 0;
            else
                ngay = 1;
            GiangVien gv = lopDao.LayThongTinGiangVien(cmbMaGV.Text);
            if(cmbDiaDiem.Text=="" || cmbGioBD.Text==""|| cmbLichHoc.Text==""|| txtGKT.Text=="" || txtLop.Text == "")
            {
                FrmMessageBox frmMessage = new FrmMessageBox("The information is not valid", "ANNOUNCEMENT");
                frmMessage.ShowDialog();
                return;
            }
            else
            {
                LopHoc lop = new LopHoc(txtLop.Text, dtNgayBD.Value.Date, dtNgayKT.Value.Date, txtHocPhi.Text, txtSoHV.Text, cmbMaGV.Text, cmbMaKH.Text);
                lopDao.ThemLop(lop, gv, ngay, DateTime.Parse(cmbGioBD.Text), DateTime.Parse(txtGKT.Text), cmbDiaDiem.Text);
            }
            FrmQTV_Lop_Load(sender, e);
        }
        private void radThem_CheckedChanged(object sender, EventArgs e)
        {
            txtGKT.Text = "";
            pbThem.Enabled = radThem.Checked;
            pbSua.Enabled = radSua.Checked;
            cmbMaLop_SelectedIndexChanged(sender, e);
            txtLop.ReadOnly = false;
            cmbMaKH.Enabled = true;
            dtNgayBD.Enabled = true;
            cmbMaKH.Enabled = true;
            cmbGioBD.Enabled = true;
            cmbLichHoc.Enabled = true;
            txtGKT.ReadOnly = true;
            cmbDiaDiem.Enabled = true;
            cmbDiaDiem.Visible = true;
            cmbGioBD.Visible = true;
            txtDiaDiem.Visible = false;
            txtGioBD.Visible = false;
            khoiTaoLai();
        }

        private void radSua_CheckedChanged(object sender, EventArgs e)
        {
            pbSua.Enabled = radSua.Checked;
            pbThem.Enabled = radThem.Checked;
            cmbMaLop_SelectedIndexChanged(sender, e);
            txtLop.ReadOnly = true;
            cmbDiaDiem.Visible = false;
            cmbGioBD.Visible = false;
            txtDiaDiem.Visible = true;
            txtGioBD.Visible = true;
            cmbLichHoc.Text = lopDao.LayLichHoc(txtLop.Text);
            cmbMaKH.Enabled = false;
            cmbGioBD.Enabled = false;
            cmbLichHoc.Enabled = false;
            txtGKT.ReadOnly = true;
            cmbDiaDiem.Enabled = false;
            if (txtGioBD.Text == "17:50")
                txtGKT.Text = "19:20";
            else if (txtGioBD.Text == "19:50")
                txtGKT.Text = "21:20";
        }
        private void itemXoa_Click(object sender, EventArgs e)
        {
            LopHoc lop = lopDao.LayThongTinLopHoc(cmbMaLop.Text);
            lopDao.XoaLop(lop);
            FrmQTV_Lop_Load(sender, e);
        }

        private void itemSua_Click(object sender, EventArgs e)
        {
            LopHoc lop_new = new LopHoc(txtLop.Text, dtNgayBD.Value.Date, dtNgayKT.Value.Date,
                                        txtHocPhi.Text, txtSoHV.Text, cmbMaGV.Text, cmbMaKH.Text);
            lopDao.SuaLop(lop_new);
            FrmQTV_Lop_Load(sender, e);
        }

        private void cmbKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            int time = lopDao.LayThongTinKhoaHoc(cmbMaKH.Text).thoiGianHoc;
            int ngay = time * 7 + 7;
            DateTime dt = dtNgayBD.Value.Date;
            dt = dt.AddDays(ngay);
            dtNgayKT.Value = dt;
            txtKH.Text = lopDao.TenKhoaHoc(cmbMaKH.Text);
        }
        private void cmbGioBD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGioBD.Text == "17:50")
            {
                txtGKT.Text = "19:20";
            }
            else if (cmbGioBD.Text == "19:50")
            {
                txtGKT.Text = "21:20";
            }
            string[] lst_diaDiem = { "Tầng 1 Phòng 1", "Tầng 1 Phòng 2", "Tầng 2 Phòng 1", "Tầng 2 Phòng 2", "Tầng 3 Phòng 1", "Tầng 3 Phòng 2", "Tầng 3 Phòng 3"};
            cmbDiaDiem.Items.Clear();
            foreach (string d in lst_diaDiem)
            {
                if (lopDao.KiemTraPhong(cmbLichHoc.Text, dtNgayBD.Value.Date.ToString(), cmbGioBD.Text, d))
                {
                    cmbDiaDiem.Items.Add(d);
                }
            }
        }

        private void FrmQTV_Lop_Load(object sender, EventArgs e)
        {
            DataTable dslop = lopDao.LayDanhSachLopHoc();
            for (int i = 0; i < dslop.Rows.Count; i++)
                cmbMaLop.Items.Add(dslop.Rows[i][0].ToString());
            cmbMaLop.SelectedIndex = 0;
            pnlTK.Controls.Clear();
            formChild.OpenFormChild(pnlTK, ref currentFormChild, new BieuDoSoSanh_Lop());
            txtDiaDiem.Visible = false;
            txtGioBD.Visible = false;
        }
        private void khoiTaoLai()
        {
            txtLop.Clear();
            cmbMaKH.SelectedIndex = 0;
            cmbMaGV.SelectedIndex = 0;
            dtNgayBD.Value = DateTime.Now;
            dtNgayKT.Value = DateTime.Now;
            txtSoHV.Text = "";
            txtHocPhi.Text = "";
            txtLop.Text = "";
        }

        private void cmbLichHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] list_gioBatDau = { "17:50", "19:50" };
            cmbGioBD.Items.Clear();
            for (int i = 0; i< list_gioBatDau.Length; i++)
            {
                if (lopDao.KiemTraGioBatDau(cmbMaGV.Text, cmbLichHoc. Text, dtNgayBD.Value.Date.ToString(), list_gioBatDau[i]))
                {
                    cmbGioBD.Items.Add(list_gioBatDau[i]);
                }
            }
        }
    }
}
