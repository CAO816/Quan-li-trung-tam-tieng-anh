using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project_group5
{
    public class QLFile
    {
        public static string docDuLieu(string duongdan)
        {
            string s = "";
            StreamReader streamReader=new StreamReader(duongdan);
            s= streamReader.ReadToEnd();
            streamReader.Close();
            return s;
        }
        public static List<string> docKetQua(string duongdan)
        {
            List<string> ketQua = new List<string>();
            string dong = "";
            StreamReader streamReader = new StreamReader(duongdan);
            while((dong=streamReader.ReadLine())!=null)
            {
                ketQua.Add(dong);
            }
            streamReader.Close();
            return ketQua;
        }
    }
}
