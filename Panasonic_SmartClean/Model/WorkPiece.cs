using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panasonic_SmartClean.Model
{
    public class WorkPiece
    {
        public int Index { get; set; }
        public EWorkPieceType Type { get; set; }
        public bool IsExist { get; set; }
        public string Ocr { get; set; }
        public string BarCode { get; set; }
        //吸嘴
        public string MouseResult { get; set; } = "";
        //反光板
        public string ReflectBoardResult { get; set; } = "";
        //流量
        public string FlowResult { get; set; } = "";
        //流量值
        public int FlowCount { get; set; } = 0;

        public string MouseBefore { get; set; }
        public string MouseAfter { get; set; }
        public string BoardBefore { get; set; }
        public string BoardAfter { get; set; }

    }

    public enum EWorkPieceType
    {
        small=0,
        big=1,
        superbig=2
    }

}
