using HslCommunication;
using HslCommunication.Core;
using HslCommunication.Profinet.Melsec;
using HslCommunication.Profinet.Omron;
using HslCommunication.Profinet.Siemens;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Panasonic_SmartClean.Service
{
    public class Hsl
    {

        private LogCls log = LogCls.Instance;

        private Thread th;

        private Thread thCheckConnect;

        private ConcurrentQueue<string> CmdQueue = new ConcurrentQueue<string>();

        public static readonly Hsl Instance = new Hsl();
        private Hsl() { }

        //状态
        public static volatile string Alarm = "";

        private MelsecMcNet melsec_net = null;
        public static bool _connected = false;

        public bool[] bWarn = new bool[65];

        #region 动作点位
        public string front_after_air_out_1 = "M100";
        public string front_after_air_back_1 = "M101";
        public string front_after_air_out_2 = "M102";
        public string front_after_air_back_2 = "M103";
        public string front_after_air_out_3 = "M104";
        public string front_after_air_back_3 = "M105";
        public string front_after_air_out_4 = "M106";
        public string front_after_air_back_4 = "M107";

        public string clip_air_close_1 = "M108";
        public string clip_air_open_1 = "M109";
        public string clip_air_close_2 = "M110";
        public string clip_air_open_2 = "M111";
        public string clip_air_close_3 = "M112";
        public string clip_air_open_3 = "M113";
        public string clip_air_close_4 = "M114";
        public string clip_air_open_4 = "M115";

        public string cleancover_air_out = "M116";
        public string cleancover_air_back = "M117";

        public string blow_emvalve_work = "M124";
        public string blow_emvalve_stop = "M125";

        public string Penetrability_emvalve_work = "M126";
        public string Penetrability_emvalve_stop = "M127";

        public string bigsmall_clip_air_close_1 = "M128";
        public string bigsmall_clip_air_open_1 = "M129";
        public string superbig_clip_air_close_1 = "M130";
        public string superbig_clip_air_open_1 = "M131";

        public string ultrasonic = "M140";
        public string heating = "M141";
        public string loop = "M142";

        public string x_origin = "M400";
        public string x_add = "M401";
        public string x_minu = "M402";
        public string x_posi = "M403";
        public string x_posi_value = "D1150";

        public string y_origin = "M415";
        public string y_add = "M416";
        public string y_minu = "M417";
        public string y_posi = "M418";
        public string y_posi_value = "D1650";

        public string z_origin = "M431";
        public string z_add = "M432";
        public string z_minu = "M433";
        public string z_posi = "M434";//M450
        public string z_posi_value = "D2150";
        //位置行数
        public string locationX1 = "D3100";
        public string locationX2 = "D3101";
        public string locationX3 = "D3102";
        public string locationX4 = "D3103";
        public string locationX5 = "D3104";
        public string locationX6 = "D3105";
        public string locationX7 = "D3106";
        public string locationX8 = "D3107";
        public string locationX9 = "D3108";
        public string locationX10 = "D3109";
        public string locationX11 = "D3110";
        public string locationX12= "D3111";
        public string locationX13= "D3112";
        public string locationX14= "D3113";
        public string locationX15 = "D3114";
        public string locationX16 = "D3115";
        public string locationX17 = "D3116";
        public string locationX18 = "D3117";
        public string locationX19 = "D3118";
        public string locationX20 = "D3119";
        public string locationX21 = "D3120";
        public string locationX22 = "D3121";
        public string locationX23 = "D3122";
        public string locationX24 = "D3123";
        public string locationX25 = "D3124";
        public string locationX26 = "D3125";
        public string locationX27 = "D3126";
        public string locationX28 = "D3127";
        public string locationX29 = "D3128";
        public string locationX30 = "D3129";
        public string locationX31 = "D3130";
        public string locationX32 = "D3131";
        //位置列数
        public string locationY1 = "D3150";
        public string locationY2 = "D3151";
        public string locationY3 = "D3152";
        public string locationY4 = "D3153";
        public string locationY5 = "D3154";
        public string locationY6 = "D3155";
        public string locationY7 = "D3156";
        public string locationY8 = "D3157";
        public string locationY9 = "D3158";
        public string locationY10 = "D3159";
        public string locationY11 = "D3160";
        public string locationY12 = "D3161";
        public string locationY13 = "D3162";
        public string locationY14 = "D3163";
        public string locationY15 = "D3164";
        public string locationY16 = "D3165";
        public string locationY17 = "D3166";
        public string locationY18 = "D3167";
        public string locationY19 = "D3168";
        public string locationY20 = "D3169";
        public string locationY21 = "D3170";
        public string locationY22 = "D3171";
        public string locationY23 = "D3172";
        public string locationY24 = "D3173";
        public string locationY25 = "D3174";
        public string locationY26 = "D3175";
        public string locationY27 = "D3176";
        public string locationY28 = "D3177";
        public string locationY29 = "D3178";
        public string locationY30 = "D3179";
        public string locationY31 = "D3180";
        public string locationY32 = "D3181";





        #endregion

        #region 异常点位
        public bool b_front_after_air_out_1 = false;
        public bool b_front_after_air_back_1 = false;
        public bool b_front_after_air_out_2 = false;
        public bool b_front_after_air_back_2 = false;
        public bool b_front_after_air_out_3 = false;
        public bool b_front_after_air_back_3 = false;
        public bool b_front_after_air_out_4 = false;
        public bool b_front_after_air_back_4 = false;
                    
        public bool b_clip_air_close_1 = false;
        public bool b_clip_air_open_1 = false;
        public bool b_clip_air_close_2 = false;
        public bool b_clip_air_open_2 = false;
        public bool b_clip_air_close_3 = false;
        public bool b_clip_air_open_3 = false;
        public bool b_clip_air_close_4 = false;
        public bool b_clip_air_open_4 = false;
                    
        public bool b_cleancover_air_out = false;
        public bool b_cleancover_air_back = false;
                    
        public bool b_blow_emvalve_work = false;
        public bool b_blow_emvalve_stop = false;
                    
        public bool b_Penetrability_emvalve_work = false;
        public bool b_Penetrability_emvalve_stop = false;
                    
        public bool b_bigsmall_clip_air_close_1 = false;
        public bool b_bigsmall_clip_air_open_1 = false;
        public bool b_superbig_clip_air_close_1 = false;
        public bool b_superbig_clip_air_open_1 = false;
        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        public bool Init()
        {
            try
            {
                string retMsg = "";

                if (Authorization.SetAuthorizationCode("e3e27344-1a9f-4d8b-b4fc-da5cae4b99bf"))
                {
                    th = new Thread(StartFunc);
                    th.IsBackground = true;
                    th.Start();

                    thCheckConnect = new Thread(CheckConnect);
                    thCheckConnect.IsBackground = true;
                    thCheckConnect.Start();

                    melsec_net = new MelsecMcNet();
                    melsec_net.ConnectTimeOut = 2000;
                    melsec_net.IpAddress = ConfigurationManager.AppSettings["PlcIP"].ToString();
                    melsec_net.Port = int.Parse(ConfigurationManager.AppSettings["PlcPort"].ToString());
                    OperateResult connect = melsec_net.ConnectServer();
                    if (connect.IsSuccess)
                    {
                        _connected = true;
                    }
                    else
                    {
                        retMsg = connect.Message;
                        return false;
                    }
                }

                

                

                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        private void StartFunc()
        {
            while (true)
            {
                Thread.Sleep(200);
                if (CmdQueue.Count>0)
                {
                    try
                    {
                        string strCmd = "";
                        CmdQueue.TryDequeue(out strCmd);
                        bWarn = ReadBool("M300", 67);
                    }
                    catch (Exception ex)
                    {

                    }
                }
                
            }
        }

        private void CheckConnect()
        {
            while (true)
            {
                Thread.Sleep(5000);

                try
                {
                    OperateResult<UInt16[]> b = melsec_net.ReadUInt16("D5022", 1);
                    _connected = true;
                }
                catch (Exception ex)
                {
                    log.SendCommand("PLC读取失败，开始重连", 1);
                    _connected = false; ;
                }
                if (!_connected)//重连
                {
                    try
                    {
                        melsec_net = new MelsecMcNet();
                        melsec_net.ConnectTimeOut = 2000;
                        melsec_net.IpAddress = ConfigurationManager.AppSettings["PlcIP"].ToString();
                        melsec_net.Port = int.Parse(ConfigurationManager.AppSettings["PlcPort"].ToString());
                        OperateResult connect = melsec_net.ConnectServer();
                        if (connect.IsSuccess)
                        {
                            _connected = true;
                            log.SendCommand("重连PLC成功",0);
                        }
                        else
                        {
                            _connected = false;
                            log.SendCommand("重连PLC失败", 1);
                        }
                    }
                    catch (Exception ex)
                    {
                        _connected = false;
                        log.SendCommand("重连PLC失败", 1);
                    }
                }
                
            }
        }

        public void SendCommand(string CmdStr)
        {
            CmdQueue.Enqueue(CmdStr);
        }


        #region PLC调用封装
        /// <summary>
        /// 写字节
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public bool WriteBool(string address,bool b)
        {
            try
            {
                
                bool bResult = melsec_net.Write(address, b).IsSuccess;
                return bResult;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
        /// <summary>
        /// 写Ushort
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public bool WriteUshort(string address, ushort f)
        {
            try
            {
                return melsec_net.Write(address, f).IsSuccess;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        /// <summary>
        /// 写UInt
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public bool WriteFloat(string address, float f)
        {
            try
            {
                return melsec_net.Write(address, f).IsSuccess;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        /// <summary>
        /// 写UInt
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public bool WriteInt(string address, int f)
        {
            try
            {
                return melsec_net.Write(address, f).IsSuccess;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        /// <summary>

        /// <summary>
        /// 读bool
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public bool[] ReadBool(string address,ushort iCount)
        {
            try
            {
                OperateResult<bool[]> b = melsec_net.ReadBool(address, iCount);
                return b.Content;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public UInt16[] ReadUShort(string address, ushort iCount)
        {
            try
            {
                OperateResult<UInt16[]> b = melsec_net.ReadUInt16(address, iCount);
                return b.Content;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        /// <summary>
        /// 读Int
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public Int32[] ReadInt(string address, ushort iCount)
        {
            try
            {
                OperateResult<Int32[]> b = melsec_net.ReadInt32(address, iCount);
                return b.Content;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        /// <summary>
        /// 读4字节数字
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public float[] ReadFloat(string address, ushort iCount)
        {
            try
            {
                OperateResult<float[]> b = melsec_net.ReadFloat(address, iCount);
                return b.Content;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        
        #endregion

    }
}
