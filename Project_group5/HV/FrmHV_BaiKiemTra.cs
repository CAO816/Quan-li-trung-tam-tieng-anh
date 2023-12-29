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
    public partial class FrmHV_BaiKiemTra : UserControl
    {
        HV_DAO hV_DAO = new HV_DAO();
        string maHV;
        public FrmHV_BaiKiemTra(string maHocVien)
        {
            InitializeComponent();
            flpKT.AutoScroll = true;
            maHV = maHocVien;
            DataTable dt = hV_DAO.LayBaiKT(maHV);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                UCHV_kiemTra uc = new UCHV_kiemTra(i, dt.Rows[i]);
                flpKT.Controls.Add(uc);
            }
        }
    }
}
