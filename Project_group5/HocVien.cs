using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_group5
{
    public class HocVien
    {
        string MaHV;
        string Ho;
        string Lot;
        string Ten;
        DateTime NgaySinh;
        string CMND;
        string DiaChi;
        string SDT;
        string Email;
        string MaLop;
        public string maHV { get { return MaHV; } }
        public string ho { get { return Ho; } }
        public string lot { get { return Lot; } }
        public string ten { get { return Ten; } }
        public DateTime ngaySinh { get { return NgaySinh; } }
        public string cmnd { get { return CMND; } }
        public string diaChi { get { return DiaChi; } }
        public string sdt { get { return SDT; } }
        public string email { get { return Email; } }
        public string maLop { get { return MaLop; } }

        public HocVien(string maHV, string ho, string lot, string ten, DateTime ngaySinh, string cMND, string diaChi, string sDT, string email, string maLop)
        {
            MaHV = maHV;
            Ho = ho;
            Lot = lot;
            Ten = ten;
            NgaySinh = ngaySinh;
            CMND = cMND;
            DiaChi = diaChi;
            SDT = sDT;
            Email = email;
            MaLop = maLop;
        }
    }
}
