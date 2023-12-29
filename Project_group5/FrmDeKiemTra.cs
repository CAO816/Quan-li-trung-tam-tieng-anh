using Guna.UI2.WinForms;
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
    public partial class FrmDeKiemTra : Form
    {
        HV_DAO hV_DAO = new HV_DAO();
        QLDeKiemTra qLDeKiemTra;
        List<Guna2TextBox> textBoxes;
        List<Label> labels;
        string DeKT;
        string DapAn;
        string maBKT;
        string maHV;
        public FrmDeKiemTra(string maBKT, string maHV, string deKT, string dapAn, int maDe)
        {
            InitializeComponent();
            this.MaximumSize = new Size(1500, 798);
            this.TopMost = false;
            this.maBKT = maBKT;
            this.maHV = maHV;
            this.DapAn=dapAn;
            this.DeKT = deKT;
            textBoxes = new List<Guna2TextBox>() { txt1, txt2, txt3, txt4, txt5 };
            labels = new List<Label>() { lbl1, lbl2, lbl3, lbl4, lbl5 };
            lblDe.Text = "ĐỀ " + maDe.ToString();
        }

        private void FrmDeKiemTra_Load(object sender, EventArgs e)
        {
            qLDeKiemTra = new QLDeKiemTra(QLFile.docDuLieu(DeKT),QLFile.docKetQua(DapAn));
            rtbDe.Text = qLDeKiemTra.maDe;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            txt1.ReadOnly = true;
            txt2.ReadOnly = true;
            txt3.ReadOnly = true;
            txt4.ReadOnly = true;
            txt5.ReadOnly = true;
            string diem = "0";
            for (int i = 0; i < textBoxes.Count; i++)
            {
                if (textBoxes[i].Text.Trim().Equals(qLDeKiemTra.dapAn[i], StringComparison.OrdinalIgnoreCase))
                {
                    diem = (int.Parse(diem) + 50).ToString();
                    textBoxes[i].BorderColor = Color.LightGreen;
                }
                else
                {
                    textBoxes[i].BorderColor = Color.Red;
                    textBoxes[i].Text = textBoxes[i].Text;
                    labels[i].Text = "Correct answer: " + qLDeKiemTra.dapAn[i];
                }
            }
            hV_DAO.SuaDiem(maBKT, maHV, diem);
            FrmMessageBox frmMessageBox = new FrmMessageBox("Your score: " + diem, "ANNOUNCEMENT");
             frmMessageBox.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
