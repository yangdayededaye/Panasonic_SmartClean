using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panasonic_SmartClean.Model
{
    public class IOModel
    {
        public IOModel(int i,string s,int a)
        {
            index = i;
            remark = s;
            addressIndex = a;
        }
        public int index { get; set; }
        public string remark { get; set; }
        public int addressIndex   { get; set; }
    }
}
