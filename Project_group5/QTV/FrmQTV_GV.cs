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
    public partial class FrmQTV_GV : Form
    {
        GiangVienDAO gvDao = new GiangVienDAO();
        public FrmQTV_GV()
        {
            InitializeComponent();
        }
        private void FrmQTV_GV1_Load(object sender, EventArgs e)
        {
            this.gvGV.DataSource = gvDao.LayDanhSachGiangVien();
            gvGV.ScrollBars = ScrollBars.Both;
        }

        private void pbLamSach_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtMaGV.Clear();
            txtCMND.Clear();
            txtEmail.Clear();
            txtSDT.Clear();
            FrmQTV_GV1_Load(sender, e);
        }
        private void pbXoa_Click(object sender, EventArgs e)
        {
            GiangVien gv = gvDao.LayThongTinGiangVien(txtMaGV.Text);
            if (gv != null)
            {
                gvDao.Xoa(gv);
                FrmQTV_GV1_Load(sender, e);
            }
            else
            {
                FrmMessageBox frmMessageBox = new FrmMessageBox("This information is not available", "WARNING");
                frmMessageBox.ShowDialog();
            }
        }

        private void pbThem_Click(object sender, EventArgs e)
        {
            if(kiemTra())
            {
                List<string> hovaten = gvDao.tachTen(txtHoTen.Text);
                GiangVien gv = new GiangVien(txtMaGV.Text, hovaten[0], hovaten[1], hovaten[2], txtCMND.Text, txtSDT.Text, txtEmail.Text);
                gvDao.Them(gv);
                FrmQTV_GV1_Load(sender, e);
            }
        }

        private void pbSua_Click(object sender, EventArgs e)
        {
            if(kiemTra())
            {
                GiangVien gv = gvDao.LayThongTinGiangVien(txtMaGV.Text);
                if (gv != null)
                {
                    gvDao.Sua(gv);
                    FrmQTV_GV1_Load(sender, e);
                }
                else
                {
                    FrmMessageBox frmMessageBox = new FrmMessageBox("This information is not available", "WARNING");
                    frmMessageBox.ShowDialog();
                }
            }    
        }
        private void HienThiLop()
        {
            this.gvLop.DataSource = gvDao.ThongTinGiangVienVaLop(txtMaGV.Text);
            gvLop.Columns[0].HeaderText = "Mã lớp";
            gvLop.Columns[1].HeaderText = "Ngày bắt đầu";
            gvLop.Columns[2].HeaderText = "Ngày Kết thúc";
            gvLop.Columns[3].HeaderText = "Sĩ số";
            gvLop.Columns[3].Width = 50;
            gvLop.Columns[4].HeaderText = "Khóa học";
        }

        private void gvGV_doubleClick(object sender, EventArgs e)
        {
            txtMaGV.Text = gvGV.CurrentRow.Cells[0].Value.ToString();
            txtHoTen.Text = gvGV.CurrentRow.Cells[1].Value.ToString();
            txtCMND.Text = gvGV.CurrentRow.Cells[2].Value.ToString();
            txtSDT.Text = gvGV.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = gvGV.CurrentRow.Cells[4].Value.ToString();
            HienThiLop();
        }

        private void lblTinhLuong_Click(object sender, EventArgs e)
        {
            if (txtMaGV.Text == "")
                txtTinhLuong.Text = "0 VND";
            else
                txtTinhLuong.Text = gvDao.TinhLuong(txtMaGV.Text).ToString() + " VND";
        }
        private bool kiemTra()
        {
            if(txtMaGV.Text=="" || txtHoTen.Text=="" || txtEmail.Text=="" || txtCMND.Text=="" || txtSDT.Text=="")
            {
                FrmMessageBox messageBox = new FrmMessageBox("The information is not valid", "WARMNING");
                messageBox.ShowDialog();
                return false;
            }
            else return true;
        }
    }
}
