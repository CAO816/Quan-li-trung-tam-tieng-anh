using Project_group5.HV;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_group5
{
    internal class KhoaHoc_DAO
    {
        DataBaseConn dbConn = new DataBaseConn();
        public DataTable LayDanhSachKhoaHoc()
        {
            string sqlStr = string.Format("SELECT TenKH, MaKH, SoTiet FROM KhoaHoc");
            return dbConn.LayDanhSach(sqlStr);
        }
        public void Them(KhoaHoc kh)
        {
            string sqlStr = string.Format("Select * from KhoaHoc where MaKH = '{0}'", kh.maKhoaHoc);
            DataTable tb = dbConn.LayDanhSach(sqlStr);
            if (tb.Rows.Count > 0)
            {
                FrmMessageBox messageBox = new FrmMessageBox("The course already exists", "WARMNING");
                messageBox.ShowDialog();
                return;
            }
            sqlStr = string.Format("INSERT INTO KHOAHOC VALUES ('{0}',N'{1}', {2}, N'{3}', {4})",
                                            kh.maKhoaHoc, kh.tenKhoaHoc, int.Parse(kh.soTiet), kh.moTa, kh.thoiGianHoc);
            dbConn.ThucThi(sqlStr, "");
        }
        public void Xoa(KhoaHoc kh)
        {
            string sqlStr = string.Format("Select * from Lop where MaKH = '{0}' and NgayKetThuc > '{1}'", kh.maKhoaHoc, DateTime.Now.Date.ToString());
            DataTable tb = dbConn.LayDanhSach(sqlStr);
            if (tb.Rows.Count > 0)
            {
                FrmMessageBox messageBox = new FrmMessageBox("The course cannot be deleted, this course still has classes", "WARNMING");
                messageBox.ShowDialog();
                return;
            }
            sqlStr = string.Format("Delete From KhoaHoc where MaKH = '{0}'", kh.maKhoaHoc);
            dbConn.ThucThi(sqlStr,"");
        }
        public void Sua(KhoaHoc kh)
        {
            string sqlStr = string.Format("Select * from KhoaHoc where MaKH = '{0}'", kh.maKhoaHoc);
            DataTable tb = dbConn.LayDanhSach(sqlStr);
            if (tb.Rows.Count <= 0)
            {
                FrmMessageBox messageBox = new FrmMessageBox("The course does not exist, please check the course code","WARMNING");
                messageBox.ShowDialog();
                return;
            }
            sqlStr = string.Format("Update KhoaHoc set TenKH = N'{0}', SoTiet = '{1}', MoTa = N'{2}', ThoiGianHoc = {3}" +
                "where MaKH = '{4}'", kh.tenKhoaHoc, int.Parse(kh.soTiet), kh.moTa, kh.thoiGianHoc, kh.maKhoaHoc);
            dbConn.ThucThi(sqlStr, "");
        }
        public DataTable LayDanhSachLop(string maKH)
        {
            string sqlStr = string.Format("Select MaLop, NgayBatDau, NgayKetThuc, HoTen from " +
                "Lop join (select HoGV + ' ' + TenlotGV + ' ' + TenGV as [HoTen], MaGV from GiangVien) Q on Lop.MaGV = Q.MaGV " +
                "where MaKh = '{0}'", maKH);
            return dbConn.LayDanhSach(sqlStr);
        }
        public KhoaHoc LayThongTinKhoaHoc(string maKH)
        {
            string sqlStr = string.Format("Select * from KhoaHoc where MaKH = '{0}'", maKH);
            DataTable tb = dbConn.LayDanhSach(sqlStr);
            if (tb.Rows.Count > 0)
            {
                DataRow r = tb.Rows[0];
                KhoaHoc kh = new KhoaHoc(r["MaKH"].ToString(), r["TenKH"].ToString(), r["SoTiet"].ToString(),
                                        r["MoTa"].ToString(), int.Parse(r["ThoiGianHoc"].ToString()));
                return kh;
            }
            else
            { return null; }
        }
    }
}
