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

namespace Project_group5
{
    public partial class FrmGV_ThongBao : Form
    {
        GiangVienDAO gvDAO = new GiangVienDAO();
        string maGV;
        HienThiTen hvDuocChon;
        public FrmGV_ThongBao(string maGV)
        {
            InitializeComponent();
            this.maGV = maGV;
            GiangVien gv= gvDAO.LayThongTinGiangVien(maGV);
            lblNguoiGui.Text = gv.ho + " " + gv.lot + " " + gv.ten;
            DataTable dsLop = gvDAO.layCacLop(maGV);
            for (int i = 0; i < dsLop.Rows.Count; i++)
                cmbLop.Items.Add(dsLop.Rows[i][0].ToString());
            cmbLop.Text = dsLop.Rows[0][0].ToString();
            hienThiLop();
            cmbNguoiNhan.Text = "Tất cả";
            DataGridViewTextBoxColumn MHV = new DataGridViewTextBoxColumn();
            MHV.HeaderText = "Mã học viên";
            DataGridViewTextBoxColumn TenHV = new DataGridViewTextBoxColumn();
            TenHV.HeaderText = "Họ tên";
            DataGridViewCheckBoxColumn Vang = new DataGridViewCheckBoxColumn();
            Vang.HeaderText = "Vắng";
            gvDiemDanh.Columns.Add(MHV);
            gvDiemDanh.Columns.Add(TenHV);
            gvDiemDanh.Columns.Add(Vang);
            gvDiemDanh.Columns[1].Width = 150;
            cmbLop.Text = dsLop.Rows[0][0].ToString();
            hienThiTuan();
        }
        private void btnGui_Click(object sender, EventArgs e)
        {
            if (cmbLop.Text == "" || cmbNguoiNhan.Text == "" || lblNguoiGui.Text == "" || rtbNoiDung.Text == "")
            {
                FrmMessageBox frmMessageBox = new FrmMessageBox("Your information is not valid", "WARNING");
                frmMessageBox.ShowDialog();
            } 
            else
            {
                FrmMessageBox frmMessageBox = new FrmMessageBox("Are you sure you want to finish?", "CONFIRM");
                DialogResult result = frmMessageBox.ShowDialog();
                if (result == DialogResult.OK)
                {
                    gvDAO.ThemThongBao(cmbLop.Text, maGV, hvDuocChon.Ma, "From: " + lblNguoiGui.Text + " \n" + "Nội dung: " + rtbNoiDung.Text);
                    FrmMessageBox messageBox = new FrmMessageBox("Your announcement was sent successfully", "ANNOUNCEMENT");
                    messageBox.ShowDialog();
                    rtbNoiDung.Text = "";
                }
            }
        }
        private void cmbLop_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            hienThiLop();
        }
        private void hienThiLop()
        {
            List<HienThiTen> dsTenHV = new List<HienThiTen>(); 
            dsTenHV.Add(new HienThiTen("%", "Tất cả"));
            DataTable dsHV = gvDAO.layHVTheoLop(cmbLop.Text);
            if (dsHV.Rows.Count > 0)
            {
                for (int i = 0; i < dsHV.Rows.Count; i++)
                {
                    dsTenHV.Add(new HienThiTen(dsHV.Rows[i][0].ToString(), dsHV.Rows[i][1].ToString() + " " + dsHV.Rows[i][2].ToString() + " " + dsHV.Rows[i][3].ToString()));
                }
                cmbNguoiNhan.DataSource = dsTenHV;
                cmbNguoiNhan.DisplayMember = "Ten";
                cmbNguoiNhan.ValueMember = "Ma";
            }
            else
            {
                FrmMessageBox frmMessageBox = new FrmMessageBox("Your information is not valid", "WARNING");
                frmMessageBox.ShowDialog();
            }
        }
        private void cmbNguoiNhan_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            hvDuocChon = (HienThiTen)cmbNguoiNhan.SelectedItem;
        }
        private void hienThiTuan()
        {
            cmbBuoi.Items.Clear();
            cmbTuan.Items.Clear();
            gvDiemDanh.Rows.Clear();
            DataTable dsTuan = gvDAO.layTuanHoc(cmbLop.Text);
            for (int i = 0; i < dsTuan.Rows.Count; i++)
                cmbTuan.Items.Add(dsTuan.Rows[i][0].ToString());
            cmbTuan.Text = dsTuan.Rows[0][0].ToString();
            hienThiBuoi();
        }
        private void hienThiBuoi()
        {
            cmbBuoi.Items.Clear();
            gvDiemDanh.Rows.Clear();
            DataTable dsBuoiHoc = gvDAO.layBuoiHoc(cmbTuan.Text);
            for (int i = 0; i < dsBuoiHoc.Rows.Count; i++)
                cmbBuoi.Items.Add(dsBuoiHoc.Rows[i][0].ToString());
            cmbBuoi.Text = dsBuoiHoc.Rows[0][0].ToString();
            hienThiData();
        }

        private void cmbBuoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            hienThiData();
        }
        private void hienThiData()
        {
            gvDiemDanh.Rows.Clear();
            bool check;
            DataTable dsHV = gvDAO.layHVTheoLop(cmbLop.Text);
            for (int i = 0; i < dsHV.Rows.Count; i++)
            {
                if (string.Equals(gvDAO.KTtrVang(dsHV.Rows[i][0].ToString(), cmbBuoi.Text), "0"))
                    check = true;
                else
                    check = false;
                gvDiemDanh.Rows.Add(dsHV.Rows[i][0].ToString(),
                                    dsHV.Rows[i][1].ToString() + " " + dsHV.Rows[i][2].ToString() + " " + dsHV.Rows[i][3].ToString(), check);
            }
        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            FrmMessageBox frmMessageBox = new FrmMessageBox("Are you sure you want to finish?", "CONFIRM");
            DialogResult result = frmMessageBox.ShowDialog();
            if (result == DialogResult.OK)
            {
                int vang = 1;
                for (int i = 0; i < gvDiemDanh.Rows.Count - 1; i++)
                {
                    if ((bool)gvDiemDanh.Rows[i].Cells[2].Value == true) vang = 0;
                    else vang = 1;
                    gvDAO.DiemDanh(cmbBuoi.Text, gvDiemDanh.Rows[i].Cells[0].Value.ToString(), vang);
                    FrmMessageBox messageBox = new FrmMessageBox("Successfully", "ANNOUNCEMENT");
                    messageBox.ShowDialog();
                }
            }
        }
        private void cmbTuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            hienThiBuoi();
        }
    }
}
