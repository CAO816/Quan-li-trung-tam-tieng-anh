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
    public partial class UCNgay : UserControl
    {
        DateTime today = DateTime.Now;
        public UCNgay()
        {
            InitializeComponent();
        }
        public void songay(int ngay)
        {
            lblDay.Text = ngay + " ";
        }
        public void kiemtraDL(int year, int month, int day)
        {

            if (day == today.Day && month == today.Month && year == today.Year)
            {
                this.BackColor = Color.Pink;
            }
        }
    }
}
