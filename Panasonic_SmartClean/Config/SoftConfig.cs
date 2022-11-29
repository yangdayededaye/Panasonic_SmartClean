using Panasonic_SmartClean;
using Panasonic_SmartClean.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.Core;

namespace Panasonic_SmartClean
{
    public class SoftConfig
    {
        public static string _SoftName = "智能清洗V1.0";

        public static Panasonic_SmartCleanEntities db = new Panasonic_SmartCleanEntities();

        public static int CabNo = int.Parse(ConfigurationManager.AppSettings["CabNo"].ToString());
        public static UserCls user = new UserCls("000", "admin","1");
        
        //调试模式
        public static bool IsDebug = ConfigurationManager.AppSettings["IsDebug"].ToString() == "1" ? true : false;

        public static Dictionary<int, string> _WarnMap = new Dictionary<int, string>();
        public static List<IOModel> _IMap = new List<IOModel>();
        public static List<IOModel> _OMap = new List<IOModel>();

        public static List<VmProcedure> processList = null;//流程
        //工件信息集合
        public static List<WorkPiece> lstWorkPiece = new List<WorkPiece>();
        //流量阈值集合
        public static List<Flow> lstFlow = new List<Flow>();
        //流程集合
        public static List<VisonProcess> lstProcess = new List<VisonProcess>();

        public static string ImagePath = "";
        public static int iLogCount = 0;
        public static IniCls ini = IniCls.Instance;

        //public static FrmKeyboard fr;

    }
}
