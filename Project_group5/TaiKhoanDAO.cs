using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_group5
{
    internal class TaiKhoanDAO
    {
        DataBaseConn dbConn = new DataBaseConn();
        public DataTable LayDanhSachTaiKhoanGiangVien()
        {
            string sqlStr = string.Format("SELECT MaGV, HoGV + ' ' + TenlotGV + ' ' + TenGV as [HoTen], SoDT FROM TaiKhoan join (select * from GiangVien) Q on TaiKhoan.TK = Q.MaGV");
            return dbConn.LayDanhSach(sqlStr);
        }
        public DataTable LayDanhSachTaiKhoanHocVien()
        {
            string sqlStr = string.Format("SELECT MaHV, HoHV + ' ' + TenlotHV + ' ' + TenHV as [HoTen], SoDT FROM TaiKhoan join (select * from HocVien) Q on TaiKhoan.TK = Q.MaHV");
            return dbConn.LayDanhSach(sqlStr);
        }
        public void TaoTK(string doiTuong, TaiKhoan tk)
        {
            string col;
            if (doiTuong == "HocVien")
                col = "MaHV";
            else
                col = "MaGV";
            string sqlStr = string.Format("select * from {0} where {1} = '{2}'", doiTuong, col, tk.tK);
            DataTable tb = dbConn.LayDanhSach(sqlStr);
            if (tb.Rows.Count > 0)
            {
                sqlStr = string.Format("select * from TaiKhoan where Tk = '{0}'", tk.tK);
                DataTable tbTk = dbConn.LayDanhSach(sqlStr);
                if (tbTk.Rows.Count > 0)
                {
                    MessageBox.Show("Tài khoản đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    sqlStr = string.Format("Insert into TaiKhoan values('{0}', '{1}', '{2}')", tk.tK, tk.matKhau, "1");
                    dbConn.ThucThi(sqlStr, "");
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy đối tượng có thể sử dụng tài khoản này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void XoaTk(string doiTuong, string tk)
        {
            string sqlStr = string.Format("select * from TaiKhoan where Tk = '{0}'", tk);
            DataTable tb = dbConn.LayDanhSach(sqlStr);
            if (tb.Rows.Count > 0)
            {
                string col;
                if (doiTuong == "HocVien")
                    col = "MaHV";
                else 
                    col = "MaGV";
                sqlStr = string.Format("select * from {0} where {1} = '{2}'", doiTuong, col, tk);
                DataTable tbTk = dbConn.LayDanhSach(sqlStr);
                if (tbTk.Rows.Count > 0)
                {
                    MessageBox.Show("Không thể xóa tài khoản này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    sqlStr = string.Format("Delete from TaiKhoan where Tk = '{0}'", tk);
                    dbConn.ThucThi(sqlStr, "");
                }
            }
            else
            {
                MessageBox.Show("Tài khoản không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public DataRow ThongTinGV(string maGV)
        {
            string sqlStr = string.Format("SELECT MaGV, HoGV + ' ' + TenlotGV + ' ' + TenGV as [HoTen], MatKhau, Email, SoDT FROM TaiKhoan join (select * from GiangVien) Q on TaiKhoan.TK = Q.MaGV where MaGV = '{0}'", maGV);
            DataTable tb = dbConn.LayDanhSach(sqlStr);
            if (tb.Rows.Count > 0)
                return tb.Rows[0];
            else
                return null;
        }
        public DataRow ThongTinHV(string maHV)
        {
            string sqlStr = string.Format("SELECT MaHV, HoHV + ' ' + TenlotHV + ' ' + TenHV as [HoTen], MatKhau, Email, SoDT FROM TaiKhoan join (select * from HocVien) Q on TaiKhoan.TK = Q.MaHV where MaHV = '{0}'", maHV);
            DataTable tb = dbConn.LayDanhSach(sqlStr);
            if (tb.Rows.Count > 0)
                return tb.Rows[0];
            else
                return null;
        }
        public DataTable TimKiemGV(string thongTin)
        {
            string sqlStr = string.Format("Select MaGV, HoTen, SoDT from TaiKhoan join (SELECT MaGV + HoGV + ' ' + TenlotGV + ' ' + TenGV + SoDT as [ThongTin], MaGV, HoGV + ' ' + TenlotGV + ' ' + TenGV as [HoTen], SoDT FROM TaiKhoan join (select * from GiangVien) Q on TaiKhoan.TK = Q.MaGV) P on TK = MaGV where ThongTin like N'%{0}%'", thongTin);
            return dbConn.LayDanhSach(sqlStr);
        }
        public DataTable TimKiemHV(string thongTin)
        {
            string sqlStr = string.Format("Select MaHV, HoTen, SoDT from TaiKhoan join (SELECT MaHV + HoHV + ' ' + TenlotHV + ' ' + TenHV + SoDT as [ThongTin], MaHV, HoHV + ' ' + TenlotHV + ' ' + TenHV as [HoTen], SoDT FROM TaiKhoan join (select * from HocVien) Q on TaiKhoan.TK = Q.MaHV) P on TK = MaHV where ThongTin like N'%{0}%'", thongTin);
            return dbConn.LayDanhSach(sqlStr);
        }
    }
}
