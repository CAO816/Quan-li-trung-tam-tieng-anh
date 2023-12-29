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
    public partial class FrmMessageBox : Form
    {
        public FrmMessageBox(string tb, string tit)
        {
            InitializeComponent();
            lblTitle.Text = tit;
            lblNd.Text = tb;
            if (tit == "ANNOUNCEMENT")
                pbIcon.Image = Properties.Resources.information;
            else if (tit ==  "CONFIRM")
                pbIcon.Image= Properties.Resources.question;
            else 
                pbIcon.Image = Properties.Resources.warning;
        }
        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnNo_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
