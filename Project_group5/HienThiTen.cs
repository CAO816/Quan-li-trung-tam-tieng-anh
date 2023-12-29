using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_group5
{
    public class HienThiTen
    {
        string ma;
        string ten;
        public string Ma { get { return ma; } }
        public string Ten { get { return ten; } }

        public HienThiTen(string ma, string ten)
        {
            this.ma = ma;
            this.ten = ten;
        }
    }
}
