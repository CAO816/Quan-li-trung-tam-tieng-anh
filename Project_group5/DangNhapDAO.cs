using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Project_group5
{
    public  class DangNhapDAO
    {
        DataBaseConn dbcon = new DataBaseConn();
        public bool KiemTraHVDN (TaiKhoan tk)
        {
            string sqlStr = string.Format("select * from TaiKhoan,HocVien where TK=MaHV and TK='{0}' and MatKhau='{1}' ",tk.tK,tk.matKhau);
            DataTable dt= dbcon.LayDanhSach(sqlStr);
            if( dt.Rows.Count>0) return true;
            return false;
        }
        public bool KiemTraGVDN(TaiKhoan tk)
        {
            string sqlStr = string.Format("select * from TaiKhoan, GiangVien where TK=MaGV and TK='{0}' and MatKhau='{1}' ", tk.tK, tk.matKhau);
            DataTable dt = dbcon.LayDanhSach(sqlStr);
            if (dt.Rows.Count > 0)
            {
                return true;
            } 
                
            return false;
        }
        public bool KiemTraNVDN(TaiKhoan tk)
        {
            string sqlStr = string.Format("select * from TaiKhoan, NhanVien where TK=MaNV and TK='{0}' and MatKhau='{1}' ", tk.tK, tk.matKhau);
            DataTable dt = dbcon.LayDanhSach(sqlStr);
            if (dt.Rows.Count > 0) return true;
            return false;
        }
        public DataTable KiemTraThongTin(string mahv)
        {
            string sqlStr = string.Format("(select MaHV,cmnd,Email from HOCVIEN where MaHV='{0}' ) ",mahv);
            return dbcon.LayDanhSach(sqlStr);
        }
        public void DoiMatKhau(string TK, string MatKhauMoi)
        {
            string sqlStr = string.Format("update TaiKhoan set MatKhau='{0}' where TK='{1}'", MatKhauMoi, TK);
            dbcon.ThucThi(sqlStr);
        }
        public bool KiemTraDN_QTV(TaiKhoan tk)
        {
            string sqlStr = string.Format("select * from QUANTRIVIEN_TK where TK_QTV='{0}' and MatKhau='{1}' ", tk.tK, tk.matKhau);
            DataTable dt = dbcon.LayDanhSach(sqlStr);
            if (dt.Rows.Count > 0) return true;
            return false;
        }
    }
}
