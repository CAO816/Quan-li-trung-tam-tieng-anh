using Project_group5.HV;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_group5
{
    internal class LopHocDAO
    {
        DataBaseConn dbConn = new DataBaseConn();
        public DataTable LayDanhSachLopHoc()
        {
            string sqlStr = string.Format("Select MaLop, HoTen, TenKH, SiSo, NgayBatDau, NgayKetThuc from KhoaHoc join (Select Lop.MaLop, HoGV + ' ' + TenlotGV + ' ' + TenGV as [HoTen], SiSo, NgayBatDau, NgayKetThuc, MaKH from Lop join GiangVien on Lop.MaGV = GiangVien.MaGV) Q on Q.MaKH = KhoaHoc.MaKH");
            return dbConn.LayDanhSach(sqlStr);
        }
        public void ThemBaiKiemTra(LopHoc lop)
        {
            string sqlStr = string.Format("select * from KhoaHoc where MaKH = '{0}'", lop.maKhoaHoc);
            DataTable KhoaHoc = dbConn.LayDanhSach(sqlStr);
            DataRow drKhoaHoc = KhoaHoc.Rows[0];
            int soBaiKT = int.Parse(drKhoaHoc["SoTiet"].ToString()) / 12 + 1;
            for (int i = 0; i < soBaiKT; i++)
            {
                string maBKT, tuan;
                if (i < 9)
                {
                    maBKT = "B0" + (i + 1).ToString() + "_" + lop.maLop;
                }
                else
                {
                    maBKT = "B" + (i + 1).ToString() + "_" + lop.maLop;
                }
                if (i < 2)
                {
                    tuan = "Tuần 0" + ((i + 1) * 4).ToString();
                }
                else
                {
                    tuan = "Tuần " + ((i + 1) * 4).ToString();
                }
                sqlStr = string.Format("Insert into BaiKiemTra values ('{0}', N'{1}', '{2}')", maBKT, tuan, lop.maLop);
                dbConn.ThucThi(sqlStr);
            }
        }
        public void ThemBuoiHoc_Lop(LopHoc lop, int thu, string diaDiem, DateTime gioBD, DateTime gioKT)
        {
            IDictionary<int, string> thu_dct = new Dictionary<int, string>();
            thu_dct.Add(1, "Thứ 2");
            thu_dct.Add(2, "Thứ 3");
            thu_dct.Add(3, "Thứ 4");
            thu_dct.Add(4, "Thứ 5");
            thu_dct.Add(5, "Thứ 6");
            thu_dct.Add(0, "Thứ 7");
            int ngay = thu + 1;
            string sqlStr = string.Format("select * from KhoaHoc where MaKH = '{0}'", lop.maKhoaHoc);
            DataTable KhoaHoc = dbConn.LayDanhSach(sqlStr);
            DataRow drKhoaHoc = KhoaHoc.Rows[0];
            int soBH = int.Parse(drKhoaHoc["SoTiet"].ToString());
            for (int i = 0; i < soBH; i++)
            {
                string maBH;
                if (i < 9)
                {
                    maBH = "BH-00" + (i + 1).ToString();
                }
                else if (i < 99)
                {
                    maBH = "BH-0" + (i + 1).ToString();
                }
                else
                {
                    maBH = "BH-" + (i + 1).ToString();
                }
                ngay += 2;
                sqlStr = string.Format("insert into BuoiHoc_Lop values ('{0}', '{1}', N'{2}', N'{3}', '{4}', '{5}')",
                                                maBH, lop.maLop, thu_dct[ngay % 6], diaDiem, gioBD, gioKT);
                dbConn.ThucThi(sqlStr);
            }
        }
        private void ThemLop(LopHoc lop, int thu, string diaDiem, DateTime gioBD, DateTime gioKT)
        {
            string sqlStr = string.Format("insert into Lop values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                                            lop.maLop, lop.ngayBatDau, lop.ngayKetThuc, lop.triGia, lop.siSo, lop.maGV, lop.maKhoaHoc);
            dbConn.ThucThi(sqlStr, "");
            ThemBaiKiemTra(lop);
            ThemBuoiHoc_Lop(lop, thu, diaDiem, gioBD, gioKT);
        }
        public void ThemLop(LopHoc lop, GiangVien gv, int ngay, DateTime gioBD, DateTime gioKT, string diaDiem)
        {
            LopHoc checkLop = LayThongTinLopHoc(lop.maLop);
            if (checkLop != null)
            {
                FrmMessageBox frmMessageBox = new FrmMessageBox("This classID already exists", "WARNING");
                frmMessageBox.ShowDialog();
            }
            else
            {
                string thu = "Thứ " + (ngay + 1).ToString();
                string sqlStr = string.Format("select * from BuoiHoc_Lop join (select MaLop from Lop where NgayKetThuc > '{0}' and MaGV = '{1}') Q on BuoiHoc_Lop.MaLop = Q.MaLop where Thu = N'{2}' and GioBatDau = '{3}' and DiaDiem = N'{4}'", lop.ngayBatDau, lop.maGV, thu, gioBD, diaDiem);
                DataTable tb = dbConn.LayDanhSach(sqlStr);
                if (tb.Rows.Count <= 0)
                {
                    ThemLop(lop, ngay, diaDiem, gioBD, gioKT);
                }
                else
                {
                    FrmMessageBox frmMessageBox = new FrmMessageBox("This class cannot be added", "WARNING");
                    frmMessageBox.ShowDialog();
                }
            }
        }
        public void XoaLop(LopHoc lop)
        {
            string sqlStr = string.Format("Select * from HocVien where MaLop = '{0}'", lop.maLop);
            DataTable tb = dbConn.LayDanhSach(sqlStr);
            if (lop.ngayBatDau > DateTime.Now || lop.ngayKetThuc < DateTime.Now)
            {
                sqlStr = string.Format("delete from DanhGia where MaLop ='{0}'", lop.maLop);
                dbConn.ThucThi(sqlStr);
                sqlStr = string.Format("delete from ThongBao where MaLop ='{0}'", lop.maLop);
                dbConn.ThucThi(sqlStr);
                sqlStr = string.Format("delete from KiemTra where MaHV in (select MaHV from HocVien where MaLop ='{0}')", lop.maLop);
                dbConn.ThucThi(sqlStr);
                sqlStr = string.Format("delete from TaiKhoan where Tk in (select MaHV from HocVien where MaLop ='{0}')", lop.maLop);
                dbConn.ThucThi(sqlStr);
                sqlStr = string.Format("delete from DiemDanh where MaHV in (select MaHV from HocVien where MaLop ='{0}')", lop.maLop);
                dbConn.ThucThi(sqlStr);
                sqlStr = string.Format("delete from HocVien where MaLop = '{0}'", lop.maLop);
                dbConn.ThucThi(sqlStr);
                sqlStr = string.Format("delete from BaiKiemTra where MaLop = '{0}'", lop.maLop);
                dbConn.ThucThi(sqlStr);
                sqlStr = string.Format("delete from BuoiHoc_lop where MaLop ='{0}'", lop.maLop);
                dbConn.ThucThi(sqlStr);
                sqlStr = string.Format("delete from Lop where MaLop ='{0}'", lop.maLop);
                dbConn.ThucThi(sqlStr, "");
            }
            else
            {
                FrmMessageBox frmMessageBox = new FrmMessageBox("This class cannot be deleted", "WARNING");
                frmMessageBox.ShowDialog();
            }
        }
        private void Sua(LopHoc lop)
        {
            string sqlStr = string.Format("Update Lop Set NgayBatDau = '{0}', NgayKetThuc ='{1}'," +
                "TriGia = '{2}', SiSo = '{3}', MaGV = '{4}' where MaLop = '{5}'", lop.ngayBatDau, lop.ngayKetThuc,
                lop.triGia, lop.siSo, lop.maGV, lop.maLop);
            dbConn.ThucThi(sqlStr, "");
        }
        public void SuaLop(LopHoc lop)
        {
            LopHoc lopCur = LayThongTinLopHoc(lop.maLop);
            if (lop.maGV == lopCur.maGV)
            {
                Sua(lop);
            }
            else
            {
                string lichHoc = LayLichHoc(lop.maLop);
                string sqlStr = string.Format("select NgayBatDau from Lop where MaLop = '{0}'", lop.maLop);
                string ngayBatDau = dbConn.LayDanhSach(sqlStr).Rows[0]["NgayBatDau"].ToString();
                string gioBatDau = LayGioBatDau(lop.maLop);
                if (KiemTraGioBatDau(lop.maGV, lichHoc, ngayBatDau, gioBatDau))
                    Sua(lop);
                else
                {
                    FrmMessageBox frmMessageBox = new FrmMessageBox("This teacher has a different teaching schedule", "WARNING");
                    frmMessageBox.ShowDialog();
                }
            }
        }
        public string TenGiangVienTheoLop(string maLop)
        {
            string sqlStr = string.Format("select HoGV, TenlotGV, TenGV from GiangVien join Lop on GiangVien.MaGV = Lop.MaGV where Lop.MaLop = '{0}'", maLop);
            DataTable tb = dbConn.LayDanhSach(sqlStr);
            if (tb.Rows.Count > 0)
            {
                DataRow dr = tb.Rows[0];
                return dr["HoGV"].ToString() + " " + dr["TenlotGV"].ToString() + " " + dr["TenGV"].ToString();
            }
            else
            { return ""; }
        }
        public string TenGiangVienTheoMaGV(string maGV)
        {
            string sqlStr = string.Format("select HoGV, TenlotGV, TenGV from GiangVien where MaGV = '{0}'", maGV);
            DataTable tb = dbConn.LayDanhSach(sqlStr);
            if (tb.Rows.Count > 0)
            {
                DataRow dr = tb.Rows[0];
                return dr["HoGV"].ToString() + " " + dr["TenlotGV"].ToString() + " " + dr["TenGV"].ToString();
            }
            else
            { return ""; }
        }
        public DataTable LayDanhSachHocVien(string maLop)
        {
            string sqlStr = string.Format("select MaHV,HoHV+' '+TenlotHV+' '+TenHV as HoTen, NgaySinh,Cmnd,SoDT,Email from HocVien where MaLop = '{0}'", maLop);
            return dbConn.LayDanhSach(sqlStr);
        }
        public LopHoc LayThongTinLopHoc(string maLop)
        {
            string sqlStr = string.Format("Select * from Lop where MaLop = '{0}'", maLop);
            DataTable tb = dbConn.LayDanhSach(sqlStr);
            if (tb.Rows.Count > 0)
            {
                DataRow dr = tb.Rows[0];
                LopHoc lop = new LopHoc(dr[0].ToString(), DateTime.Parse(dr[1].ToString()), DateTime.Parse(dr[2].ToString()),
                                        dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
                return lop;
            }
            else
            {
                return null;
            }
        }
        public DataTable LayDanhSachKhoaHoc()
        {
            string sqlStr = string.Format("Select MaKH from KhoaHoc");
            return dbConn.LayDanhSach(sqlStr);
        }
        public DataTable LayDanhSachGiangVien()
        {
            string sqlStr = string.Format("Select MaGV from GiangVien order by MaGV");
            return dbConn.LayDanhSach(sqlStr);
        }
        public GiangVien LayThongTinGiangVien(string maGV)
        {
            string sqlStr = string.Format("select * from GiangVien where MaGV = '{0}'", maGV);
            DataTable tb = dbConn.LayDanhSach(sqlStr);
            if (tb.Rows.Count > 0)
            {
                DataRow dr = tb.Rows[0];
                GiangVien gv = new GiangVien(dr["MaGV"].ToString(), dr["HoGV"].ToString(), dr["TenlotGV"].ToString(),
                                                dr["TenGV"].ToString(), dr["Cmnd"].ToString(), dr["SoDT"].ToString(), dr["Email"].ToString());
                return gv;
            }
            else
            { return null; }
        }
        public KhoaHoc LayThongTinKhoaHoc(string maKH)
        {
            string sqlStr = string.Format("select * from KhoaHoc where MaKH ='{0}'", maKH);
            DataTable tb = dbConn.LayDanhSach(sqlStr);
            if (tb.Rows.Count > 0)
            {
                DataRow dr = tb.Rows[0];
                KhoaHoc kh = new KhoaHoc(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(),
                                        dr[3].ToString(), int.Parse(dr[4].ToString()));
                return kh;
            }
            else { return null; }
        }
        public DataTable layTuanHoc(string MaLop)
        {
            string sqlStr = string.Format("select distinct SoTuan from BuoiHoc where MaBH in (select MaBH from BuoiHoc_Lop where BuoiHoc_Lop.MaLop='{0}')", MaLop);
            return dbConn.LayDanhSach(sqlStr);
        }
        public DataTable LayTKB(string TuanHoc, string MaLop)
        {
            string sqlStr = string.Format("select Q.MaBH as [Mã buổi hoc] ,MaLop as [Mã lớp],Thu as [Thứ] ,DiaDiem as [Địa điểm] ,GioBatDau as [Giờ bắt đầu],GioKetThuc as[Giờ kết thúc]" +
                " from BuoiHoc_Lop as Q,(select MaBH from BuoiHoc where SoTuan='{0}') as BH where Q.MaLop='{1}' and Q.MaBH = BH.MaBH", TuanHoc, MaLop);
            return dbConn.LayDanhSach(sqlStr);
        }
        public void SuaTKB(BuoiHoc_Lop buoiHoc)
        {
            string sqlStr = string.Format("update BuoiHoc_Lop set Thu= '{0}', DiaDiem= N'{1}', GioBatDau='{2}', GioKetThuc='{3}' where MaBH='{4}' and MaLop='{5}'",
                buoiHoc.thu, buoiHoc.diaDiem, buoiHoc.gioBatDau.ToShortTimeString(), buoiHoc.gioKetThuc.ToShortTimeString(), buoiHoc.maBH, buoiHoc.maLop);
            dbConn.ThucThi(sqlStr);
        }
        public DataTable DiemTrungBinhTheoLop()
        {
            string sqlStr = string.Format("select MaLop, avg(DTB) as TB from HocVien join (select MaHV, avg(KetQua) as DTB from KiemTra group by MaHV) Q on HocVien.MaHV = Q.MaHV group by MaLop");
            return dbConn.LayDanhSach(sqlStr);
        }
        public string TenKhoaHoc(string maKh)
        {
            string sqlStr = string.Format("select * from KhoaHoc where MaKH = '{0}'", maKh);
            DataTable tb = dbConn.LayDanhSach(sqlStr);
            if (tb.Rows.Count > 0)
            {
                DataRow dr = tb.Rows[0];
                return dr["TenKH"].ToString();
            }
            else
            { return ""; }
        }
        public BuoiHoc_Lop laybuoiHoc_Lop(string maLop)
        {
            string sqlStr = string.Format("select top(1) * from BuoiHoc_Lop where MaLop='{0}'", maLop);
            DataRow dr = dbConn.LayDanhSach(sqlStr).Rows[0];
            return new BuoiHoc_Lop(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), DateTime.Parse(dr[4].ToString()), DateTime.Parse(dr[5].ToString()));
        }
        public bool KiemTraGioBatDau(string maGV, string lichHoc, string ngayBatDau, string gioBatDau)
        {
            if (lichHoc == "Thứ 2, Thứ 4, Thứ 6")
                lichHoc = "Thứ 2";
            else
                lichHoc = "Thứ 3";
            string sqlStr = string.Format("select * from BuoiHoc_Lop join (select MaLop from Lop where NgayKetThuc > '{0}' and MaGV = '{1}') Q on BuoiHoc_Lop.MaLop = Q.MaLop where Thu = N'{2}' and GioBatDau = '{3}'", ngayBatDau, maGV, lichHoc,gioBatDau);
            DataTable tb = dbConn.LayDanhSach(sqlStr);
            if (tb.Rows.Count > 0)
            {
                return false;
            }
            return true;
        }
        public bool KiemTraPhong(string lichHoc, string ngayBatDau, string gioBatDau, string diaDiem)
        {
            if (lichHoc == "Thứ 2, Thứ 4, Thứ 6")
                lichHoc = "Thứ 2";
            else
                lichHoc = "Thứ 3";
            string sqlStr = string.Format("select * from BuoiHoc_Lop join (select MaLop from Lop where NgayKetThuc > '{0}') Q on BuoiHoc_Lop.MaLop = Q.MaLop where Thu = N'{1}' and GioBatDau = '{2}' and DiaDiem = N'{3}'", ngayBatDau, lichHoc, gioBatDau, diaDiem);
            DataTable tb = dbConn.LayDanhSach(sqlStr);
            if (tb.Rows.Count > 0)
            {
                return false;
            }
            return true;
        }
        public string LayLichHoc(string maLop)
        {
            string sqlStr = string.Format("select Thu, count(Thu) as SL from BuoiHoc_Lop where MaLop = '{0}' group by Thu order by SL desc", maLop);
            string lichHoc = dbConn.LayDanhSach(sqlStr).Rows[0]["Thu"].ToString();
            if (lichHoc == "Thứ 2" || lichHoc == "Thứ 4" || lichHoc == "Thứ 6")
                lichHoc = "Thứ 2, Thứ 4, Thứ 6";
            else
                lichHoc = "Thứ 3, Thứ 5, Thứ 7";
            return lichHoc;
        }
        public string LayDiaDiem(string maLop)
        {
            string sqlStr = string.Format("select DiaDiem, count(DiaDiem) as SL from BuoiHoc_Lop where MaLop = '{0}' group by DiaDiem order by SL desc", maLop);
            return dbConn.LayDanhSach(sqlStr).Rows[0]["DiaDiem"].ToString();
        }
        public string LayGioBatDau(string maLop)
        {
            string sqlStr = string.Format("select GioBatDau, count(GioBatDau) as SL from BuoiHoc_Lop where MaLop = '{0}' group by GioBatDau order by SL desc", maLop);
            string gioBatDau = dbConn.LayDanhSach(sqlStr).Rows[0]["GioBatDau"].ToString();
            return gioBatDau.Remove(gioBatDau.Length - 3);
        }
    }
}
