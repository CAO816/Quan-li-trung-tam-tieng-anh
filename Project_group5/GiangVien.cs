using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_group5
{
    public class GiangVien
    {
        string MaGV;
        string Ho;
        string Lot;
        string Ten;
        string CMND;
        string SDT;
        string Email;
     
        public string maGV { get { return MaGV; } }
        public string ho { get { return Ho; } }
        public string lot { get { return Lot; } }
        public string ten { get { return Ten; } }
        public string cmnd { get { return CMND; } }
        public string sdt { get { return SDT; } }
        public string email { get { return Email; } }

        public GiangVien(string maGV, string ho, string lot, string ten, string cMND, string sDT, string email)
        {
            MaGV = maGV;
            Ho = ho;
            Lot = lot;
            Ten = ten;
            CMND = cMND;
            SDT = sDT;
            Email = email;
        }
    }

}
