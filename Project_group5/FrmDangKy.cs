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
    public partial class FrmDangKy : Form
    {
        List<HienThiTen> dsTenHV = new List<HienThiTen>();
        HV_DAO hvDao = new HV_DAO();
        HienThiTen kh;
        public FrmDangKy()
        {
            InitializeComponent();
        }

        private void btnDk_Click(object sender, EventArgs e)
        {
            if (txtHo.Text != "" && txtTen.Text != "" && txtCMND.Text != "" && txtDiaChi.Text != "" && txtSDT.Text != "" && txtEmail.Text != "")
                hvDao.HocVien_DK(txtHo.Text, txtTenlot.Text, txtTen.Text, DateTime.Parse(dtNgaySinh.Text), txtCMND.Text, txtDiaChi.Text, txtSDT.Text, txtEmail.Text, kh.Ma);
            else
            {
                FrmMessageBox frmMessageBox = new FrmMessageBox("The information is not valid", "WARNING");
                DialogResult result = frmMessageBox.ShowDialog();
            }    
        }

        private void FrmDangKy_Load(object sender, EventArgs e)
        {
            DataTable dsKH = hvDao.LayDSKhoaHoc();
            for (int i = 0; i < dsKH.Rows.Count; i++)
            {
                dsTenHV.Add(new HienThiTen(dsKH.Rows[i][0].ToString(), dsKH.Rows[i][1].ToString()));
               
            }
            cmbMaKH.DataSource = dsTenHV;
            cmbMaKH.DisplayMember = "Ten";
            cmbMaKH.ValueMember = "Ma";
        }

        private void cmbMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            kh = (HienThiTen)cmbMaKH.SelectedItem;
        }
    }
}
