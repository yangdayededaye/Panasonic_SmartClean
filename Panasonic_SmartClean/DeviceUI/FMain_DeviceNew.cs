using EntityFramework.Extensions;
using ImageSourceModuleCs;
using Panasonic_SmartClean.CommonUI;
using Panasonic_SmartClean.DeviceUI;
using Panasonic_SmartClean.Model;
using Panasonic_SmartClean.Service;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VM.Core;
using VM.PlatformSDKCS;

namespace Panasonic_SmartClean
{
#pragma warning disable CS0246 // 未能找到类型或命名空间名“UIForm”(是否缺少 using 指令或程序集引用?)
    public partial class FMain_DeviceNew : UIForm
#pragma warning restore CS0246 // 未能找到类型或命名空间名“UIForm”(是否缺少 using 指令或程序集引用?)
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();
        public Hsl hsl = Hsl.Instance;
        public LogCls lg = LogCls.Instance;
        public CameraSocket cs = CameraSocket.Instance;
        
        public FMain_DeviceNew()
        {
            InitializeComponent();
            asc.controllInitializeSize(this,true);

            this.WindowState = FormWindowState.Maximized;
            this.Text = SoftConfig._SoftName;

            UserCenter.Text = SoftConfig.user.Name;
            UpdateButton();
            //开启日志
            lg.init(true);
            //加载配置
            ReadMap();
            if (SoftConfig.IsDebug)
            {
                return;
            }
            //连接plc和数据库
            Task.Run(()=> {
                try
                {
                    SoftConfig.ImagePath = SoftConfig.ini.IniReadValue("SOFT", "ImagePath") + "Image";
                    if (!Directory.Exists(SoftConfig.ImagePath))
                    { Directory.CreateDirectory(SoftConfig.ImagePath); }
                }
                catch (Exception ex)
                {
                    lg.SendCommand("初始化图片路径异常:"+ex.Message,1);
                    return;
                }

                if (hsl.Init())
                    lightPLC.State = UILightState.On;
                else
                    lightPLC.State = UILightState.Off;

                if (Util.initDB())
                    lightDB.State = UILightState.On;
                else
                    lightDB.State = UILightState.Off;

                //加载视觉
                try
                {
                    VmSolution.Load(@ConfigurationManager.AppSettings["Sol"].ToString());//加载
                    SoftConfig.processList = GetCurrentSolProcedureList();
                    //设置图像源 调用拍照流程
                    ImageSourceModuleTool imageSourceToolBig = (ImageSourceModuleTool)VmSolution.Instance["大型.图像源1"];
                    imageSourceToolBig.ModuParams.ImageSourceType = ImageSourceParam.ImageSourceTypeEnum.LocalImage;
                    imageSourceToolBig.AddInputImageByPath(System.Environment.CurrentDirectory + "\\PreLoadBig.jpg");
                    VmProcedure procedureBig = VmSolution.Instance["大型"] as VmProcedure;
                    procedureBig.OnWorkEndStatusCallBack += VmProcedure_OnWorkEndStatusCallBack;

                    ImageSourceModuleTool imageSourceToolSmall = (ImageSourceModuleTool)VmSolution.Instance["小型(上位机).图像源1"];
                    imageSourceToolSmall.ModuParams.ImageSourceType = ImageSourceParam.ImageSourceTypeEnum.LocalImage;
                    imageSourceToolSmall.AddInputImageByPath(System.Environment.CurrentDirectory + "\\PreLoadSmall.jpg");
                    VmProcedure procedureSmall = VmSolution.Instance["小型(上位机)"] as VmProcedure;
                    procedureSmall.OnWorkEndStatusCallBack += VmProcedure_OnWorkEndStatusCallBack;

                    if (procedureBig != null)
                    {
                        lg.SendCommand("调用大型", 0);
                        IsPreLoadFinish = false;
                        procedureBig.Run();
                        while (!IsPreLoadFinish)
                        {
                            Task.Delay(500);
                            lg.SendCommand("等待大型回调", 0);
                        }
                    }

                    if (procedureSmall != null)
                    {
                        lg.SendCommand("调用小型", 0);
                        IsPreLoadFinish = false;
                        procedureSmall.Run();
                        while (!IsPreLoadFinish)
                        {
                            Task.Delay(500);
                            lg.SendCommand("等待小型回调", 0);
                        }
                    }

                    //更换图像源 注销回调
                    imageSourceToolBig.ModuParams.ImageSourceType = ImageSourceParam.ImageSourceTypeEnum.Camera;
                    imageSourceToolBig.ModuParams.SetParamValue("CameraID","27");
                    imageSourceToolSmall.ModuParams.ImageSourceType = ImageSourceParam.ImageSourceTypeEnum.Camera;
                    imageSourceToolSmall.ModuParams.SetParamValue("CameraID", "27");
                    procedureBig.OnWorkEndStatusCallBack -= VmProcedure_OnWorkEndStatusCallBack;
                    procedureSmall.OnWorkEndStatusCallBack -= VmProcedure_OnWorkEndStatusCallBack;

                    lightScan.State = UILightState.On;
                }
                catch (Exception ex)
                {
                    lightScan.State = UILightState.Off;
                    lg.SendCommand("打开视觉文件失败："+ex.Message,1);
                }

            });
            
            
            
            
        }

        public bool IsPreLoadFinish = false;

        /// <summary>
        /// 流程结束回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VmProcedure_OnWorkEndStatusCallBack(object sender, EventArgs e)
        {
            try
            {
                VmProcedure procedure = sender as VmProcedure;
                if (procedure != null)
                {
                    IsPreLoadFinish = true;
                    lg.SendCommand("收到预加载回调:"+procedure.FullName,0);
                }
            }
            catch (Exception ex)
            {
                //AppendLog(ex.Message);
            }
        }

        public void UpdateButton()
        {
            btnClean.Enabled = false;
            btnTest.Enabled = false;
            btnUser.Enabled = false;
            btnReport.Enabled = false;
            btnSet.Enabled = false;
            if (SoftConfig.user.Type == "1")
            {
                btnClean.Enabled = true;
                btnTest.Enabled = true;
                btnUser.Enabled = true;
                btnReport.Enabled = true;
                btnSet.Enabled = true;
            }
            else
            {
                btnClean.Enabled = true;
                btnReport.Enabled = true;
            }
        }

        /// <summary>
        /// 获取当前方案的流程列表
        /// </summary>
        private List<VmProcedure> GetCurrentSolProcedureList()
        {
            List<VmProcedure> procedureList = new List<VmProcedure>();
            string processName = "";
            var processInfoList = VmSolution.Instance.GetAllProcedureList();
            for (int i = 0; i < processInfoList.nNum; i++)
            {
                processName = processInfoList.astProcessInfo[i].strProcessName;
                procedureList.Add((VmProcedure)VmSolution.Instance[processName]);
            }
            return procedureList;
        }
        

        public bool ReadMap()
        {
            try
            {
                FileInfo finfo = new FileInfo(System.Environment.CurrentDirectory+"\\warn.txt");
                FileStream fs = finfo.Open(FileMode.OpenOrCreate,
                FileAccess.ReadWrite);
                StreamReader sr = new StreamReader(fs);
                string strList = sr.ReadLine();
                while (strList != null)
                {
                    if (strList.Contains("="))
                    {
                        int iKey = -1;
                        int.TryParse(strList.Split('=')[0],out iKey);
                        if (iKey!=-1&&!SoftConfig._WarnMap.ContainsKey(iKey))
                        {
                            SoftConfig._WarnMap.Add(iKey, strList.Split('=')[1]);
                        }
                    }
                    strList = sr.ReadLine();
                }
                sr.Close();
                fs.Close();

                finfo = new FileInfo(System.Environment.CurrentDirectory + "\\I.txt");
                fs = finfo.Open(FileMode.OpenOrCreate,
                FileAccess.ReadWrite);
                sr = new StreamReader(fs);
                strList = sr.ReadLine();
                while (strList != null)
                {
                    if (strList.Contains("="))
                    {
                        int iKey = -1;
                        int.TryParse(strList.Split('=')[0], out iKey);
                        if (iKey != -1)
                        {
                            SoftConfig._IMap.Add(new IOModel(iKey, strList.Split('=')[1]));
                        }
                    }
                    strList = sr.ReadLine();
                }
                sr.Close();
                fs.Close();

                finfo = new FileInfo(System.Environment.CurrentDirectory + "\\O.txt");
                fs = finfo.Open(FileMode.OpenOrCreate,
                FileAccess.ReadWrite);
                sr = new StreamReader(fs);
                strList = sr.ReadLine();
                while (strList != null)
                {
                    if (strList.Contains("="))
                    {
                        int iKey = -1;
                        int.TryParse(strList.Split('=')[0], out iKey);
                        if (iKey != -1)
                        {
                            SoftConfig._OMap.Add(new IOModel(iKey, strList.Split('=')[1]));
                        }
                    }
                    strList = sr.ReadLine();
                }
                sr.Close();
                fs.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void FMain_DeviceNew_Resize(object sender, EventArgs e)
        {
            asc.controlAutoSize(this.Width, this.Height, this, true);
        }


        private void FMain_DeviceNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            lbTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            if (Hsl._connected&& lightPLC.State != UILightState.On)
                lightPLC.State = UILightState.On;

            if (!Hsl._connected && lightPLC.State != UILightState.Off)
                lightPLC.State = UILightState.Off;
        }

        public int iTouchTime = 0;
        private void FMain_DeviceNew_Click(object sender, EventArgs e)
        {
            iTouchTime++;
            if (iTouchTime==10)
            {
                iTouchTime = 0;
                FUpdateLog f = new FUpdateLog();
                f.ShowDialog();
            }
        }

        private void UserCenter_Click(object sender, EventArgs e)
        {
            if (ShowAskDialog("请选择需要的操作,点击\"确定\"切换用户,点击\"取消\"修改密码"))
            {
                FLogin f = new FLogin(true);
                f.ShowDialog();
                UpdateButton();
            }
            else
            {
                FChangePsw f = new FChangePsw();
                f.ShowDialog();
            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            if (lightScan.State != UILightState.On && !SoftConfig.IsDebug)
            {
                ShowErrorTip("方案加载中");
                return;
            }
            FCleanNew f = new FCleanNew();
            f.ShowDialog();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (lightScan.State != UILightState.On && !SoftConfig.IsDebug)
            {
                ShowErrorTip("方案加载中");
                return;
            }
            //VmSolution.OnWorkStatusEvent -= VmSolution_OnWorkStatusEvent;//注册流程状态回调
            FTest f = new FTest();
            f.ShowDialog();
            //VmSolution.OnWorkStatusEvent += VmSolution_OnWorkStatusEvent;//注册流程状态回调
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            FUser f = new FUser();
            f.ShowDialog();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            FDataView f = new FDataView();
            f.ShowDialog();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            FSet f = new FSet();
            f.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (!ShowAskDialog("确认退出系统吗？"))
            {
                
            }
            else
            {
                foreach (Process p in Process.GetProcesses())
                {
                    if (p.ProcessName.Contains("Panasonic_SmartClean"))
                    {
                        try
                        {
                            p.Kill();
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }
        }
    }
}
