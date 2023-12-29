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
    public partial class UC_TKB : UserControl
    {
        HV_DAO hV_DAO = new HV_DAO();
        List<string> thus = new List<string>() { "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5" , "Thứ 6", "Thứ 7", "Chủ nhật"};
        public UC_TKB(string Tuan, string maLop, int thu)
        {
            InitializeComponent();
            DataTable dt = hV_DAO.HienThiTKB(Tuan, maLop);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (string.Equals(dt.Rows[i][2].ToString(), thus[thu - 2], StringComparison.OrdinalIgnoreCase))
                {                    
                    lblThoiGian.Text = dt.Rows[i][4].ToString() + " - " + dt.Rows[i][5].ToString();
                    lblDiaDiem.Text = dt.Rows[i][3].ToString();
                    this.BackColor = ColorTranslator.FromHtml("#AFB3F9");
                    return;
                }  
                this.BackColor = Color.AliceBlue;
            }
        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblDiaDiem_Click(object sender, EventArgs e)
        {

        }

        private void lblThoiGian_Click(object sender, EventArgs e)
        {

        }
    }
}
