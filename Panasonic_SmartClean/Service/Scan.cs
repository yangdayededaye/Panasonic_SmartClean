using Sunny.UI;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Panasonic_SmartClean.Service
{
    public class Scan
    {
        private StringBuilder strRece = new StringBuilder();
        private ConcurrentQueue<Command> CmdQueue = new ConcurrentQueue<Command>();

        private LogCls log = LogCls.Instance;

        public int iTakeCount = 0;
        private Thread th;
        private Thread thRec;
        private Socket clientSocket = null;

        private DateTime dtHeart;
        public static volatile string barcode="";

        public class Command
        {
            public string CmdText;
        }

        public static readonly Scan Instance = new Scan();
        private Scan() { }


        /// <summary>
        /// 初始化
        /// </summary>
        public bool Init()
        {
            try
            {
                IPAddress ip = IPAddress.Parse(ConfigurationManager.AppSettings["ScanIP"]);
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.Connect(new IPEndPoint(ip, Convert.ToInt32(ConfigurationManager.AppSettings["ScanPort"]))); //配置服务器IP与端口

                th = new Thread(StartFunc);
                th.IsBackground = true;
                th.Start();

                thRec = new Thread(Rec);
                thRec.IsBackground = true;
                thRec.Start();

                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        public void StartFunc()
        {
            while (true)
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

        private void DispatchCmd(Command cmd)
        {
            try
            {

                switch (cmd.CmdText)
                {
                    case "Check":

                        break;
                }

            }
            catch (System.Exception ex)
            {
                log.SendCommand("【ScanDispatchCmd】" + ex.Message, 1);
            }
        }

        public void Rec()
        {
            byte[] b = new byte[2];
            byte[] buffer = null;
            string strRec = "";
            while (true)
            {
                try
                {
                    buffer = new byte[128];
                    clientSocket.Receive(buffer);
                    strRec = System.Text.Encoding.Default.GetString(buffer, 0, 128);
                    while (strRec[strRec.Length-1]=='\0')
                    {
                        strRec = strRec.RemoveRight(1);
                    }
                    barcode = strRec.Trim(' ');
                    log.SendCommand("【扫码枪获取到条码】" + barcode, 0);
                }
                catch (System.Exception ex)
                {

                }
            }

        }


        /// <summary>
        /// 关闭
        /// </summary>
        public bool Close()
        {
            try
            {
                th.Abort();
                thRec.Abort();

                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();

                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        private void ClearCmdQueue()
        {
            CmdQueue = new ConcurrentQueue<Command>();
        }

        //主要用来查询
        public void SendCommand(string cmd)
        {
            Command command = new Command();
            command.CmdText = cmd;
            CmdQueue.Enqueue(command);
        }

        public DateTime GetHeart()
        {
            return dtHeart;
        }

        public string GetBarCode()
        {
            return barcode;
        }
        public void SetBarCode(string _barcode)
        {
            barcode = _barcode;
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
