using Project_group5.HV;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Project_group5
{
    public class HV_DAO
    {
        DataBaseConn dbconn = new DataBaseConn();
        DateTime today = DateTime.Now;
        public HocVien ThongTinHV(string maHV)
        {
            string sqlStr = string.Format("SELECT *FROM HOCVIEN WHERE MaHV='{0}'", maHV);
            DataRow dr = dbconn.LayDanhSach(sqlStr).Rows[0];
            return new HocVien(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), DateTime.Parse(dr[4].ToString()), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString());
        }
        public LopHoc ThongTinLop(string maLop)
        {
            string sqlStr = string.Format("SELECT *FROM Lop WHERE MaLop='{0}'", maLop);
            DataRow dr = dbconn.LayDanhSach(sqlStr).Rows[0];
            return new LopHoc(dr[0].ToString(), DateTime.Parse(dr[1].ToString()), DateTime.Parse(dr[2].ToString()), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
        }
        public KhoaHoc ThongTinKhoaHoc(string maKhoaHoc)
        {
            string sqlStr = string.Format("SELECT *FROM KHOAHOC WHERE MaKH='{0}'", maKhoaHoc);
            DataRow dr = dbconn.LayDanhSach(sqlStr).Rows[0];
            return new KhoaHoc(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), int.Parse(dr[4].ToString()));
        }
        public DataTable layTuanHoc(string MaLop)
        {
            string sqlStr = string.Format("select distinct SoTuan from BuoiHoc where MaBH in (select MaBH from BuoiHoc_Lop where BuoiHoc_Lop.MaLop='{0}')", MaLop);
            return dbconn.LayDanhSach(sqlStr);
        }
        public DataTable HienThiTKB(string TuanHoc, string MaLop)
        {
            string sqlStr = string.Format("select Q.MaBH,MaLop,Thu,DiaDiem,GioBatDau,GioKetThuc from BuoiHoc_Lop as Q,(select MaBH from BuoiHoc where SoTuan= N'{0}') as BH where Q.MaLop='{1}' and Q.MaBH = BH.MaBH", TuanHoc, MaLop);
            return dbconn.LayDanhSach(sqlStr);
        }
        public DataTable LayBaiKT(string maHV)
        {
            string sqlStr = string.Format("select KiemTra.MaBKT,MaHV,KetQua,MaLop,TuanKT\r\nfrom KiemTra,BaiKiemTra\r\nwhere MaHV='{0}' and KiemTra.MaBKT=BaiKiemTra.MaBKT", maHV);
            return dbconn.LayDanhSach(sqlStr);
        }
        public DataTable XemDiemKT(string maBKT, string maHV)
        {
            string sqlStr = string.Format("select KetQua from KiemTra where MaBKT='{0}' and MaHV='{1}'", maBKT, maHV);
            return dbconn.LayDanhSach(sqlStr);
        }
        public void SuaDiem(string maBKT, string maHV, string diem)
        {
            string sqlStr = string.Format("UPDATE KiemTra set KetQua='{0}' where MaBKT='{1}' and MaHV='{2}'", diem, maBKT, maHV);
            dbconn.ThucThi(sqlStr);
        }
        public DataTable KQHT(string maBaiKT)
        {
            string sqlStr = string.Format("select HoHV+' '+TenlotHV+' '+TenHV as[HoTen], KetQua from HOCVIEN, (select * from KiemTra where MaBKT='{0}') as KQ where HOCVIEN.MaHV=kq.MaHV order by KetQua DESC", maBaiKT);
            return dbconn.LayDanhSach(sqlStr);
        }
        public DataTable LayDanhSachHocVien()
        {
            string sqlStr = string.Format("SELECT *FROM HocVien");
            return dbconn.LayDanhSach(sqlStr);
        }
        public void ThemDanhGia(string maHV, string maGV, string maLop, List<string> list)
        {
            string sqlStr = string.Format("insert into DanhGia values ('{0}','{1}','{2}','{3}'", maHV, maGV, maLop, today.ToShortDateString());
            for (int i = 0; i < list.Count; i++)
            {
                sqlStr = sqlStr + string.Format(", {0}", list[i]);
            }
            dbconn.ThucThi(sqlStr + ")");
        }
        public void Them(HocVien hv)
        {
            string sqlStr = string.Format("select MaHV from HocVien order by MaHV");
            DataTable dt = dbconn.LayDanhSach(sqlStr);
            string maHV_last = dt.Rows[dt.Rows.Count - 1][0].ToString();
            maHV_last = maHV_last[3].ToString() + maHV_last[4] + maHV_last[5] + maHV_last[6];
            string maHV = (int.Parse(maHV_last) + 1).ToString();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string ma = dt.Rows[i][0].ToString();
                ma = ma[3].ToString() + ma[4] + ma[5] + ma[6];
                if (int.Parse(ma) != i + 1)
                {
                    maHV = (i + 1).ToString();
                    break;
                }
            }
            while (maHV.Length < 4)
                maHV = '0' + maHV;
            maHV = "HV-" + maHV;
            sqlStr = string.Format("select NgayBatDau, SiSo From Lop Where MaLop = '{0}'", hv.maLop);
            DataTable tb = dbconn.LayDanhSach(sqlStr);
            if (tb.Rows.Count != 0)
            {
                //dem so hoc vien cua lop
                sqlStr = string.Format("select count(*) as SL from HocVien where MaLop = '{0}'", hv.maLop);
                DataTable tbSoLuong = dbconn.LayDanhSach(sqlStr);
                DataRow rowSoLuong = tbSoLuong.Rows[0];
                int sl = int.Parse(rowSoLuong["SL"].ToString());
                //lay siso va ngay bat dau cua lop
                DataRow row = tb.Rows[0];
                int SiSo = int.Parse(row["SiSo"].ToString());
                DateTime ngay = DateTime.Parse(row["NgayBatDau"].ToString());
                if (sl >= SiSo)
                {
                    MessageBox.Show("Lớp học này đã đủ học viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (ngay < DateTime.Now)
                    {
                        FrmMessageBox frmMessageBox = new FrmMessageBox("This class has started, do you still want to add students to this class?", "INFORMATION");
                        DialogResult result = frmMessageBox.ShowDialog();
                        if (result != DialogResult.OK)
                        {
                            return;
                        }
                    }
                    sqlStr = string.Format("INSERT INTO HocVien VALUES ('{0}', N'{1}', N'{2}', N'{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')",
                                                        maHV, hv.ho, hv.lot, hv.ten, hv.ngaySinh, hv.cmnd, hv.diaChi, hv.sdt, hv.email, hv.maLop);
                    string sqlStr1 = string.Format("INSERT INTO TaiKhoan VALUES ('{0}', '{1}', '{2}')", maHV, "1", "1");
                    dbconn.ThucThi(sqlStr, sqlStr1);
                    xoa_HocVien_DKy(hv.sdt);
                    //lay ma khoa hoc
                    sqlStr = string.Format("Select MaKH from Lop where MaLop = '{0}'", hv.maLop);
                    string maKH = dbconn.LayDanhSach(sqlStr).Rows[0]["MaKH"].ToString();
                    //lay so tiet hoc
                    sqlStr = string.Format("Select SoTiet from KhoaHoc where MaKH = '{0}'", maKH);
                    int soTiet = int.Parse(dbconn.LayDanhSach(sqlStr).Rows[0]["SoTiet"].ToString());
                    for (int i = 0; i < soTiet; i++)
                    {
                        string maBH;
                        if (i < 9)
                            maBH = "BH-00" + (i + 1).ToString();
                        else if (i < 99)
                            maBH = "BH-0" + (i + 1).ToString();
                        else maBH = "BH-" + (i + 1).ToString();
                        sqlStr = string.Format("insert into DiemDanh values ('{0}','{1}',1)", maBH, maHV);
                        dbconn.ThucThi(sqlStr);
                    }
                }
            }
        }
        public void Xoa(HocVien hv)
        {
            //xoa hoc vien trong bang diem danh
            string sqlStr = string.Format("select * from DiemDanh where MaHV = '{0}'", hv.maHV);
            DataTable tb = dbconn.LayDanhSach(sqlStr);
            if (tb.Rows.Count > 0)
            {
                sqlStr = string.Format("Delete from DiemDanh where MaHV = '{0}'", hv.maHV);
                dbconn.ThucThi(sqlStr);
            }
            //xoa hoc vien trong bang kiem tra
            sqlStr = string.Format("select * from KiemTra where MaHV = '{0}'", hv.maHV);
            tb = dbconn.LayDanhSach(sqlStr);
            if (tb.Rows.Count > 0)
            {
                sqlStr = string.Format("Delete from KiemTra where MaHV = '{0}'", hv.maHV);
                dbconn.ThucThi(sqlStr);
            }
            //xoa danh gia cua hoc vien
            sqlStr = string.Format("select * from DanhGia where MaHV = '{0}'", hv.maHV);
            tb = dbconn.LayDanhSach(sqlStr);
            if (tb.Rows.Count > 0)
            {
                sqlStr = string.Format("Delete from DanhGia where MaHV = '{0}'", hv.maHV);
                dbconn.ThucThi(sqlStr);
            }
            //xoa thong bao den hoc vien
            sqlStr = string.Format("select * from ThongBao where MaNguoiNhan = '{0}'", hv.maHV);
            tb = dbconn.LayDanhSach(sqlStr);
            if (tb.Rows.Count > 0)
            {
                sqlStr = string.Format("Delete from ThongBao where MaNguoiNhan = '{0}'", hv.maHV);
                dbconn.ThucThi(sqlStr);
            }
            //xoa hoc vien
            sqlStr = string.Format("Select * from HocVien WHERE MaHV = '{0}'", hv.maHV);
            tb = dbconn.LayDanhSach(sqlStr);
            string sqlStr1 = "";
            if (tb.Rows.Count > 0)
            {
                sqlStr1 = string.Format("DELETE FROM TaiKhoan WHERE TK = '{0}'", hv.maHV);
                sqlStr = string.Format("DELETE FROM HocVien WHERE MaHV = '{0}'", hv.maHV);
                dbconn.ThucThi(sqlStr, sqlStr1);
            }
        }
        public void Sua(HocVien hv)
        {
            string sqlStr = string.Format("select SiSo From Lop Where MaLop = '{0}'", hv.maLop);
            DataTable tb = dbconn.LayDanhSach(sqlStr);
            if (tb.Rows.Count != 0)
            {
                //dem so hoc vien cua lop
                sqlStr = string.Format("select count(MaHV) as SL from HocVien where MaLop = '{0}' group by MaLop", hv.maLop);
                DataTable tbSoLuong = dbconn.LayDanhSach(sqlStr);
                DataRow rowSoLuong = tbSoLuong.Rows[0];
                int sl = int.Parse(rowSoLuong["SL"].ToString());
                //lay siso cua lop
                DataRow row = tb.Rows[0];
                int SiSo = int.Parse(row["SiSo"].ToString());
                if (sl >= SiSo)//neu sl>siso thi khong cho chuyen lop
                {
                    FrmMessageBox frmMessageBox = new FrmMessageBox("This class is full of students", "INFORMATION");
                    DialogResult result = frmMessageBox.ShowDialog();
                }
                else
                {
                    sqlStr = string.Format("UPDATE HocVien SET HoHV = N'{0}', TenlotHV = N'{1}', TenHV = N'{2}', NgaySinh = '{3}'," +
                    "Cmnd = '{4}', DiaChi = N'{5}', SoDT = '{6}', Email = '{7}', MaLop = '{8}' WHERE MaHV = '{9}'", hv.ho, hv.lot, hv.ten,
                    hv.ngaySinh, hv.cmnd, hv.diaChi, hv.sdt, hv.email, hv.maLop, hv.maHV);
                    dbconn.ThucThi(sqlStr, "");
                }
            }
        }
        public void Sua(LopHoc lopCur, LopHoc lopNew, HocVien hv)
        {
            if (lopCur.maLop != lopNew.maLop)
            {
                DateTime NgayBatDauCur = lopCur.ngayBatDau;
                string MaKHCur = lopCur.maKhoaHoc;
                DateTime NgayBatDauNew = lopNew.ngayBatDau;
                string MaKHNew = lopNew.maKhoaHoc;
                if (MaKHCur != MaKHNew || NgayBatDauCur < DateTime.Now || NgayBatDauNew < DateTime.Now)
                {
                    FrmMessageBox frmMessageBox = new FrmMessageBox("Can't change class", "INFORMATION");
                    DialogResult result = frmMessageBox.ShowDialog();
                }
                else
                {
                    Sua(hv);
                }
            }
            else
            {
                Sua(hv);
            }
        }
        public DataTable layThongBao(string MaHV)
        {
            string sqlStr = string.Format("select * from THONGBAO where MaNguoiNhan='{0}' order by ThoiGian DESC", MaHV);
            return dbconn.LayDanhSach(sqlStr);
        }
        public DataTable LayDSLop()
        {
            string sqlStr = string.Format("Select MaLop from Lop");
            return dbconn.LayDanhSach(sqlStr);
        }
        public HocVien LayThongTinHocVien(string MaHV)
        {
            string strSql = string.Format("Select * from HocVien where MaHV = '{0}'", MaHV);
            DataTable tb = dbconn.LayDanhSach(strSql);
            if (tb.Rows.Count > 0)
            {
                DataRow dr = tb.Rows[0];
                HocVien hv = new HocVien(dr["MaHV"].ToString(), dr["HoHV"].ToString(),
                                        dr["TenlotHV"].ToString(), dr["TenHV"].ToString(),
                                        DateTime.Parse(dr["NgaySinh"].ToString()), dr["Cmnd"].ToString(),
                                        dr["DiaChi"].ToString(), dr["SoDT"].ToString(), dr["Email"].ToString(),
                                        dr["MaLop"].ToString());
                return hv;
            }
            else
            { return null; }
        }
        public DataTable LayKetQuaKiemTra(string maHV)
        {
            string sqlStr = string.Format("select KetQua from KiemTra where MaHV = '{0}'", maHV);
            return dbconn.LayDanhSach(sqlStr);
        }
        public DataTable LayHocVienDangKyTheoMaKhoaHoc(string maKH)
        {
            string sqlStr = string.Format("Select HoHV+' '+TenlotHV+' '+TenHV as [HoTen], SoDT from HocVien_DangKy where MaKH = '{0}'", maKH);
            return dbconn.LayDanhSach(sqlStr);
        }
        public DataTable LayDSHocVien()
        {
            string sqlStr = string.Format("Select MaHV, HoHV+' '+TenlotHV+' '+TenHV as [HoTen], SoDT from HocVien");
            return dbconn.LayDanhSach(sqlStr);
        }
        public DataTable LayDSTimKiem(string thongTin)
        {
            string sqlStr = string.Format("select HocVien.MaHV, HocVien.HoHV + ' ' + HocVien.TenlotHV + ' ' + HocVien.TenHV as [HoTen], HocVien.SoDT " +
                "From HocVien join (select MaHV + HoHV + ' ' + TenlotHV + ' ' + TenHV + Convert(varchar, NgaySinh, 101) + Cmnd + DiaChi + SoDT + Email + MaLop as [ThongTin], MaHV from HocVien) Q on HocVien.MaHV= Q.MaHV " +
                "where Q.ThongTin like N'%{0}%'", thongTin);
            return dbconn.LayDanhSach(sqlStr);
        }
        public bool CheckDanhGia(string maHV, string maGV, string maLop)
        {
            string sqlStr = string.Format("select * from DanhGia where MaHV='{0}' and MaGV='{1}' and MaLop='{2}'", maHV, maGV, maLop);
            DataTable dt = dbconn.LayDanhSach(sqlStr);
            return dt.Rows.Count > 0;
        }
        public DataTable DSDeKT(string maHV)
        {
            string sqlStr = string.Format("SELECT MaBKT, TuanKT, Q.MaLop from BaiKiemTra join (select MaLop from HocVien where MaHV = '{0}')Q on BaiKiemTra.MaLop = Q.MaLop", maHV);
            return dbconn.LayDanhSach(sqlStr);
        }
        public HocVien ThongTinHocVienDangKy(string sdt, string maLop)
        {
            string sqlStr = string.Format("select * from HocVien_DangKy where Sodt = '{0}'", sdt);
            DataTable tb = dbconn.LayDanhSach(sqlStr);
            if (tb.Rows.Count > 0)
            {
                DataRow dr = tb.Rows[0];
                return new HocVien("-1", dr[0].ToString(), dr[1].ToString(), dr[2].ToString(),
                    DateTime.Parse(dr[3].ToString()), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), maLop);
            }
            else { return null; }
        }
        public void xoa_HocVien_DKy(string sdt)
        {
            string sqlStr = string.Format("Delete From HocVien_DangKy where SoDT = '{0}'", sdt);
            dbconn.ThucThi(sqlStr);
        }
        public void HocVien_DK(string ho, string tenlot, string ten, DateTime ngaySinh, string cmnd, string diaChi, string sdt, string email, string maKH)
        {
            string sqlStr = string.Format("insert into HocVien_DangKy VALUES (N'{0}', N'{1}', N'{2}', '{3}', '{4}', N'{5}', '{6}', '{7}', '{8}')",
                ho, tenlot, ten, ngaySinh.Date.ToString(), cmnd, diaChi, sdt, email, maKH);
            dbconn.ThucThi(sqlStr, "");
        }
        public DataTable LayDSKhoaHoc()
        {
            string sqlStr = string.Format("select * from KhoaHoc");
            return dbconn.LayDanhSach(sqlStr);
        }
    }
}
