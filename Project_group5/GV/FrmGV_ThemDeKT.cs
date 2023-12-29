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
    public partial class frmGV_ThemDeKiemTra : Form
    {
        GiangVienDAO gvDAO = new GiangVienDAO();
        DirectoryInfo duongdan = new DirectoryInfo(".");
        private void FrmGV_ThemDeKT_Load(object sender, EventArgs e)
        {

        }
        public frmGV_ThemDeKiemTra(string maGV)
        {
            InitializeComponent();
            DataTable dt= gvDAO.layCacLop(maGV);
            for(int i=0;i<dt.Rows.Count;i++)
            {
                cmbMaLop.Items.Add(dt.Rows[i][0].ToString());
            }
            cmbMaLop.Text = dt.Rows[0][0].ToString();
        }
        void XoaDuLieu()
        {
            rtbDA.Clear();
            rtbDe.Clear();
            cmbMaLop.Text = "";
            cmbDsDe.Text = "";
        }
        private void cmbMaLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbTuan.Items.Clear();
            DataTable dsTuan = gvDAO.layTuanHoc(cmbMaLop.Text);
            for (int i = 0; i < dsTuan.Rows.Count; i++)
                cmbTuan.Items.Add(dsTuan.Rows[i][0].ToString());
            cmbTuan.Text = dsTuan.Rows[0][0].ToString();
            
            cmbDsDe.Items.Clear();
            DataTable dt = gvDAO.layBaiKT(cmbMaLop.Text);
            for (int i = 0; i < dt.Rows.Count; i++)
                cmbDsDe.Items.Add(dt.Rows[i][0].ToString());
        }
        private void pbThem_Click(object sender, EventArgs e)
        {
            if (txtMaBKT.Text == "" || cmbMaLop.Text == "" || rtbDA.Text == "" || rtbDe.Text == "" || cmbTuan.Text == "")
            {
                FrmMessageBox frmMessageBox = new FrmMessageBox("Your information is not valid", "WARNING"); frmMessageBox.ShowDialog();
            }
            else
            {
                FrmMessageBox frmMessageBox = new FrmMessageBox("Are you sure you want to create a new test?", "CONFIRM");
                DialogResult result = frmMessageBox.ShowDialog();
                if (result == DialogResult.OK)
                {
                    gvDAO.TaoDe(txtMaBKT.Text, cmbMaLop.Text, cmbTuan.Text);
                    File.WriteAllText(string.Format(@"{0}\DeKT\{1}.txt", duongdan, txtMaBKT.Text), rtbDe.Text);
                    File.WriteAllText(string.Format(@"{0}\DeKT\DA{1}.txt", duongdan, txtMaBKT.Text), rtbDA.Text);
                    XoaDuLieu();
                }
            }
        }

        private void pbMo_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDsDe.Text == "" || cmbMaLop.Text == "")
                {
                    FrmMessageBox frmMessageBox = new FrmMessageBox("Your information is not valid", "WARNING");
                    DialogResult result = frmMessageBox.ShowDialog();
                }
                else
                {
                    StreamReader streamReaderDe = new StreamReader(string.Format(@"{0}\DeKT\{1}.txt", duongdan, cmbDsDe.Text));
                    rtbDe.Text = streamReaderDe.ReadToEnd();
                    StreamReader streamReaderDA = new StreamReader(string.Format(@"{0}\DeKT\DA{1}.txt", duongdan, cmbDsDe.Text));
                    rtbDA.Text = streamReaderDA.ReadToEnd();
                    streamReaderDe.Close();
                    streamReaderDA.Close();
                }
            }
            catch
            {
                FrmMessageBox frmMessageBox1 = new FrmMessageBox("Cannot found this test", "WARNING");
                frmMessageBox1.ShowDialog();
            }
        }

        private void pbXoa_Click(object sender, EventArgs e)
        {
            FrmMessageBox frmMessageBox = new FrmMessageBox("Are you sure you want to delete this test", "CONFIRM");
            DialogResult result = frmMessageBox.ShowDialog();
            if (result == DialogResult.Yes)
            {
                XoaDuLieu();
            }
        }

        private void pbLuu_Click(object sender, EventArgs e)
        {
            if (cmbDsDe.Text == "" || cmbMaLop.Text == "" || rtbDA.Text == "" || rtbDe.Text == "")
            {
                FrmMessageBox frmMessageBox = new FrmMessageBox("Your information is not valid", "WARNING");
                DialogResult result = frmMessageBox.ShowDialog();
            }
            else
            {
                File.WriteAllText(string.Format(@"{0}\DeKT\{1}.txt", duongdan, cmbDsDe.Text), rtbDe.Text);
                File.WriteAllText(string.Format(@"{0}\DeKT\DA{1}.txt", duongdan, cmbDsDe.Text), rtbDA.Text);
                XoaDuLieu();
            }
        }
        
    }
}
