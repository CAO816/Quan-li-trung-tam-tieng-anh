using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_group5
{
    public class TaiKhoan
    {
        string TK;
        string MatKhau;
        public string tK { get{ return TK; } }
        public string matKhau { get{ return MatKhau; } }

        public TaiKhoan(string tK, string matKhau)
        {
            TK = tK;
            MatKhau = matKhau;
        }
    }
}
