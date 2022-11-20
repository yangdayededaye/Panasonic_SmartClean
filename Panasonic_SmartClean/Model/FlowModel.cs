using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panasonic_SmartClean.Model
{
    public class FlowCls
    {
        public FlowCls(string ocr, int value)
        {
            Ocr = ocr;
            Value = value;
        }
        //
        public string Ocr { get; set; }
        //
        public int Value { get; set; }
        //
        public int ID { get; set; }
    }
}
