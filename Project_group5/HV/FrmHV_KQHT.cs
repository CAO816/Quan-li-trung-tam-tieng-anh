using Project_group5.QTV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Project_group5.HV
{
    public partial class FrmHV_KQHT : UserControl
    {
        public Form currentFormChild;
        FormChild formChild = new FormChild();
        List<Tuple<string, string>> myList = new List<Tuple<string, string>>();
        HV_DAO hvDAO = new HV_DAO();
        public FrmHV_KQHT(string mahv)
        {
            InitializeComponent();
            HocVien hv = hvDAO.LayThongTinHocVien(mahv);
            pnlBieuDo.Controls.Clear();
            formChild.OpenFormChild(pnlBieuDo, ref currentFormChild, new BieuDoDiem_HV(mahv, hv.ho + " " + hv.lot + " " + hv.ten));
            DataTable dsKT = hvDAO.DSDeKT(mahv);
            for (int i = 0; i < dsKT.Rows.Count; i++)
                cmbBKT.Items.Add(dsKT.Rows[i][0]);
            cmbBKT.Text = cmbBKT.Items[0].ToString();
            hienThi();
            DataTable dt = hvDAO.XemDiemKT("%", mahv);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    myList.Add(new Tuple<string, string>(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString()));
                }
            }
            else return;
        }

        private void cmbBKT_SelectedIndexChanged(object sender, EventArgs e)
        {
            hienThi();
            
        }
        private void hienThi()
        {
            DataTable dt = hvDAO.KQHT(cmbBKT.Text);
            if(dt.Rows.Count > 0)
            {
                dt.Columns.Add("Hang");
                for (int i = 0; i < dt.Rows.Count; i++)
                    dt.Rows[i]["Hang"] = i + 1;
                gvXepHang.DataSource = dt;
                gvXepHang.Columns["Hang"].DisplayIndex = 0;
                if (dt.Rows.Count > 2)
                {
                    lblTen1.Text = dt.Rows[0][0].ToString();
                    lblTen2.Text = dt.Rows[1][0].ToString();
                    lblTen3.Text = dt.Rows[2][0].ToString();
                    lblDiem1.Text = dt.Rows[0][1].ToString();
                    lblDiem2.Text = dt.Rows[1][1].ToString();
                    lblDiem3.Text = dt.Rows[2][1].ToString();
                }
                else if ( dt.Rows.Count > 1)
                {
                    lblTen1.Text = dt.Rows[0][0].ToString();
                    lblTen2.Text = dt.Rows[1][0].ToString();
                    lblDiem1.Text = dt.Rows[0][1].ToString();
                    lblDiem2.Text = dt.Rows[1][1].ToString();
                }
                else if (dt.Rows.Count > 0)
                {
                    lblTen1.Text = dt.Rows[0][0].ToString();
                    lblDiem1.Text = dt.Rows[0][1].ToString();
                }
            }
            else return;
        }
    }
}
