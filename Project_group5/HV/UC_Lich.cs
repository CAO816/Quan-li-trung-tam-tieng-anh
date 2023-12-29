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
    public partial class UC_Lich : UserControl
    {
        List<string> months = new List<string>() { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        DateTime datecal;
        public UC_Lich()
        {
            InitializeComponent();
        }

        private void UC_Lich_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            datecal = new DateTime(now.Year, now.Month, 1);
            lblThang.Text = months[ int.Parse(datecal.Month.ToString()) -1 ] + " , " + datecal.Year.ToString();
            Hienlich();
        }

        private void btnThangSau_Click(object sender, EventArgs e)
        {
            fpnlDays.Controls.Clear();
            datecal = datecal.AddMonths(1);
            lblThang.Text = months[int.Parse(datecal.Month.ToString()) - 1] + " , " + datecal.Year.ToString();
            Hienlich();
        }

        private void btnThangTruoc_Click(object sender, EventArgs e)
        {
            fpnlDays.Controls.Clear();
            datecal = datecal.AddMonths(-1);
            lblThang.Text = months[int.Parse(datecal.Month.ToString()) - 1] + " , " + datecal.Year.ToString();
            Hienlich();
        }
        private void Hienlich()
        {
            DateTime ngaydau = datecal;
            int songay = DateTime.DaysInMonth(datecal.Year, datecal.Month);
            int ngaytrongtuan = Convert.ToInt32(ngaydau.DayOfWeek.ToString("d")) + 1;

            for (int i = 1; i < ngaytrongtuan; i++)
            {
                UCBlank ucblank = new UCBlank();
                fpnlDays.Controls.Add(ucblank);
            }

            for (int i = 1; i <= songay; i++)
            {
                UCNgay ucngay = new UCNgay();
                ucngay.songay(i);
                ucngay.kiemtraDL(datecal.Year, datecal.Month, i);
                fpnlDays.Controls.Add(ucngay);
            }
        }
    }
}
