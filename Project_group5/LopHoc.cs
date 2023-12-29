using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_group5
{
    public class LopHoc
    {
        string MaLop;
        DateTime NgayBatDau;
        DateTime NgayKetThuc;
        string TriGia;
        string SiSo;
        string MaGV;
        string MaKhoaHoc;
        public string maLop { get { return MaLop; } }
        public DateTime ngayBatDau { get { return NgayBatDau; } }
        public DateTime ngayKetThuc { get { return NgayKetThuc; } }
        public string triGia { get { return TriGia; } }
        public string siSo { get { return SiSo; } }
        public string maGV { get { return MaGV; } }
        public string maKhoaHoc { get { return MaKhoaHoc; } }

        public LopHoc(string maLop, DateTime ngayBatDau, DateTime ngayKetThuc, string triGia, string siSo, string maGV, string maKhoaHoc)
        {
            MaLop = maLop;
            NgayBatDau = ngayBatDau;
            NgayKetThuc = ngayKetThuc;
            TriGia = triGia;
            SiSo = siSo;
            MaGV = maGV;
            MaKhoaHoc = maKhoaHoc;
        }
    }
}
