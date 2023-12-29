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
    public partial class FrmDoiMK : Form
    {
        DangNhapDAO dnDAO = new DangNhapDAO();
        public FrmDoiMK()
        {
            InitializeComponent();
        }
        private void btnDoi_Click(object sender, EventArgs e)
        {
            DataTable dt = dnDAO.KiemTraThongTin(txttendn.Text);
            if (string.Equals(dt.Rows[0][1].ToString(), txtCMND.Text) && string.Equals(dt.Rows[0][2].ToString(), txtEmail.Text))
            {
                dnDAO.DoiMatKhau(txttendn.Text, txtMKM.Text);
                FrmMessageBox frmMessageBox = new FrmMessageBox("The password has been successfully changed", "ANNOUNCEMENT");
                DialogResult result = frmMessageBox.ShowDialog();
            }
            else 
            {
                FrmMessageBox frmMessageBox = new FrmMessageBox("The information is not valid", "WARNING");
                DialogResult result = frmMessageBox.ShowDialog();
            }
        }
    }
}
