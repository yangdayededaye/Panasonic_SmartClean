using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panasonic_SmartClean.Model
{
    public class IOModel
    {
        public IOModel(int i,string s)
        {
            index = i;
            remark = s;
        }
        public int index { get; set; }
        public string remark { get; set; }
    }
}
