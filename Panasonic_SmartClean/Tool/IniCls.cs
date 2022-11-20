using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Xml;

namespace Panasonic_SmartClean
{
    public class IniCls
    {
        public string inipath = System.Environment.CurrentDirectory + "\\config.ini";
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        
        private IniCls()
        {
        }

        public static IniCls Instance = new IniCls();
        
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="INIPath">文件路径</param>
        //public IniClass(string INIPath)
        //{
        //    inipath = INIPath;
        //}
        /// <summary>
        /// 写入INI文件
        /// </summary>
        /// <param name="Section">项目名称(如 [TypeName] )</param>
        /// <param name="Key">键</param>
        /// <param name="Value">值</param>
        public void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.inipath);
        }
        /// <summary>
        /// 读出INI文件
        /// </summary>
        /// <param name="Section">项目名称(如 [TypeName] )</param>
        /// <param name="Key">键</param>
        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(500);
            int i = GetPrivateProfileString(Section, Key, "", temp, 500, this.inipath);
            return temp.ToString();
        }

        /// <summary>
        /// 方法保存修改的设置
        /// </summary>
        /// <param name="ConnenctionString"></param>
        /// <param name="strKey"></param>
        public static void SaveConfig(string strExeName, string strKey,string strValue)
        {
            XmlDocument doc = new XmlDocument();
            //获得配置文件的全路径
            //string strFileName = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            string strFileName = Environment.CurrentDirectory + "\\"+strExeName+".exe.config";
            doc.Load(strFileName);
            //找出名称为“add”的所有元素
            XmlNodeList nodes = doc.GetElementsByTagName("add");
            for (int i = 0; i < nodes.Count; i++)
            {
                //获得将当前元素的key属性
                XmlAttribute att = nodes[i].Attributes["key"];
                //根据元素的第一个属性来判断当前的元素是不是目标元素
                if (att.Value == strKey)
                {
                    //对目标元素中的第二个属性赋值
                    att = nodes[i].Attributes["value"];
                    att.Value = strValue;
                    break;
                }
            }
            //保存上面的修改
            doc.Save(strFileName);
        }
    }
}
