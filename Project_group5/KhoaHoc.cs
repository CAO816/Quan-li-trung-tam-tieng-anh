using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_group5
{
    public class KhoaHoc
    {
        string MaKhoaHoc;
        string TenKhoaHoc;
        string SoTiet;
        string MoTa;
        int ThoiGianHoc;
        public string maKhoaHoc { get { return MaKhoaHoc; } }
        public string tenKhoaHoc { get { return TenKhoaHoc; } }
        public string soTiet { get { return SoTiet; } }
        public string moTa { get { return MoTa; } }
        public int thoiGianHoc { get { return ThoiGianHoc; } }

        public KhoaHoc(string maKhoaHoc, string tenKhoaHoc, string soTiet, string moTa, int thoiGianHoc)
        {
            MaKhoaHoc = maKhoaHoc;
            TenKhoaHoc = tenKhoaHoc;
            SoTiet = soTiet;
            MoTa = moTa;
            ThoiGianHoc = thoiGianHoc;
        }
    }
}
