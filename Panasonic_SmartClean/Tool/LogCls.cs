using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Collections.Concurrent;

namespace Panasonic_SmartClean
{
    public class LogCls
    {
        private LogCls()
        {
        }

        public class Command
        {
            public string CmdText;
            public int CmdValue;
            public string CmdString;
        }

        private ConcurrentQueue<Command> CmdQueue = new ConcurrentQueue<Command>();

        public static LogCls Instance = new LogCls();

        public static bool _IsLogOpen = true;

        private Thread th = null;

        public void SendCommand(string cmd, int value,string filename="main")
        {
            Command command = new Command();
            command.CmdText = cmd;
            command.CmdValue = value;
            command.CmdString = filename;
            CmdQueue.Enqueue(command);
        }

        public void init(bool IsLogOpen)
        {
            _IsLogOpen = IsLogOpen;
            th = new Thread(run);
            th.IsBackground = true;
            th.Start();
        }

        public void openLog()
        {
            _IsLogOpen = true;
        }
        
        public void closeLog()
        {
            _IsLogOpen = false;
        }

        public void finalize()
        {
            th.Abort();
        }

        private void run()
        {
            while (true)
            {
                if (!CmdQueue.IsEmpty && CmdQueue.Count > 0)
                {
                    Command cmd;
                    if (CmdQueue.TryDequeue(out cmd))
                    {
                        //处理队列内容
                        //if (_IsLogOpen)
                        //{
                            DispatchCmd(cmd.CmdText,cmd.CmdValue,cmd.CmdString);
                        //}
                    }
                }

                Thread.Sleep(10);
            }
        }



        private void DispatchCmd(string str,int iType,string strFileName)
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
                        if (_IsLogOpen)
                        {
                            sw.WriteLine(strEX + str);
                        }
                        break;
                }

                sw.Close();
            }
            catch (System.Exception ex)
            {

            }
        }



    }
}
