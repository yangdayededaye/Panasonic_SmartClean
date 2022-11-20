using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Security.Cryptography;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Panasonic_SmartClean
{
    public class Util
    {
        LogCls lg = LogCls.Instance;

        public static bool initDB()
        {
            try
            {
                SoftConfig.db = new Panasonic_SmartCleanEntities();
                SoftConfig.db.Database.CommandTimeout = 600;
                SoftConfig.db.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public static byte[] GetHexFromChs(string s)
        {
            System.Text.Encoding chs = System.Text.Encoding.GetEncoding("GBK");

            byte[] bytes = chs.GetBytes(s);

            return bytes;
        }

        /// <summary>
        /// 使DataGridView的列自适应宽度
        /// </summary>
        /// <param name="dgViewFiles"></param>
        public static void AutoSizeColumn(DataGridView dgViewFiles)
        {
            int width = 0;
            //使列自使用宽度
            //对于DataGridView的每一个列都调整
            for (int i = 0; i < dgViewFiles.Columns.Count; i++)
            {
                //将每一列都调整为自动适应模式
                dgViewFiles.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);
                //记录整个DataGridView的宽度
                width += dgViewFiles.Columns[i].Width;
            }
            //判断调整后的宽度与原来设定的宽度的关系，如果是调整后的宽度大于原来设定的宽度，
            //则将DataGridView的列自动调整模式设置为显示的列即可，
            //如果是小于原来设定的宽度，将模式改为填充。
            if (width > dgViewFiles.Size.Width)
            {
                dgViewFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            else
            {
                dgViewFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            //冻结某列 从左开始 0，1，2
            dgViewFiles.Columns[1].Frozen = true;
        }

        

        

        /// <summary>
        /// 方法保存修改的设置
        /// </summary>
        /// <param name="ConnenctionString"></param>
        /// <param name="strKey"></param>
        public static void SaveConfig(string strValue, string strKey)
        {
            XmlDocument doc = new XmlDocument();
            //获得配置文件的全路径
            //string strFileName = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            string strFileName = Environment.CurrentDirectory + "\\XJISR.exe.config";
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

        

        public static void DispatchCmd(string str, int iType, string strFileName="log")
        {
            string strNow;
            string strEX;
            string strLog;
            strNow = DateTime.Now.ToString("HH:mm:ss.ffff");

            string strToday;
            string strLogPath;
            strToday = DateTime.Now.ToString("yyyy-MM-dd");
            //strLogPath = System.Windows.Forms.Application.StartupPath + "\\Log";
            strLogPath = System.Environment.CurrentDirectory + "\\Log";
            if (!Directory.Exists(strLogPath))
            { Directory.CreateDirectory(strLogPath); }

            string strLogFile = strLogPath + "\\" + strFileName + "_" + strToday + ".Log";

            strLog = strLogFile;

            try
            {
                FileStream file = null;
                if (File.Exists(strLog))
                {
                    file = new FileStream(strLog, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                }
                else
                {
                    file = new FileStream(strLog, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.ReadWrite);
                }

                StreamWriter sw = new StreamWriter(file, Encoding.Default);

                switch (iType)
                {
                    case 1:
                        strEX = "[" + strNow + "] [错误信息] :";
                        sw.WriteLine(strEX + str);
                        break;
                    default:
                        strEX = "[" + strNow + "] [运行信息] :";
                        sw.WriteLine(strEX + str);
                        break;
                }

                sw.Close();
            }
            catch (System.Exception ex)
            {

            }
        }

        /// <summary>
        /// 计算字符串的MD5值
        /// </summary>
        public static string Md5Func(string source)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(source);
            byte[] md5Data = md5.ComputeHash(data, 0, data.Length);
            md5.Clear();
 
            string destString = string.Empty;
            for (int i = 0; i < md5Data.Length; i++)
            {
                //返回一个新字符串，该字符串通过在此实例中的字符左侧填充指定的 Unicode 字符来达到指定的总长度，从而使这些字符右对齐。
                // string num=12; num.PadLeft(4, '0'); 结果为为 '0012' 看字符串长度是否满足4位,不满足则在字符串左边以"0"补足
                //调用Convert.ToString(整型,进制数) 来转换为想要的进制数
                destString += System.Convert.ToString(md5Data[i], 16).PadLeft(2, '0');
            }
            //使用 PadLeft 和 PadRight 进行轻松地补位
            destString = destString.PadLeft(32, '0');
            return destString;
        }

         public static string GetMD5WithString(string sDataIn)
         {
            string str = "";
            byte[] data = Encoding.GetEncoding("utf-8").GetBytes(str);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytes = md5.ComputeHash(data);
            for (int i = 0; i < bytes.Length; i++)
            {
                str += bytes[i].ToString("x2");
            }
            return str;
         }

        public static void GetFiles(string strPath, string strEx, List<string> FileList)
        {
            //C#遍历指定文件夹中的所有文件 
            DirectoryInfo TheFolder = new DirectoryInfo(strPath);
            DirectoryInfo[] df = null;
            //遍历文件
            try
            {
                foreach (FileInfo NextFile in TheFolder.GetFiles())
                {
                    if (strEx != "")
                    {
                        if (NextFile.FullName.Contains(strEx))
                        {
                            FileList.Add(NextFile.FullName);
                        }
                    }
                    else
                    {
                        FileList.Add(NextFile.FullName);
                    }
                }

                df = TheFolder.GetDirectories();
            }
            catch (System.Exception ex)
            {
                
            }

            if (df == null)
            {
                return;
            }

            //遍历文件夹
            foreach (DirectoryInfo NextFolder in df)
            {
                GetFiles(NextFolder.FullName, strEx,FileList);
            }
        }

        public static string GetDateTimeString()
        {
            return DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00");

        }

        public static Int64 GetDateTimeInt()
        {
            Int64 iOut = Int64.Parse(DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString());
            return iOut;
        }
        /// <summary>
        /// 字节数组转16进制字串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string BytesToHexString(byte[] bytes)
        {
            try
            {
                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    sBuilder.Append(bytes[i].ToString("X2"));
                }

                return sBuilder.ToString();
            }
            catch (Exception e)
            {
                throw new ApplicationException("将指定无符号数组编码成十六进制字串时失败", e);
            }

        }

        /// <summary>
        /// 字节数组转16进制字串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string BytesToHexString(byte[] bytes,int iLength)
        {
            try
            {
                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < iLength; i++)
                {
                    sBuilder.Append(bytes[i].ToString("X2"));
                }

                return sBuilder.ToString();
            }
            catch (Exception e)
            {
                throw new ApplicationException("将指定无符号数组编码成十六进制字串时失败", e);
            }
        }

        /// <summary>
        /// 十六进制字串转字节数组
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static byte[] HexStringToBytes(string hexString)
        {
            try
            {
                hexString = hexString.PadLeft(4, '0');
                byte[] bytes = new byte[hexString.Length / 2];

                for (int i = 0; i < bytes.Length; i++)
                {
                    try
                    {
                        //每2个字符是一个byte
                        bytes[i] = byte.Parse(hexString.Substring(i * 2, 2),
                        System.Globalization.NumberStyles.HexNumber);
                    }
                    catch
                    {
                        throw new ArgumentException("hex is not a valid hex number!", "hex");
                    }
                }

                return bytes;
            }
            catch (Exception e)
            {
                throw new ApplicationException("将指定十六进制字符串解码成无符号字节数组时失败", e);
            }
        }

        
        
        ///// <summary>
        ///// 将Json字符串反序列化为对象实例——Newtonsoft.Json
        ///// </summary>
        ///// <typeparam name="T">对象类型</typeparam>
        ///// <param name="jsonString">Json字符串</param>
        ///// <returns>对象实例</returns>
        //public static T DeserializeObjectFromJson_NJ<T>(this string jsonString)
        //{
        //    return JsonConvert.DeserializeObject<T>(jsonString);
        //}

        ///// <summary>
        ///// 将对象实例序列化为Json字符串——Newtonsoft.Json
        ///// </summary>
        ///// <typeparam name="T">对象类型</typeparam>
        ///// <param name="obj">对象实例</param>
        ///// <returns>Json字符串</returns>
        //public static string SerializeObjectToJson_NJ<T>(this T obj)
        //{
        //    return JsonConvert.SerializeObject(obj);
        //}
        

        public static string XmlSerialize<T>(T obj)
        {
            using (StringWriter sw = new StringWriter())
            {
                Type t = obj.GetType();
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(sw, obj);
                sw.Close();
                return sw.ToString();
            }
        }

        public static T DESerializer<T>(string strXML) where T : class
        {
            try
            {
                using (StringReader sr = new StringReader(strXML))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    return serializer.Deserialize(sr) as T;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //List<LogCls> ll = JsonConvert.DeserializeObject<List<LogCls>>(retString);

        public static byte NotOrAnd(byte[] b)
        {
            byte check = 0;
            check = (byte)(b[b.Length - 1] ^ b[b.Length - 2]);
            for (int i = 2; i < b.Length;i++ )
            {
                check=(byte)(check^b[b.Length-i-1]);
            }
            string CheckSumHex = Convert.ToString(check,16);
            if (CheckSumHex.Length == 1)
            {
                CheckSumHex = "0" + CheckSumHex;
            }
            return Convert.ToByte(CheckSumHex,16);
        }

        /// <summary>
        /// dss
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public static byte[] GetCRC(byte[] Data)
        {
            byte[] b = new byte[2];
            byte num = 0xff;
            byte num2 = 0xff;
            byte num3 = 1;
            byte num4 = 160;
            byte[] buffer = new byte[Data.Length-4];
            Buffer.BlockCopy(Data,1,buffer,0,buffer.Length);
            for (int i = 0; i < buffer.Length; i++)
            {         //位异或运算       
                num = (byte)(num ^ buffer[i]);
                for (int j = 0; j <= 7; j++)
                {
                    byte num5 = num2;
                    byte num6 = num;
                    //位右移运算           
                    num2 = (byte)(num2 >> 1);
                    num = (byte)(num >> 1);
                    //位与运算          
                    if ((num5 & 1) == 1)
                    {                 //位或运算               
                        num = (byte)(num | 0x80);
                    }
                    if ((num6 & 1) == 1)
                    {
                        num2 = (byte)(num2 ^ num4);
                        num = (byte)(num ^ num3);
                    }
                }
            }


            b[0] = num;
            b[1] = num2;
            return b;

        }

        /// <summary>  
        /// 计算给定长度数据的16位CRC  checktable
        /// </summary>  
        /// <param name="data">要计算CRC的字节数组</param>  
        /// <returns>CRC值</returns>  
        public static UInt16 GetCrc16(Byte[] data)
        {   // 初始化  
            Int32 High = 0xFF;  // 高字节  
            Int32 Low = 0xFF;   // 低字节  
            if (data != null)
            {
                foreach (Byte b in data)
                {
                    Int32 Index = Low ^ b;
                    Low = High ^ CRC16TABLE_LO[Index];
                    High = CRC16TABLE_HI[Index];
                }
            }

            return (UInt16)(~((High << 8) + Low));    // 取反  
        }

        /// <summary>  
        /// 检查给定长度数据的16位CRC是否正确  
        /// </summary>  
        /// <param name="data">要校验的字节数组</param>  
        /// <returns>  
        ///     true：正确  
        ///     false：错误  
        /// </returns>  
        /// <reamrks>  
        /// 字节数组最后2个字节为校验码，且低字节在前面，高字节在后面  
        /// </reamrks>  
        public static Boolean IsCrc16Good(Byte[] data)
        {
            // 初始化  
            Int32 High = 0xFF;
            Int32 Low = 0xFF;
            if (data != null)
            {
                foreach (Byte b in data)
                {
                    Int32 Index = Low ^ b;
                    Low = High ^ CRC16TABLE_LO[Index];
                    High = CRC16TABLE_HI[Index];
                }
            }

            return (High == 0xF0 && Low == 0xB8);
        }

        /// <summary>  
        /// CRC16查找表高字节  
        /// </summary>  
        private static readonly Byte[] CRC16TABLE_HI =  
        {  
            0x00, 0x11, 0x23, 0x32, 0x46, 0x57, 0x65, 0x74, 0x8C, 0x9D, 0xAF, 0xBE, 0xCA, 0xDB, 0xE9, 0xF8,  
            0x10, 0x01, 0x33, 0x22, 0x56, 0x47, 0x75, 0x64, 0x9C, 0x8D, 0xBF, 0xAE, 0xDA, 0xCB, 0xF9, 0xE8,  
            0x21, 0x30, 0x02, 0x13, 0x67, 0x76, 0x44, 0x55, 0xAD, 0xBC, 0x8E, 0x9F, 0xEB, 0xFA, 0xC8, 0xD9,  
            0x31, 0x20, 0x12, 0x03, 0x77, 0x66, 0x54, 0x45, 0xBD, 0xAC, 0x9E, 0x8F, 0xFB, 0xEA, 0xD8, 0xC9,  
            0x42, 0x53, 0x61, 0x70, 0x04, 0x15, 0x27, 0x36, 0xCE, 0xDF, 0xED, 0xFC, 0x88, 0x99, 0xAB, 0xBA,  
            0x52, 0x43, 0x71, 0x60, 0x14, 0x05, 0x37, 0x26, 0xDE, 0xCF, 0xFD, 0xEC, 0x98, 0x89, 0xBB, 0xAA,  
            0x63, 0x72, 0x40, 0x51, 0x25, 0x34, 0x06, 0x17, 0xEF, 0xFE, 0xCC, 0xDD, 0xA9, 0xB8, 0x8A, 0x9B,  
            0x73, 0x62, 0x50, 0x41, 0x35, 0x24, 0x16, 0x07, 0xFF, 0xEE, 0xDC, 0xCD, 0xB9, 0xA8, 0x9A, 0x8B,  
            0x84, 0x95, 0xA7, 0xB6, 0xC2, 0xD3, 0xE1, 0xF0, 0x08, 0x19, 0x2B, 0x3A, 0x4E, 0x5F, 0x6D, 0x7C,  
            0x94, 0x85, 0xB7, 0xA6, 0xD2, 0xC3, 0xF1, 0xE0, 0x18, 0x09, 0x3B, 0x2A, 0x5E, 0x4F, 0x7D, 0x6C,  
            0xA5, 0xB4, 0x86, 0x97, 0xE3, 0xF2, 0xC0, 0xD1, 0x29, 0x38, 0x0A, 0x1B, 0x6F, 0x7E, 0x4C, 0x5D,  
            0xB5, 0xA4, 0x96, 0x87, 0xF3, 0xE2, 0xD0, 0xC1, 0x39, 0x28, 0x1A, 0x0B, 0x7F, 0x6E, 0x5C, 0x4D,  
            0xC6, 0xD7, 0xE5, 0xF4, 0x80, 0x91, 0xA3, 0xB2, 0x4A, 0x5B, 0x69, 0x78, 0x0C, 0x1D, 0x2F, 0x3E,  
            0xD6, 0xC7, 0xF5, 0xE4, 0x90, 0x81, 0xB3, 0xA2, 0x5A, 0x4B, 0x79, 0x68, 0x1C, 0x0D, 0x3F, 0x2E,  
            0xE7, 0xF6, 0xC4, 0xD5, 0xA1, 0xB0, 0x82, 0x93, 0x6B, 0x7A, 0x48, 0x59, 0x2D, 0x3C, 0x0E, 0x1F,  
            0xF7, 0xE6, 0xD4, 0xC5, 0xB1, 0xA0, 0x92, 0x83, 0x7B, 0x6A, 0x58, 0x49, 0x3D, 0x2C, 0x1E, 0x0F  
        };

        /// <summary>  
        /// CRC16查找表低字节  
        /// </summary>  
        private static readonly Byte[] CRC16TABLE_LO =   
        {  
            0x00, 0x89, 0x12, 0x9B, 0x24, 0xAD, 0x36, 0xBF, 0x48, 0xC1, 0x5A, 0xD3, 0x6C, 0xE5, 0x7E, 0xF7,  
            0x81, 0x08, 0x93, 0x1A, 0xA5, 0x2C, 0xB7, 0x3E, 0xC9, 0x40, 0xDB, 0x52, 0xED, 0x64, 0xFF, 0x76,  
            0x02, 0x8B, 0x10, 0x99, 0x26, 0xAF, 0x34, 0xBD, 0x4A, 0xC3, 0x58, 0xD1, 0x6E, 0xE7, 0x7C, 0xF5,  
            0x83, 0x0A, 0x91, 0x18, 0xA7, 0x2E, 0xB5, 0x3C, 0xCB, 0x42, 0xD9, 0x50, 0xEF, 0x66, 0xFD, 0x74,  
            0x04, 0x8D, 0x16, 0x9F, 0x20, 0xA9, 0x32, 0xBB, 0x4C, 0xC5, 0x5E, 0xD7, 0x68, 0xE1, 0x7A, 0xF3,  
            0x85, 0x0C, 0x97, 0x1E, 0xA1, 0x28, 0xB3, 0x3A, 0xCD, 0x44, 0xDF, 0x56, 0xE9, 0x60, 0xFB, 0x72,  
            0x06, 0x8F, 0x14, 0x9D, 0x22, 0xAB, 0x30, 0xB9, 0x4E, 0xC7, 0x5C, 0xD5, 0x6A, 0xE3, 0x78, 0xF1,  
            0x87, 0x0E, 0x95, 0x1C, 0xA3, 0x2A, 0xB1, 0x38, 0xCF, 0x46, 0xDD, 0x54, 0xEB, 0x62, 0xF9, 0x70,  
            0x08, 0x81, 0x1A, 0x93, 0x2C, 0xA5, 0x3E, 0xB7, 0x40, 0xC9, 0x52, 0xDB, 0x64, 0xED, 0x76, 0xFF,  
            0x89, 0x00, 0x9B, 0x12, 0xAD, 0x24, 0xBF, 0x36, 0xC1, 0x48, 0xD3, 0x5A, 0xE5, 0x6C, 0xF7, 0x7E,  
            0x0A, 0x83, 0x18, 0x91, 0x2E, 0xA7, 0x3C, 0xB5, 0x42, 0xCB, 0x50, 0xD9, 0x66, 0xEF, 0x74, 0xFD,  
            0x8B, 0x02, 0x99, 0x10, 0xAF, 0x26, 0xBD, 0x34, 0xC3, 0x4A, 0xD1, 0x58, 0xE7, 0x6E, 0xF5, 0x7C,  
            0x0C, 0x85, 0x1E, 0x97, 0x28, 0xA1, 0x3A, 0xB3, 0x44, 0xCD, 0x56, 0xDF, 0x60, 0xE9, 0x72, 0xFB,  
            0x8D, 0x04, 0x9F, 0x16, 0xA9, 0x20, 0xBB, 0x32, 0xC5, 0x4C, 0xD7, 0x5E, 0xE1, 0x68, 0xF3, 0x7A,  
            0x0E, 0x87, 0x1C, 0x95, 0x2A, 0xA3, 0x38, 0xB1, 0x46, 0xCF, 0x54, 0xDD, 0x62, 0xEB, 0x70, 0xF9,  
            0x8F, 0x06, 0x9D, 0x14, 0xAB, 0x22, 0xB9, 0x30, 0xC7, 0x4E, 0xD5, 0x5C, 0xE3, 0x6A, 0xF1, 0x78  
        };






    }
}
