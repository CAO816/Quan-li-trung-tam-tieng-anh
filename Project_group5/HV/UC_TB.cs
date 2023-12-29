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
    public partial class UC_TB : UserControl
    {
        public UC_TB(string tg, string noiDung)
        {
            InitializeComponent();
            lblTG.Text = tg;
            lblND.Text = noiDung;
        }
    }
}
