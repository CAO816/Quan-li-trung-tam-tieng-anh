using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Project_group5
{
    public class QLDeKiemTra
    {
        string MaDe;
        List<string> DapAn;
        public string maDe { get => MaDe; set => MaDe = value; }
        public List<string> dapAn { get => DapAn; set => DapAn = value; }

        public QLDeKiemTra(string maDe, List<string> dapAn)
        {
            MaDe = maDe;
            DapAn = dapAn;
        }

        public QLDeKiemTra()
        {
        }
    }
}
