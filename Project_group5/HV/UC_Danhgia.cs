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
    public partial class UC_Danhgia : UserControl
    {
        public UC_Danhgia(string tieude)
        {
            InitializeComponent();
            lblNdDg.Text = tieude;
        }

        public int indexCheck()
        {
            if (rd1.Checked)
                return 1;
            if(rd2.Checked)
                return 2;
            if(rd3.Checked)
                return 3;
            if(rd4.Checked)
                return 4;
            if(rd5.Checked)
                return 5;
            return -1;
        }
    }
}
