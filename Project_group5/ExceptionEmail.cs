using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_group5
{
    public class ExceptionEmail : System.ApplicationException
    {
        public ExceptionEmail(string message) : base(message)
        {
        }
    }
}
