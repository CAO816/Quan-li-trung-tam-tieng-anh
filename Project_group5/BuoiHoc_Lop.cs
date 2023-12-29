using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_group5
{
    public class BuoiHoc_Lop
    {
        string MaBH;
        string MaLop;
        string Thu;
        string DiaDiem;
        DateTime GioBatDau;
        DateTime GioKetThuc;
        public string maBH { get { return MaBH; } }
        public string maLop { get { return MaLop; } }
        public string thu { get { return Thu; } }
        public string diaDiem { get { return DiaDiem; } }
        public DateTime gioBatDau { get { return GioBatDau; } }
        public DateTime gioKetThuc { get { return GioKetThuc; } }

        public BuoiHoc_Lop(string maBH, string maLop, string thu, string diaDiem, DateTime gioBatDau, DateTime gioKetThuc)
        {
            MaBH = maBH;
            MaLop = maLop;
            Thu = thu;
            DiaDiem = diaDiem;
            GioBatDau = gioBatDau;
            GioKetThuc = gioKetThuc;
        }
    }
}
