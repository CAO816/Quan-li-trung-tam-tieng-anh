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
    public partial class FrmHV_TKB : UserControl
    {
        HV_DAO hV_DAO = new HV_DAO();
        string maLop;
        string sodienthoai;
        public FrmHV_TKB(string maLopHV, string sodienthoai, string maHV)
        {
            InitializeComponent();
            maLop = maLopHV;
            this.sodienthoai = sodienthoai;
            DataTable dt = hV_DAO.layTuanHoc(maLop);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmbTuan.Items.Add(dt.Rows[i][0].ToString());
            }
            UC_Lich uc = new UC_Lich();
            pnlLich.Controls.Add(uc);
            DataTable dsThongBao = hV_DAO.layThongBao(maHV);
            for (int i = 0; i < dsThongBao.Rows.Count; i++)
            {
                UC_TB uctb = new UC_TB(dsThongBao.Rows[i][0].ToString(), dsThongBao.Rows[i][4].ToString());
                flpThongBao.Controls.Add(uctb);
            }
        }
        private void cmbTuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            hienThiTuan();
        }
        private void hienThiTuan()
        {
            flpTBK.Controls.Clear();
            for (int i = 2; i <= 8; i++)
            {
                UC_TKB uc = new UC_TKB(cmbTuan.Text, maLop, i);
                flpTBK.Controls.Add(uc);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
