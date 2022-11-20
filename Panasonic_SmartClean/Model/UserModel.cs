using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Panasonic_SmartClean
{

    /// <summary>
    /// 用户类
    /// </summary>
    public class UserCls
    {
        public UserCls(string no,string name,string type)
        {
            No = no;
            Name = name;
            Type = type;
        }
        //编号
        public string No { get; set; }
        //名称
        public string Name { get; set; }
        //拼音
        public string PY { get; set; }
        //密码
        public string Psw { get; set; }
        //类别
        public string Type { get; set; }
        //性别
        public string Sex { get; set; }
        public int ID { get; set; }

    }


    
    
}
