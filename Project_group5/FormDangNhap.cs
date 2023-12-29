using Project_group5.GV;
using Project_group5.HV;
using Project_group5.QTV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project_group5
{
    public partial class FormDangNhap : Form
    {
        DangNhapDAO dnDAO = new DangNhapDAO();
        public FormDangNhap()
        {
            InitializeComponent();
        }    
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void btnQuen_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmDoiMK frmDoiMK = new FrmDoiMK();
            frmDoiMK.ShowDialog();
            this.Show();
        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            TaiKhoan taiKhoan = new TaiKhoan(txtTenTaiKhoan.Text, txtMatKhau.Text);
            if (radQTV.Checked && dnDAO.KiemTraDN_QTV(taiKhoan))
            {
                this.Hide();
                FrmQTV frmQTV = new FrmQTV();
                frmQTV.ShowDialog();
                this.Show();
            }
            else if (radHV.Checked && dnDAO.KiemTraHVDN(taiKhoan))
            {
                this.Hide();
                FrmHV frmQTV_HV = new FrmHV(txtTenTaiKhoan.Text);
                frmQTV_HV.ShowDialog();
                this.Show();
            }
            else if (radGV.Checked && dnDAO.KiemTraGVDN(taiKhoan))
            {
                this.Hide();
                FrmGV frmGV = new FrmGV(txtTenTaiKhoan.Text);
                frmGV.ShowDialog();
                this.Show();
            }
            else
            {
                FrmMessageBox frmMessageBox = new FrmMessageBox("Your login information is not correct. Please try again.", "WARNING");
                DialogResult result = frmMessageBox.ShowDialog();
            }
        }

        private void cbHide_CheckedChanged(object sender, EventArgs e)
        {

            if (cbHide.Checked)
                txtMatKhau.PasswordChar = '●';
            else
                txtMatKhau.PasswordChar = '\0';
        }

        private void lblDK_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmDangKy frm = new FrmDangKy();
            frm.ShowDialog();
            this.Show();
        }
    }
}
