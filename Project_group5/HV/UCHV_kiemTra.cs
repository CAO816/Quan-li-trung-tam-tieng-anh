using Project_group5.HV;
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

namespace Project_group5
{
    public partial class UCHV_kiemTra : UserControl
    {
        HV_DAO hV_DAO = new HV_DAO();
        string maBKT;
        string maHV;
        int sttDe;
        DataRow dr;
        public UCHV_kiemTra(int STT_De, DataRow dr)
        {
            InitializeComponent();
            this.maBKT = dr[0].ToString();
            this.maHV = dr[1].ToString();
            this.dr = dr;
            this.sttDe = STT_De;
            lblDe.Text = "Đề "+(STT_De + 1).ToString();
            lblMaDe.Text = dr[0].ToString();
            lblTuan.Text = dr[4].ToString();
            lblTg.Text = "90 phút";
        }
        private void UCHV_kiemTra_Load(object sender, EventArgs e)
        {
            
        }
        private void btnBD_Click(object sender, EventArgs e)
        {
            DirectoryInfo duongdan = new DirectoryInfo(".");
            FrmDeKiemTra doi_Diem = new FrmDeKiemTra(maBKT, maHV, string.Format(@"{0}\DeKT\{1}.txt", duongdan.FullName, maBKT), string.Format(@"{0}\DeKT\DA{1}.txt", duongdan.FullName, maBKT),sttDe + 1);
            doi_Diem.ShowDialog();
        }
        private void btnKQ_Click(object sender, EventArgs e)
        {
            DataTable dt = hV_DAO.XemDiemKT(maBKT, maHV);
            FrmMessageBox frmMessageBox = new FrmMessageBox("Your score: " + dt.Rows[0][0].ToString(), "ANNOUNCEMENT");
            frmMessageBox.ShowDialog();
        }
    }
}
