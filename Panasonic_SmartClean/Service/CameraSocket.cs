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
using System.Windows.Forms;

namespace Panasonic_SmartClean.Service
{
    
    /// <summary>
    /// 指令处理反馈
    /// </summary>
    /// 
    public class CameraSocket
    {
        public LogCls log = LogCls.Instance;

        public Thread thCheckConnection;
        public Thread thRec;
        public Hsl hsl = Hsl.Instance;

        public delegate void GetCameraData(string data);
        public static readonly CameraSocket Instance = new CameraSocket();
        private CameraSocket() { }

        Socket clientSocket = null;

        public GetCameraData ReceiveCameraData;
        /// <summary>
        /// 初始化
        /// </summary>
        public bool Init()
        {
            try
            {
                try
                {
                    //IPAddress ip = IPAddress.Parse(ConfigurationManager.AppSettings["CameraIP"].ToString());
                    IPAddress ip = IPAddress.Parse("127.0.0.1");
                    clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    //clientSocket.Connect(new IPEndPoint(ip, Convert.ToInt32(ConfigurationManager.AppSettings["CameraPort"].ToString()))); //配置服务器IP与端口
                    clientSocket.Connect(new IPEndPoint(ip, 7930));//配置服务器IP与端口

                }
                catch (Exception)
                {

                }

                thRec = new Thread(Rec);
                thRec.IsBackground = true;
                thRec.Start();

                thCheckConnection = new Thread(CheckConnection);
                thCheckConnection.IsBackground = true;
                thCheckConnection.Start();

                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }

        }

        public void CheckConnection()
        {
            while (true)
            {
                try
                {
                    clientSocket.Send(Encoding.Default.GetBytes("heart"));

                }
                catch (Exception ex)
                {
                    //发送失败开始重连
                    try
                    {
                       // IPAddress ip = IPAddress.Parse(ConfigurationManager.AppSettings["CameraIP"].ToString());
                        IPAddress ip = IPAddress.Parse("127.0.0.1");
                        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        //clientSocket.Connect(new IPEndPoint(ip, Convert.ToInt32(ConfigurationManager.AppSettings["CameraPort"].ToString()))); //配置服务器IP与端口
                        clientSocket.Connect(new IPEndPoint(ip, 7930));//配置服务器IP与端口
                    }
                    catch (Exception)
                    {

                    }
                }
                Thread.Sleep(2000);
            }
        }

        public void Rec()
        {
            byte[] b = new byte[2];
            byte[] buffer = null;
            while (true)
            {
                try
                {
                    buffer = new byte[1000];
                   int ret= clientSocket.Receive(buffer);

                    ReceiveCameraData?.Invoke(Encoding.Default.GetString(buffer,0,ret));//改动
                              
                    log.SendCommand("【接收到相机返回】" + Util.BytesToHexString(buffer), 0);
                }
                catch (System.Exception ex)
                {

                }
                Thread.Sleep(10);
            }

        }



    }
}

