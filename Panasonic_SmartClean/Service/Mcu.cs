using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.IO;
using System.Collections.Concurrent;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.Net;

namespace Panasonic_SmartClean
{
    /// <summary>
    /// 指令处理反馈
    /// </summary>
    public class Mcu
    {                          
        private ConcurrentQueue<Command> CmdQueue = new ConcurrentQueue<Command>();
        private StringBuilder strRece;
        public LogCls log = LogCls.Instance;

        public Thread th;
        public Thread thAnalysis;
        System.IO.Ports.SerialPort com = new System.IO.Ports.SerialPort();

        private static DateTime dtHeart;
        
        public class Command
        {
            public int CmdBox;
            public string CmdText;
            public int CmdFlag;
            public string CmdValue;
            public int CmdRealCount;
            public int CmdNeedCount;
            public bool CmdSwitch;
        }

        public static readonly Mcu Instance = new Mcu();
        private Mcu() { }


        /// <summary>
        /// 初始化
        /// </summary>
        public bool Init()
        {
            try
            {
                com.BaudRate = 9600;
                com.PortName = ConfigurationManager.AppSettings["Control"].ToString();
                com.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(Com_DataReceive);
                com.Open();

                th = new Thread(StartFunc);
                th.IsBackground = true;
                th.Start();
                
                thAnalysis = new Thread(AnalysisFunc);
                thAnalysis.IsBackground = true;
                //thAnalysis.Start();

                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        public void StartFunc()
        {
            while(true)
            {
                if (!CmdQueue.IsEmpty && CmdQueue.Count > 0)
                {
                    Command cmd;
                    if (CmdQueue.TryDequeue(out cmd))
                    {
                        if (cmd != null)
                        {
                            
                            DispatchCmd(cmd);
                            
                        }
                    }
                }
                Thread.Sleep(200);
            }
        }

        public int Len = 0;
        public int DataLen = 0;
        public int MsgLen = 0;
        public byte[] Msg = null;
        public byte[] CRC = null;
        private void DispatchCmd(Command cmd)
        {
            try
            {
                
                switch (cmd.CmdText)
                {
                    case "ShowTotalSorted":
                        int Len = 8;
                        byte[] bDepName = Util.GetHexFromChs(cmd.CmdValue);

                        int DataLen = bDepName.Length;
                        int MsgLen = Len + DataLen;


                        byte[] Msg = new byte[MsgLen];
                        Msg[0] = 0xFA;

                        Msg[1] = (byte)((cmd.CmdBox & 0xFF00) >> 8);
                        Msg[2] = (byte)(cmd.CmdBox & 0xFF);
                        Msg[3] = 0x25;
                        Msg[4] = (byte)(DataLen);
                        for (int i = 0; i < DataLen; i++)
                        {
                            Msg[i + 5] = bDepName[i];
                        }
                        Msg[MsgLen - 1] = 0xFC;
                        CRC = new byte[2];
                        CRC = Util.GetCRC(Msg);
                        Msg[MsgLen - 3] = CRC[0];
                        Msg[MsgLen - 2] = CRC[1];
                        com.Write(Msg, 0, Msg.Length);
                        log.SendCommand("【发送ShowTotalSorted指令】" + Util.BytesToHexString(Msg), 0, "device");
                        break;
                    case "ShowCurrentAndGoal":
                        Len = 8;
                        DataLen = 4;
                        MsgLen = Len + DataLen;
                        Msg = new byte[MsgLen];
                        Msg[0] = 0xFA;
                        Msg[1] = (byte)((cmd.CmdBox & 0xFF00) >> 8);
                        Msg[2] = (byte)(cmd.CmdBox & 0xFF);
                        Msg[3] = 0x20;
                        Msg[4] = (byte)(DataLen);
                        Msg[5] = (byte)((cmd.CmdRealCount & 0xFF00) >> 8);
                        Msg[6] = (byte)(cmd.CmdRealCount & 0xFF);
                        Msg[7] = (byte)((cmd.CmdNeedCount & 0xFF00) >> 8);
                        Msg[8] = (byte)(cmd.CmdNeedCount & 0xFF);
                        Msg[MsgLen - 1] = 0xFC;
                        CRC = new byte[2];
                        CRC = Util.GetCRC(Msg);
                        Msg[MsgLen - 3] = CRC[0];
                        Msg[MsgLen - 2] = CRC[1];
                        com.Write(Msg, 0, Msg.Length);
                        log.SendCommand("【发送ShowCurrentAndGoal指令】" + Util.BytesToHexString(Msg),0, "device");
                        break;
                    case "Light":
                        Len = 8;
                        DataLen = 1;
                        MsgLen = Len + DataLen;
                        Msg = new byte[MsgLen];
                        Msg[0] = 0xFA;
                        Msg[1] = (byte)((cmd.CmdBox & 0xFF00) >> 8);
                        Msg[2] = (byte)(cmd.CmdBox & 0xFF);
                        Msg[3] = 0x30;
                        Msg[4] = (byte)(DataLen);
                        Msg[5] = (byte)(cmd.CmdFlag);
                        Msg[MsgLen - 1] = 0xFC;
                        CRC = new byte[2];
                        CRC = Util.GetCRC(Msg);
                        Msg[MsgLen - 3] = CRC[0];
                        Msg[MsgLen - 2] = CRC[1];
                        com.Write(Msg, 0, Msg.Length);
                        log.SendCommand("【发送Light指令】" + Util.BytesToHexString(Msg), 0, "device");
                        break;
                    case "Department":
                        Len = 8;
                        if (cmd.CmdValue.Length > 5)
                        {
                            cmd.CmdValue = cmd.CmdValue.Substring(0, 5);
                        }
                        bDepName = Util.GetHexFromChs(cmd.CmdValue);
                        DataLen = bDepName.Length;
                        MsgLen = Len + DataLen;
                        Msg = new byte[MsgLen];
                        Msg[0] = 0xFA;
                        Msg[1] = (byte)((cmd.CmdBox & 0xFF00) >> 8);
                        Msg[2] = (byte)(cmd.CmdBox & 0xFF);
                        Msg[3] = 0x23;
                        Msg[4] = (byte)(DataLen);
                        for (int i = 0; i < DataLen; i++)
                        {
                            Msg[i + 5] = bDepName[i];
                        }
                        Msg[MsgLen - 1] = 0xFC;
                        CRC = new byte[2];
                        CRC = Util.GetCRC(Msg);
                        Msg[MsgLen - 3] = CRC[0];
                        Msg[MsgLen - 2] = CRC[1];
                        com.Write(Msg, 0, Msg.Length);
                        log.SendCommand("【发送Batch指令】" + Util.BytesToHexString(Msg), 0, "device");
                        break;
                    case "AddressSwitch":
                        Msg = new byte[8];
                        Msg[0] = 0xFA;
                        Msg[1] = 0xFF;
                        Msg[2] = 0xFF;
                        if (cmd.CmdSwitch)
                        {
                            Msg[3] = 0x42;
                        }
                        else
                        {
                            Msg[3] = 0x43;
                        }
                        Msg[4] = 0x00;
                        Msg[7] = 0xFC;
                        CRC = new byte[2];
                        CRC = Util.GetCRC(Msg);
                        Msg[5] = CRC[0];
                        Msg[6] = CRC[1];
                        com.Write(Msg, 0, Msg.Length);
                        log.SendCommand("【发送AddressSwitch指令】" + Util.BytesToHexString(Msg), 0, "device");
                        break;
                    case "SetAddress":
                        Len = 8;
                        DataLen = 2;
                        MsgLen = Len + DataLen;
                        Msg = new byte[MsgLen];
                        Msg[0] = 0xFA;
                        Msg[1] = 0xFF;
                        Msg[2] = 0xFF;
                        Msg[3] = 0x44;
                        Msg[4] = (byte)(DataLen);
                        Msg[5] = (byte)(cmd.CmdBox / 256);
                        Msg[6] = (byte)(cmd.CmdBox - cmd.CmdBox / 256);
                        Msg[MsgLen - 1] = 0xFC;
                        CRC = new byte[2];
                        CRC = Util.GetCRC(Msg);
                        Msg[MsgLen - 3] = CRC[0];
                        Msg[MsgLen - 2] = CRC[1];
                        com.Write(Msg, 0, Msg.Length);
                        log.SendCommand("【发送SetAddress指令】" + Util.BytesToHexString(Msg), 0, "device");
                        break;
                }

            }
            catch (System.Exception ex)
            {
                log.SendCommand("【McuDispatchCmd】" + ex.Message, 1);
            }
        }

        private void AnalysisFunc()
        {
            while(true)
            {
                if (!ReceQueue.IsEmpty && ReceQueue.Count > 0)
                {
                    string s;
                    if (ReceQueue.TryDequeue(out s))
                    {
                        if (s != null)
                        {
                            strRece.Append(s);
                        }
                    }
                }

                try
                {
                    int iStart = strRece.ToString().IndexOf("FA");
                    int iEnd = strRece.ToString().IndexOf("FC");
                    if (iStart != -1 && iEnd != -1)
                    {
                        string str = strRece.ToString().Substring(iStart, iEnd - iStart + 2);
                        log.SendCommand("【开始解析】" + str, 0);
                        strRece.Remove(iStart, iEnd - iStart + 2);
                        //解析
                        byte[] buffer = Util.HexStringToBytes(str);
                        if (buffer[3] == 0x28)//锁状态返回
                        {
                            
                        }

                    }
                }
                catch (Exception)
                {

                    
                }

                Thread.Sleep(10);
            }
        }

        public ConcurrentQueue<string> ReceQueue = new ConcurrentQueue<string>();
        
        private void Com_DataReceive(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                byte[] buffer = null;
                Thread.Sleep(10);

                int iLength = com.BytesToRead;

                buffer = new byte[iLength];
                com.Read(buffer, 0, iLength);

                dtHeart = DateTime.Now;
                //log.SendCommand("【收到屏幕回复】" + Util.BytesToHexString(buffer), 0, "device");
                //ReceQueue.Enqueue(Util.BytesToHexString(buffer));

            }
            catch (System.Exception ex)
            {

            }
        }


        private void ClearCmdQueue()
        {
            CmdQueue = new ConcurrentQueue<Command>();
        }

        #region crc
        /// <summary>
        /// CRC高位校验码checkCRCHigh
        /// </summary>
        static byte[] ArrayCRCHigh =
        {
        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0,
        0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
        0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
        0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1,
        0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1,
        0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0,
        0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40,
        0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1,
        0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0,
        0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40,
        0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
        0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0,
        0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
        0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
        0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
        0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
        0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40,
        0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1,
        0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0,
        0x80, 0x41, 0x00, 0xC1, 0x81, 0x40
        };
        /// <summary>
        /// CRC地位校验码checkCRCLow
        /// </summary>
        static byte[] checkCRCLow =
        {
        0x00, 0xC0, 0xC1, 0x01, 0xC3, 0x03, 0x02, 0xC2, 0xC6, 0x06,
        0x07, 0xC7, 0x05, 0xC5, 0xC4, 0x04, 0xCC, 0x0C, 0x0D, 0xCD,
        0x0F, 0xCF, 0xCE, 0x0E, 0x0A, 0xCA, 0xCB, 0x0B, 0xC9, 0x09,
        0x08, 0xC8, 0xD8, 0x18, 0x19, 0xD9, 0x1B, 0xDB, 0xDA, 0x1A,
        0x1E, 0xDE, 0xDF, 0x1F, 0xDD, 0x1D, 0x1C, 0xDC, 0x14, 0xD4,
        0xD5, 0x15, 0xD7, 0x17, 0x16, 0xD6, 0xD2, 0x12, 0x13, 0xD3,
        0x11, 0xD1, 0xD0, 0x10, 0xF0, 0x30, 0x31, 0xF1, 0x33, 0xF3,
        0xF2, 0x32, 0x36, 0xF6, 0xF7, 0x37, 0xF5, 0x35, 0x34, 0xF4,
        0x3C, 0xFC, 0xFD, 0x3D, 0xFF, 0x3F, 0x3E, 0xFE, 0xFA, 0x3A,
        0x3B, 0xFB, 0x39, 0xF9, 0xF8, 0x38, 0x28, 0xE8, 0xE9, 0x29,
        0xEB, 0x2B, 0x2A, 0xEA, 0xEE, 0x2E, 0x2F, 0xEF, 0x2D, 0xED,
        0xEC, 0x2C, 0xE4, 0x24, 0x25, 0xE5, 0x27, 0xE7, 0xE6, 0x26,
        0x22, 0xE2, 0xE3, 0x23, 0xE1, 0x21, 0x20, 0xE0, 0xA0, 0x60,
        0x61, 0xA1, 0x63, 0xA3, 0xA2, 0x62, 0x66, 0xA6, 0xA7, 0x67,
        0xA5, 0x65, 0x64, 0xA4, 0x6C, 0xAC, 0xAD, 0x6D, 0xAF, 0x6F,
        0x6E, 0xAE, 0xAA, 0x6A, 0x6B, 0xAB, 0x69, 0xA9, 0xA8, 0x68,
        0x78, 0xB8, 0xB9, 0x79, 0xBB, 0x7B, 0x7A, 0xBA, 0xBE, 0x7E,
        0x7F, 0xBF, 0x7D, 0xBD, 0xBC, 0x7C, 0xB4, 0x74, 0x75, 0xB5,
        0x77, 0xB7, 0xB6, 0x76, 0x72, 0xB2, 0xB3, 0x73, 0xB1, 0x71,
        0x70, 0xB0, 0x50, 0x90, 0x91, 0x51, 0x93, 0x53, 0x52, 0x92,
        0x96, 0x56, 0x57, 0x97, 0x55, 0x95, 0x94, 0x54, 0x9C, 0x5C,
        0x5D, 0x9D, 0x5F, 0x9F, 0x9E, 0x5E, 0x5A, 0x9A, 0x9B, 0x5B,
        0x99, 0x59, 0x58, 0x98, 0x88, 0x48, 0x49, 0x89, 0x4B, 0x8B,
        0x8A, 0x4A, 0x4E, 0x8E, 0x8F, 0x4F, 0x8D, 0x4D, 0x4C, 0x8C,
        0x44, 0x84, 0x85, 0x45, 0x87, 0x47, 0x46, 0x86, 0x82, 0x42,
        0x43, 0x83, 0x41, 0x81, 0x80, 0x40
        };
        /// <summary>
        /// CRC校验
        /// </summary>
        /// <param name="data">校验的字节数组</param>
        /// <param name="length">校验的数组长度</param>
        /// <returns>该字节数组的奇偶校验字节</returns>
        public static Int16 CRC16(byte[] data, int arrayLength)
        {
            byte CRCHigh = 0xFF;
            byte CRCLow = 0xFF;
            byte index;
            int i = 0;
            while (arrayLength-- > 0)
            {
                index = (System.Byte)(CRCHigh ^ data[i++]);
                CRCHigh = (System.Byte)(CRCLow ^ ArrayCRCHigh[index]);
                CRCLow = checkCRCLow[index];
            }
            return (Int16)(CRCHigh << 8 | CRCLow);
        }
        #endregion

        /// <summary>
        /// 关闭
        /// </summary>
        public bool Close()
        {
            try
            {

                th.Abort();
                thAnalysis.Abort();

                return true;
            }
            catch (System.Exception ex)
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
        /// 主要用来控制修改地址
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="iBoxNo"></param>
        public void SendCommand(string cmd, int iBoxNo)
        {
            Command command = new Command();
            command.CmdText = cmd;
            command.CmdBox = iBoxNo;
            CmdQueue.Enqueue(command);
        }
        /// <summary>
        /// 主要用来控制修改地址开关
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="iBoxNo"></param>
        /// <param name="bOn"></param>
        public void SendCommand(string cmd, int iBoxNo, bool bOn)
        {
            Command command = new Command();
            command.CmdText = cmd;
            command.CmdSwitch = bOn;
            command.CmdBox = iBoxNo;
            CmdQueue.Enqueue(command);
        }
        /// <summary>
        /// 主要用来控制灯
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="iBoxNo"></param>
        /// <param name="iFlag"></param>
        public void SendCommand(string cmd, int iBoxNo, int iFlag)
        {
            Command command = new Command();
            command.CmdText = cmd;
            command.CmdFlag = iFlag;
            command.CmdBox = iBoxNo;
            CmdQueue.Enqueue(command);
        }
        /// <summary>
        /// 主要用来显示内容,例如病区名称、累计清空数
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="iBoxNo"></param>
        /// <param name="strContext"></param>
        public void SendCommand(string cmd, int iBoxNo,string strContext)
        {
            Command command = new Command();
            command.CmdText = cmd;
            command.CmdBox = iBoxNo;
            command.CmdValue = strContext.Length > 5 ? strContext.Substring(0, 5) : strContext;
            CmdQueue.Enqueue(command);
        }
        /// <summary>
        /// 主要用来显示数量
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="iBoxNo"></param>
        /// <param name="iRealCount"></param>
        /// <param name="iNeedCount"></param>
        public void SendCommand(string cmd, int iBoxNo, int iRealCount,int iNeedCount)
        {
            Command command = new Command();
            command.CmdText = cmd;
            command.CmdBox = iBoxNo;
            command.CmdRealCount = iRealCount;
            command.CmdNeedCount = iNeedCount;
            CmdQueue.Enqueue(command);
        }

        public DateTime GetHeart()
        {
            return dtHeart;
        }
        
        /// <summary>
        /// 判断是否还有指令未执行
        /// </summary>
        /// <returns></returns>
        public bool IsExistCommand()
        {
            if (!CmdQueue.IsEmpty && CmdQueue.Count > 0)
            {
                return true;
            }
            else
                return false;
        }




    }
}
