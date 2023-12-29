using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_group5
{
    public class classHV_DAO
    {
        DataBaseConn dbconn=new DataBaseConn();
        public classHocVien ThongTinHV(string sodienthoai)
        {
            string sqlStr = string.Format("SELECT *FROM HOCVIEN WHERE SoDT='{0}'", sodienthoai);
            DataRow dr = dbconn.LayDanhSach(sqlStr).Rows[0];
            return new classHocVien(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), DateTime.Parse(dr[4].ToString()), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString());
        }
        public classLopHoc ThongTinLop(string maLop)
        {
            string sqlStr = string.Format("SELECT *FROM Lop WHERE MaLop='{0}'", maLop);
            DataRow dr = dbconn.LayDanhSach(sqlStr).Rows[0];
            return new classLopHoc(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
        }
        public classKhoaHoc ThongTinKhoaHoc(string maKhoaHoc)
        {
            string sqlStr = string.Format("SELECT *FROM KHOAHOC WHERE MaKH='{0}'", maKhoaHoc);
            DataRow dr = dbconn.LayDanhSach(sqlStr).Rows[0];
            return new classKhoaHoc(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
        }
        public DataTable dsTuan()
        {
            string sqlStr = string.Format("SELECT * FROM Tuan");
            return dbconn.LayDanhSach(sqlStr);
        }
        public DataTable HienThiTKB( string TuanHoc, string MaLop)
        {
            string sqlStr = string.Format("select Q.MaBH,MaLop,Thu,DiaDiem,GioBatDau,GioKetThuc\r\nfrom BuoiHoc_Lop as Q,(select MaBH\r\n\t\t\t\tfrom BuoiHoc\r\n\t\t\t\twhere SoTuan='{0}') as BH\r\nwhere Q.MaLop='{1}' and Q.MaBH = BH.MaBH", TuanHoc, MaLop);
            return dbconn.LayDanhSach(sqlStr);
        }
        public DataTable LayBaiKT(string maHV)
        {
            string sqlStr = string.Format("select KiemTra.MaBKT,MaHV,KetQua,MaLop,TuanKT\r\nfrom KiemTra,BaiKiemTra\r\nwhere MaHV='{0}' and KiemTra.MaBKT=BaiKiemTra.MaBKT",maHV);
            return dbconn.LayDanhSach(sqlStr) ;
        }
        public DataTable XemDiemKT(string maBKT, string maHV)
        {
            string sqlStr = string.Format("select KetQua\r\nfrom KiemTra\r\nwhere MaBKT='{0}' and MaHV='{1}'", maBKT, maHV);
            return dbconn.LayDanhSach(sqlStr);
        }
        public void SuaDiem(string maBKT, string maHV, string diem)
        {
            string sqlStr = string.Format("UPDATE KiemTra set KetQua='{0}' where MaBKT='{1}' and MaHV='{2}'", diem, maBKT, maHV);
            dbconn.ThucThi(sqlStr, "");
        }
    }
}
