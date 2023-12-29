using Project_group5.HV;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_group5
{
    public class GiangVienDAO
    {
        DataBaseConn dbconn = new DataBaseConn();
        public GiangVien ThongTinGV(string maGV)
        {
            string sqlStr = string.Format("SELECT * FROM GiangVien WHERE MaGV='{0}'", maGV);
            DataRow dr = dbconn.LayDanhSach(sqlStr).Rows[0];
            return new GiangVien(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
        }
        public DataTable ThongTinGiangVienVaLop(string maGV)
        {
            string sqlStr = string.Format("select P.MaLop, NgayBatDau, NgayKetThuc, SL, TenKH from KhoaHoc join (select Q.MaLop, NgayBatDau, NgayKetThuc, SL, Lop.MaKH, Lop.MaGV from Lop join (select Lop.MaLop, count(MaHV) as SL from HocVien right join Lop on HocVien.MaLop = Lop.MaLop group by Lop.MaLop) Q on Lop.MaLop = Q.MaLop) P on P.MaKH = KhoaHoc.MaKH where P.MaGV = '{0}'", maGV);
            return dbconn.LayDanhSach(sqlStr);
        }
        public GiangVien LayThongTinGiangVien(string maGV)
        {
            string sqlStr = string.Format("Select * From GiangVien where MaGV = '{0}'", maGV);
            DataTable tb = dbconn.LayDanhSach(sqlStr);
            if (tb.Rows.Count > 0)
            {
                DataRow row = tb.Rows[0];
                GiangVien gv = new GiangVien(row["MaGV"].ToString(), row["HoGV"].ToString(),
                                        row["TenLotGV"].ToString(), row["TenGV"].ToString(),
                                        row["Cmnd"].ToString(), row["SoDT"].ToString(), row["Email"].ToString());
                return gv;
            }
            else
            { return null; }
        }
        public DataTable layCacLop(string maGV)
        {
            string sqlStr = string.Format("select * from Lop where MaGV='{0}'", maGV);
            return dbconn.LayDanhSach(sqlStr);
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
        public void TaoDe(string maDe, string maLop, string Tuan)
        {
            string sqlTaoDe = string.Format("INSERT INTO BaiKiemTra VALUES ('{0}', N'{1}' , '{2}')", maDe, Tuan, maLop);
            dbconn.ThucThi(sqlTaoDe, "");
            DataTable dt = dbconn.LayDanhSach(string.Format("select MaHV from HOCVIEN where MaLop='{0}'", maLop));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dbconn.ThucThi(string.Format("INSERT INTO KiemTra VALUES ('{0}', '{1}', {2})", maDe, dt.Rows[i][0].ToString(), 0), "");
            }
        }
        public DataTable layTuanHoc()
        {
            string sqlStr = string.Format("select * from Tuan");
            return dbconn.LayDanhSach(sqlStr);
        }
        public DataTable layBaiKT(string lop)
        {
            return dbconn.LayDanhSach(string.Format("select MaBKT from BaiKiemTra where MaLop='{0}'", lop));
        }
        public DataTable layThoiKhoaBieu(string maGV, string Tuan)
        {
            string sqlStr = string.Format("select * from BuoiHoc_Lop,BuoiHoc where MaLop in (select MaLop from GiangVien,Lop where GiangVien.MaGV='{0}' and GiangVien.MaGV=Lop.MaGV) and BuoiHoc.MaBH=BuoiHoc_Lop.MaBH and SoTuan='{1}'", maGV, Tuan);
            return dbconn.LayDanhSach(sqlStr);
        }
        public void DiemDanh(string MaBH, string MaHV, int TrangThai)
        {
            string sqlStr = string.Format("update DiemDanh set TrangThai='{0}' where MaBH='{1}' and MaHV='{2}'", TrangThai, MaBH, MaHV);
            dbconn.ThucThi(sqlStr);

        }
        public DataTable layTuanHoc(string MaLop)
        {
            string sqlStr = string.Format("select distinct SoTuan from BuoiHoc where MaBH in (select MaBH from BuoiHoc_Lop where BuoiHoc_Lop.MaLop='{0}')", MaLop);
            return dbconn.LayDanhSach(sqlStr);
        }
        public DataTable layHVTheoLop(string maLop)
        {
            string sqlStr = string.Format("select * from HOCVIEN where MaLop='{0}'", maLop);
            return dbconn.LayDanhSach(sqlStr);
        }
        public DataTable layBuoiHoc(string Tuan)
        {
            string sqlStr = string.Format("select MaBH from BuoiHoc where SoTuan= N'{0}'", Tuan);
            return dbconn.LayDanhSach(sqlStr);
        }
        public string KTtrVang(string MaHV, string MaBH)
        {
            string sqlStr = string.Format("select TrangThai from DiemDanh where MaHV='{0}' and MaBH='{1}'", MaHV, MaBH);
            return dbconn.LayDanhSach(sqlStr).Rows[0][0].ToString();
        }
        public DataTable LayDiemTheoLop(string MaLop, string MaHV)
        {
            string sqlStr = string.Format("select Q.MaHV as [Mã học viên], HoHV as [Họ], TenlotHV as [Tên lót], TenHV as [Tên],MaBKT as [Mã bài kiểm tra],KetQua as [Kết quả],TuanKT as [Tuần],Q.MaLop as [Mã lớp] from HOCVIEN," +
                "(select MaHV,KiemTra.MaBKT,KetQua,TuanKT,MaLop from KiemTra,BaiKiemTra where MaLop='{0}' and KiemTra.MaBKT=BaiKiemTra.MaBKT and KiemTra.MaHV like '{1}') as Q " +
                "where HOCVIEN.MaHV=Q.MaHV", MaLop, MaHV);
            return dbconn.LayDanhSach(sqlStr);
        }
        public DataTable LayDanhSachGiangVien()
        {
            string sqlStr = string.Format("select MaGV, HoGV+' '+TenlotGV+' '+TenGV as HoTen ,Cmnd as CCCD, SoDT , Email  from GiangVien");
            return dbconn.LayDanhSach(sqlStr);
        }
        public void Them(GiangVien gv)
        {
            string sqlStr = string.Format("Select * from GiangVien WHERE MaGV = '{0}'", gv.maGV);
            DataTable tb = dbconn.LayDanhSach(sqlStr);
            if (tb.Rows.Count > 0)
            {
                FrmMessageBox messageBox = new FrmMessageBox("The teacher's code already exists", "INFORMATION");
                messageBox.ShowDialog();
                return;
            }
            if (gv.maGV != "" && gv.ho != "" && gv.ten != "" && gv.cmnd != "" && gv.sdt != "" && gv.email != "")
            {
                sqlStr = string.Format("Insert into GiangVien values ('{0}', N'{1}', N'{2}', N'{3}', '{4}', '{5}', '{6}')",
                                                gv.maGV, gv.ho, gv.lot, gv.ten, gv.cmnd, gv.sdt, gv.email);
                string sqlStr1 = string.Format("INSERT INTO TaiKhoan VALUES ('{0}', '{1}', '{2}')", gv.maGV, "1", "1");
                dbconn.ThucThi(sqlStr, sqlStr1);
            }
            else
            {
                MessageBox.Show("Thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void Xoa(GiangVien gv)
        {
            string sqlStr = string.Format("Select * from GiangVien join Lop on GiangVien.MaGV = Lop.MaGV WHERE Lop.MaGV = '{0}'", gv.maGV);
            DataTable tb = dbconn.LayDanhSach(sqlStr);
            //tim xem giang vien co dang day lop nao khong
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                DataRow row = tb.Rows[i];
                string lop = row["MaLop"].ToString();
                string tengv = row["HoGV"].ToString() + " " + row["TenlotGV"].ToString() + " " + row["TenGV"].ToString();
                DateTime tg = DateTime.Parse(row["NgayKetThuc"].ToString());
                if (tg >= DateTime.Now)
                {
                    string thongbao =  tengv + " had been teaching class '" + lop + "', please change the teacher for the class before deleting this teacher.";
                    FrmMessageBox messageBox = new FrmMessageBox(thongbao, "INFORMATION");
                    messageBox.ShowDialog();
                    return;
                }
            }
            string sqlStr1 = string.Format("DELETE FROM TaiKhoan WHERE TK = '{0}'", gv.maGV);
            sqlStr = string.Format("DELETE FROM GiangVien WHERE MaGV = '{0}'", gv.maGV);
            dbconn.ThucThi(sqlStr, sqlStr1);
        }
        public void Sua(GiangVien gv)
        {
            //khong cho doi MaGV, khong doi MK nen khong can update TaiKhoan
            string sqlStr = string.Format("UPDATE GiangVien SET HoGV = N'{0}', TenlotGV = N'{1}', TenGV = N'{2}', Cmnd = '{3}'," +
            "SoDT = '{4}', Email = '{5}' WHERE MaGV = '{6}'", gv.ho, gv.lot, gv.ten, gv.cmnd, gv.sdt, gv.email, gv.maGV);
            dbconn.ThucThi(sqlStr, "");
        }
        public void SuaTKB(BuoiHoc_Lop buoiHoc)
        {
            string sqlStr = string.Format("update BuoiHoc_Lop set Thu= N'{0}', DiaDiem= N'{1}', GioBatDau='{2}', GioKetThuc='{3}' where MaBH='{4}' and MaLop='{5}'",
                buoiHoc.thu, buoiHoc.diaDiem, buoiHoc.gioBatDau.ToShortTimeString(), buoiHoc.gioKetThuc.ToShortTimeString(), buoiHoc.maBH, buoiHoc.maLop);
            dbconn.ThucThi(sqlStr);
        }
        public DataTable LayTKB(string TuanHoc, string MaLop)
        {
            string sqlStr = string.Format("select Q.MaBH as [Mã buổi hoc] ,MaLop as [Mã lớp],Thu as [Thứ] ,DiaDiem as [Địa điểm] ,GioBatDau as [Giờ bắt đầu],GioKetThuc as[Giờ kết thúc]" +
                " from BuoiHoc_Lop as Q,(select MaBH from BuoiHoc where SoTuan= N'{0}') as BH where Q.MaLop='{1}' and Q.MaBH = BH.MaBH", TuanHoc, MaLop);
            return dbconn.LayDanhSach(sqlStr);
        }
        public void ThemThongBao(string MaLop, string NguoiGui, string NguoiNhan, string NoiDung)
        {
            DateTime ThoiGian = DateTime.Now;
            if (NguoiNhan == "%")
            {
                string sqlStr = string.Format("select MaHV from HocVien where MaLop = '{0}'", MaLop);
                DataTable dt = dbconn.LayDanhSach(sqlStr);
                for (int i = 0; i< dt.Rows.Count; i++)
                {
                    sqlStr = string.Format("INSERT INTO THONGBAO VALUES ('{0}', '{1}', '{2}', '{3}', N'{4}')", ThoiGian.ToString(), MaLop, NguoiGui, dt.Rows[i][0].ToString(), NoiDung);
                    dbconn.ThucThi(sqlStr);
                }  
            }
            else
            {
                string sqlStr = string.Format("INSERT INTO THONGBAO VALUES ('{0}', '{1}', '{2}', '{3}', N'{4}')", ThoiGian.ToString(), MaLop, NguoiGui, NguoiNhan, NoiDung);
                dbconn.ThucThi(sqlStr);
            }
            
        }
        public List<string> tachTen(string hovaten)
        {
            string[] strings = hovaten.Split(' ');
            List<string> hvt = new List<string>();
            string tenlot = string.Empty;
            for (int i = 1; i < strings.Length - 1; i++)
                tenlot += strings[i] + " ";
            hvt.Add(strings[0]);
            hvt.Add(tenlot);
            hvt.Add(strings[strings.Length - 1]);
            return hvt;
        }
        public int TinhLuong(string maGV)
        {
            string sqlStr = string.Format("Select * from Lop WHERE MaGV = '{0}' and NgayKetThuc > '{1}'", maGV, DateTime.Now.ToString());
            DataTable tb = dbconn.LayDanhSach(sqlStr);
            return 6500000 * tb.Rows.Count;
        }
    }
}
