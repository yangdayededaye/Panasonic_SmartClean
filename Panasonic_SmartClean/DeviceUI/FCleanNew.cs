using EntityFramework.Extensions;
using ImageSourceModuleCs;
using Panasonic_SmartClean.Model;
using Panasonic_SmartClean.Service;
using Newtonsoft.Json;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Collections.Concurrent;
using System.Configuration;

namespace Panasonic_SmartClean
{
    public partial class FCleanNew : UIForm
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();
        public LogCls lg = LogCls.Instance;
        public Hsl hsl = Hsl.Instance;
        public bool IsBeforeEnable;

        public CancellationTokenSource cts=new CancellationTokenSource();

        public ConcurrentQueue<string> CmdNeedRefresh = new ConcurrentQueue<string>();
        public ConcurrentQueue<string> CmdNeedAdd = new ConcurrentQueue<string>();
        public ConcurrentQueue<ImageModel> CmdImage = new ConcurrentQueue<ImageModel>();

        private Bitmap ImageBaseDataToBitmap(ImageBaseData imageBaseData)
        {
            try
            {
                System.Drawing.Imaging.PixelFormat bitMaPixelFormat = System.Drawing.Imaging.PixelFormat.Undefined;
                byte[] imageDataBytes = imageBaseData.ImageData;
                byte[] bitmapDataBytes;
                Int32 imageWidth = Convert.ToInt32(imageBaseData.Width);
                Int32 imageHeight = Convert.ToInt32(imageBaseData.Height);
                Bitmap bmap = null;
                System.Drawing.Imaging.BitmapData bitmapData = null;
                IntPtr imageBufferPtr = IntPtr.Zero;
                int offset;
                int bitmapBytesLenth = 0;
                int strid;
                switch (imageBaseData.Pixelformat)
                {
                    case ImvsSdkDefine.IMVS_IMG_FORMAT_MONO8:
                        bitMaPixelFormat = System.Drawing.Imaging.PixelFormat.Format8bppIndexed;
                        offset = imageWidth % 4 != 0 ? (4 - imageWidth % 4) : 0;
                        strid = imageWidth + offset;
                        bmap = new Bitmap(imageWidth, imageHeight, bitMaPixelFormat);
                        bitmapBytesLenth = strid * imageHeight;
                        bitmapDataBytes = new byte[bitmapBytesLenth];
                        var colorPalettes = bmap.Palette;
                        for (int j = 0; j < 256; j++)
                        {
                            colorPalettes.Entries[j] = Color.FromArgb(j, j, j);
                        }
                        bmap.Palette = colorPalettes;
                        for (int i = 0; i < imageHeight; i++)
                        {
                            for (int j = 0; j < strid; j++)
                            {
                                int bitIndex = i * strid + j;
                                int mvdIndex = i * imageWidth + j;
                                if (j >= imageWidth)
                                {
                                    bitmapDataBytes[bitIndex] = 0;
                                }
                                else
                                {
                                    bitmapDataBytes[bitIndex] = imageDataBytes[mvdIndex];
                                }
                            }
                        }
                        bitmapData = bmap.LockBits(new Rectangle(0, 0, imageWidth, imageHeight), System.Drawing.Imaging.ImageLockMode.WriteOnly, bitMaPixelFormat); imageBufferPtr = bitmapData.Scan0;
                        imageBufferPtr = bitmapData.Scan0;
                        System.Runtime.InteropServices.Marshal.Copy(bitmapDataBytes, 0, imageBufferPtr, bitmapBytesLenth);
                        bmap.UnlockBits(bitmapData);
                        break;
                    case ImvsSdkDefine.IMVS_IMG_FORMAT_RGB24:
                        bitMaPixelFormat = System.Drawing.Imaging.PixelFormat.Format24bppRgb;
                        offset = imageWidth % 4 != 0 ? (4 - (imageWidth * 3) % 4) : 0;
                        strid = imageWidth * 3 + offset;
                        bmap = new Bitmap(imageWidth, imageHeight, bitMaPixelFormat);
                        bitmapBytesLenth = strid * imageHeight;
                        bitmapDataBytes = new byte[bitmapBytesLenth];
                        for (int i = 0; i < imageHeight; i++)
                        {
                            for (int j = 0; j < imageWidth; j++)
                            {
                                int mvdIndex = i * imageWidth * 3 + j * 3;
                                int bitIndex = i * strid + j * 3;
                                bitmapDataBytes[bitIndex] = imageDataBytes[mvdIndex + 2];
                                bitmapDataBytes[bitIndex + 1] = imageDataBytes[mvdIndex + 1];
                                bitmapDataBytes[bitIndex + 2] = imageDataBytes[mvdIndex];
                            }
                            for (int k = 0; k < offset; k++)
                            {
                                bitmapDataBytes[i * strid + imageWidth * 3 + k] = 0;
                            }
                        }
                        bitmapData = bmap.LockBits(new Rectangle(0, 0, imageWidth, imageHeight), System.Drawing.Imaging.ImageLockMode.WriteOnly, bitMaPixelFormat);
                        imageBufferPtr = bitmapData.Scan0;
                        System.Runtime.InteropServices.Marshal.Copy(bitmapDataBytes, 0, imageBufferPtr, bitmapBytesLenth);
                        bmap.UnlockBits(bitmapData);
                        break;
                    default:
                        break;
                }
                return bmap;
            }
            catch (Exception ex)
            {
                ShowLog("转换图片异常:图像尺寸"+ imageBaseData.Width.ToString()+"-"+ imageBaseData.Height.ToString() +" "+ ex.Message,1);
                return null;
            }
            
        }

        public EWorkPieceType CurrentType;

        //清洗时间
        public ushort iCleanTime = 0;

        public FCleanNew()
        {
            InitializeComponent();
            asc.controllInitializeSize(this);
            this.WindowState = FormWindowState.Maximized;
            //注册
            VmSolution.OnWorkStatusEvent += VmSolution_OnWorkStatusEvent;//注册流程状态回调
        }

        public VmProcedure GetProcessByID(uint ID)
        {
            for (int i = 0; i < SoftConfig.processList.Count(); i++)
            {
                if (SoftConfig.processList[i].ID==ID)
                {
                    return SoftConfig.processList[i];
                }
            }
            return null;
        }

        private void FCleanNew_Load(object sender, EventArgs e)
        {
            if (SoftConfig.IsDebug)
            {
                GenMap(EWorkPieceType.small);
                return;
            }

            bool bState = hsl.ReadBool("M9", 1)[0];
            if (bState)
            {
                btnDoor.Text = "门禁已屏蔽";
            }
            else
            {
                btnDoor.Text = "门禁已开启";
            }
            bState = hsl.ReadBool("M5", 1)[0];
            if (bState)
            {
                btnBell.Text = "蜂鸣已屏蔽";
            }
            else
            {
                btnBell.Text = "蜂鸣已开启";
            }

            //读取清洗时间
            iCleanTime = hsl.ReadUShort("D5000", 1)[0];
            iCleanTime = (ushort)(iCleanTime / 10);
            lbCleanTime.Text = "清洗时间 : " + iCleanTime.ToString()+" 秒";

            //查询流量阈值
            SoftConfig.lstFlow = SoftConfig.db.Flow.Where(x => x.Ocr != "").ToList();
            ShowLog("获取到流量阈值记录："+SoftConfig.lstFlow.Count.ToString());
            //查询流程
            SoftConfig.lstProcess = SoftConfig.db.VisonProcess.Where(x => x.ProcessID != "").ToList();
            ShowLog("获取到视觉流程记录：" + SoftConfig.lstProcess.Count.ToString());
            //示意图
            Task.Run(() =>
            {
                ShowLog("检测流程已开启");
                while (true)
                {
                    if (cts.Token.IsCancellationRequested)
                    {
                        return;
                    }

                    try
                    {
                        

                        //刷新示意图
                        if (CmdNeedRefresh.Count > 0)
                        {
                            string strResult = "";
                            if (CmdNeedRefresh.TryDequeue(out strResult))
                            {
                                try
                                {
                                    RefreshMap();
                                }
                                catch (Exception ex)
                                {
                                    ShowLog("刷新示意图异常:" + ex.Message + " " + GetIndexString(), 1);
                                }
                            }
                        }
                        
                    }
                    catch (Exception)
                    {

                    }

                    Task.Delay(50);

                }
            }, cts.Token);
            //异常/示意图/结束
            Task.Run(() =>
            {
                ShowLog("检测流程已开启");
                while (true)
                {
                    if (cts.Token.IsCancellationRequested)
                    {
                        return;
                    }

                    try
                    {
                        if (hsl.ReadBool("M351", 1)[0])
                        {
                            hsl.WriteBool("M351", false);
                            ShowLog("小型通透检测NG槽位满");
                            FAttention f = new FAttention("小型通透检测NG槽位满");
                            f.ShowDialog();
                        }
                        if (hsl.ReadBool("M352", 1)[0])
                        {
                            hsl.WriteBool("M352", false);
                            ShowLog("小型吸嘴堵塞NG槽位满");
                            FAttention f = new FAttention("小型吸嘴堵塞NG槽位满");
                            f.ShowDialog();
                        }
                        if (hsl.ReadBool("M353", 1)[0])
                        {
                            hsl.WriteBool("M353", false);
                            ShowLog("小型反光板NG槽位满");
                            FAttention f = new FAttention("小型反光板NG槽位满");
                            f.ShowDialog();
                        }
                        if (hsl.ReadBool("M354", 1)[0])
                        {
                            hsl.WriteBool("M354", false);
                            ShowLog("小型吸嘴反光板破损NG槽位满");
                            FAttention f = new FAttention("小型吸嘴反光板破损NG槽位满");
                            f.ShowDialog();
                        }
                        if (hsl.ReadBool("M355", 1)[0])
                        {
                            hsl.WriteBool("M355", false);
                            ShowLog("大型通透检测NG槽位满");
                            FAttention f = new FAttention("大型通透检测NG槽位满");
                            f.ShowDialog();
                        }
                        if (hsl.ReadBool("M356", 1)[0])
                        {
                            hsl.WriteBool("M356", false);
                            ShowLog("大型吸嘴堵塞NG槽位满");
                            FAttention f = new FAttention("大型吸嘴堵塞NG槽位满");
                            f.ShowDialog();
                        }
                        if (hsl.ReadBool("M357", 1)[0])
                        {
                            hsl.WriteBool("M357", false);
                            ShowLog("大型反光板NG槽位满");
                            FAttention f = new FAttention("大型反光板NG槽位满");
                            f.ShowDialog();
                        }
                        if (hsl.ReadBool("M358", 1)[0])
                        {
                            hsl.WriteBool("M358", false);
                            ShowLog("大型吸嘴反光板破损NG槽位满");
                            FAttention f = new FAttention("大型吸嘴反光板破损NG槽位满");
                            f.ShowDialog();
                        }
                        if (hsl.ReadBool("M359", 1)[0])
                        {
                            hsl.WriteBool("M359", false);
                            ShowLog("超大型通透检测NG槽位满");
                            FAttention f = new FAttention("超大型通透检测NG槽位满");
                            f.ShowDialog();
                        }
                        if (hsl.ReadBool("M360", 1)[0])
                        {
                            hsl.WriteBool("M360", false);
                            ShowLog("超大型吸嘴NG槽位满");
                            FAttention f = new FAttention("超大型吸嘴NG槽位满");
                            f.ShowDialog();
                        }
                        if (hsl.ReadBool("M361", 1)[0])
                        {
                            hsl.WriteBool("M361", false);
                            ShowLog("超大型反光板NG槽位满");
                            FAttention f = new FAttention("超大型反光板NG槽位满");
                            f.ShowDialog();
                        }

                        if (hsl.ReadBool("M370", 1)[0])
                        {
                            hsl.WriteBool("M370", false);
                            ShowLog("小型流通量NG槽位未取走");
                            FAttention f = new FAttention("小型流通量NG槽位未取走");
                            f.ShowDialog();
                        }
                        if (hsl.ReadBool("M371", 1)[0])
                        {
                            hsl.WriteBool("M371", false);
                            ShowLog("小型吸嘴NG槽位未取走");
                            FAttention f = new FAttention("小型吸嘴NG槽位未取走");
                            f.ShowDialog();
                        }
                        if (hsl.ReadBool("M372", 1)[0])
                        {
                            hsl.WriteBool("M372", false);
                            ShowLog("小型反光板NG槽位未取走");
                            FAttention f = new FAttention("小型反光板NG槽位未取走");
                            f.ShowDialog();
                        }
                        if (hsl.ReadBool("M373", 1)[0])
                        {
                            hsl.WriteBool("M373", false);
                            ShowLog("小型破损NG槽位未取走");
                            FAttention f = new FAttention("小型破损NG槽位未取走");
                            f.ShowDialog();
                        }

                        if (hsl.ReadBool("M374", 1)[0])
                        {
                            hsl.WriteBool("M374", false);
                            ShowLog("大型流通量NG槽位未取走");
                            FAttention f = new FAttention("大型流通量NG槽位未取走");
                            f.ShowDialog();
                        }
                        if (hsl.ReadBool("M375", 1)[0])
                        {
                            hsl.WriteBool("M375", false);
                            ShowLog("大型吸嘴NG槽位未取走");
                            FAttention f = new FAttention("大型吸嘴NG槽位未取走");
                            f.ShowDialog();
                        }
                        if (hsl.ReadBool("M376", 1)[0])
                        {
                            hsl.WriteBool("M376", false);
                            ShowLog("大型反光板NG槽位未取走");
                            FAttention f = new FAttention("大型反光板NG槽位未取走");
                            f.ShowDialog();
                        }
                        if (hsl.ReadBool("M377", 1)[0])
                        {
                            hsl.WriteBool("M377", false);
                            ShowLog("大型破损NG槽位未取走");
                            FAttention f = new FAttention("大型破损NG槽位未取走");
                            f.ShowDialog();
                        }
                        if (hsl.ReadBool("M378", 1)[0])
                        {
                            hsl.WriteBool("M378", false);
                            ShowLog("超大型流通量NG工位料未取走");
                            FAttention f = new FAttention("超大型流通量NG工位料未取走");
                            f.ShowDialog();
                        }
                        if (hsl.ReadBool("M379", 1)[0])
                        {
                            hsl.WriteBool("M379", false);
                            ShowLog("超大型吸嘴NG工位料未取走");
                            FAttention f = new FAttention("超大型吸嘴NG工位料未取走");
                            f.ShowDialog();
                        }
                        if (hsl.ReadBool("M380", 1)[0])
                        {
                            hsl.WriteBool("M380", false);
                            ShowLog("超大型反光板NG工位料未取走");
                            FAttention f = new FAttention("超大型反光板NG工位料未取走");
                            f.ShowDialog();
                        }
                        //复位
                        if (hsl.ReadBool("M55", 1)[0])
                        {
                            hsl.WriteBool("M55", false);
                            SoftConfig.lstWorkPiece = new List<WorkPiece>();
                            ShowLog("检测到重新开始", 0);
                        }
                    }
                    catch (Exception)
                    {

                    }

                    try
                    {
                        //解析工位拍照
                        if (CmdNeedAdd.Count > 0)
                        {
                            string strResult = "";
                            if (CmdNeedAdd.TryDequeue(out strResult))
                            {
                                try
                                {
                                    switch (CurrentType)
                                    {
                                        case EWorkPieceType.small:
                                            GetInfoByResultSmall(strResult);
                                            break;
                                        case EWorkPieceType.big:
                                            GetInfoByResultBig(strResult);
                                            break;
                                        case EWorkPieceType.superbig:
                                            GetInfoByResultsuperbig(strResult);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    ShowLog("解析工件数据异常:" + ex.Message, 1);
                                }
                            }
                        }
                        //监听结束上传
                        if (hsl.ReadBool("M35", 1)[0])
                        {
                            hsl.WriteBool("M35", false);
                            ShowLog("开始写CVS日志", 0);
                            ReportLog();
                            //清空
                            SoftConfig.lstWorkPiece = new List<WorkPiece>();
                            if (SoftConfig.lstWorkPiece.Count() > 0)
                            {
                                ShowLog("流程结束清理失败", 1);
                            }
                            else
                            {
                                ShowLog("流程结束清理成功", 0);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowLog("拍照解析|结束监听线程异常:"+ex.Message,1);
                    }
                    
                    Task.Delay(50);

                }
            }, cts.Token);
            //图片生成流程
            Task.Run(() =>
            {
                ShowLog("图片生成流程已开启");
                while (true)
                {
                    if (cts.Token.IsCancellationRequested)
                    {
                        return;
                    }

                    try
                    {
                        //写图片
                        if (CmdImage.Count>0)
                        {
                            ImageModel im = new ImageModel();
                            if (CmdImage.TryDequeue(out im))
                            {
                                if (File.Exists(im.path))
                                {
                                    ShowLog("图片已存在:" + im.path);
                                    continue;
                                }
                                try
                                {
                                    im.img.Save(im.path);
                                    ShowLog("保存图片成功:" + im.path);
                                }
                                catch (Exception ex)
                                {
                                    ShowLog("保存图片异常:" + im.path+" "+ex.Message);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowLog("图片成功线程异常:" + ex.Message, 1);
                    }

                    Task.Delay(50);

                }
            }, cts.Token);
            //20 30视觉触发流程
            Task.Run(() =>
            {
                ShowLog("视觉请求检测流程已开启");
                while (true)
                {
                    if (cts.Token.IsCancellationRequested)
                    {
                        return;
                    }

                    try
                    {
                        //监听3020
                        int iD3020 = hsl.ReadUShort("D3020", 1)[0];
                        //lg.SendCommand(iD3020.ToString(), 0, "monitor");
                        if (iD3020 == 1)
                        {
                            int iIndex = hsl.ReadUShort("D3019", 1)[0];
                            WorkPiece wp = SoftConfig.lstWorkPiece.Where(x => x.Index == iIndex).FirstOrDefault();
                            if (wp == null)
                            {
                                ShowLog("3020触发后未找到对应工件数据,index=" + iIndex.ToString() + " 工件集合:" + GetIndexString(), 1);
                                return;
                            }
                            VmProcedure procedure = VmSolution.Instance[wp.Ocr] as VmProcedure;
                            if (procedure != null)
                            {
                                procedure.Run();
                                ShowLog("触发喷嘴清洗后检测：" + wp.Index.ToString() + " " + wp.Ocr, 0);
                            }
                            else
                            {
                                VmProcedure procedureNull = VmSolution.Instance["OCR"] as VmProcedure;
                                procedureNull.Run();
                                ShowLog("触发喷嘴清洗后默认检测：" + wp.Index.ToString() + " 默认OCR", 0);
                            }
                            Task.Delay(200);
                        }
                        int iD3030 = hsl.ReadUShort("D3030", 1)[0];
                        //lg.SendCommand(iD3030.ToString(), 0, "monitor");
                        //监听3030
                        if (iD3030 == 1)
                        {
                            int iIndex = hsl.ReadUShort("D3019", 1)[0];
                            WorkPiece wp = SoftConfig.lstWorkPiece.Where(x => x.Index == iIndex).FirstOrDefault();
                            if (wp == null)
                            {
                                ShowLog("3030触发后未找到对应工件数据,index=" + iIndex.ToString() + " 工件集合:" + GetIndexString(), 1);
                                return;
                            }
                            VmProcedure procedure = VmSolution.Instance["反光板"] as VmProcedure;
                            if (procedure != null)
                            {
                                procedure.Run();
                                ShowLog("触发反光板清洗后检测：" + wp.Index.ToString() + " " + wp.Ocr, 0);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowLog("2030监听线程异常:" + ex.Message, 1);
                    }

                    Task.Delay(50);

                }
            }, cts.Token);

            #region 
            ////解析工位拍照
            //Task.Run(() =>
            //{
            //    while (true)
            //    {
            //        if (cts.Token.IsCancellationRequested)
            //        {
            //            return;
            //        }
            //        if (CmdNeedAdd.Count > 0)
            //        {
            //            string strResult = "";
            //            if (CmdNeedAdd.TryDequeue(out strResult))
            //            {
            //                try
            //                {
            //                    GetInfoByResult(strResult);
            //                }
            //                catch (Exception ex)
            //                {
            //                    ShowLog("解析工件数据异常:"+ex.Message,1);
            //                }
            //            }
            //        }
            //        Task.Delay(10);

            //    }
            //}, cts.Token);
            ////刷新示意图
            //Task.Run(() =>
            //{
            //    while (true)
            //    {
            //        if (cts.Token.IsCancellationRequested)
            //        {
            //            return;
            //        }
            //        if (CmdNeedRefresh.Count > 0)
            //        {
            //            string strResult = "";
            //            if (CmdNeedRefresh.TryDequeue(out strResult))
            //            {
            //                try
            //                {
            //                    RefreshMap();
            //                }
            //                catch (Exception ex)
            //                {
            //                    ShowLog("刷新示意图异常:" + ex.Message+" "+GetIndexString(), 1);
            //                }
            //            }
            //        }
            //        Task.Delay(10);

            //    }
            //}, cts.Token);
            ////监听结束上传
            //Task.Run(() =>
            //{
            //    while (true)
            //    {
            //        if (cts.Token.IsCancellationRequested)
            //        {
            //            return;
            //        }
            //        try
            //        {
            //            if (hsl.ReadBool("M35", 1)[0])
            //            {
            //                hsl.WriteBool("M35", false);
            //                ShowLog("开始写CVS日志", 0);
            //                ReportLog();
            //                //清空
            //                SoftConfig.lstWorkPiece = new List<WorkPiece>();
            //                if (SoftConfig.lstWorkPiece.Count() > 0)
            //                {
            //                    ShowLog("流程结束清理失败", 1);
            //                }
            //            }
            //        }
            //        catch (Exception ex)
            //        {

            //        }
            //        Task.Delay(200);

            //    }
            //}, cts.Token);
            ////监听3020
            //Task.Run(() =>
            //{
            //    while (true)
            //    {
            //        if (cts.Token.IsCancellationRequested)
            //        {
            //            return;
            //        }
            //        try
            //        {
            //            if (hsl.ReadUShort("D3020", 1)[0] == 1)
            //            {
            //                int iIndex = hsl.ReadUShort("D3019", 1)[0];
            //                WorkPiece wp = SoftConfig.lstWorkPiece.Where(x=>x.Index==iIndex).FirstOrDefault();
            //                if (wp == null)
            //                {
            //                    ShowLog("3020触发后未找到对应工件数据,index=" + iIndex.ToString()+" 工件集合:"+GetIndexString(), 1);
            //                    return;
            //                }
            //                VmProcedure procedure = VmSolution.Instance[wp.Ocr] as VmProcedure;
            //                if (procedure != null)
            //                {
            //                    procedure.Run();
            //                    ShowLog("触发喷嘴清洗后检测：" + wp.Index.ToString() + " " + wp.Ocr, 0);
            //                }
            //                else
            //                {
            //                    VmProcedure procedureNull = VmSolution.Instance["OCR"] as VmProcedure;
            //                    procedureNull.Run();
            //                    ShowLog("触发喷嘴清洗后默认检测：" + wp.Index.ToString() + " 默认OCR", 0);
            //                }
            //                Task.Delay(200);
            //            }
            //        }
            //        catch (Exception ex)
            //        {

            //        }

            //        Task.Delay(200);
            //    }
            //}, cts.Token);
            ////监听3030
            //Task.Run(() =>
            //{
            //    while (true)
            //    {
            //        if (cts.Token.IsCancellationRequested)
            //        {
            //            return;
            //        }
            //        try
            //        {
            //            if (hsl.ReadUShort("D3030", 1)[0] == 1)
            //            {
            //                int iIndex = hsl.ReadUShort("D3019", 1)[0];
            //                WorkPiece wp = SoftConfig.lstWorkPiece.Where(x=>x.Index==iIndex).FirstOrDefault();
            //                if (wp == null)
            //                {
            //                    ShowLog("3030触发后未找到对应工件数据,index=" + iIndex.ToString()+" 工件集合:"+GetIndexString(), 1);
            //                    return;
            //                }
            //                VmProcedure procedure = VmSolution.Instance["反光板"] as VmProcedure;
            //                if (procedure != null)
            //                {
            //                    procedure.Run();
            //                    ShowLog("触发反光板清洗后检测：" + wp.Index.ToString() + " " + wp.Ocr, 0);
            //                }
            //                Task.Delay(200);
            //            }
            //        }
            //        catch (Exception)
            //        {

            //        }

            //        Task.Delay(200);
            //    }
            //}, cts.Token);
            ////监听NG槽位满
            //Task.Run(() =>
            //{
            //    while (true)
            //    {
            //        if (cts.Token.IsCancellationRequested)
            //        {
            //            return;
            //        }
            //        try
            //        {
            //            if (hsl.ReadBool("M351", 1)[0])
            //            {
            //                hsl.WriteBool("M351", false);
            //                ShowLog("通透检测NG槽位满");
            //                FAttention f = new FAttention("通透检测NG槽位满");
            //                f.ShowDialog();
            //            }
            //            if (hsl.ReadBool("M352", 1)[0])
            //            {
            //                hsl.WriteBool("M352", false);
            //                ShowLog("通透检测NG槽位满");
            //                FAttention f = new FAttention("吸嘴堵塞NG槽位满");
            //                f.ShowDialog();
            //            }
            //            if (hsl.ReadBool("M353", 1)[0])
            //            {
            //                hsl.WriteBool("M353", false);
            //                ShowLog("通透检测NG槽位满");
            //                FAttention f = new FAttention("反光板NG槽位满");
            //                f.ShowDialog();
            //            }
            //            if (hsl.ReadBool("M354", 1)[0])
            //            {
            //                hsl.WriteBool("M354", false);
            //                ShowLog("通透检测NG槽位满");
            //                FAttention f = new FAttention("吸嘴反光板破损NG槽位满");
            //                f.ShowDialog();
            //            }
            //        }
            //        catch (Exception)
            //        {

            //        }

            //        Task.Delay(200);
            //    }
            //}, cts.Token);
            #endregion
        }

        /// <summary>
        /// 生成示意图
        /// </summary>
        /// <param name="e"></param>
        public void GenMap(EWorkPieceType e)
        {
            Invoke(new Action(() => {
                pMap.Controls.Clear();
                //获取panel尺寸
                int iWidth = pMap.Width;
                int iHeight = pMap.Height;
                int BoxWidth = 0;
                int BoxHeight = 0;
                int iIndex = 0;
                switch (e)
                {
                    //4列8行
                    case EWorkPieceType.small:
                        BoxWidth = iWidth / 4 - 5;
                        BoxHeight = iHeight / 8 - 5;
                        iIndex = 1;
                        for (int i = 0; i < 4; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                UILight l = new UILight();
                                l.Width = BoxWidth;
                                l.Height = BoxHeight;
                                l.Location = new Point(i * BoxWidth + BoxWidth / 5, j * BoxHeight + BoxHeight / 4);
                                l.Name = "light" + iIndex.ToString();
                                l.State = UILightState.Off;
                                l.OffColor = Color.FromArgb(140, 140, 140);
                                pMap.Controls.Add(l);
                                iIndex++;
                            }
                        }

                        break;
                    //4列4行
                    case EWorkPieceType.big:
                        BoxWidth = iWidth / 4 - 5;
                        BoxHeight = iHeight / 4 - 5;
                        iIndex = 1;
                        for (int i = 0; i < 4; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                UILight l = new UILight();
                                l.Width = BoxWidth;
                                l.Height = BoxHeight;
                                l.Location = new Point(i * BoxWidth -2 + BoxWidth / 5, j * BoxHeight + BoxHeight / 4);
                                l.Name = "light" + iIndex.ToString();
                                l.State = UILightState.Off;
                                l.OffColor = Color.FromArgb(140, 140, 140);
                                pMap.Controls.Add(l);
                                iIndex++;
                            }
                        }
                        break;
                    //2行3列
                    case EWorkPieceType.superbig:
                        BoxWidth = iWidth / 2 - 5;
                        BoxHeight = iHeight / 3 - 5;
                        iIndex = 1;
                        for (int i = 0; i < 2; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                UILight l = new UILight();
                                l.Width = BoxWidth;
                                l.Height = BoxHeight;
                                l.Location = new Point(i * BoxWidth - 2 + BoxWidth / 5, j * BoxHeight + BoxHeight / 4);
                                l.Name = "light" + iIndex.ToString();
                                l.State = UILightState.Off;
                                l.OffColor = Color.FromArgb(140, 140, 140);
                                pMap.Controls.Add(l);
                                iIndex++;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }));
        }
        /// <summary>
        /// 刷新示意图
        /// </summary>
        public void RefreshMap()
        {
            //记录队列
            //lg.SendCommand(JsonConvert.SerializeObject(SoftConfig.lstWorkPiece),0,"map");

            Invoke(new Action(()=> {
                foreach (Control item in pMap.Controls)
                {
                    //获取序号
                    int iIndex = int.Parse(item.Name.Substring(5, item.Name.Length - 5));
                    WorkPiece wp = SoftConfig.lstWorkPiece.Where(x => x.Index == iIndex).FirstOrDefault();
                    if (wp==null)
                    {
                        //ShowLog("刷新示意图时未找到工件数据:"+ iIndex.ToString() + " 工件集合:" + GetIndexString(), 1);
                        continue;
                    }
                    UILight light = (UILight)item;
                    //根据状态修改颜色 
                    //140, 140, 140
                    //128, 128, 255
                    //110, 190, 40
                    //Red
                    if (!wp.IsExist)//不存在
                    {
                        light.OffColor = Color.FromArgb(140, 140, 140);
                    }
                    else
                    {
                        if (wp.MouseResult == "" || wp.ReflectBoardResult == ""|| wp.FlowResult == "")//还未有结果
                        {
                            light.OffColor = Color.FromArgb(128, 128, 255);
                        }
                        else
                        {
                            if (wp.MouseResult == "NG" || wp.ReflectBoardResult == "NG" || wp.FlowResult == "NG")
                            {
                                light.OffColor = Color.Red;
                            }
                            else
                            {
                                light.OffColor = Color.FromArgb(110, 190, 40);
                            }
                            //if (wp.MouseResult == "OK" && wp.ReflectBoardResult == "OK"&&wp.FlowResult=="OK")
                            //{
                            //    light.OffColor = Color.FromArgb(110, 190, 40);
                            //}
                            //else
                            //{
                            //    light.OffColor = Color.Red;
                            //}
                        }
                    }
                }
            }));
        }

        public string GetIndexString()
        {
            string strResult = "";
            for (int i = 0; i < SoftConfig.lstWorkPiece.Count(); i++)
            {
                strResult += SoftConfig.lstWorkPiece[i].Index.ToString()+"|";
            }
            strResult = strResult.TrimEnd('|');
            return strResult;
        }

        /// <summary>
        /// 回调函数
        /// </summary>
        /// <param name="workStatusInfo"></param>
        private void VmSolution_OnWorkStatusEvent(VM.PlatformSDKCS.ImvsSdkDefine.IMVS_MODULE_WORK_STAUS workStatusInfo)
        {
            try
            {
                string ProcessID = workStatusInfo.nProcessID.ToString();
                var vProcess = SoftConfig.lstProcess.Where(x => x.ProcessID == ProcessID).ToList();
                if (vProcess==null||vProcess.Count<=0)
                {
                    ShowLog("未知视觉流程请注意添加:"+ ProcessID, 1);
                    return;
                }
                else
                {
                    if (workStatusInfo.nWorkStatus == 1)
                    {
                        switch (vProcess[0].Type)
                        {
                            case "反光板清洗前":
                                Task.Run(() => {
                                    Thread.Sleep(1000);
                                    Invoke(new Action(() => {
                                        VmProcedure vp = GetProcessByID(workStatusInfo.nProcessID);
                                        vmRenderControl1.ModuleSource = vp;
                                    }));
                                });
                                break;
                            case "反光板清洗后":
                                Task.Run(() => {
                                    Thread.Sleep(1000);
                                    Invoke(new Action(() => {
                                        VmProcedure vp = GetProcessByID(workStatusInfo.nProcessID);
                                        vmRenderControl1.ModuleSource = vp;
                                    }));
                                });
                                break;
                            default:
                                Invoke(new Action(() => {
                                    VmProcedure vp = GetProcessByID(workStatusInfo.nProcessID);
                                    vmRenderControl1.ModuleSource = vp;
                                }));
                                break;
                        }
                    }
                    else if (workStatusInfo.nWorkStatus == 0)
                    {
                        List<VmDynamicIODefine.IoNameInfo> ioNameInfos;
                        int iIndex = -1;
                        WorkPiece wp;
                        int iWorkPieceIndex = -1;

                        switch (vProcess[0].Type)
                        {
                            case "小型":
                                CurrentType = EWorkPieceType.small;
                                ioNameInfos = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetAllOutputNameInfo();
                                if (ioNameInfos.Count != 0)//判断流程结果个数是否为0
                                {
                                    if (ioNameInfos[0].TypeName == IMVS_MODULE_BASE_DATA_TYPE.IMVS_GRAP_TYPE_STRING)//判断流程第一个结果是否为字符串类型
                                    {
                                        //获取流程结果
                                        string strResult = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetOutputString(ioNameInfos[0].Name).astStringVal[0].strValue;
                                        if (strResult != null)
                                        {
                                            ShowLog("小型工位拍照获取结果:" + strResult, 0);
                                            //解析输出
                                            CmdNeedAdd.Enqueue(strResult);
                                            Invoke(new Action(() => {
                                                btnType.Text = "小型";
                                            }));
                                        }
                                        else
                                        {
                                            ShowLog("小型工位拍照获取结果失败：结果为空!", 1);
                                        }
                                    }
                                }
                                break;
                            case "大型":
                                CurrentType = EWorkPieceType.big;
                                ioNameInfos = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetAllOutputNameInfo();
                                if (ioNameInfos.Count != 0)//判断流程结果个数是否为0
                                {
                                    if (ioNameInfos[0].TypeName == IMVS_MODULE_BASE_DATA_TYPE.IMVS_GRAP_TYPE_STRING)//判断流程第一个结果是否为字符串类型
                                    {
                                        //获取流程结果
                                        string strResult = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetOutputString(ioNameInfos[0].Name).astStringVal[0].strValue;
                                        if (strResult != null)
                                        {
                                            ShowLog("大型工位拍照获取结果:" + strResult, 0);
                                            //解析输出
                                            CmdNeedAdd.Enqueue(strResult);
                                            Invoke(new Action(() => {
                                                btnType.Text = "大型";
                                            }));
                                        }
                                        else
                                        {
                                            ShowLog("大型工位拍照获取结果失败：结果为空!", 1);
                                            //strMessage = "获取结果失败：结果为空!";
                                        }
                                    }
                                }
                                break;
                            case "超大型":
                                CurrentType = EWorkPieceType.superbig;
                                ioNameInfos = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetAllOutputNameInfo();
                                if (ioNameInfos.Count != 0)//判断流程结果个数是否为0
                                {
                                    if (ioNameInfos[0].TypeName == IMVS_MODULE_BASE_DATA_TYPE.IMVS_GRAP_TYPE_STRING)//判断流程第一个结果是否为字符串类型
                                    {
                                        //获取流程结果
                                        string strResult = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetOutputString(ioNameInfos[0].Name).astStringVal[0].strValue;
                                        if (strResult != null)
                                        {
                                            ShowLog("超大型工位拍照获取结果:" + strResult, 0);
                                            //解析输出
                                            CmdNeedAdd.Enqueue(strResult);
                                            Invoke(new Action(() =>
                                            {
                                                btnType.Text = "超大型";
                                            }));
                                        }
                                        else
                                        {
                                            ShowLog("大型工位拍照获取结果失败：结果为空!", 1);
                                            //strMessage = "获取结果失败：结果为空!";
                                        }
                                    }
                                }
                                break;
                            case "吸嘴清洗前":
                                ShowLog("收到吸嘴清洗前回调");
                                iIndex = hsl.ReadUShort("D3019", 1)[0];
                                wp = SoftConfig.lstWorkPiece.Where(x => x.Index == iIndex).FirstOrDefault();
                                if (wp == null)
                                {
                                    ShowLog("吸嘴清洗前未找到对应工件数据,index=" + iIndex.ToString() + " 工件集合:" + GetIndexString(), 1);
                                    return;
                                }
                                Task.Run(() => {
                                    Invoke(new Action(() => {
                                        ImageSourceModuleTool tool = (ImageSourceModuleTool)VmSolution.Instance[vProcess[0].ProcessName+".图像源1"];
                                        ImageBaseData pic = tool.ModuResult.ImageData;
                                        Image img = ImageBaseDataToBitmap(pic);
                                        wp.MouseBefore = SoftConfig.ImagePath + "\\" + IndexOfTask + "_" + iIndex.ToString() + "_" + wp.BarCode + "_" + wp.Ocr + "_1.jpg";
                                        SaveImage(img, wp.MouseBefore);
                                    }));
                                });
                                break;
                            case "吸嘴清洗后":
                                iIndex = hsl.ReadUShort("D3019", 1)[0];
                                wp = SoftConfig.lstWorkPiece.Where(x => x.Index == iIndex).FirstOrDefault();
                                if (wp == null)
                                {
                                    ShowLog("吸嘴清洗后 "+ vProcess[0].ProcessName + " 未找到对应工件数据,index=" + iIndex.ToString() + " 工件集合:" + GetIndexString(), 1);
                                    return;
                                }
                                iWorkPieceIndex = GetWorkPieceIndexByIndex(iIndex);
                                ioNameInfos = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetAllOutputNameInfo();
                                if (ioNameInfos.Count != 0)//判断流程结果个数是否为0
                                {
                                    if (ioNameInfos[0].TypeName == IMVS_MODULE_BASE_DATA_TYPE.IMVS_GRAP_TYPE_STRING)//判断流程第一个结果是否为字符串类型
                                    {

                                        Task.Run(() => {
                                            Invoke(new Action(() => {
                                                ImageSourceModuleTool tool = (ImageSourceModuleTool)VmSolution.Instance[vProcess[0].ProcessName+".图像源1"];
                                                ImageBaseData pic = tool.ModuResult.ImageData;
                                                Image img = ImageBaseDataToBitmap(pic);
                                                wp.MouseAfter = SoftConfig.ImagePath + "\\" + IndexOfTask + "_" + iIndex.ToString() + "_" + wp.BarCode + "_" + wp.Ocr + "_3.jpg";
                                                SaveImage(img, wp.MouseAfter);

                                            }));
                                        });

                                        //获取流程结果
                                        string strResult = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetOutputString(ioNameInfos[0].Name).astStringVal[0].strValue;
                                        if (strResult != null)
                                        {
                                            //实时显示结果
                                            Invoke(new Action(() => {
                                                MouseResult.Text = strResult == "OK" ? "OK" : "NG";
                                                MouseResult.ForeColor = strResult == "OK" ? Color.Chartreuse : Color.Red;
                                            }));
                                            ShowLog(workStatusInfo.nProcessID.ToString() + "获取喷嘴检测结果:" + strResult, 0);
                                            SoftConfig.lstWorkPiece[iWorkPieceIndex].MouseResult = strResult;
                                        }
                                        else
                                        {
                                            ShowLog(workStatusInfo.nProcessID.ToString() + "获取喷嘴检测结果失败：结果为空!", 1);
                                            //strMessage = "获取结果失败：结果为空!";
                                        }
                                    }
                                }
                                break;
                            case "反光板清洗前":
                                ShowLog("收到反光板清洗前回调");
                                iIndex = hsl.ReadUShort("D3019", 1)[0];
                                wp = SoftConfig.lstWorkPiece.Where(x => x.Index == iIndex).FirstOrDefault();
                                if (wp == null)
                                {
                                    ShowLog("反光板清洗前未找到对应工件数据,index=" + iIndex.ToString() + " 工件集合:" + GetIndexString(), 1);
                                    return;
                                }
                                Task.Run(() =>
                                {
                                    Invoke(new Action(() =>
                                    {
                                        ImageSourceModuleTool tool = (ImageSourceModuleTool)VmSolution.Instance[vProcess[0].ProcessName+".图像源1"];
                                        ImageBaseData pic = tool.ModuResult.ImageData;
                                        Image img = ImageBaseDataToBitmap(pic);
                                        wp.BoardBefore = SoftConfig.ImagePath + "\\" + IndexOfTask + "_" + iIndex.ToString() + "_" + wp.BarCode + "_" + wp.Ocr + "_2.jpg";
                                        SaveImage(img,  wp.BoardBefore);
                                    }));
                                });
                                break;
                            case "反光板清洗后":
                                iIndex = hsl.ReadUShort("D3019", 1)[0];
                                wp = SoftConfig.lstWorkPiece.Where(x => x.Index == iIndex).FirstOrDefault();
                                if (wp == null)
                                {
                                    ShowLog("反光板清洗后未找到对应工件数据,index=" + iIndex.ToString() + " 工件集合:" + GetIndexString(), 1);
                                    return;
                                }
                                iWorkPieceIndex = GetWorkPieceIndexByIndex(iIndex);
                                ioNameInfos = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetAllOutputNameInfo();
                                if (ioNameInfos.Count != 0)//判断流程结果个数是否为0
                                {
                                    if (ioNameInfos[0].TypeName == IMVS_MODULE_BASE_DATA_TYPE.IMVS_GRAP_TYPE_STRING)//判断流程第一个结果是否为字符串类型
                                    {

                                        Task.Run(() =>
                                        {
                                            try
                                            {
                                                int FlowCountStr = 0;
                                                string FlowResultStr = "";
                                                //获取流量信息
                                                if (CurrentType == EWorkPieceType.superbig)
                                                {
                                                    FlowCountStr = hsl.ReadUShort("D5024", 1)[0];
                                                    //FlowResultStr = hsl.ReadUShort("D5012",1)[0];
                                                }
                                                else
                                                {
                                                    FlowCountStr = hsl.ReadUShort("D5022", 1)[0];
                                                    //FlowResultStr = hsl.ReadUShort("D5002", 1)[0];
                                                }
                                                ShowLog("获取到流量值：" + FlowCountStr.ToString());

                                                //记录流量结果
                                                var vValue = SoftConfig.lstFlow.Where(x => x.Ocr == SoftConfig.lstWorkPiece[iWorkPieceIndex].Ocr).SingleOrDefault();
                                                int iThresholdValue = vValue == null ? 2000 : (int)vValue.Value;
                                                ShowLog("获取到流量阈值：" + iThresholdValue.ToString());
                                                FlowResultStr = FlowCountStr > iThresholdValue ? "OK" : "NG";
                                                SoftConfig.lstWorkPiece[iWorkPieceIndex].FlowResult = FlowResultStr;
                                                SoftConfig.lstWorkPiece[iWorkPieceIndex].FlowCount = FlowCountStr;
                                                //流量结果给plc
                                                hsl.WriteUshort("D5002", FlowCountStr > iThresholdValue ? (ushort)1 : (ushort)2);
                                                Invoke(new Action(() =>
                                                {
                                                    ImageSourceModuleTool tool = (ImageSourceModuleTool)VmSolution.Instance[vProcess[0].ProcessName+".图像源1"];
                                                    ImageBaseData pic = tool.ModuResult.ImageData;
                                                    Image img = ImageBaseDataToBitmap(pic);
                                                    wp.BoardAfter = SoftConfig.ImagePath + "\\" + IndexOfTask + "_" + iIndex.ToString() + "_" + wp.BarCode + "_" + wp.Ocr + "_4.jpg";
                                                    SaveImage(img,  wp.BoardAfter);

                                                    FlowResult.Text = FlowResultStr;
                                                    FlowResult.ForeColor = FlowResultStr == "OK" ? Color.Chartreuse : Color.Red;
                                                    FlowCount.Text = FlowCountStr.ToString() + " ml/min";
                                                }));
                                                //多一次刷新
                                                CmdNeedRefresh.Enqueue("refresh");
                                            }
                                            catch (Exception ex)
                                            {
                                                ShowLog("获取流量异常：" + ex.Message, 1);
                                            }

                                        });

                                        //获取流程结果
                                        string strResult = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetOutputString(ioNameInfos[0].Name).astStringVal[0].strValue;
                                        if (strResult != null)
                                        {
                                            //实时显示结果
                                            Invoke(new Action(() => {
                                                BoardResult.Text = strResult == "OK" ? "OK" : "NG";
                                                BoardResult.ForeColor = strResult == "OK" ? Color.Chartreuse : Color.Red;
                                            }));
                                            ShowLog("10007获取反光板检测结果:" + strResult, 0);
                                            SoftConfig.lstWorkPiece[iWorkPieceIndex].ReflectBoardResult = strResult;

                                        }
                                        else
                                        {
                                            ShowLog("10007获取反光板结果失败：结果为空!", 1);
                                            //strMessage = "获取结果失败：结果为空!";
                                        }
                                    }
                                }
                                break;
                            default:
                                ShowLog("未知视觉类型请确认",1);
                                break;
                        }
                    }
                }


            }
            catch (VmException ex)
            {
                ShowLog("获取结果失败，错误码：0x" + Convert.ToString(ex.errorCode, 16), 1);
            }
            catch (Exception ex)
            {
                ShowLog("获取结果失败：" + Convert.ToString(ex.Message), 1);
            }

            #region 注释不用
            //try
            //{
            //    if (workStatusInfo.nWorkStatus == 1)
            //    {
            //        if (workStatusInfo.nProcessID==10006|| workStatusInfo.nProcessID == 10007)
            //        {
            //            Task.Run(()=> {
            //                Thread.Sleep(1000);
            //                Invoke(new Action(() => {
            //                    VmProcedure vp = GetProcessByID(workStatusInfo.nProcessID);
            //                    vmRenderControl1.ModuleSource = vp;
            //                }));
            //            });
            //        }
            //        else
            //        {
            //            Invoke(new Action(() => {
            //                VmProcedure vp = GetProcessByID(workStatusInfo.nProcessID);
            //                vmRenderControl1.ModuleSource = vp;
            //            }));
            //        }
            //    }
            //    else if(workStatusInfo.nWorkStatus == 0)
            //    {
            //        switch (workStatusInfo.nProcessID)
            //        {
            //            case 10003:
            //                //小型工位拍照
            //                if (workStatusInfo.nWorkStatus == 0)//为了折叠
            //                {
            //                    CurrentType = EWorkPieceType.small;
            //                    List<VmDynamicIODefine.IoNameInfo> ioNameInfos = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetAllOutputNameInfo();
            //                    if (ioNameInfos.Count != 0)//判断流程结果个数是否为0
            //                    {
            //                        if (ioNameInfos[0].TypeName == IMVS_MODULE_BASE_DATA_TYPE.IMVS_GRAP_TYPE_STRING)//判断流程第一个结果是否为字符串类型
            //                        {
            //                            //获取流程结果
            //                            string strResult = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetOutputString(ioNameInfos[0].Name).astStringVal[0].strValue;
            //                            if (strResult != null)
            //                            {
            //                                ShowLog("10003小型工位拍照获取结果:" + strResult, 0);
            //                                //解析输出
            //                                CmdNeedAdd.Enqueue(strResult);
            //                                Invoke(new Action(()=> {
            //                                    btnType.Text = "小型";
            //                                }));
            //                            }
            //                            else
            //                            {
            //                                ShowLog("10003小型工位拍照获取结果失败：结果为空!", 1);
            //                            }
            //                        }
            //                    }
            //                    else
            //                    {
            //                        //strMessage = "获取结果失败：流程结果个数为0!";
            //                    }
            //                }
            //                break;
            //            case 10004:
            //                //大型工位拍照
            //                if (workStatusInfo.nWorkStatus == 0)//流程空闲且为流程
            //                {
            //                    CurrentType = EWorkPieceType.big;
            //                    List<VmDynamicIODefine.IoNameInfo> ioNameInfos = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetAllOutputNameInfo();
            //                    if (ioNameInfos.Count != 0)//判断流程结果个数是否为0
            //                    {
            //                        if (ioNameInfos[0].TypeName == IMVS_MODULE_BASE_DATA_TYPE.IMVS_GRAP_TYPE_STRING)//判断流程第一个结果是否为字符串类型
            //                        {
            //                            //获取流程结果
            //                            string strResult = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetOutputString(ioNameInfos[0].Name).astStringVal[0].strValue;
            //                            if (strResult != null)
            //                            {
            //                                ShowLog("10004大型工位拍照获取结果:" + strResult, 0);
            //                                //解析输出
            //                                CmdNeedAdd.Enqueue(strResult);
            //                                Invoke(new Action(() => {
            //                                    btnType.Text = "大型";
            //                                }));
            //                            }
            //                            else
            //                            {
            //                                ShowLog("10004大型工位拍照获取结果失败：结果为空!", 1);
            //                                //strMessage = "获取结果失败：结果为空!";
            //                            }
            //                        }
            //                    }
            //                    else
            //                    {
            //                        //strMessage = "获取结果失败：流程结果个数为0!";
            //                    }
            //                }
            //                break;
            //            case 10005:
            //                //超大型工位拍照
            //                if (workStatusInfo.nWorkStatus == 0)//流程空闲且为流程
            //                {
            //                    CurrentType = EWorkPieceType.superbig;
            //                    List<VmDynamicIODefine.IoNameInfo> ioNameInfos = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetAllOutputNameInfo();
            //                    if (ioNameInfos.Count != 0)//判断流程结果个数是否为0
            //                    {
            //                        if (ioNameInfos[0].TypeName == IMVS_MODULE_BASE_DATA_TYPE.IMVS_GRAP_TYPE_STRING)//判断流程第一个结果是否为字符串类型
            //                        {
            //                            //获取流程结果
            //                            string strResult = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetOutputString(ioNameInfos[0].Name).astStringVal[0].strValue;
            //                            if (strResult != null)
            //                            {
            //                                ShowLog("10005超大型工位拍照获取结果:" + strResult, 0);
            //                                //解析输出
            //                                CmdNeedAdd.Enqueue(strResult);
            //                                Invoke(new Action(() => {
            //                                    btnType.Text = "超大型";
            //                                }));
            //                            }
            //                            else
            //                            {
            //                                ShowLog("10005超大型工位拍照获取结果失败：结果为空!", 1);
            //                                //strMessage = "获取结果失败：结果为空!";
            //                            }
            //                        }
            //                    }
            //                    else
            //                    {
            //                        //strMessage = "获取结果失败：流程结果个数为0!";
            //                    }
            //                }
            //                break;

            //            case 10008:
            //                //喷嘴清洗前
            //                if (workStatusInfo.nWorkStatus == 0)
            //                {
            //                    ShowLog("收到喷嘴清洗前回调");
            //                    int iIndex = hsl.ReadUShort("D3019", 1)[0];
            //                    WorkPiece wp = SoftConfig.lstWorkPiece.Where(x=>x.Index==iIndex).FirstOrDefault();
            //                    if (wp == null)
            //                    {
            //                        ShowLog("喷嘴清洗前未找到对应工件数据,index=" + iIndex.ToString() + " 工件集合:" + GetIndexString(), 1);
            //                        return;
            //                    }
            //                    Task.Run(() => {
            //                        Invoke(new Action(() => {
            //                            ImageSourceModuleTool tool = (ImageSourceModuleTool)VmSolution.Instance["吸嘴前.图像源1"];
            //                            ImageBaseData pic = tool.ModuResult.ImageData;
            //                            Image img = ImageBaseDataToBitmap(pic);
            //                            wp.MouseBefore = IndexOfTask + "_" + iIndex.ToString() + "_" + wp.BarCode + "_" + wp.Ocr + "_1.jpg";
            //                            SaveImage(img,SoftConfig.ImagePath + "\\" + wp.MouseBefore);
            //                        }));
            //                    });
            //                }
            //                break;

            //            case 10020:
            //                //喷嘴检测结果235CN
            //                if (workStatusInfo.nWorkStatus == 0)
            //                {
            //                    int iIndex = hsl.ReadUShort("D3019", 1)[0];
            //                    WorkPiece wp = SoftConfig.lstWorkPiece.Where(x=>x.Index==iIndex).FirstOrDefault();
            //                    if (wp == null)
            //                    {
            //                        ShowLog("喷嘴清洗后235CN未找到对应工件数据,index=" + iIndex.ToString() + " 工件集合:" + GetIndexString(), 1);
            //                        return;
            //                    }
            //                    int iWorkPieceIndex = GetWorkPieceIndexByIndex(iIndex);
            //                    List<VmDynamicIODefine.IoNameInfo> ioNameInfos = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetAllOutputNameInfo();
            //                    if (ioNameInfos.Count != 0)//判断流程结果个数是否为0
            //                    {
            //                        if (ioNameInfos[0].TypeName == IMVS_MODULE_BASE_DATA_TYPE.IMVS_GRAP_TYPE_STRING)//判断流程第一个结果是否为字符串类型
            //                        {

            //                            Task.Run(() => {
            //                                Invoke(new Action(() => {
            //                                    ImageSourceModuleTool tool = (ImageSourceModuleTool)VmSolution.Instance["235CN.图像源1"];
            //                                    ImageBaseData pic = tool.ModuResult.ImageData;
            //                                    Image img = ImageBaseDataToBitmap(pic);
            //                                    wp.MouseAfter = IndexOfTask + "_" + iIndex.ToString() + "_" + wp.BarCode + "_" + wp.Ocr + "_3.jpg";
            //                                    SaveImage(img,SoftConfig.ImagePath + "\\" + wp.MouseAfter);

            //                                }));
            //                            });

            //                            //获取流程结果
            //                            string strResult = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetOutputString(ioNameInfos[0].Name).astStringVal[0].strValue;
            //                            if (strResult != null)
            //                            {
            //                                //实时显示结果
            //                                Invoke(new Action(() => {
            //                                    MouseResult.Text = strResult == "OK" ? "OK" : "NG";
            //                                    MouseResult.ForeColor = strResult == "OK" ? Color.Chartreuse : Color.Red;
            //                                }));
            //                                ShowLog("10020获取喷嘴检测结果:" + strResult, 0);
            //                                SoftConfig.lstWorkPiece[iWorkPieceIndex].MouseResult = strResult;
            //                            }
            //                            else
            //                            {
            //                                ShowLog("10020获取喷嘴检测结果失败：结果为空!", 1);
            //                                //strMessage = "获取结果失败：结果为空!";
            //                            }
            //                        }
            //                    }

            //                }
            //                break;
            //            case 10019:
            //                //喷嘴检测结果230CN
            //                if (workStatusInfo.nWorkStatus == 0)
            //                {
            //                    int iIndex = hsl.ReadUShort("D3019", 1)[0];
            //                    WorkPiece wp = SoftConfig.lstWorkPiece.Where(x=>x.Index==iIndex).FirstOrDefault();
            //                    if (wp == null)
            //                    {
            //                        ShowLog("喷嘴清洗后230CN未找到对应工件数据,index=" + iIndex.ToString() + " 工件集合:" + GetIndexString(), 1);
            //                        return;
            //                    }
            //                    int iWorkPieceIndex = GetWorkPieceIndexByIndex(iIndex);
            //                    List<VmDynamicIODefine.IoNameInfo> ioNameInfos = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetAllOutputNameInfo();
            //                    if (ioNameInfos.Count != 0)//判断流程结果个数是否为0
            //                    {
            //                        if (ioNameInfos[0].TypeName == IMVS_MODULE_BASE_DATA_TYPE.IMVS_GRAP_TYPE_STRING)//判断流程第一个结果是否为字符串类型
            //                        {

            //                            Task.Run(() => {
            //                                Invoke(new Action(() => {
            //                                    ImageSourceModuleTool tool = (ImageSourceModuleTool)VmSolution.Instance["230CN.图像源1"];
            //                                    ImageBaseData pic = tool.ModuResult.ImageData;
            //                                    Image img = ImageBaseDataToBitmap(pic);
            //                                    wp.MouseAfter = IndexOfTask + "_" + iIndex.ToString() + "_" + wp.BarCode + "_" + wp.Ocr + "_3.jpg";
            //                                    SaveImage(img,SoftConfig.ImagePath + "\\" + wp.MouseAfter);

            //                                }));
            //                            });

            //                            //获取流程结果
            //                            string strResult = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetOutputString(ioNameInfos[0].Name).astStringVal[0].strValue;
            //                            if (strResult != null)
            //                            {
            //                                //实时显示结果
            //                                Invoke(new Action(() => {
            //                                    MouseResult.Text = strResult == "OK" ? "OK" : "NG";
            //                                    MouseResult.ForeColor = strResult == "OK" ? Color.Chartreuse : Color.Red;
            //                                }));
            //                                ShowLog("10019获取喷嘴检测结果:" + strResult, 0);
            //                                SoftConfig.lstWorkPiece[iWorkPieceIndex].MouseResult = strResult;
            //                            }
            //                            else
            //                            {
            //                                ShowLog("10019获取喷嘴检测结果失败：结果为空!", 1);
            //                                //strMessage = "获取结果失败：结果为空!";
            //                            }
            //                        }
            //                    }

            //                }
            //                break;
            //            case 10028:
            //                //喷嘴检测结果240CN
            //                if (workStatusInfo.nWorkStatus == 0)
            //                {
            //                    int iIndex = hsl.ReadUShort("D3019", 1)[0];
            //                    WorkPiece wp = SoftConfig.lstWorkPiece.Where(x=>x.Index==iIndex).FirstOrDefault();
            //                    if (wp == null)
            //                    {
            //                        ShowLog("喷嘴清洗后240CN未找到对应工件数据,index=" + iIndex.ToString() + " 工件集合:" + GetIndexString(), 1);
            //                        return;
            //                    }
            //                    int iWorkPieceIndex = GetWorkPieceIndexByIndex(iIndex);
            //                    List<VmDynamicIODefine.IoNameInfo> ioNameInfos = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetAllOutputNameInfo();
            //                    if (ioNameInfos.Count != 0)//判断流程结果个数是否为0
            //                    {
            //                        if (ioNameInfos[0].TypeName == IMVS_MODULE_BASE_DATA_TYPE.IMVS_GRAP_TYPE_STRING)//判断流程第一个结果是否为字符串类型
            //                        {

            //                            Task.Run(() => {
            //                                Invoke(new Action(() => {
            //                                    ImageSourceModuleTool tool = (ImageSourceModuleTool)VmSolution.Instance["240CN.图像源1"];
            //                                    ImageBaseData pic = tool.ModuResult.ImageData;
            //                                    Image img = ImageBaseDataToBitmap(pic);
            //                                    wp.MouseAfter = IndexOfTask + "_" + iIndex.ToString() + "_" + wp.BarCode + "_" + wp.Ocr + "_3.jpg";
            //                                    SaveImage(img,SoftConfig.ImagePath + "\\" + wp.MouseAfter);

            //                                }));
            //                            });

            //                            //获取流程结果
            //                            string strResult = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetOutputString(ioNameInfos[0].Name).astStringVal[0].strValue;
            //                            if (strResult != null)
            //                            {
            //                                //实时显示结果
            //                                Invoke(new Action(() => {
            //                                    MouseResult.Text = strResult == "OK" ? "OK" : "NG";
            //                                    MouseResult.ForeColor = strResult == "OK" ? Color.Chartreuse : Color.Red;
            //                                }));
            //                                ShowLog("10028获取喷嘴检测结果:" + strResult, 0);
            //                                SoftConfig.lstWorkPiece[iWorkPieceIndex].MouseResult = strResult;
            //                            }
            //                            else
            //                            {
            //                                ShowLog("10028获取喷嘴检测结果失败：结果为空!", 1);
            //                                //strMessage = "获取结果失败：结果为空!";
            //                            }
            //                        }
            //                    }

            //                }
            //                break;
            //            case 10018:
            //                //喷嘴检测结果163N
            //                if (workStatusInfo.nWorkStatus == 0)
            //                {
            //                    int iIndex = hsl.ReadUShort("D3019", 1)[0];
            //                    WorkPiece wp = SoftConfig.lstWorkPiece.Where(x=>x.Index==iIndex).FirstOrDefault();
            //                    if (wp == null)
            //                    {
            //                        ShowLog("喷嘴清洗后163N未找到对应工件数据,index=" + iIndex.ToString() + " 工件集合:" + GetIndexString(), 1);
            //                        return;
            //                    }
            //                    int iWorkPieceIndex = GetWorkPieceIndexByIndex(iIndex);
            //                    List<VmDynamicIODefine.IoNameInfo> ioNameInfos = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetAllOutputNameInfo();
            //                    if (ioNameInfos.Count != 0)//判断流程结果个数是否为0
            //                    {
            //                        if (ioNameInfos[0].TypeName == IMVS_MODULE_BASE_DATA_TYPE.IMVS_GRAP_TYPE_STRING)//判断流程第一个结果是否为字符串类型
            //                        {

            //                            Task.Run(() => {
            //                                Invoke(new Action(() => {
            //                                    ImageSourceModuleTool tool = (ImageSourceModuleTool)VmSolution.Instance["163N.图像源1"];
            //                                    ImageBaseData pic = tool.ModuResult.ImageData;
            //                                    Image img = ImageBaseDataToBitmap(pic);
            //                                    wp.MouseAfter = IndexOfTask + "_" + iIndex.ToString() + "_" + wp.BarCode + "_" + wp.Ocr + "_3.jpg";
            //                                    SaveImage(img,SoftConfig.ImagePath + "\\" + wp.MouseAfter);

            //                                }));
            //                            });

            //                            //获取流程结果
            //                            string strResult = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetOutputString(ioNameInfos[0].Name).astStringVal[0].strValue;
            //                            if (strResult != null)
            //                            {
            //                                //实时显示结果
            //                                Invoke(new Action(() => {
            //                                    MouseResult.Text = strResult == "OK" ? "OK" : "NG";
            //                                    MouseResult.ForeColor = strResult == "OK" ? Color.Chartreuse : Color.Red;
            //                                }));
            //                                ShowLog("10018获取喷嘴检测结果:" + strResult, 0);
            //                                SoftConfig.lstWorkPiece[iWorkPieceIndex].MouseResult = strResult;
            //                            }
            //                            else
            //                            {
            //                                ShowLog("10018获取喷嘴检测结果失败：结果为空!", 1);
            //                                //strMessage = "获取结果失败：结果为空!";
            //                            }
            //                        }
            //                    }

            //                }
            //                break;
            //            case 10021:
            //                //喷嘴检测结果235CSN
            //                if (workStatusInfo.nWorkStatus == 0)
            //                {
            //                    int iIndex = hsl.ReadUShort("D3019", 1)[0];
            //                    WorkPiece wp = SoftConfig.lstWorkPiece.Where(x => x.Index == iIndex).FirstOrDefault();
            //                    if (wp == null)
            //                    {
            //                        ShowLog("喷嘴清洗后235CSN未找到对应工件数据,index=" + iIndex.ToString() + " 工件集合:" + GetIndexString(), 1);
            //                        return;
            //                    }
            //                    int iWorkPieceIndex = GetWorkPieceIndexByIndex(iIndex);
            //                    List<VmDynamicIODefine.IoNameInfo> ioNameInfos = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetAllOutputNameInfo();
            //                    if (ioNameInfos.Count != 0)//判断流程结果个数是否为0
            //                    {
            //                        if (ioNameInfos[0].TypeName == IMVS_MODULE_BASE_DATA_TYPE.IMVS_GRAP_TYPE_STRING)//判断流程第一个结果是否为字符串类型
            //                        {

            //                            Task.Run(() => {
            //                                Invoke(new Action(() => {
            //                                    ImageSourceModuleTool tool = (ImageSourceModuleTool)VmSolution.Instance["235CSN.图像源1"];
            //                                    ImageBaseData pic = tool.ModuResult.ImageData;
            //                                    Image img = ImageBaseDataToBitmap(pic);
            //                                    wp.MouseAfter = IndexOfTask + "_" + iIndex.ToString() + "_" + wp.BarCode + "_" + wp.Ocr + "_3.jpg";
            //                                    SaveImage(img,SoftConfig.ImagePath + "\\" + wp.MouseAfter);

            //                                }));
            //                            });

            //                            //获取流程结果
            //                            string strResult = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetOutputString(ioNameInfos[0].Name).astStringVal[0].strValue;
            //                            if (strResult != null)
            //                            {
            //                                //实时显示结果
            //                                Invoke(new Action(() => {
            //                                    MouseResult.Text = strResult == "OK" ? "OK" : "NG";
            //                                    MouseResult.ForeColor = strResult == "OK" ? Color.Chartreuse : Color.Red;
            //                                }));
            //                                ShowLog(workStatusInfo.nProcessID.ToString() + "获取喷嘴检测结果:" + strResult, 0);
            //                                SoftConfig.lstWorkPiece[iWorkPieceIndex].MouseResult = strResult;
            //                            }
            //                            else
            //                            {
            //                                ShowLog(workStatusInfo.nProcessID.ToString() + "获取喷嘴检测结果失败：结果为空!", 1);
            //                                //strMessage = "获取结果失败：结果为空!";
            //                            }
            //                        }
            //                    }

            //                }
            //                break;
            //            case 10022:
            //                //喷嘴检测结果230CS
            //                if (workStatusInfo.nWorkStatus == 0)
            //                {
            //                    int iIndex = hsl.ReadUShort("D3019", 1)[0];
            //                    WorkPiece wp = SoftConfig.lstWorkPiece.Where(x => x.Index == iIndex).FirstOrDefault();
            //                    if (wp == null)
            //                    {
            //                        ShowLog("喷嘴清洗后230CS未找到对应工件数据,index=" + iIndex.ToString() + " 工件集合:" + GetIndexString(), 1);
            //                        return;
            //                    }
            //                    int iWorkPieceIndex = GetWorkPieceIndexByIndex(iIndex);
            //                    List<VmDynamicIODefine.IoNameInfo> ioNameInfos = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetAllOutputNameInfo();
            //                    if (ioNameInfos.Count != 0)//判断流程结果个数是否为0
            //                    {
            //                        if (ioNameInfos[0].TypeName == IMVS_MODULE_BASE_DATA_TYPE.IMVS_GRAP_TYPE_STRING)//判断流程第一个结果是否为字符串类型
            //                        {

            //                            Task.Run(() => {
            //                                Invoke(new Action(() => {
            //                                    ImageSourceModuleTool tool = (ImageSourceModuleTool)VmSolution.Instance["230CS.图像源1"];
            //                                    ImageBaseData pic = tool.ModuResult.ImageData;
            //                                    Image img = ImageBaseDataToBitmap(pic);
            //                                    wp.MouseAfter = IndexOfTask + "_" + iIndex.ToString() + "_" + wp.BarCode + "_" + wp.Ocr + "_3.jpg";
            //                                    SaveImage(img,SoftConfig.ImagePath + "\\" + wp.MouseAfter);

            //                                }));
            //                            });

            //                            //获取流程结果
            //                            string strResult = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetOutputString(ioNameInfos[0].Name).astStringVal[0].strValue;
            //                            if (strResult != null)
            //                            {
            //                                //实时显示结果
            //                                Invoke(new Action(() => {
            //                                    MouseResult.Text = strResult == "OK" ? "OK" : "NG";
            //                                    MouseResult.ForeColor = strResult == "OK" ? Color.Chartreuse : Color.Red;
            //                                }));
            //                                ShowLog(workStatusInfo.nProcessID.ToString() + "获取喷嘴检测结果:" + strResult, 0);
            //                                SoftConfig.lstWorkPiece[iWorkPieceIndex].MouseResult = strResult;
            //                            }
            //                            else
            //                            {
            //                                ShowLog(workStatusInfo.nProcessID.ToString() + "获取喷嘴检测结果失败：结果为空!", 1);
            //                                //strMessage = "获取结果失败：结果为空!";
            //                            }
            //                        }
            //                    }

            //                }
            //                break;
            //            case 10029:
            //                //喷嘴检测结果161
            //                if (workStatusInfo.nWorkStatus == 0)
            //                {
            //                    int iIndex = hsl.ReadUShort("D3019", 1)[0];
            //                    WorkPiece wp = SoftConfig.lstWorkPiece.Where(x=>x.Index==iIndex).FirstOrDefault();
            //                    if (wp == null)
            //                    {
            //                        ShowLog("喷嘴清洗后161未找到对应工件数据,index=" + iIndex.ToString() + " 工件集合:" + GetIndexString(), 1);
            //                        return;
            //                    }
            //                    int iWorkPieceIndex = GetWorkPieceIndexByIndex(iIndex);
            //                    List<VmDynamicIODefine.IoNameInfo> ioNameInfos = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetAllOutputNameInfo();
            //                    if (ioNameInfos.Count != 0)//判断流程结果个数是否为0
            //                    {
            //                        if (ioNameInfos[0].TypeName == IMVS_MODULE_BASE_DATA_TYPE.IMVS_GRAP_TYPE_STRING)//判断流程第一个结果是否为字符串类型
            //                        {

            //                            Task.Run(() => {
            //                                Invoke(new Action(() => {
            //                                    ImageSourceModuleTool tool = (ImageSourceModuleTool)VmSolution.Instance["161.图像源1"];
            //                                    ImageBaseData pic = tool.ModuResult.ImageData;
            //                                    Image img = ImageBaseDataToBitmap(pic);
            //                                    wp.MouseAfter = IndexOfTask + "_" + iIndex.ToString() + "_" + wp.BarCode + "_" + wp.Ocr + "_3.jpg";
            //                                    SaveImage(img,SoftConfig.ImagePath + "\\" + wp.MouseAfter);

            //                                }));
            //                            });

            //                            //获取流程结果
            //                            string strResult = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetOutputString(ioNameInfos[0].Name).astStringVal[0].strValue;
            //                            if (strResult != null)
            //                            {
            //                                //实时显示结果
            //                                Invoke(new Action(() => {
            //                                    MouseResult.Text = strResult == "OK" ? "OK" : "NG";
            //                                    MouseResult.ForeColor = strResult == "OK" ? Color.Chartreuse : Color.Red;
            //                                }));
            //                                ShowLog("10029获取喷嘴检测结果:" + strResult, 0);
            //                                SoftConfig.lstWorkPiece[iWorkPieceIndex].MouseResult = strResult;
            //                            }
            //                            else
            //                            {
            //                                ShowLog("10029获取喷嘴检测结果失败：结果为空!", 1);
            //                                //strMessage = "获取结果失败：结果为空!";
            //                            }
            //                        }
            //                    }

            //                }
            //                break;
            //            case 10027:
            //                //喷嘴检测结果240CS
            //                if (workStatusInfo.nWorkStatus == 0)
            //                {
            //                    int iIndex = hsl.ReadUShort("D3019", 1)[0];
            //                    WorkPiece wp = SoftConfig.lstWorkPiece.Where(x=>x.Index==iIndex).FirstOrDefault();
            //                    if (wp == null)
            //                    {
            //                        ShowLog("喷嘴清洗后240CS未找到对应工件数据,index=" + iIndex.ToString() + " 工件集合:" + GetIndexString(), 1);
            //                        return;
            //                    }
            //                    int iWorkPieceIndex = GetWorkPieceIndexByIndex(iIndex);
            //                    List<VmDynamicIODefine.IoNameInfo> ioNameInfos = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetAllOutputNameInfo();
            //                    if (ioNameInfos.Count != 0)//判断流程结果个数是否为0
            //                    {
            //                        if (ioNameInfos[0].TypeName == IMVS_MODULE_BASE_DATA_TYPE.IMVS_GRAP_TYPE_STRING)//判断流程第一个结果是否为字符串类型
            //                        {

            //                            Task.Run(() => {
            //                                Invoke(new Action(() => {
            //                                    ImageSourceModuleTool tool = (ImageSourceModuleTool)VmSolution.Instance["240CS.图像源1"];
            //                                    ImageBaseData pic = tool.ModuResult.ImageData;
            //                                    Image img = ImageBaseDataToBitmap(pic);
            //                                    wp.MouseAfter = IndexOfTask + "_" + iIndex.ToString() + "_" + wp.BarCode + "_" + wp.Ocr + "_3.jpg";
            //                                    SaveImage(img,SoftConfig.ImagePath + "\\" + wp.MouseAfter);

            //                                }));
            //                            });

            //                            //获取流程结果
            //                            string strResult = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetOutputString(ioNameInfos[0].Name).astStringVal[0].strValue;
            //                            if (strResult != null)
            //                            {
            //                                //实时显示结果
            //                                Invoke(new Action(() => {
            //                                    MouseResult.Text = strResult == "OK" ? "OK" : "NG";
            //                                    MouseResult.ForeColor = strResult == "OK" ? Color.Chartreuse : Color.Red;
            //                                }));
            //                                ShowLog("10027获取喷嘴检测结果:" + strResult, 0);
            //                                SoftConfig.lstWorkPiece[iWorkPieceIndex].MouseResult = strResult;
            //                            }
            //                            else
            //                            {
            //                                ShowLog("10027获取喷嘴检测结果失败：结果为空!", 1);
            //                                //strMessage = "获取结果失败：结果为空!";
            //                            }
            //                        }
            //                    }

            //                }
            //                break;
            //            case 10026:
            //                //喷嘴检测结果240CSN
            //                if (workStatusInfo.nWorkStatus == 0)
            //                {
            //                    int iIndex = hsl.ReadUShort("D3019", 1)[0];
            //                    WorkPiece wp = SoftConfig.lstWorkPiece.Where(x=>x.Index==iIndex).FirstOrDefault();
            //                    if (wp == null)
            //                    {
            //                        ShowLog("喷嘴清洗后240CSN未找到对应工件数据,index=" + iIndex.ToString() + " 工件集合:" + GetIndexString(), 1);
            //                        return;
            //                    }
            //                    int iWorkPieceIndex = GetWorkPieceIndexByIndex(iIndex);
            //                    List<VmDynamicIODefine.IoNameInfo> ioNameInfos = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetAllOutputNameInfo();
            //                    if (ioNameInfos.Count != 0)//判断流程结果个数是否为0
            //                    {
            //                        if (ioNameInfos[0].TypeName == IMVS_MODULE_BASE_DATA_TYPE.IMVS_GRAP_TYPE_STRING)//判断流程第一个结果是否为字符串类型
            //                        {

            //                            Task.Run(() => {
            //                                Invoke(new Action(() => {
            //                                    ImageSourceModuleTool tool = (ImageSourceModuleTool)VmSolution.Instance["240CSN.图像源1"];
            //                                    ImageBaseData pic = tool.ModuResult.ImageData;
            //                                    Image img = ImageBaseDataToBitmap(pic);
            //                                    wp.MouseAfter = IndexOfTask + "_" + iIndex.ToString() + "_" + wp.BarCode + "_" + wp.Ocr + "_3.jpg";
            //                                    SaveImage(img,SoftConfig.ImagePath + "\\" + wp.MouseAfter);

            //                                }));
            //                            });

            //                            //获取流程结果
            //                            string strResult = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetOutputString(ioNameInfos[0].Name).astStringVal[0].strValue;
            //                            if (strResult != null)
            //                            {
            //                                //实时显示结果
            //                                Invoke(new Action(() => {
            //                                    MouseResult.Text = strResult == "OK" ? "OK" : "NG";
            //                                    MouseResult.ForeColor = strResult == "OK" ? Color.Chartreuse : Color.Red;
            //                                }));
            //                                ShowLog("10026获取喷嘴检测结果:" + strResult, 0);
            //                                SoftConfig.lstWorkPiece[iWorkPieceIndex].MouseResult = strResult;
            //                            }
            //                            else
            //                            {
            //                                ShowLog("10026获取喷嘴检测结果失败：结果为空!", 1);
            //                                //strMessage = "获取结果失败：结果为空!";
            //                            }
            //                        }
            //                    }

            //                }
            //                break;
            //            case 10000:
            //                //喷嘴检测结果225CS
            //                if (workStatusInfo.nWorkStatus == 0)
            //                {
            //                    int iIndex = hsl.ReadUShort("D3019", 1)[0];
            //                    WorkPiece wp = SoftConfig.lstWorkPiece.Where(x=>x.Index==iIndex).FirstOrDefault();
            //                    if (wp == null)
            //                    {
            //                        ShowLog("喷嘴清洗后225CS未找到对应工件数据,index=" + iIndex.ToString() + " 工件集合:" + GetIndexString(), 1);
            //                        return;
            //                    }
            //                    int iWorkPieceIndex = GetWorkPieceIndexByIndex(iIndex);
            //                    List<VmDynamicIODefine.IoNameInfo> ioNameInfos = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetAllOutputNameInfo();
            //                    if (ioNameInfos.Count != 0)//判断流程结果个数是否为0
            //                    {
            //                        if (ioNameInfos[0].TypeName == IMVS_MODULE_BASE_DATA_TYPE.IMVS_GRAP_TYPE_STRING)//判断流程第一个结果是否为字符串类型
            //                        {

            //                            Task.Run(() => {
            //                                Invoke(new Action(() => {
            //                                    ImageSourceModuleTool tool = (ImageSourceModuleTool)VmSolution.Instance["225CS.图像源1"];
            //                                    ImageBaseData pic = tool.ModuResult.ImageData;
            //                                    Image img = ImageBaseDataToBitmap(pic);
            //                                    wp.MouseAfter = IndexOfTask + "_" + iIndex.ToString() + "_" + wp.BarCode + "_" + wp.Ocr + "_3.jpg";
            //                                    SaveImage(img,SoftConfig.ImagePath + "\\" + wp.MouseAfter);

            //                                }));
            //                            });

            //                            //获取流程结果
            //                            string strResult = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetOutputString(ioNameInfos[0].Name).astStringVal[0].strValue;
            //                            if (strResult != null)
            //                            {
            //                                //实时显示结果
            //                                Invoke(new Action(()=> {
            //                                    MouseResult.Text = strResult == "OK" ? "OK" : "NG";
            //                                    MouseResult.ForeColor = strResult == "OK" ? Color.Chartreuse : Color.Red;
            //                                }));
            //                                ShowLog("10000获取喷嘴检测结果:" + strResult, 0);
            //                                SoftConfig.lstWorkPiece[iWorkPieceIndex].MouseResult = strResult;
            //                            }
            //                            else
            //                            {
            //                                ShowLog("10000获取喷嘴检测结果失败：结果为空!", 1);
            //                                //strMessage = "获取结果失败：结果为空!";
            //                            }
            //                        }
            //                    }

            //                }
            //                break;
            //            case 10010:
            //                //喷嘴检测结果226CSN
            //                if (workStatusInfo.nWorkStatus == 0)
            //                {
            //                    int iIndex = hsl.ReadUShort("D3019", 1)[0];
            //                    WorkPiece wp = SoftConfig.lstWorkPiece.Where(x=>x.Index==iIndex).FirstOrDefault();
            //                    if (wp == null)
            //                    {
            //                        ShowLog("喷嘴清洗后226CSN未找到对应工件数据,index=" + iIndex.ToString() + " 工件集合:" + GetIndexString(), 1);
            //                        return;
            //                    }
            //                    int iWorkPieceIndex = GetWorkPieceIndexByIndex(iIndex);
            //                    List<VmDynamicIODefine.IoNameInfo> ioNameInfos = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetAllOutputNameInfo();
            //                    if (ioNameInfos.Count != 0)//判断流程结果个数是否为0
            //                    {
            //                        if (ioNameInfos[0].TypeName == IMVS_MODULE_BASE_DATA_TYPE.IMVS_GRAP_TYPE_STRING)//判断流程第一个结果是否为字符串类型
            //                        {

            //                            Task.Run(() => {
            //                                Invoke(new Action(() => {
            //                                    ImageSourceModuleTool tool = (ImageSourceModuleTool)VmSolution.Instance["226CSN.图像源1"];
            //                                    ImageBaseData pic = tool.ModuResult.ImageData;
            //                                    Image img = ImageBaseDataToBitmap(pic);
            //                                    wp.MouseAfter = IndexOfTask + "_" + iIndex.ToString() + "_" + wp.BarCode + "_" + wp.Ocr + "_3.jpg";
            //                                    SaveImage(img,SoftConfig.ImagePath + "\\" + wp.MouseAfter);

            //                                }));
            //                            });

            //                            //获取流程结果
            //                            string strResult = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetOutputString(ioNameInfos[0].Name).astStringVal[0].strValue;
            //                            if (strResult != null)
            //                            {
            //                                //实时显示结果
            //                                Invoke(new Action(() => {
            //                                    MouseResult.Text = strResult == "OK" ? "OK" : "NG";
            //                                    MouseResult.ForeColor = strResult == "OK" ? Color.Chartreuse : Color.Red;
            //                                }));
            //                                ShowLog("10010获取喷嘴检测结果:" + strResult, 0);
            //                                SoftConfig.lstWorkPiece[iWorkPieceIndex].MouseResult = strResult;
            //                            }
            //                            else
            //                            {
            //                                ShowLog("10010获取喷嘴检测结果失败：结果为空!", 1);
            //                                //strMessage = "获取结果失败：结果为空!";
            //                            }
            //                        }
            //                    }

            //                }
            //                break;
            //            case 10012:
            //                //喷嘴检测结果110
            //                if (workStatusInfo.nWorkStatus == 0)
            //                {
            //                    int iIndex = hsl.ReadUShort("D3019", 1)[0];
            //                    WorkPiece wp = SoftConfig.lstWorkPiece.Where(x=>x.Index==iIndex).FirstOrDefault();
            //                    if (wp == null)
            //                    {
            //                        ShowLog("喷嘴清洗后110未找到对应工件数据,index=" + iIndex.ToString() + " 工件集合:" + GetIndexString(), 1);
            //                        return;
            //                    }
            //                    int iWorkPieceIndex = GetWorkPieceIndexByIndex(iIndex);
            //                    List<VmDynamicIODefine.IoNameInfo> ioNameInfos = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetAllOutputNameInfo();
            //                    if (ioNameInfos.Count != 0)//判断流程结果个数是否为0
            //                    {
            //                        if (ioNameInfos[0].TypeName == IMVS_MODULE_BASE_DATA_TYPE.IMVS_GRAP_TYPE_STRING)//判断流程第一个结果是否为字符串类型
            //                        {

            //                            Task.Run(() => {
            //                                Invoke(new Action(() => {
            //                                    ImageSourceModuleTool tool = (ImageSourceModuleTool)VmSolution.Instance["110.图像源1"];
            //                                    ImageBaseData pic = tool.ModuResult.ImageData;
            //                                    Image img = ImageBaseDataToBitmap(pic);
            //                                    wp.MouseAfter = IndexOfTask + "_" + iIndex.ToString() + "_" + wp.BarCode + "_" + wp.Ocr + "_3.jpg";
            //                                    SaveImage(img,SoftConfig.ImagePath + "\\" + wp.MouseAfter);
            //                                }));
            //                            });

            //                            //获取流程结果
            //                            string strResult = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetOutputString(ioNameInfos[0].Name).astStringVal[0].strValue;
            //                            if (strResult != null)
            //                            {
            //                                //实时显示结果
            //                                Invoke(new Action(() => {
            //                                    MouseResult.Text = strResult == "OK" ? "OK" : "NG";
            //                                    MouseResult.ForeColor = strResult == "OK" ? Color.Chartreuse : Color.Red;
            //                                }));
            //                                ShowLog("10012获取喷嘴检测结果:" + strResult, 0);
            //                                SoftConfig.lstWorkPiece[iWorkPieceIndex].MouseResult = strResult;
            //                            }
            //                            else
            //                            {
            //                                ShowLog("10012获取喷嘴检测结果失败：结果为空!", 1);
            //                                //strMessage = "获取结果失败：结果为空!";
            //                            }
            //                        }
            //                    }

            //                }
            //                break;
            //            case 10013:
            //                //喷嘴检测结果230CSN
            //                if (workStatusInfo.nWorkStatus == 0)
            //                {
            //                    int iIndex = hsl.ReadUShort("D3019", 1)[0];
            //                    WorkPiece wp = SoftConfig.lstWorkPiece.Where(x=>x.Index==iIndex).FirstOrDefault();
            //                    if (wp == null)
            //                    {
            //                        ShowLog("喷嘴清洗后230CSN未找到对应工件数据,index=" + iIndex.ToString() + " 工件集合:" + GetIndexString(), 1);
            //                        return;
            //                    }
            //                    int iWorkPieceIndex = GetWorkPieceIndexByIndex(iIndex);
            //                    List<VmDynamicIODefine.IoNameInfo> ioNameInfos = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetAllOutputNameInfo();
            //                    if (ioNameInfos.Count != 0)//判断流程结果个数是否为0
            //                    {
            //                        if (ioNameInfos[0].TypeName == IMVS_MODULE_BASE_DATA_TYPE.IMVS_GRAP_TYPE_STRING)//判断流程第一个结果是否为字符串类型
            //                        {

            //                            Task.Run(() => {
            //                                Invoke(new Action(() => {
            //                                    ImageSourceModuleTool tool = (ImageSourceModuleTool)VmSolution.Instance["230CSN.图像源1"];
            //                                    ImageBaseData pic = tool.ModuResult.ImageData;
            //                                    Image img = ImageBaseDataToBitmap(pic);
            //                                    wp.MouseAfter = IndexOfTask + "_" + iIndex.ToString() + "_" + wp.BarCode + "_" + wp.Ocr + "_3.jpg";
            //                                    SaveImage(img,SoftConfig.ImagePath + "\\" + wp.MouseAfter);
            //                                }));
            //                            });

            //                            //获取流程结果
            //                            string strResult = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetOutputString(ioNameInfos[0].Name).astStringVal[0].strValue;
            //                            if (strResult != null)
            //                            {
            //                                //实时显示结果
            //                                Invoke(new Action(() => {
            //                                    MouseResult.Text = strResult == "OK" ? "OK" : "NG";
            //                                    MouseResult.ForeColor = strResult == "OK" ? Color.Chartreuse : Color.Red;
            //                                }));
            //                                ShowLog("10013获取喷嘴检测结果:" + strResult, 0);
            //                                SoftConfig.lstWorkPiece[iWorkPieceIndex].MouseResult = strResult;
            //                            }
            //                            else
            //                            {
            //                                ShowLog("10013获取喷嘴检测结果失败：结果为空!", 1);
            //                                //strMessage = "获取结果失败：结果为空!";
            //                            }
            //                        }
            //                    }

            //                }
            //                break;
            //            case 10014:
            //                //喷嘴检测结果256CSN
            //                if (workStatusInfo.nWorkStatus == 0)
            //                {
            //                    int iIndex = hsl.ReadUShort("D3019", 1)[0];
            //                    WorkPiece wp = SoftConfig.lstWorkPiece.Where(x=>x.Index==iIndex).FirstOrDefault();
            //                    if (wp == null)
            //                    {
            //                        ShowLog("喷嘴清洗后256CSN未找到对应工件数据,index=" + iIndex.ToString() + " 工件集合:" + GetIndexString(), 1);
            //                        return;
            //                    }
            //                    int iWorkPieceIndex = GetWorkPieceIndexByIndex(iIndex);
            //                    List<VmDynamicIODefine.IoNameInfo> ioNameInfos = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetAllOutputNameInfo();
            //                    if (ioNameInfos.Count != 0)//判断流程结果个数是否为0
            //                    {
            //                        if (ioNameInfos[0].TypeName == IMVS_MODULE_BASE_DATA_TYPE.IMVS_GRAP_TYPE_STRING)//判断流程第一个结果是否为字符串类型
            //                        {

            //                            Task.Run(() => {
            //                                Invoke(new Action(() => {
            //                                    ImageSourceModuleTool tool = (ImageSourceModuleTool)VmSolution.Instance["256CSN.图像源1"];
            //                                    ImageBaseData pic = tool.ModuResult.ImageData;
            //                                    Image img = ImageBaseDataToBitmap(pic);
            //                                    wp.MouseAfter = IndexOfTask + "_" + iIndex.ToString() + "_" + wp.BarCode + "_" + wp.Ocr + "_3.jpg";
            //                                    SaveImage(img,SoftConfig.ImagePath + "\\" + wp.MouseAfter);
            //                                }));
            //                            });

            //                            //获取流程结果
            //                            string strResult = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetOutputString(ioNameInfos[0].Name).astStringVal[0].strValue;
            //                            if (strResult != null)
            //                            {
            //                                //实时显示结果
            //                                Invoke(new Action(() => {
            //                                    MouseResult.Text = strResult == "OK" ? "OK" : "NG";
            //                                    MouseResult.ForeColor = strResult == "OK" ? Color.Chartreuse : Color.Red;
            //                                }));
            //                                ShowLog("10014获取喷嘴检测结果:" + strResult, 0);
            //                                SoftConfig.lstWorkPiece[iWorkPieceIndex].MouseResult = strResult;
            //                            }
            //                            else
            //                            {
            //                                ShowLog("10014获取喷嘴检测结果失败：结果为空!", 1);
            //                                //strMessage = "获取结果失败：结果为空!";
            //                            }
            //                        }
            //                    }

            //                }
            //                break;
            //            case 10015:
            //                //喷嘴检测结果115AS
            //                if (workStatusInfo.nWorkStatus == 0)
            //                {
            //                    int iIndex = hsl.ReadUShort("D3019", 1)[0];
            //                    WorkPiece wp = SoftConfig.lstWorkPiece.Where(x=>x.Index==iIndex).FirstOrDefault();
            //                    if (wp == null)
            //                    {
            //                        ShowLog("喷嘴清洗后115AS未找到对应工件数据,index=" + iIndex.ToString() + " 工件集合:" + GetIndexString(), 1);
            //                        return;
            //                    }
            //                    int iWorkPieceIndex = GetWorkPieceIndexByIndex(iIndex);
            //                    List<VmDynamicIODefine.IoNameInfo> ioNameInfos = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetAllOutputNameInfo();
            //                    if (ioNameInfos.Count != 0)//判断流程结果个数是否为0
            //                    {
            //                        if (ioNameInfos[0].TypeName == IMVS_MODULE_BASE_DATA_TYPE.IMVS_GRAP_TYPE_STRING)//判断流程第一个结果是否为字符串类型
            //                        {

            //                            Task.Run(() => {
            //                                Invoke(new Action(() => {
            //                                    ImageSourceModuleTool tool = (ImageSourceModuleTool)VmSolution.Instance["115AS.图像源1"];
            //                                    ImageBaseData pic = tool.ModuResult.ImageData;
            //                                    Image img = ImageBaseDataToBitmap(pic);
            //                                    wp.MouseAfter = IndexOfTask + "_" + iIndex.ToString() + "_" + wp.BarCode + "_" + wp.Ocr + "_3.jpg";
            //                                    SaveImage(img,SoftConfig.ImagePath + "\\" + wp.MouseAfter);
            //                                }));
            //                            });

            //                            //获取流程结果
            //                            string strResult = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetOutputString(ioNameInfos[0].Name).astStringVal[0].strValue;
            //                            if (strResult != null)
            //                            {
            //                                //实时显示结果
            //                                Invoke(new Action(() => {
            //                                    MouseResult.Text = strResult == "OK" ? "OK" : "NG";
            //                                    MouseResult.ForeColor = strResult == "OK" ? Color.Chartreuse : Color.Red;
            //                                }));
            //                                ShowLog("10015获取喷嘴检测结果:" + strResult, 0);
            //                                SoftConfig.lstWorkPiece[iWorkPieceIndex].MouseResult = strResult;
            //                            }
            //                            else
            //                            {
            //                                ShowLog("10015获取喷嘴检测结果失败：结果为空!", 1);
            //                                //strMessage = "获取结果失败：结果为空!";
            //                            }
            //                        }
            //                    }

            //                }
            //                break;
            //            case 10009:
            //                //喷嘴检测结果235CS
            //                if (workStatusInfo.nWorkStatus == 0)
            //                {
            //                    int iIndex = hsl.ReadUShort("D3019", 1)[0];
            //                    WorkPiece wp = SoftConfig.lstWorkPiece.Where(x=>x.Index==iIndex).FirstOrDefault();
            //                    if (wp == null)
            //                    {
            //                        ShowLog("喷嘴清洗后235CS未找到对应工件数据,index=" + iIndex.ToString() + " 工件集合:" + GetIndexString(), 1);
            //                        return;
            //                    }
            //                    int iWorkPieceIndex = GetWorkPieceIndexByIndex(iIndex);
            //                    List<VmDynamicIODefine.IoNameInfo> ioNameInfos = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetAllOutputNameInfo();
            //                    if (ioNameInfos.Count != 0)//判断流程结果个数是否为0
            //                    {
            //                        if (ioNameInfos[0].TypeName == IMVS_MODULE_BASE_DATA_TYPE.IMVS_GRAP_TYPE_STRING)//判断流程第一个结果是否为字符串类型
            //                        {

            //                            Task.Run(() => {
            //                                Invoke(new Action(() => {
            //                                    ImageSourceModuleTool tool = (ImageSourceModuleTool)VmSolution.Instance["235CS.图像源1"];
            //                                    ImageBaseData pic = tool.ModuResult.ImageData;
            //                                    Image img = ImageBaseDataToBitmap(pic);
            //                                    wp.MouseAfter = IndexOfTask + "_" + iIndex.ToString() + "_" + wp.BarCode + "_" + wp.Ocr + "_3.jpg";
            //                                    SaveImage(img,SoftConfig.ImagePath + "\\" + wp.MouseAfter);
            //                                }));
            //                            });

            //                            //获取流程结果
            //                            string strResult = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetOutputString(ioNameInfos[0].Name).astStringVal[0].strValue;
            //                            if (strResult != null)
            //                            {
            //                                //实时显示结果
            //                                Invoke(new Action(() => {
            //                                    MouseResult.Text = strResult == "OK" ? "OK" : "NG";
            //                                    MouseResult.ForeColor = strResult == "OK" ? Color.Chartreuse : Color.Red;
            //                                }));
            //                                ShowLog("10009获取喷嘴检测结果:" + strResult, 0);
            //                                SoftConfig.lstWorkPiece[iWorkPieceIndex].MouseResult = strResult;
            //                            }
            //                            else
            //                            {
            //                                ShowLog("10009获取喷嘴检测结果失败：结果为空!", 1);
            //                                //strMessage = "获取结果失败：结果为空!";
            //                            }
            //                        }
            //                    }

            //                }
            //                break;
            //            case 10011:
            //                //喷嘴检测默认结果OCR
            //                if (workStatusInfo.nWorkStatus == 0)
            //                {
            //                    int iIndex = hsl.ReadUShort("D3019", 1)[0];
            //                    WorkPiece wp = SoftConfig.lstWorkPiece.Where(x=>x.Index==iIndex).FirstOrDefault();
            //                    if (wp == null)
            //                    {
            //                        ShowLog("喷嘴清洗后OCR未找到对应工件数据,index=" + iIndex.ToString() + " 工件集合:" + GetIndexString(), 1);
            //                        return;
            //                    }
            //                    int iWorkPieceIndex = GetWorkPieceIndexByIndex(iIndex);
            //                    List<VmDynamicIODefine.IoNameInfo> ioNameInfos = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetAllOutputNameInfo();
            //                    if (ioNameInfos.Count != 0)//判断流程结果个数是否为0
            //                    {
            //                        if (ioNameInfos[0].TypeName == IMVS_MODULE_BASE_DATA_TYPE.IMVS_GRAP_TYPE_STRING)//判断流程第一个结果是否为字符串类型
            //                        {

            //                            Task.Run(() => {
            //                                Invoke(new Action(() => {
            //                                    ImageSourceModuleTool tool = (ImageSourceModuleTool)VmSolution.Instance["OCR.图像源1"];
            //                                    ImageBaseData pic = tool.ModuResult.ImageData;
            //                                    Image img = ImageBaseDataToBitmap(pic);
            //                                    wp.MouseAfter = IndexOfTask + "_" + iIndex.ToString() + "_" + wp.BarCode + "_" + wp.Ocr + "_3.jpg";
            //                                    SaveImage(img,SoftConfig.ImagePath + "\\" + wp.MouseAfter);
            //                                }));
            //                            });

            //                            //获取流程结果
            //                            string strResult = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetOutputString(ioNameInfos[0].Name).astStringVal[0].strValue;
            //                            if (strResult != null)
            //                            {
            //                                //实时显示结果
            //                                Invoke(new Action(() => {
            //                                    MouseResult.Text = strResult == "OK" ? "OK" : "NG";
            //                                    MouseResult.ForeColor = strResult == "OK" ? Color.Chartreuse : Color.Red;
            //                                }));
            //                                ShowLog("10011获取喷嘴检测结果:" + strResult, 0);
            //                                SoftConfig.lstWorkPiece[iWorkPieceIndex].MouseResult = strResult;
            //                            }
            //                            else
            //                            {
            //                                ShowLog("10011获取喷嘴检测结果失败：结果为空!", 1);
            //                                //strMessage = "获取结果失败：结果为空!";
            //                            }
            //                        }
            //                    }

            //                }
            //                break;
            //            case 10032:
            //                //喷嘴检测结果185N
            //                if (workStatusInfo.nWorkStatus == 0)
            //                {
            //                    int iIndex = hsl.ReadUShort("D3019", 1)[0];
            //                    WorkPiece wp = SoftConfig.lstWorkPiece.Where(x => x.Index == iIndex).FirstOrDefault();
            //                    if (wp == null)
            //                    {
            //                        ShowLog("喷嘴清洗后185N未找到对应工件数据,index=" + iIndex.ToString() + " 工件集合:" + GetIndexString(), 1);
            //                        return;
            //                    }
            //                    int iWorkPieceIndex = GetWorkPieceIndexByIndex(iIndex);
            //                    List<VmDynamicIODefine.IoNameInfo> ioNameInfos = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetAllOutputNameInfo();
            //                    if (ioNameInfos.Count != 0)//判断流程结果个数是否为0
            //                    {
            //                        if (ioNameInfos[0].TypeName == IMVS_MODULE_BASE_DATA_TYPE.IMVS_GRAP_TYPE_STRING)//判断流程第一个结果是否为字符串类型
            //                        {

            //                            Task.Run(() => {
            //                                Invoke(new Action(() => {
            //                                    ImageSourceModuleTool tool = (ImageSourceModuleTool)VmSolution.Instance["185N.图像源1"];
            //                                    ImageBaseData pic = tool.ModuResult.ImageData;
            //                                    Image img = ImageBaseDataToBitmap(pic);
            //                                    wp.MouseAfter = IndexOfTask + "_" + iIndex.ToString() + "_" + wp.BarCode + "_" + wp.Ocr + "_3.jpg";
            //                                    SaveImage(img,SoftConfig.ImagePath + "\\" + wp.MouseAfter);
            //                                }));
            //                            });

            //                            //获取流程结果
            //                            string strResult = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetOutputString(ioNameInfos[0].Name).astStringVal[0].strValue;
            //                            if (strResult != null)
            //                            {
            //                                //实时显示结果
            //                                Invoke(new Action(() => {
            //                                    MouseResult.Text = strResult == "OK" ? "OK" : "NG";
            //                                    MouseResult.ForeColor = strResult == "OK" ? Color.Chartreuse : Color.Red;
            //                                }));
            //                                ShowLog(workStatusInfo.nProcessID.ToString() + "获取喷嘴检测结果:" + strResult, 0);
            //                                SoftConfig.lstWorkPiece[iWorkPieceIndex].MouseResult = strResult;
            //                            }
            //                            else
            //                            {
            //                                ShowLog(workStatusInfo.nProcessID.ToString() + "获取喷嘴检测结果失败：结果为空!", 1);
            //                                //strMessage = "获取结果失败：结果为空!";
            //                            }
            //                        }
            //                    }

            //                }
            //                break;
            //            case 10031:
            //                //喷嘴检测结果140N
            //                if (workStatusInfo.nWorkStatus == 0)
            //                {
            //                    int iIndex = hsl.ReadUShort("D3019", 1)[0];
            //                    WorkPiece wp = SoftConfig.lstWorkPiece.Where(x => x.Index == iIndex).FirstOrDefault();
            //                    if (wp == null)
            //                    {
            //                        ShowLog("喷嘴清洗后140N未找到对应工件数据,index=" + iIndex.ToString() + " 工件集合:" + GetIndexString(), 1);
            //                        return;
            //                    }
            //                    int iWorkPieceIndex = GetWorkPieceIndexByIndex(iIndex);
            //                    List<VmDynamicIODefine.IoNameInfo> ioNameInfos = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetAllOutputNameInfo();
            //                    if (ioNameInfos.Count != 0)//判断流程结果个数是否为0
            //                    {
            //                        if (ioNameInfos[0].TypeName == IMVS_MODULE_BASE_DATA_TYPE.IMVS_GRAP_TYPE_STRING)//判断流程第一个结果是否为字符串类型
            //                        {

            //                            Task.Run(() => {
            //                                Invoke(new Action(() => {
            //                                    ImageSourceModuleTool tool = (ImageSourceModuleTool)VmSolution.Instance["140N.图像源1"];
            //                                    ImageBaseData pic = tool.ModuResult.ImageData;
            //                                    Image img = ImageBaseDataToBitmap(pic);
            //                                    wp.MouseAfter = IndexOfTask + "_" + iIndex.ToString() + "_" + wp.BarCode + "_" + wp.Ocr + "_3.jpg";
            //                                    SaveImage(img,SoftConfig.ImagePath + "\\" + wp.MouseAfter);
            //                                }));
            //                            });

            //                            //获取流程结果
            //                            string strResult = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetOutputString(ioNameInfos[0].Name).astStringVal[0].strValue;
            //                            if (strResult != null)
            //                            {
            //                                //实时显示结果
            //                                Invoke(new Action(() => {
            //                                    MouseResult.Text = strResult == "OK" ? "OK" : "NG";
            //                                    MouseResult.ForeColor = strResult == "OK" ? Color.Chartreuse : Color.Red;
            //                                }));
            //                                ShowLog(workStatusInfo.nProcessID.ToString() + "获取喷嘴检测结果:" + strResult, 0);
            //                                SoftConfig.lstWorkPiece[iWorkPieceIndex].MouseResult = strResult;
            //                            }
            //                            else
            //                            {
            //                                ShowLog(workStatusInfo.nProcessID.ToString() + "获取喷嘴检测结果失败：结果为空!", 1);
            //                                //strMessage = "获取结果失败：结果为空!";
            //                            }
            //                        }
            //                    }

            //                }
            //                break;
            //            case 10030:
            //                //喷嘴检测结果161SN
            //                if (workStatusInfo.nWorkStatus == 0)
            //                {
            //                    int iIndex = hsl.ReadUShort("D3019", 1)[0];
            //                    WorkPiece wp = SoftConfig.lstWorkPiece.Where(x => x.Index == iIndex).FirstOrDefault();
            //                    if (wp == null)
            //                    {
            //                        ShowLog("喷嘴清洗后161SN未找到对应工件数据,index=" + iIndex.ToString() + " 工件集合:" + GetIndexString(), 1);
            //                        return;
            //                    }
            //                    int iWorkPieceIndex = GetWorkPieceIndexByIndex(iIndex);
            //                    List<VmDynamicIODefine.IoNameInfo> ioNameInfos = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetAllOutputNameInfo();
            //                    if (ioNameInfos.Count != 0)//判断流程结果个数是否为0
            //                    {
            //                        if (ioNameInfos[0].TypeName == IMVS_MODULE_BASE_DATA_TYPE.IMVS_GRAP_TYPE_STRING)//判断流程第一个结果是否为字符串类型
            //                        {

            //                            Task.Run(() => {
            //                                Invoke(new Action(() => {
            //                                    ImageSourceModuleTool tool = (ImageSourceModuleTool)VmSolution.Instance["161SN.图像源1"];
            //                                    ImageBaseData pic = tool.ModuResult.ImageData;
            //                                    Image img = ImageBaseDataToBitmap(pic);
            //                                    wp.MouseAfter = IndexOfTask + "_" + iIndex.ToString() + "_" + wp.BarCode + "_" + wp.Ocr + "_3.jpg";
            //                                    SaveImage(img,SoftConfig.ImagePath + "\\" + wp.MouseAfter);
            //                                }));
            //                            });

            //                            //获取流程结果
            //                            string strResult = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetOutputString(ioNameInfos[0].Name).astStringVal[0].strValue;
            //                            if (strResult != null)
            //                            {
            //                                //实时显示结果
            //                                Invoke(new Action(() => {
            //                                    MouseResult.Text = strResult == "OK" ? "OK" : "NG";
            //                                    MouseResult.ForeColor = strResult == "OK" ? Color.Chartreuse : Color.Red;
            //                                }));
            //                                ShowLog(workStatusInfo.nProcessID.ToString() + "获取喷嘴检测结果:" + strResult, 0);
            //                                SoftConfig.lstWorkPiece[iWorkPieceIndex].MouseResult = strResult;
            //                            }
            //                            else
            //                            {
            //                                ShowLog(workStatusInfo.nProcessID.ToString() + "获取喷嘴检测结果失败：结果为空!", 1);
            //                                //strMessage = "获取结果失败：结果为空!";
            //                            }
            //                        }
            //                    }

            //                }
            //                break;
            //            case 10016:
            //                //喷嘴检测结果225CSN
            //                if (workStatusInfo.nWorkStatus == 0)
            //                {
            //                    int iIndex = hsl.ReadUShort("D3019", 1)[0];
            //                    WorkPiece wp = SoftConfig.lstWorkPiece.Where(x => x.Index == iIndex).FirstOrDefault();
            //                    if (wp == null)
            //                    {
            //                        ShowLog("喷嘴清洗后225CSN未找到对应工件数据,index=" + iIndex.ToString() + " 工件集合:" + GetIndexString(), 1);
            //                        return;
            //                    }
            //                    int iWorkPieceIndex = GetWorkPieceIndexByIndex(iIndex);
            //                    List<VmDynamicIODefine.IoNameInfo> ioNameInfos = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetAllOutputNameInfo();
            //                    if (ioNameInfos.Count != 0)//判断流程结果个数是否为0
            //                    {
            //                        if (ioNameInfos[0].TypeName == IMVS_MODULE_BASE_DATA_TYPE.IMVS_GRAP_TYPE_STRING)//判断流程第一个结果是否为字符串类型
            //                        {

            //                            Task.Run(() => {
            //                                Invoke(new Action(() => {
            //                                    ImageSourceModuleTool tool = (ImageSourceModuleTool)VmSolution.Instance["225CSN.图像源1"];
            //                                    ImageBaseData pic = tool.ModuResult.ImageData;
            //                                    Image img = ImageBaseDataToBitmap(pic);
            //                                    wp.MouseAfter = IndexOfTask + "_" + iIndex.ToString() + "_" + wp.BarCode + "_" + wp.Ocr + "_3.jpg";
            //                                    SaveImage(img,SoftConfig.ImagePath + "\\" + wp.MouseAfter);

            //                                }));
            //                            });

            //                            //获取流程结果
            //                            string strResult = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetOutputString(ioNameInfos[0].Name).astStringVal[0].strValue;
            //                            if (strResult != null)
            //                            {
            //                                //实时显示结果
            //                                Invoke(new Action(() => {
            //                                    MouseResult.Text = strResult == "OK" ? "OK" : "NG";
            //                                    MouseResult.ForeColor = strResult == "OK" ? Color.Chartreuse : Color.Red;
            //                                }));
            //                                ShowLog(workStatusInfo.nProcessID.ToString() + "获取喷嘴检测结果:" + strResult, 0);
            //                                SoftConfig.lstWorkPiece[iWorkPieceIndex].MouseResult = strResult;
            //                            }
            //                            else
            //                            {
            //                                ShowLog(workStatusInfo.nProcessID.ToString() + "获取喷嘴检测结果失败：结果为空!", 1);
            //                                //strMessage = "获取结果失败：结果为空!";
            //                            }
            //                        }
            //                    }

            //                }
            //                break;
            //            case 10034:
            //                //喷嘴检测结果230C
            //                if (workStatusInfo.nWorkStatus == 0)
            //                {
            //                    int iIndex = hsl.ReadUShort("D3019", 1)[0];
            //                    WorkPiece wp = SoftConfig.lstWorkPiece.Where(x => x.Index == iIndex).FirstOrDefault();
            //                    if (wp == null)
            //                    {
            //                        ShowLog("喷嘴清洗后230C未找到对应工件数据,index=" + iIndex.ToString() + " 工件集合:" + GetIndexString(), 1);
            //                        return;
            //                    }
            //                    int iWorkPieceIndex = GetWorkPieceIndexByIndex(iIndex);
            //                    List<VmDynamicIODefine.IoNameInfo> ioNameInfos = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetAllOutputNameInfo();
            //                    if (ioNameInfos.Count != 0)//判断流程结果个数是否为0
            //                    {
            //                        if (ioNameInfos[0].TypeName == IMVS_MODULE_BASE_DATA_TYPE.IMVS_GRAP_TYPE_STRING)//判断流程第一个结果是否为字符串类型
            //                        {

            //                            Task.Run(() => {
            //                                Invoke(new Action(() => {
            //                                    ImageSourceModuleTool tool = (ImageSourceModuleTool)VmSolution.Instance["230C.图像源1"];
            //                                    ImageBaseData pic = tool.ModuResult.ImageData;
            //                                    Image img = ImageBaseDataToBitmap(pic);
            //                                    wp.MouseAfter = IndexOfTask + "_" + iIndex.ToString() + "_" + wp.BarCode + "_" + wp.Ocr + "_3.jpg";
            //                                    SaveImage(img, SoftConfig.ImagePath + "\\" + wp.MouseAfter);

            //                                }));
            //                            });

            //                            //获取流程结果
            //                            string strResult = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetOutputString(ioNameInfos[0].Name).astStringVal[0].strValue;
            //                            if (strResult != null)
            //                            {
            //                                //实时显示结果
            //                                Invoke(new Action(() => {
            //                                    MouseResult.Text = strResult == "OK" ? "OK" : "NG";
            //                                    MouseResult.ForeColor = strResult == "OK" ? Color.Chartreuse : Color.Red;
            //                                }));
            //                                ShowLog(workStatusInfo.nProcessID.ToString() + "获取喷嘴检测结果:" + strResult, 0);
            //                                SoftConfig.lstWorkPiece[iWorkPieceIndex].MouseResult = strResult;
            //                            }
            //                            else
            //                            {
            //                                ShowLog(workStatusInfo.nProcessID.ToString() + "获取喷嘴检测结果失败：结果为空!", 1);
            //                                //strMessage = "获取结果失败：结果为空!";
            //                            }
            //                        }
            //                    }

            //                }
            //                break;
            //            case 10035:
            //                //喷嘴检测结果235C
            //                if (workStatusInfo.nWorkStatus == 0)
            //                {
            //                    int iIndex = hsl.ReadUShort("D3019", 1)[0];
            //                    WorkPiece wp = SoftConfig.lstWorkPiece.Where(x => x.Index == iIndex).FirstOrDefault();
            //                    if (wp == null)
            //                    {
            //                        ShowLog("喷嘴清洗后235C未找到对应工件数据,index=" + iIndex.ToString() + " 工件集合:" + GetIndexString(), 1);
            //                        return;
            //                    }
            //                    int iWorkPieceIndex = GetWorkPieceIndexByIndex(iIndex);
            //                    List<VmDynamicIODefine.IoNameInfo> ioNameInfos = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetAllOutputNameInfo();
            //                    if (ioNameInfos.Count != 0)//判断流程结果个数是否为0
            //                    {
            //                        if (ioNameInfos[0].TypeName == IMVS_MODULE_BASE_DATA_TYPE.IMVS_GRAP_TYPE_STRING)//判断流程第一个结果是否为字符串类型
            //                        {

            //                            Task.Run(() => {
            //                                Invoke(new Action(() => {
            //                                    ImageSourceModuleTool tool = (ImageSourceModuleTool)VmSolution.Instance["235C.图像源1"];
            //                                    ImageBaseData pic = tool.ModuResult.ImageData;
            //                                    Image img = ImageBaseDataToBitmap(pic);
            //                                    wp.MouseAfter = IndexOfTask + "_" + iIndex.ToString() + "_" + wp.BarCode + "_" + wp.Ocr + "_3.jpg";
            //                                    SaveImage(img, SoftConfig.ImagePath + "\\" + wp.MouseAfter);

            //                                }));
            //                            });

            //                            //获取流程结果
            //                            string strResult = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetOutputString(ioNameInfos[0].Name).astStringVal[0].strValue;
            //                            if (strResult != null)
            //                            {
            //                                //实时显示结果
            //                                Invoke(new Action(() => {
            //                                    MouseResult.Text = strResult == "OK" ? "OK" : "NG";
            //                                    MouseResult.ForeColor = strResult == "OK" ? Color.Chartreuse : Color.Red;
            //                                }));
            //                                ShowLog(workStatusInfo.nProcessID.ToString() + "获取喷嘴检测结果:" + strResult, 0);
            //                                SoftConfig.lstWorkPiece[iWorkPieceIndex].MouseResult = strResult;
            //                            }
            //                            else
            //                            {
            //                                ShowLog(workStatusInfo.nProcessID.ToString() + "获取喷嘴检测结果失败：结果为空!", 1);
            //                                //strMessage = "获取结果失败：结果为空!";
            //                            }
            //                        }
            //                    }

            //                }
            //                break;
            //            case 10036:
            //                //喷嘴检测结果240C
            //                if (workStatusInfo.nWorkStatus == 0)
            //                {
            //                    int iIndex = hsl.ReadUShort("D3019", 1)[0];
            //                    WorkPiece wp = SoftConfig.lstWorkPiece.Where(x => x.Index == iIndex).FirstOrDefault();
            //                    if (wp == null)
            //                    {
            //                        ShowLog("喷嘴清洗后240C未找到对应工件数据,index=" + iIndex.ToString() + " 工件集合:" + GetIndexString(), 1);
            //                        return;
            //                    }
            //                    int iWorkPieceIndex = GetWorkPieceIndexByIndex(iIndex);
            //                    List<VmDynamicIODefine.IoNameInfo> ioNameInfos = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetAllOutputNameInfo();
            //                    if (ioNameInfos.Count != 0)//判断流程结果个数是否为0
            //                    {
            //                        if (ioNameInfos[0].TypeName == IMVS_MODULE_BASE_DATA_TYPE.IMVS_GRAP_TYPE_STRING)//判断流程第一个结果是否为字符串类型
            //                        {

            //                            Task.Run(() => {
            //                                Invoke(new Action(() => {
            //                                    ImageSourceModuleTool tool = (ImageSourceModuleTool)VmSolution.Instance["240C.图像源1"];
            //                                    ImageBaseData pic = tool.ModuResult.ImageData;
            //                                    Image img = ImageBaseDataToBitmap(pic);
            //                                    wp.MouseAfter = IndexOfTask + "_" + iIndex.ToString() + "_" + wp.BarCode + "_" + wp.Ocr + "_3.jpg";
            //                                    SaveImage(img, SoftConfig.ImagePath + "\\" + wp.MouseAfter);

            //                                }));
            //                            });

            //                            //获取流程结果
            //                            string strResult = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetOutputString(ioNameInfos[0].Name).astStringVal[0].strValue;
            //                            if (strResult != null)
            //                            {
            //                                //实时显示结果
            //                                Invoke(new Action(() => {
            //                                    MouseResult.Text = strResult == "OK" ? "OK" : "NG";
            //                                    MouseResult.ForeColor = strResult == "OK" ? Color.Chartreuse : Color.Red;
            //                                }));
            //                                ShowLog(workStatusInfo.nProcessID.ToString() + "获取喷嘴检测结果:" + strResult, 0);
            //                                SoftConfig.lstWorkPiece[iWorkPieceIndex].MouseResult = strResult;
            //                            }
            //                            else
            //                            {
            //                                ShowLog(workStatusInfo.nProcessID.ToString() + "获取喷嘴检测结果失败：结果为空!", 1);
            //                                //strMessage = "获取结果失败：结果为空!";
            //                            }
            //                        }
            //                    }

            //                }
            //                break;

            //            case 10006:
            //                //反光板清洗前
            //                if (workStatusInfo.nWorkStatus == 0)
            //                {
            //                    ShowLog("收到反光板清洗前回调");
            //                    int iIndex = hsl.ReadUShort("D3019", 1)[0];
            //                    WorkPiece wp = SoftConfig.lstWorkPiece.Where(x=>x.Index==iIndex).FirstOrDefault();
            //                    if (wp == null)
            //                    {
            //                        ShowLog("反光板清洗前未找到对应工件数据,index=" + iIndex.ToString() + " 工件集合:" + GetIndexString(), 1);
            //                        return;
            //                    }
            //                    Task.Run(() =>
            //                    {
            //                        Invoke(new Action(() =>
            //                        {
            //                            ImageSourceModuleTool tool = (ImageSourceModuleTool)VmSolution.Instance["反光板前.图像源1"];
            //                            ImageBaseData pic = tool.ModuResult.ImageData;
            //                            Image img = ImageBaseDataToBitmap(pic);
            //                            wp.BoardBefore = IndexOfTask + "_" + iIndex.ToString() + "_" + wp.BarCode + "_" + wp.Ocr + "_2.jpg";
            //                            SaveImage(img,SoftConfig.ImagePath + "\\" + wp.BoardBefore);
            //                        }));
            //                    });

            //                }
            //                break;
            //            case 10007:
            //                //反光板检测结果
            //                if (workStatusInfo.nWorkStatus == 0)
            //                {
            //                    int iIndex = hsl.ReadUShort("D3019", 1)[0];
            //                    WorkPiece wp = SoftConfig.lstWorkPiece.Where(x=>x.Index==iIndex).FirstOrDefault();
            //                    if (wp == null)
            //                    {
            //                        ShowLog("反光板清洗后未找到对应工件数据,index=" + iIndex.ToString() + " 工件集合:" + GetIndexString(), 1);
            //                        return;
            //                    }
            //                    int iWorkPieceIndex = GetWorkPieceIndexByIndex(iIndex);
            //                    List<VmDynamicIODefine.IoNameInfo> ioNameInfos = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetAllOutputNameInfo();
            //                    if (ioNameInfos.Count != 0)//判断流程结果个数是否为0
            //                    {
            //                        if (ioNameInfos[0].TypeName == IMVS_MODULE_BASE_DATA_TYPE.IMVS_GRAP_TYPE_STRING)//判断流程第一个结果是否为字符串类型
            //                        {

            //                            Task.Run(() =>
            //                            {
            //                                try
            //                                {
            //                                    int FlowCountStr = 0;
            //                                    string FlowResultStr = "";
            //                                    //获取流量信息
            //                                    if (CurrentType == EWorkPieceType.superbig)
            //                                    {
            //                                        FlowCountStr = hsl.ReadUShort("D5024", 1)[0];
            //                                        //FlowResultStr = hsl.ReadUShort("D5012",1)[0];
            //                                    }
            //                                    else
            //                                    {
            //                                        FlowCountStr = hsl.ReadUShort("D5022", 1)[0];
            //                                        //FlowResultStr = hsl.ReadUShort("D5002", 1)[0];
            //                                    }
            //                                    ShowLog("获取到流量值：" + FlowCountStr.ToString());

            //                                    //记录流量结果
            //                                    var vValue = SoftConfig.lstFlow.Where(x => x.Ocr == SoftConfig.lstWorkPiece[iWorkPieceIndex].Ocr).SingleOrDefault();
            //                                    int iThresholdValue = vValue == null ? 2000 : (int)vValue.Value;
            //                                    ShowLog("获取到流量阈值：" + iThresholdValue.ToString());
            //                                    FlowResultStr = FlowCountStr > iThresholdValue ? "OK" : "NG";
            //                                    SoftConfig.lstWorkPiece[iWorkPieceIndex].FlowResult = FlowResultStr;
            //                                    SoftConfig.lstWorkPiece[iWorkPieceIndex].FlowCount = FlowCountStr;
            //                                    //流量结果给plc
            //                                    hsl.WriteUshort("D5002", FlowCountStr > iThresholdValue ? (ushort)1 : (ushort)2);
            //                                    Invoke(new Action(() =>
            //                                    {
            //                                        ImageSourceModuleTool tool = (ImageSourceModuleTool)VmSolution.Instance["反光板.图像源1"];
            //                                        ImageBaseData pic = tool.ModuResult.ImageData;
            //                                        Image img = ImageBaseDataToBitmap(pic);
            //                                        wp.BoardAfter = IndexOfTask + "_" + iIndex.ToString() + "_" + wp.BarCode + "_" + wp.Ocr + "_4.jpg";
            //                                        SaveImage(img, SoftConfig.ImagePath + "\\" + wp.BoardAfter);

            //                                        FlowResult.Text = FlowResultStr;
            //                                        FlowResult.ForeColor = FlowResultStr == "OK" ? Color.Chartreuse : Color.Red;
            //                                        FlowCount.Text = FlowCountStr.ToString() + " ml/min";
            //                                    }));
            //                                    //多一次刷新
            //                                    CmdNeedRefresh.Enqueue("refresh");
            //                                }
            //                                catch (Exception ex)
            //                                {
            //                                    ShowLog("获取流量异常："+ex.Message,1);
            //                                }

            //                            });


            //                            //获取流程结果
            //                            string strResult = GetProcessByID(workStatusInfo.nProcessID).ModuResult.GetOutputString(ioNameInfos[0].Name).astStringVal[0].strValue;
            //                            if (strResult != null)
            //                            {
            //                                //实时显示结果
            //                                Invoke(new Action(() => {
            //                                    BoardResult.Text = strResult == "OK" ? "OK" : "NG";
            //                                    BoardResult.ForeColor = strResult == "OK" ? Color.Chartreuse : Color.Red;
            //                                }));
            //                                ShowLog("10007获取反光板检测结果:" + strResult, 0);
            //                                SoftConfig.lstWorkPiece[iWorkPieceIndex].ReflectBoardResult = strResult;

            //                            }
            //                            else
            //                            {
            //                                ShowLog("10007获取反光板结果失败：结果为空!", 1);
            //                                //strMessage = "获取结果失败：结果为空!";
            //                            }

            //                            //显示
            //                            //CmdNeedShow.Enqueue(iIndex);
            //                        }
            //                    }

            //                }
            //                break;
            //        }
            //        //回调后刷新示意图
            //        CmdNeedRefresh.Enqueue("refresh");
            //    }


            //}
            //catch (VmException ex)
            //{
            //    ShowLog("获取结果失败，错误码：0x" + Convert.ToString(ex.errorCode, 16),1);
            //}
            //catch (Exception ex)
            //{
            //    ShowLog("获取结果失败：" + Convert.ToString(ex.Message),1);
            //}
            #endregion
        }

        public void SaveImage(Image img,string strFile)
        {
            try
            {
                ImageModel im = new ImageModel();
                im.img = img;
                im.path = strFile;
                CmdImage.Enqueue(im);
            }
            catch (Exception ex)
            {
                ShowLog("图片任务异常:"+ex.Message+" "+strFile);
            }
        }



        public void ShowLog(string strContext,int Type=0)
        {
            Invoke(new Action(()=> {
                SoftConfig.iLogCount++;
                if (SoftConfig.iLogCount>=1000)
                {
                    lstLog.Items.Clear();
                    SoftConfig.iLogCount = 0;
                }
                lstLog.Items.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+" "+strContext);
                lstLog.SelectedIndex = lstLog.Items.Count - 1;
            }));
            lg.SendCommand(strContext,Type);
        }

        public bool ReportLog()
        {
            try
            {
                //上传结果
                if (SoftConfig.lstWorkPiece != null && SoftConfig.lstWorkPiece.Count > 0)
                {
                    //更新清洗次数
                    int iCount = int.Parse(SoftConfig.ini.IniReadValue("SOFT", "CleanCount"));
                    int iCleaned = SoftConfig.lstWorkPiece.Where(x => x.IsExist == true).Count();
                    SoftConfig.ini.IniWriteValue("SOFT", "CleanCount", (iCount + iCleaned).ToString());
                    for (int i = 0; i < SoftConfig.lstWorkPiece.Count; i++)
                    {
                        if (!SoftConfig.lstWorkPiece[i].IsExist)
                        {
                            continue;
                        }
                        CleanLog cl = new CleanLog();
                        cl.CabNo = SoftConfig.CabNo;
                        cl.WorkPieceIndex = SoftConfig.lstWorkPiece[i].Index;
                        cl.Exist = SoftConfig.lstWorkPiece[i].IsExist ? "1" : "0";
                        cl.LogTime = DateTime.Now;
                        cl.BarCode = SoftConfig.lstWorkPiece[i].BarCode;
                        cl.Ocr = SoftConfig.lstWorkPiece[i].Ocr;
                        cl.Type = SoftConfig.lstWorkPiece[i].Type.ToString();
                        cl.MouseResult = SoftConfig.lstWorkPiece[i].MouseResult;
                        cl.ReflectPanelResult = SoftConfig.lstWorkPiece[i].ReflectBoardResult;
                        cl.FlowResult= SoftConfig.lstWorkPiece[i].FlowResult;
                        cl.FlowCount = SoftConfig.lstWorkPiece[i].FlowCount;
                        cl.MouseBefore = SoftConfig.lstWorkPiece[i].MouseBefore;
                        cl.MouseAfter = SoftConfig.lstWorkPiece[i].MouseAfter;
                        cl.BoardBefore = SoftConfig.lstWorkPiece[i].BoardBefore;
                        cl.BoardAfter = SoftConfig.lstWorkPiece[i].BoardAfter;
                        cl.TaskIndex = IndexOfTask;
                        cl.Operator = SoftConfig.user.No;
                        WriteCVS(cl.TaskIndex+" "+cl.LogTime + " "+cl.WorkPieceIndex.ToString() + " " + cl.BarCode + " " + cl.Ocr + " " + cl.Type + " " + cl.MouseResult + " " + cl.ReflectPanelResult+" "+ cl.FlowResult + " " + cl.FlowCount.ToString(), "LogFile");
                        SoftConfig.db.CleanLog.Add(cl);
                    }
                    SoftConfig.db.SaveChanges();
                    
                }
                return true;
            }
            catch (Exception ex)
            {
                ShowLog("写日志异常:"+ex.Message,1);
                return false;
            }
        }

        private void WriteCVS(string str, string strFileName)
        {
            string strNow;
            string strLog;
            strNow = DateTime.Now.ToString("HH:mm:ss.ffff");

            string strToday;
            string strLogPath;
            strToday = DateTime.Now.ToString("yyyy-MM-dd");
            //strLogPath = System.Windows.Forms.Application.StartupPath + "\\Log";
            strLogPath = System.Environment.CurrentDirectory + "\\CVS";
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
                sw.WriteLine(str);
                sw.Close();
            }
            catch (System.Exception ex)
            {

            }
        }

        public int GetWorkPieceIndexByIndex(int index)
        {
            for (int i = 0; i < SoftConfig.lstWorkPiece.Count; i++)
            {
                if (SoftConfig.lstWorkPiece[i].Index == index)
                {
                    return i;
                }
            }
            return -1;
        }


        public string IndexOfTask = "";
        //public void GetInfoByResultSmall(string str)
        //{
        //    try
        //    {
        //        string[] Str = str.Split(';');
        //        string type = Str[0];//大中小 321
        //        string PhotoTime = Str[1];//拍照次数
        //        string info1 = Str[2];//1产品信息
        //        string info2 = Str[3];//2产品信息
        //        string info3 = Str[4];//3产品信息
        //        string info4 = Str[5];//4产品信息
        //        string info5 = Str[6];//5产品信息
        //        string info6 = Str[7];//6产品信息
        //        WorkPiece wp1 = new WorkPiece();
        //        WorkPiece wp2 = new WorkPiece();
        //        WorkPiece wp3 = new WorkPiece();
        //        WorkPiece wp4 = new WorkPiece();
        //        WorkPiece wp5 = new WorkPiece();
        //        WorkPiece wp6 = new WorkPiece();

        //        switch (PhotoTime)
        //        {   //第一次拍照
        //            case "1":
        //                //初始化任务序号
        //                IndexOfTask = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00");
        //                //生成示意图
        //                GenMap(EWorkPieceType.small);

        //                string[] str1 = info1.Split(',');//分割产品信息1
        //                string flag1 = str1[0];//产品1信息
        //                string ocr1 = str1[2];
        //                string code1 = str1[1];
        //                if (flag1 == "1")
        //                {
        //                    hsl.WriteInt(hsl.locationX1, 1);
        //                    hsl.WriteInt(hsl.locationY1, 1);
        //                }
        //                else
        //                {
        //                    hsl.WriteInt(hsl.locationX1, 0);
        //                    hsl.WriteInt(hsl.locationY1, 0);
        //                }

        //                wp1.Index = 1;
        //                wp1.Type = CurrentType;
        //                wp1.IsExist = flag1 == "1" ? true : false;
        //                wp1.Ocr = ocr1;
        //                wp1.BarCode = code1;


        //                string[] str2 = info2.Split(',');//分割产品信息2
        //                string flag2 = str2[0];//产品2信息
        //                string ocr2 = str2[2];
        //                string code2 = str2[1];
        //                if (flag2 == "1")
        //                {
        //                    hsl.WriteInt(hsl.locationX2, 2);
        //                    hsl.WriteInt(hsl.locationY2, 1);
        //                }
        //                else
        //                {
        //                    hsl.WriteInt(hsl.locationX2, 0);
        //                    hsl.WriteInt(hsl.locationY2, 0);
        //                }

        //                wp2.Index = 2;
        //                wp2.Type = CurrentType;
        //                wp2.IsExist = flag2 == "1" ? true : false;
        //                wp2.Ocr = ocr2;
        //                wp2.BarCode = code2;


        //                string[] str3 = info3.Split(',');//分割产品信息3
        //                string flag3 = str3[0];//产品2信息
        //                string ocr3 = str3[2];
        //                string code3 = str3[1];
        //                if (flag3 == "1")
        //                {
        //                    hsl.WriteInt(hsl.locationX3, 1);
        //                    hsl.WriteInt(hsl.locationY3, 2);
        //                }
        //                else
        //                {
        //                    hsl.WriteInt(hsl.locationX3, 0);
        //                    hsl.WriteInt(hsl.locationY3, 0);
        //                }

        //                wp3.Index = 3;
        //                wp3.Type = CurrentType;
        //                wp3.IsExist = flag3 == "1" ? true : false;
        //                wp3.Ocr = ocr3;
        //                wp3.BarCode = code3;


        //                string[] str4 = info4.Split(',');//分割产品信息4
        //                string flag4 = str4[0];//产品4信息
        //                string ocr4 = str4[2];
        //                string code4 = str4[1];
        //                if (flag4 == "1")
        //                {
        //                    hsl.WriteInt(hsl.locationX4, 2);
        //                    hsl.WriteInt(hsl.locationY4, 2);
        //                }
        //                else
        //                {
        //                    hsl.WriteInt(hsl.locationX4, 0);
        //                    hsl.WriteInt(hsl.locationY4, 0);
        //                }

        //                wp4.Index = 4;
        //                wp4.Type = CurrentType;
        //                wp4.IsExist = flag4 == "1" ? true : false;
        //                wp4.Ocr = ocr4;
        //                wp4.BarCode = code4;


        //                string[] str5 = info5.Split(',');//分割产品信息5
        //                string flag5 = str5[0];//产品5信息
        //                string ocr5 = str5[2];
        //                string code5 = str5[1];
        //                if (flag5 == "1")
        //                {
        //                    hsl.WriteInt(hsl.locationX5, 1);
        //                    hsl.WriteInt(hsl.locationY5, 3);
        //                }
        //                else
        //                {
        //                    hsl.WriteInt(hsl.locationX5, 0);
        //                    hsl.WriteInt(hsl.locationY5, 0);
        //                }

        //                wp5.Index = 5;
        //                wp5.Type = CurrentType;
        //                wp5.IsExist = flag5 == "1" ? true : false;
        //                wp5.Ocr = ocr5;
        //                wp5.BarCode = code5;


        //                string[] str6 = info6.Split(',');//分割产品信息6
        //                string flag6 = str6[0];//产品6信息
        //                string ocr6 = str6[2];
        //                string code6 = str6[1];
        //                if (flag6 == "1")
        //                {
        //                    hsl.WriteInt(hsl.locationX6, 2);
        //                    hsl.WriteInt(hsl.locationY6, 3);
        //                }
        //                else
        //                {
        //                    hsl.WriteInt(hsl.locationX6, 0);
        //                    hsl.WriteInt(hsl.locationY6, 0);
        //                }

        //                wp6.Index = 6;
        //                wp6.Type = CurrentType;
        //                wp6.IsExist = flag6 == "1" ? true : false;
        //                wp6.Ocr = ocr6;
        //                wp6.BarCode = code6;

        //                SoftConfig.lstWorkPiece.Add(wp1);
        //                SoftConfig.lstWorkPiece.Add(wp2);
        //                SoftConfig.lstWorkPiece.Add(wp3);
        //                SoftConfig.lstWorkPiece.Add(wp4);
        //                SoftConfig.lstWorkPiece.Add(wp5);
        //                SoftConfig.lstWorkPiece.Add(wp6);

        //                break;
        //            //第二次拍照

        //            case "2":
        //                string[] str7 = info1.Split(',');//分割产品信息7
        //                string flag7 = str7[0];//产品7信息
        //                string ocr7 = str7[2];
        //                string code7 = str7[1];
        //                if (flag7 == "1")
        //                {
        //                    hsl.WriteInt(hsl.locationX7, 3);
        //                    hsl.WriteInt(hsl.locationY7, 1);
        //                }
        //                else
        //                {
        //                    hsl.WriteInt(hsl.locationX7, 0);
        //                    hsl.WriteInt(hsl.locationY7, 0);
        //                }
        //                wp1.Index = 7;
        //                wp1.Type = CurrentType;
        //                wp1.IsExist = flag7 == "1" ? true : false;
        //                wp1.Ocr = ocr7;
        //                wp1.BarCode = code7;

        //                string[] str8 = info2.Split(',');//分割产品信息8
        //                string flag8 = str8[0];//产品8信息
        //                string ocr8 = str8[2];
        //                string code8 = str8[1];
        //                if (flag8 == "1")
        //                {
        //                    hsl.WriteInt(hsl.locationX8, 4);
        //                    hsl.WriteInt(hsl.locationY8, 1);
        //                }
        //                else
        //                {
        //                    hsl.WriteInt(hsl.locationX8, 0);
        //                    hsl.WriteInt(hsl.locationY8, 0);
        //                }
        //                wp2.Index = 8;
        //                wp2.Type = CurrentType;
        //                wp2.IsExist = flag8 == "1" ? true : false;
        //                wp2.Ocr = ocr8;
        //                wp2.BarCode = code8;

        //                string[] str9 = info3.Split(',');//分割产品信息9
        //                string flag9 = str9[0];//产品9信息
        //                string ocr9 = str9[2];
        //                string code9 = str9[1];
        //                if (flag9 == "1")
        //                {
        //                    hsl.WriteInt(hsl.locationX9, 3);
        //                    hsl.WriteInt(hsl.locationY9, 2);
        //                }
        //                else
        //                {
        //                    hsl.WriteInt(hsl.locationX9, 0);
        //                    hsl.WriteInt(hsl.locationY9, 0);
        //                }
        //                wp3.Index = 9;
        //                wp3.Type = CurrentType;
        //                wp3.IsExist = flag9 == "1" ? true : false;
        //                wp3.Ocr = ocr9;
        //                wp3.BarCode = code9;

        //                string[] str10 = info4.Split(',');//分割产品信息10
        //                string flag10 = str10[0];//产品10信息
        //                string ocr10 = str10[2];
        //                string code10 = str10[1];
        //                if (flag10 == "1")
        //                {
        //                    hsl.WriteInt(hsl.locationX10, 4);
        //                    hsl.WriteInt(hsl.locationY10, 2);
        //                }
        //                else
        //                {
        //                    hsl.WriteInt(hsl.locationX10, 0);
        //                    hsl.WriteInt(hsl.locationY10, 0);
        //                }
        //                wp4.Index = 10;
        //                wp4.Type = CurrentType;
        //                wp4.IsExist = flag10 == "1" ? true : false;
        //                wp4.Ocr = ocr10;
        //                wp4.BarCode = code10;

        //                string[] str11 = info5.Split(',');//分割产品信息11
        //                string flag11 = str11[0];//产品11信息
        //                string ocr11 = str11[2];
        //                string code11 = str11[1];
        //                if (flag11 == "1")
        //                {
        //                    hsl.WriteInt(hsl.locationX11, 3);
        //                    hsl.WriteInt(hsl.locationY11, 3);
        //                }
        //                else
        //                {
        //                    hsl.WriteInt(hsl.locationX11, 0);
        //                    hsl.WriteInt(hsl.locationY11, 0);
        //                }
        //                wp5.Index = 11;
        //                wp5.Type = CurrentType;
        //                wp5.IsExist = flag11 == "1" ? true : false;
        //                wp5.Ocr = ocr11;
        //                wp5.BarCode = code11;

        //                string[] str12 = info6.Split(',');//分割产品信息12
        //                string flag12 = str12[0];//产品12信息
        //                string ocr12 = str12[2];
        //                string code12 = str12[1];
        //                if (flag12 == "1")
        //                {
        //                    hsl.WriteInt(hsl.locationX12, 4);
        //                    hsl.WriteInt(hsl.locationY12, 3);
        //                }
        //                else
        //                {
        //                    hsl.WriteInt(hsl.locationX12, 0);
        //                    hsl.WriteInt(hsl.locationY12, 0);
        //                }
        //                wp6.Index = 12;
        //                wp6.Type = CurrentType;
        //                wp6.IsExist = flag12 == "1" ? true : false;
        //                wp6.Ocr = ocr12;
        //                wp6.BarCode = code12;
        //                SoftConfig.lstWorkPiece.Add(wp1);
        //                SoftConfig.lstWorkPiece.Add(wp2);
        //                SoftConfig.lstWorkPiece.Add(wp3);
        //                SoftConfig.lstWorkPiece.Add(wp4);
        //                SoftConfig.lstWorkPiece.Add(wp5);
        //                SoftConfig.lstWorkPiece.Add(wp6);

        //                break;


        //            //第三次拍照

        //            case "3":
        //                string[] str13 = info1.Split(',');//分割产品信息13
        //                string flag13 = str13[0];//产品13信息
        //                string ocr13 = str13[2];
        //                string code13 = str13[1];
        //                if (flag13 == "1")
        //                {
        //                    hsl.WriteInt(hsl.locationX13, 1);
        //                    hsl.WriteInt(hsl.locationY13, 4);
        //                }
        //                else
        //                {
        //                    hsl.WriteInt(hsl.locationX13, 0);
        //                    hsl.WriteInt(hsl.locationY13, 0);
        //                }
        //                wp1.Index = 13;
        //                wp1.Type = CurrentType;
        //                wp1.IsExist = flag13 == "1" ? true : false;
        //                wp1.Ocr = ocr13;
        //                wp1.BarCode = code13;

        //                string[] str14 = info2.Split(',');//分割产品信息14
        //                string flag14 = str14[0];//产品14信息
        //                string ocr14 = str14[2];
        //                string code14 = str14[1];
        //                if (flag14 == "1")
        //                {
        //                    hsl.WriteInt(hsl.locationX14, 2);
        //                    hsl.WriteInt(hsl.locationY14, 4);
        //                }
        //                else
        //                {
        //                    hsl.WriteInt(hsl.locationX14, 0);
        //                    hsl.WriteInt(hsl.locationY14, 0);
        //                }
        //                wp2.Index = 14;
        //                wp2.Type = CurrentType;
        //                wp2.IsExist = flag14 == "1" ? true : false;
        //                wp2.Ocr = ocr14;
        //                wp2.BarCode = code14;

        //                string[] str15 = info3.Split(',');//分割产品信息15
        //                string flag15 = str15[0];//产品15信息
        //                string ocr15 = str15[2];
        //                string code15 = str15[1];
        //                if (flag15 == "1")
        //                {
        //                    hsl.WriteInt(hsl.locationX15, 1);
        //                    hsl.WriteInt(hsl.locationY15, 5);
        //                }
        //                else
        //                {
        //                    hsl.WriteInt(hsl.locationX15, 0);
        //                    hsl.WriteInt(hsl.locationY15, 0);
        //                }
        //                wp3.Index = 15;
        //                wp3.Type = CurrentType;
        //                wp3.IsExist = flag15 == "1" ? true : false;
        //                wp3.Ocr = ocr15;
        //                wp3.BarCode = code15;

        //                string[] str16 = info4.Split(',');//分割产品信息16
        //                string flag16 = str16[0];//产品16信息
        //                string ocr16 = str16[2];
        //                string code16 = str16[1];
        //                if (flag16 == "1")
        //                {
        //                    hsl.WriteInt(hsl.locationX16, 2);
        //                    hsl.WriteInt(hsl.locationY16, 5);
        //                }
        //                else
        //                {
        //                    hsl.WriteInt(hsl.locationX16, 0);
        //                    hsl.WriteInt(hsl.locationY16, 0);
        //                }
        //                wp4.Index = 16;
        //                wp4.Type = CurrentType;
        //                wp4.IsExist = flag16 == "1" ? true : false;
        //                wp4.Ocr = ocr16;
        //                wp4.BarCode = code16;

        //                string[] str17 = info5.Split(',');//分割产品信息17
        //                string flag17 = str17[0];//产品17信息
        //                string ocr17 = str17[2];
        //                string code17 = str17[1];
        //                if (flag17 == "1")
        //                {
        //                    hsl.WriteInt(hsl.locationX17, 1);
        //                    hsl.WriteInt(hsl.locationY17, 6);
        //                }
        //                else
        //                {
        //                    hsl.WriteInt(hsl.locationX17, 0);
        //                    hsl.WriteInt(hsl.locationY17, 0);
        //                }
        //                wp5.Index = 17;
        //                wp5.Type = CurrentType;
        //                wp5.IsExist = flag17 == "1" ? true : false;
        //                wp5.Ocr = ocr17;
        //                wp5.BarCode = code17;

        //                string[] str18 = info6.Split(',');//分割产品信息18
        //                string flag18 = str18[0];//产品18信息
        //                string ocr18 = str18[2];
        //                string code18 = str18[1];
        //                if (flag18 == "1")
        //                {
        //                    hsl.WriteInt(hsl.locationX18, 2);
        //                    hsl.WriteInt(hsl.locationY18, 6);
        //                }
        //                else
        //                {
        //                    hsl.WriteInt(hsl.locationX18, 0);
        //                    hsl.WriteInt(hsl.locationY18, 0);
        //                }
        //                wp6.Index = 18;
        //                wp6.Type = CurrentType;
        //                wp6.IsExist = flag18 == "1" ? true : false;
        //                wp6.Ocr = ocr18;
        //                wp6.BarCode = code18;
        //                SoftConfig.lstWorkPiece.Add(wp1);
        //                SoftConfig.lstWorkPiece.Add(wp2);
        //                SoftConfig.lstWorkPiece.Add(wp3);
        //                SoftConfig.lstWorkPiece.Add(wp4);
        //                SoftConfig.lstWorkPiece.Add(wp5);
        //                SoftConfig.lstWorkPiece.Add(wp6);

        //                break;


        //            //第四次拍照

        //            case "4":
        //                string[] str19 = info1.Split(',');//分割产品信息19
        //                string flag19 = str19[0];//产品19信息
        //                string ocr19 = str19[2];
        //                string code19 = str19[1];
        //                if (flag19 == "1")
        //                {
        //                    hsl.WriteInt(hsl.locationX19, 3);
        //                    hsl.WriteInt(hsl.locationY19, 4);
        //                }
        //                else
        //                {
        //                    hsl.WriteInt(hsl.locationX19, 0);
        //                    hsl.WriteInt(hsl.locationY19, 0);
        //                }
        //                wp1.Index = 19;
        //                wp1.Type = CurrentType;
        //                wp1.IsExist = flag19 == "1" ? true : false;
        //                wp1.Ocr = ocr19;
        //                wp1.BarCode = code19;

        //                string[] str20 = info2.Split(',');//分割产品信息20
        //                string flag20 = str20[0];//产品20信息
        //                string ocr20 = str20[2];
        //                string code20 = str20[1];
        //                if (flag20 == "1")
        //                {
        //                    hsl.WriteInt(hsl.locationX20, 4);
        //                    hsl.WriteInt(hsl.locationY20, 4);
        //                }
        //                else
        //                {
        //                    hsl.WriteInt(hsl.locationX20, 0);
        //                    hsl.WriteInt(hsl.locationY20, 0);
        //                }
        //                wp2.Index = 20;
        //                wp2.Type = CurrentType;
        //                wp2.IsExist = flag20 == "1" ? true : false;
        //                wp2.Ocr = ocr20;
        //                wp2.BarCode = code20;

        //                string[] str21 = info3.Split(',');//分割产品信息21
        //                string flag21 = str21[0];//产品21信息
        //                string ocr21 = str21[2];
        //                string code21 = str21[1];
        //                if (flag21 == "1")
        //                {
        //                    hsl.WriteInt(hsl.locationX21, 3);
        //                    hsl.WriteInt(hsl.locationY21, 5);
        //                }
        //                else
        //                {
        //                    hsl.WriteInt(hsl.locationX21, 0);
        //                    hsl.WriteInt(hsl.locationY21, 0);
        //                }
        //                wp3.Index = 21;
        //                wp3.Type = CurrentType;
        //                wp3.IsExist = flag21 == "1" ? true : false;
        //                wp3.Ocr = ocr21;
        //                wp3.BarCode = code21;

        //                string[] str22 = info4.Split(',');//分割产品信息22
        //                string flag22 = str22[0];//产品22信息
        //                string ocr22 = str22[2];
        //                string code22 = str22[1];
        //                if (flag22 == "1")
        //                {
        //                    hsl.WriteInt(hsl.locationX22, 4);
        //                    hsl.WriteInt(hsl.locationY22, 5);
        //                }
        //                else
        //                {
        //                    hsl.WriteInt(hsl.locationX22, 0);
        //                    hsl.WriteInt(hsl.locationY22, 0);
        //                }
        //                wp4.Index = 22;
        //                wp4.Type = CurrentType;
        //                wp4.IsExist = flag22 == "1" ? true : false;
        //                wp4.Ocr = ocr22;
        //                wp4.BarCode = code22;

        //                string[] str23 = info5.Split(',');//分割产品信息23
        //                string flag23 = str23[0];//产品23信息
        //                string ocr23 = str23[2];
        //                string code23 = str23[1];
        //                if (flag23 == "1")
        //                {
        //                    hsl.WriteInt(hsl.locationX23, 3);
        //                    hsl.WriteInt(hsl.locationY23, 6);
        //                }
        //                else
        //                {
        //                    hsl.WriteInt(hsl.locationX23, 0);
        //                    hsl.WriteInt(hsl.locationY23, 0);
        //                }
        //                wp5.Index = 23;
        //                wp5.Type = CurrentType;
        //                wp5.IsExist = flag23 == "1" ? true : false;
        //                wp5.Ocr = ocr23;
        //                wp5.BarCode = code23;

        //                string[] str24 = info6.Split(',');//分割产品信息24
        //                string flag24 = str24[0];//产品24信息
        //                string ocr24 = str24[2];
        //                string code24 = str24[1];
        //                if (flag24 == "1")
        //                {
        //                    hsl.WriteInt(hsl.locationX24, 4);
        //                    hsl.WriteInt(hsl.locationY24, 6);
        //                }
        //                else
        //                {
        //                    hsl.WriteInt(hsl.locationX24, 0);
        //                    hsl.WriteInt(hsl.locationY24, 0);
        //                }
        //                wp6.Index = 24;
        //                wp6.Type = CurrentType;
        //                wp6.IsExist = flag24 == "1" ? true : false;
        //                wp6.Ocr = ocr24;
        //                wp6.BarCode = code24;
        //                SoftConfig.lstWorkPiece.Add(wp1);
        //                SoftConfig.lstWorkPiece.Add(wp2);
        //                SoftConfig.lstWorkPiece.Add(wp3);
        //                SoftConfig.lstWorkPiece.Add(wp4);
        //                SoftConfig.lstWorkPiece.Add(wp5);
        //                SoftConfig.lstWorkPiece.Add(wp6);

        //                break;

        //            //第5次拍照

        //            case "5":
        //                string[] str25 = info1.Split(',');//分割产品信息25
        //                string flag25 = str25[0];//产品25信息
        //                string ocr25 = str25[2];
        //                string code25 = str25[1];
        //                if (flag25 == "1")
        //                {
        //                    hsl.WriteInt(hsl.locationX25, 1);
        //                    hsl.WriteInt(hsl.locationY25, 7);
        //                }
        //                else
        //                {
        //                    hsl.WriteInt(hsl.locationX25, 0);
        //                    hsl.WriteInt(hsl.locationY25, 0);
        //                }
        //                wp1.Index = 25;
        //                wp1.Type = CurrentType;
        //                wp1.IsExist = flag25 == "1" ? true : false;
        //                wp1.Ocr = ocr25;
        //                wp1.BarCode = code25;

        //                string[] str26 = info2.Split(',');//分割产品信息26
        //                string flag26 = str26[0];//产品26信息
        //                string ocr26 = str26[2];
        //                string code26 = str26[1];
        //                if (flag26 == "1")
        //                {
        //                    hsl.WriteInt(hsl.locationX26, 2);
        //                    hsl.WriteInt(hsl.locationY26, 7);
        //                }
        //                else
        //                {
        //                    hsl.WriteInt(hsl.locationX26, 0);
        //                    hsl.WriteInt(hsl.locationY26, 0);
        //                }
        //                wp2.Index = 26;
        //                wp2.Type = CurrentType;
        //                wp2.IsExist = flag26 == "1" ? true : false;
        //                wp2.Ocr = ocr26;
        //                wp2.BarCode = code26;

        //                string[] str27 = info3.Split(',');//分割产品信息27
        //                string flag27 = str27[0];//产品27信息
        //                string ocr27 = str27[2];
        //                string code27 = str27[1];
        //                if (flag27 == "1")
        //                {
        //                    hsl.WriteInt(hsl.locationX27, 1);
        //                    hsl.WriteInt(hsl.locationY27, 8);
        //                }
        //                else
        //                {
        //                    hsl.WriteInt(hsl.locationX27, 0);
        //                    hsl.WriteInt(hsl.locationY27, 0);
        //                }
        //                wp3.Index = 27;
        //                wp3.Type = CurrentType;
        //                wp3.IsExist = flag27 == "1" ? true : false;
        //                wp3.Ocr = ocr27;
        //                wp3.BarCode = code27;

        //                string[] str28 = info4.Split(',');//分割产品信息28
        //                string flag28 = str28[0];//产品28信息
        //                string ocr28 = str28[2];
        //                string code28 = str28[1];
        //                if (flag28 == "1")
        //                {
        //                    hsl.WriteInt(hsl.locationX28, 2);
        //                    hsl.WriteInt(hsl.locationY28, 8);
        //                }
        //                else
        //                {
        //                    hsl.WriteInt(hsl.locationX28, 0);
        //                    hsl.WriteInt(hsl.locationY28, 0);
        //                }
        //                wp4.Index = 28;
        //                wp4.Type = CurrentType;
        //                wp4.IsExist = flag28 == "1" ? true : false;
        //                wp4.Ocr = ocr28;
        //                wp4.BarCode = code28;
        //                SoftConfig.lstWorkPiece.Add(wp1);
        //                SoftConfig.lstWorkPiece.Add(wp2);
        //                SoftConfig.lstWorkPiece.Add(wp3);
        //                SoftConfig.lstWorkPiece.Add(wp4);

        //                break;


        //            //第6次拍照

        //            case "6":
        //                string[] str29 = info1.Split(',');//分割产品信息29
        //                string flag29 = str29[0];//产品29信息
        //                string ocr29 = str29[2];
        //                string code29 = str29[1];
        //                if (flag29 == "1")
        //                {
        //                    hsl.WriteInt(hsl.locationX29, 3);
        //                    hsl.WriteInt(hsl.locationY29, 7);
        //                }
        //                else
        //                {
        //                    hsl.WriteInt(hsl.locationX29, 0);
        //                    hsl.WriteInt(hsl.locationY29, 0);
        //                }
        //                wp1.Index = 29;
        //                wp1.Type = CurrentType;
        //                wp1.IsExist = flag29 == "1" ? true : false;
        //                wp1.Ocr = ocr29;
        //                wp1.BarCode = code29;

        //                string[] str30 = info2.Split(',');//分割产品信息30
        //                string flag30 = str30[0];//产品30信息
        //                string ocr30 = str30[2];
        //                string code30 = str30[1];
        //                if (flag30 == "1")
        //                {
        //                    hsl.WriteInt(hsl.locationX30, 4);
        //                    hsl.WriteInt(hsl.locationY30, 7);
        //                }
        //                else
        //                {
        //                    hsl.WriteInt(hsl.locationX30, 0);
        //                    hsl.WriteInt(hsl.locationY30, 0);
        //                }
        //                wp2.Index = 30;
        //                wp2.Type = CurrentType;
        //                wp2.IsExist = flag30 == "1" ? true : false;
        //                wp2.Ocr = ocr30;
        //                wp2.BarCode = code30;

        //                string[] str31 = info3.Split(',');//分割产品信息31
        //                string flag31 = str31[0];//产品31信息
        //                string ocr31 = str31[2];
        //                string code31 = str31[1];
        //                if (flag31 == "1")
        //                {
        //                    hsl.WriteInt(hsl.locationX31, 3);
        //                    hsl.WriteInt(hsl.locationY31, 8);
        //                }
        //                else
        //                {
        //                    hsl.WriteInt(hsl.locationX31, 0);
        //                    hsl.WriteInt(hsl.locationY31, 0);
        //                }
        //                wp3.Index = 31;
        //                wp3.Type = CurrentType;
        //                wp3.IsExist = flag31 == "1" ? true : false;
        //                wp3.Ocr = ocr31;
        //                wp3.BarCode = code31;

        //                string[] str32 = info4.Split(',');//分割产品信息32
        //                string flag32 = str32[0];//产品32信息
        //                string ocr32 = str32[2];
        //                string code32 = str32[1];
        //                if (flag32 == "1")
        //                {
        //                    hsl.WriteInt(hsl.locationX32, 4);
        //                    hsl.WriteInt(hsl.locationY32, 8);
        //                }
        //                else
        //                {
        //                    hsl.WriteInt(hsl.locationX32, 0);
        //                    hsl.WriteInt(hsl.locationY32, 0);
        //                }
        //                wp4.Index = 32;
        //                wp4.Type = CurrentType;
        //                wp4.IsExist = flag32 == "1" ? true : false;
        //                wp4.Ocr = ocr32;
        //                wp4.BarCode = code32;
        //                SoftConfig.lstWorkPiece.Add(wp1);
        //                SoftConfig.lstWorkPiece.Add(wp2);
        //                SoftConfig.lstWorkPiece.Add(wp3);
        //                SoftConfig.lstWorkPiece.Add(wp4);

        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ShowLog("解析错误:"+ex.Message,1);
        //    }
        //}

        public void GetInfoByResultSmall(string str)
        {
            try
            {
                string[] Str = str.Split(';');
                string type = Str[0];//大中小 321
                string PhotoTime = Str[1];//拍照次数
                string info1 = Str[2];//1产品信息

                WorkPiece wp1 = new WorkPiece();
                string[] str1 = info1.Split(',');//分割产品信息1
                string flag = str1[0];//产品1信息
                string ocr1 = str1[2];
                string code1 = str1[1];
                wp1.Index = int.Parse(PhotoTime);
                wp1.Type = CurrentType;
                wp1.IsExist = flag == "1" ? true : false;
                wp1.Ocr = ocr1;
                wp1.BarCode = code1;
                SoftConfig.lstWorkPiece.Add(wp1);
                if (PhotoTime=="1")
                {
                    //初始化任务序号
                    IndexOfTask = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00");
                    //生成示意图
                    GenMap(EWorkPieceType.small);

                    if (flag == "1")
                    {
                        hsl.WriteInt(hsl.locationX1, 1);
                        hsl.WriteInt(hsl.locationY1, 1);
                        ShowLog("写PLC工件1数据1:"+ hsl.locationX1+"-"+ hsl.locationY1);
                    }
                    else
                    {
                        hsl.WriteInt(hsl.locationX1, 0);
                        hsl.WriteInt(hsl.locationY1, 0);
                        ShowLog("写PLC工件1数据0:" + hsl.locationX1 + "-" + hsl.locationY1);
                    }
                }
                else
                {
                    switch(PhotoTime)
                    {
                        case "2":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX2, 1);
                                hsl.WriteInt(hsl.locationY2, 2);
                                ShowLog("写PLC工件2数据1:" + hsl.locationX2 + "-" + hsl.locationY2);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX2, 0);
                                hsl.WriteInt(hsl.locationY2, 0);
                                ShowLog("写PLC工件2数据0:" + hsl.locationX2 + "-" + hsl.locationY2);
                            }
                            break;
                        case "3":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX3, 1);
                                hsl.WriteInt(hsl.locationY3, 3);
                                ShowLog("写PLC工件3数据1:" + hsl.locationX3 + "-" + hsl.locationY3);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX3, 0);
                                hsl.WriteInt(hsl.locationY3, 0);
                                ShowLog("写PLC工件3数据0:" + hsl.locationX3 + "-" + hsl.locationY3);
                            }
                            break;
                        case "4":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX4, 1);
                                hsl.WriteInt(hsl.locationY4, 4);
                                ShowLog("写PLC工件4数据1:" + hsl.locationX4 + "-" + hsl.locationY4);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX4, 0);
                                hsl.WriteInt(hsl.locationY4, 0);
                                ShowLog("写PLC工件4数据0:" + hsl.locationX4 + "-" + hsl.locationY4);
                            }
                            break;
                        case "5":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX5, 1);
                                hsl.WriteInt(hsl.locationY5, 5);
                                ShowLog("写PLC工件5数据1:" + hsl.locationX5 + "-" + hsl.locationY5);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX5, 0);
                                hsl.WriteInt(hsl.locationY5, 0);
                                ShowLog("写PLC工件5数据0:" + hsl.locationX5 + "-" + hsl.locationY5);
                            }
                            break;
                        case "6":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX6, 1);
                                hsl.WriteInt(hsl.locationY6, 6);
                                ShowLog("写PLC工件6数据1:" + hsl.locationX6 + "-" + hsl.locationY6);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX6, 0);
                                hsl.WriteInt(hsl.locationY6, 0);
                                ShowLog("写PLC工件6数据0:" + hsl.locationX6 + "-" + hsl.locationY6);
                            }
                            break;
                        case "7":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX7, 1);
                                hsl.WriteInt(hsl.locationY7, 7);
                                ShowLog("写PLC工件7数据1:" + hsl.locationX7 + "-" + hsl.locationY7);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX7, 0);
                                hsl.WriteInt(hsl.locationY7, 0);
                                ShowLog("写PLC工件7数据0:" + hsl.locationX7 + "-" + hsl.locationY7);
                            }
                            break;
                        case "8":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX8, 1);
                                hsl.WriteInt(hsl.locationY8, 8);
                                ShowLog("写PLC工件8数据1:" + hsl.locationX8 + "-" + hsl.locationY8);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX8, 0);
                                hsl.WriteInt(hsl.locationY8, 0);
                                ShowLog("写PLC工件8数据0:" + hsl.locationX8 + "-" + hsl.locationY8);
                            }
                            break;
                        case "9":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX9, 2);
                                hsl.WriteInt(hsl.locationY9, 1);
                                ShowLog("写PLC工件9数据1:" + hsl.locationX9 + "-" + hsl.locationY9);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX9, 0);
                                hsl.WriteInt(hsl.locationY9, 0);
                                ShowLog("写PLC工件9数据0:" + hsl.locationX9 + "-" + hsl.locationY9);
                            }
                            break;
                        case "10":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX10, 2);
                                hsl.WriteInt(hsl.locationY10, 2);
                                ShowLog("写PLC工件10数据1:" + hsl.locationX10 + "-" + hsl.locationY10);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX10, 0);
                                hsl.WriteInt(hsl.locationY10, 0);
                                ShowLog("写PLC工件10数据0:" + hsl.locationX10 + "-" + hsl.locationY10);
                            }
                            break;
                        case "11":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX11, 2);
                                hsl.WriteInt(hsl.locationY11, 3);
                                ShowLog("写PLC工件11数据1:" + hsl.locationX11 + "-" + hsl.locationY11);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX11, 0);
                                hsl.WriteInt(hsl.locationY11, 0);
                                ShowLog("写PLC工件11数据0:" + hsl.locationX11 + "-" + hsl.locationY11);
                            }
                            break;
                        case "12":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX12, 2);
                                hsl.WriteInt(hsl.locationY12, 4);
                                ShowLog("写PLC工件12数据1:" + hsl.locationX12 + "-" + hsl.locationY12);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX12, 0);
                                hsl.WriteInt(hsl.locationY12, 0);
                                ShowLog("写PLC工件12数据0:" + hsl.locationX12 + "-" + hsl.locationY12);
                            }
                            break;
                        case "13":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX13, 2);
                                hsl.WriteInt(hsl.locationY13, 5);
                                ShowLog("写PLC工件13数据1:" + hsl.locationX13 + "-" + hsl.locationY13);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX13, 0);
                                hsl.WriteInt(hsl.locationY13, 0);
                                ShowLog("写PLC工件13数据0:" + hsl.locationX13 + "-" + hsl.locationY13);
                            }
                            break;
                        case "14":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX14, 2);
                                hsl.WriteInt(hsl.locationY14, 6);
                                ShowLog("写PLC工件14数据1:" + hsl.locationX14 + "-" + hsl.locationY14);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX14, 0);
                                hsl.WriteInt(hsl.locationY14, 0);
                                ShowLog("写PLC工件14数据0:" + hsl.locationX14 + "-" + hsl.locationY14);
                            }
                            break;
                        case "15":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX15, 2);
                                hsl.WriteInt(hsl.locationY15, 7);
                                ShowLog("写PLC工件15数据1:" + hsl.locationX15 + "-" + hsl.locationY15);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX15, 0);
                                hsl.WriteInt(hsl.locationY15, 0);
                                ShowLog("写PLC工件15数据0:" + hsl.locationX15 + "-" + hsl.locationY15);
                            }
                            break;
                        case "16":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX16, 2);
                                hsl.WriteInt(hsl.locationY16, 8);
                                ShowLog("写PLC工件16数据1:" + hsl.locationX16 + "-" + hsl.locationY16);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX16, 0);
                                hsl.WriteInt(hsl.locationY16, 0);
                                ShowLog("写PLC工件16数据0:" + hsl.locationX16 + "-" + hsl.locationY16);
                            }
                            break;
                        case "17":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX17, 3);
                                hsl.WriteInt(hsl.locationY17, 1);
                                ShowLog("写PLC工件17数据1:" + hsl.locationX17 + "-" + hsl.locationY17);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX17, 0);
                                hsl.WriteInt(hsl.locationY17, 0);
                                ShowLog("写PLC工件17数据0:" + hsl.locationX17 + "-" + hsl.locationY17);
                            }
                            break;
                        case "18":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX18, 3);
                                hsl.WriteInt(hsl.locationY18, 2);
                                ShowLog("写PLC工件18数据1:" + hsl.locationX18 + "-" + hsl.locationY18);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX18, 0);
                                hsl.WriteInt(hsl.locationY18, 0);
                                ShowLog("写PLC工件18数据0:" + hsl.locationX18 + "-" + hsl.locationY18);
                            }
                            break;
                        case "19":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX19, 3);
                                hsl.WriteInt(hsl.locationY19, 3);
                                ShowLog("写PLC工件19数据1:" + hsl.locationX19 + "-" + hsl.locationY19);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX19, 0);
                                hsl.WriteInt(hsl.locationY19, 0);
                                ShowLog("写PLC工件19数据0:" + hsl.locationX19 + "-" + hsl.locationY19);
                            }
                            break;
                        case "20":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX20, 3);
                                hsl.WriteInt(hsl.locationY20, 4);
                                ShowLog("写PLC工件20数据1:" + hsl.locationX20 + "-" + hsl.locationY20);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX20, 0);
                                hsl.WriteInt(hsl.locationY20, 0);
                                ShowLog("写PLC工件20数据0:" + hsl.locationX20 + "-" + hsl.locationY20);
                            }
                            break;
                        case "21":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX21, 3);
                                hsl.WriteInt(hsl.locationY21, 5);
                                ShowLog("写PLC工件21数据1:" + hsl.locationX21 + "-" + hsl.locationY21);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX21, 0);
                                hsl.WriteInt(hsl.locationY21, 0);
                                ShowLog("写PLC工件21数据0:" + hsl.locationX21 + "-" + hsl.locationY21);
                            }
                            break;
                        case "22":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX22, 3);
                                hsl.WriteInt(hsl.locationY22, 6);
                                ShowLog("写PLC工件22数据1:" + hsl.locationX22 + "-" + hsl.locationY22);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX22, 0);
                                hsl.WriteInt(hsl.locationY22, 0);
                                ShowLog("写PLC工件22数据0:" + hsl.locationX22 + "-" + hsl.locationY22);
                            }
                            break;
                        case "23":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX23, 3);
                                hsl.WriteInt(hsl.locationY23, 7);
                                ShowLog("写PLC工件23数据1:" + hsl.locationX23 + "-" + hsl.locationY23);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX23, 0);
                                hsl.WriteInt(hsl.locationY23, 0);
                                ShowLog("写PLC工件23数据0:" + hsl.locationX23 + "-" + hsl.locationY23);
                            }
                            break;
                        case "24":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX24, 3);
                                hsl.WriteInt(hsl.locationY24, 8);
                                ShowLog("写PLC工件24数据1:" + hsl.locationX24 + "-" + hsl.locationY24);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX24, 0);
                                hsl.WriteInt(hsl.locationY24, 0);
                                ShowLog("写PLC工件24数据0:" + hsl.locationX24 + "-" + hsl.locationY24);
                            }
                            break;
                        case "25":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX25, 4);
                                hsl.WriteInt(hsl.locationY25, 1);
                                ShowLog("写PLC工件25数据1:" + hsl.locationX25 + "-" + hsl.locationY25);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX25, 0);
                                hsl.WriteInt(hsl.locationY25, 0);
                                ShowLog("写PLC工件25数据0:" + hsl.locationX25 + "-" + hsl.locationY25);
                            }
                            break;
                        case "26":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX26, 4);
                                hsl.WriteInt(hsl.locationY26, 2);
                                ShowLog("写PLC工件26数据1:" + hsl.locationX26 + "-" + hsl.locationY26);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX26, 0);
                                hsl.WriteInt(hsl.locationY26, 0);
                                ShowLog("写PLC工件26数据0:" + hsl.locationX26 + "-" + hsl.locationY26);
                            }
                            break;
                        case "27":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX27, 4);
                                hsl.WriteInt(hsl.locationY27, 3);
                                ShowLog("写PLC工件27数据1:" + hsl.locationX27 + "-" + hsl.locationY27);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX27, 0);
                                hsl.WriteInt(hsl.locationY27, 0);
                                ShowLog("写PLC工件27数据0:" + hsl.locationX27 + "-" + hsl.locationY27);
                            }
                            break;
                        case "28":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX28, 4);
                                hsl.WriteInt(hsl.locationY28, 4);
                                ShowLog("写PLC工件28数据1:" + hsl.locationX28 + "-" + hsl.locationY28);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX28, 0);
                                hsl.WriteInt(hsl.locationY28, 0);
                                ShowLog("写PLC工件28数据0:" + hsl.locationX28 + "-" + hsl.locationY28);
                            }
                            break;
                        case "29":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX29, 4);
                                hsl.WriteInt(hsl.locationY29, 5);
                                ShowLog("写PLC工件29数据1:" + hsl.locationX29 + "-" + hsl.locationY29);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX29, 0);
                                hsl.WriteInt(hsl.locationY29, 0);
                                ShowLog("写PLC工件29数据0:" + hsl.locationX29 + "-" + hsl.locationY29);
                            }
                            break;
                        case "30":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX30, 4);
                                hsl.WriteInt(hsl.locationY30, 6);
                                ShowLog("写PLC工件30数据1:" + hsl.locationX30 + "-" + hsl.locationY30);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX30, 0);
                                hsl.WriteInt(hsl.locationY30, 0);
                                ShowLog("写PLC工件30数据0:" + hsl.locationX30 + "-" + hsl.locationY30);
                            }
                            break;
                        case "31":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX31, 4);
                                hsl.WriteInt(hsl.locationY31, 7);
                                ShowLog("写PLC工件31数据1:" + hsl.locationX31 + "-" + hsl.locationY31);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX31, 0);
                                hsl.WriteInt(hsl.locationY31, 0);
                                ShowLog("写PLC工件31数据0:" + hsl.locationX31 + "-" + hsl.locationY31);
                            }
                            break;
                        case "32":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX32, 4);
                                hsl.WriteInt(hsl.locationY32, 8);
                                ShowLog("写PLC工件32数据1:" + hsl.locationX32 + "-" + hsl.locationY32);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX32, 0);
                                hsl.WriteInt(hsl.locationY32, 0);
                                ShowLog("写PLC工件32数据0:" + hsl.locationX32 + "-" + hsl.locationY32);
                            }
                            break;
                    }
                }
                
            }
            catch (Exception ex)
            {
                ShowLog("解析错误:" + ex.Message, 1);
            }
        }

        public void GetInfoByResultBig(string str)
        {
            try
            {
                string[] Str = str.Split(';');
                string type = Str[0];//大中小 321
                string PhotoTime = Str[1];//拍照次数
                string info1 = Str[2];//1产品信息

                WorkPiece wp1 = new WorkPiece();
                string[] str1 = info1.Split(',');//分割产品信息1
                string flag = str1[0];//产品1信息
                string ocr1 = str1[2];
                string code1 = str1[1];
                wp1.Index = int.Parse(PhotoTime);
                wp1.Type = CurrentType;
                wp1.IsExist = flag == "1" ? true : false;
                wp1.Ocr = ocr1;
                wp1.BarCode = code1;
                SoftConfig.lstWorkPiece.Add(wp1);
                if (PhotoTime == "1")
                {
                    //初始化任务序号
                    IndexOfTask = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00");
                    //生成示意图
                    GenMap(EWorkPieceType.big);

                    if (flag == "1")
                    {
                        hsl.WriteInt(hsl.locationX1, 1);
                        hsl.WriteInt(hsl.locationY1, 1);
                    }
                    else
                    {
                        hsl.WriteInt(hsl.locationX1, 0);
                        hsl.WriteInt(hsl.locationY1, 0);
                    }
                    ShowLog("写PLC工件1数据"+flag+":" + hsl.locationX1 + "-" + hsl.locationY1);
                }
                else
                {
                    switch (PhotoTime)
                    {
                        case "2":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX2, 1);
                                hsl.WriteInt(hsl.locationY2, 2);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX2, 0);
                                hsl.WriteInt(hsl.locationY2, 0);
                            }
                            ShowLog("写PLC工件2数据" + flag + ":" + hsl.locationX2 + "-" + hsl.locationY2);
                            break;
                        case "3":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX3, 1);
                                hsl.WriteInt(hsl.locationY3, 3);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX3, 0);
                                hsl.WriteInt(hsl.locationY3, 0);
                            }
                            ShowLog("写PLC工件3数据" + flag + ":" + hsl.locationX3 + "-" + hsl.locationY3);
                            break;
                        case "4":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX4, 1);
                                hsl.WriteInt(hsl.locationY4, 4);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX4, 0);
                                hsl.WriteInt(hsl.locationY4, 0);
                            }
                            ShowLog("写PLC工件4数据" + flag + ":" + hsl.locationX4 + "-" + hsl.locationY4);
                            break;
                        case "5":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX5, 2);
                                hsl.WriteInt(hsl.locationY5, 1);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX5, 0);
                                hsl.WriteInt(hsl.locationY5, 0);
                            }
                            ShowLog("写PLC工件5数据" + flag + ":" + hsl.locationX5 + "-" + hsl.locationY5);
                            break;
                        case "6":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX6, 2);
                                hsl.WriteInt(hsl.locationY6, 2);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX6, 0);
                                hsl.WriteInt(hsl.locationY6, 0);
                            }
                            ShowLog("写PLC工件6数据" + flag + ":" + hsl.locationX6 + "-" + hsl.locationY6);
                            break;
                        case "7":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX7, 2);
                                hsl.WriteInt(hsl.locationY7, 3);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX7, 0);
                                hsl.WriteInt(hsl.locationY7, 0);
                            }
                            ShowLog("写PLC工件7数据" + flag + ":" + hsl.locationX7 + "-" + hsl.locationY7);
                            break;
                        case "8":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX8, 2);
                                hsl.WriteInt(hsl.locationY8, 4);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX8, 0);
                                hsl.WriteInt(hsl.locationY8, 0);
                            }
                            ShowLog("写PLC工件8数据" + flag + ":" + hsl.locationX8 + "-" + hsl.locationY8);
                            break;
                        case "9":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX9, 3);
                                hsl.WriteInt(hsl.locationY9, 1);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX9, 0);
                                hsl.WriteInt(hsl.locationY9, 0);
                            }
                            ShowLog("写PLC工件9数据" + flag + ":" + hsl.locationX9 + "-" + hsl.locationY9);
                            break;
                        case "10":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX10, 3);
                                hsl.WriteInt(hsl.locationY10, 2);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX10, 0);
                                hsl.WriteInt(hsl.locationY10, 0);
                            }
                            ShowLog("写PLC工件10数据" + flag + ":" + hsl.locationX10 + "-" + hsl.locationY10);
                            break;
                        case "11":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX11, 3);
                                hsl.WriteInt(hsl.locationY11, 3);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX11, 0);
                                hsl.WriteInt(hsl.locationY11, 0);
                            }
                            ShowLog("写PLC工件11数据" + flag + ":" + hsl.locationX11 + "-" + hsl.locationY11);
                            break;
                        case "12":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX12, 3);
                                hsl.WriteInt(hsl.locationY12, 4);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX12, 0);
                                hsl.WriteInt(hsl.locationY12, 0);
                            }
                            ShowLog("写PLC工件12数据" + flag + ":" + hsl.locationX12 + "-" + hsl.locationY12);
                            break;
                        case "13":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX13, 4);
                                hsl.WriteInt(hsl.locationY13, 1);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX13, 0);
                                hsl.WriteInt(hsl.locationY13, 0);
                            }
                            ShowLog("写PLC工件13数据" + flag + ":" + hsl.locationX13 + "-" + hsl.locationY13);
                            break;
                        case "14":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX14, 4);
                                hsl.WriteInt(hsl.locationY14, 2);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX14, 0);
                                hsl.WriteInt(hsl.locationY14, 0);
                            }
                            ShowLog("写PLC工件14数据" + flag + ":" + hsl.locationX14 + "-" + hsl.locationY14);
                            break;
                        case "15":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX15, 4);
                                hsl.WriteInt(hsl.locationY15, 3);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX15, 0);
                                hsl.WriteInt(hsl.locationY15, 0);
                            }
                            ShowLog("写PLC工件15数据" + flag + ":" + hsl.locationX15 + "-" + hsl.locationY15);
                            break;
                        case "16":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX16, 4);
                                hsl.WriteInt(hsl.locationY16, 4);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX16, 0);
                                hsl.WriteInt(hsl.locationY16, 0);
                            }
                            ShowLog("写PLC工件16数据" + flag + ":" + hsl.locationX16 + "-" + hsl.locationY16);
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                ShowLog("解析错误:" + ex.Message, 1);
            }
        }
        public void GetInfoByResultsuperbig(string str)
        {
            try
            {
                string[] Str = str.Split(';');
                string type = Str[0];//大中小 321
                string PhotoTime = Str[1];//拍照次数
                string info1 = Str[2];//1产品信息

                WorkPiece wp1 = new WorkPiece();
                string[] str1 = info1.Split(',');//分割产品信息1
                string flag = str1[0];//产品1信息
                string ocr1 = str1[2];
                string code1 = str1[1];
                wp1.Index = int.Parse(PhotoTime);
                wp1.Type = CurrentType;
                wp1.IsExist = flag == "1" ? true : false;
                wp1.Ocr = ocr1;
                wp1.BarCode = code1;
                SoftConfig.lstWorkPiece.Add(wp1);
                if (PhotoTime == "1")
                {
                    //初始化任务序号
                    IndexOfTask = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00");
                    //生成示意图
                    GenMap(EWorkPieceType.superbig);

                    if (flag == "1")
                    {
                        hsl.WriteInt(hsl.locationX1, 1);
                        hsl.WriteInt(hsl.locationY1, 1);
                    }
                    else
                    {
                        hsl.WriteInt(hsl.locationX1, 0);
                        hsl.WriteInt(hsl.locationY1, 0);
                    }
                    ShowLog("写PLC工件1数据" + flag + ":" + hsl.locationX1 + "-" + hsl.locationY1);
                }
                else
                {
                    switch (PhotoTime)
                    {
                        case "2":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX2, 1);
                                hsl.WriteInt(hsl.locationY2, 2);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX2, 0);
                                hsl.WriteInt(hsl.locationY2, 0);
                            }
                            ShowLog("写PLC工件2数据" + flag + ":" + hsl.locationX2 + "-" + hsl.locationY2);
                            break;
                        case "3":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX3, 1);
                                hsl.WriteInt(hsl.locationY3, 3);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX3, 0);
                                hsl.WriteInt(hsl.locationY3, 0);
                            }
                            ShowLog("写PLC工件3数据" + flag + ":" + hsl.locationX3 + "-" + hsl.locationY3);
                            break;
                        case "4":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX4, 1);
                                hsl.WriteInt(hsl.locationY4, 4);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX4, 0);
                                hsl.WriteInt(hsl.locationY4, 0);
                            }
                            ShowLog("写PLC工件4数据" + flag + ":" + hsl.locationX4 + "-" + hsl.locationY4);
                            break;
                        case "5":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX5, 2);
                                hsl.WriteInt(hsl.locationY5, 1);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX5, 0);
                                hsl.WriteInt(hsl.locationY5, 0);
                            }
                            ShowLog("写PLC工件5数据" + flag + ":" + hsl.locationX5 + "-" + hsl.locationY5);
                            break;
                        case "6":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX6, 2);
                                hsl.WriteInt(hsl.locationY6, 2);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX6, 0);
                                hsl.WriteInt(hsl.locationY6, 0);
                            }
                            ShowLog("写PLC工件6数据" + flag + ":" + hsl.locationX6 + "-" + hsl.locationY6);
                            break;
                        case "7":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX7, 2);
                                hsl.WriteInt(hsl.locationY7, 3);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX7, 0);
                                hsl.WriteInt(hsl.locationY7, 0);
                            }
                            ShowLog("写PLC工件7数据" + flag + ":" + hsl.locationX7 + "-" + hsl.locationY7);
                            break;
                        case "8":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX8, 2);
                                hsl.WriteInt(hsl.locationY8, 4);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX8, 0);
                                hsl.WriteInt(hsl.locationY8, 0);
                            }
                            ShowLog("写PLC工件8数据" + flag + ":" + hsl.locationX8 + "-" + hsl.locationY8);
                            break;
                        case "9":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX9, 3);
                                hsl.WriteInt(hsl.locationY9, 1);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX9, 0);
                                hsl.WriteInt(hsl.locationY9, 0);
                            }
                            ShowLog("写PLC工件9数据" + flag + ":" + hsl.locationX9 + "-" + hsl.locationY9);
                            break;
                        case "10":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX10, 3);
                                hsl.WriteInt(hsl.locationY10, 2);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX10, 0);
                                hsl.WriteInt(hsl.locationY10, 0);
                            }
                            ShowLog("写PLC工件10数据" + flag + ":" + hsl.locationX10 + "-" + hsl.locationY10);
                            break;
                        case "11":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX11, 3);
                                hsl.WriteInt(hsl.locationY11, 3);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX11, 0);
                                hsl.WriteInt(hsl.locationY11, 0);
                            }
                            ShowLog("写PLC工件11数据" + flag + ":" + hsl.locationX11 + "-" + hsl.locationY11);
                            break;
                        case "12":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX12, 3);
                                hsl.WriteInt(hsl.locationY12, 4);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX12, 0);
                                hsl.WriteInt(hsl.locationY12, 0);
                            }
                            ShowLog("写PLC工件12数据" + flag + ":" + hsl.locationX12 + "-" + hsl.locationY12);
                            break;
                        case "13":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX13, 4);
                                hsl.WriteInt(hsl.locationY13, 1);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX13, 0);
                                hsl.WriteInt(hsl.locationY13, 0);
                            }
                            ShowLog("写PLC工件13数据" + flag + ":" + hsl.locationX13 + "-" + hsl.locationY13);
                            break;
                        case "14":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX14, 4);
                                hsl.WriteInt(hsl.locationY14, 2);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX14, 0);
                                hsl.WriteInt(hsl.locationY14, 0);
                            }
                            ShowLog("写PLC工件14数据" + flag + ":" + hsl.locationX14 + "-" + hsl.locationY14);
                            break;
                        case "15":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX15, 4);
                                hsl.WriteInt(hsl.locationY15, 3);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX15, 0);
                                hsl.WriteInt(hsl.locationY15, 0);
                            }
                            ShowLog("写PLC工件15数据" + flag + ":" + hsl.locationX15 + "-" + hsl.locationY15);
                            break;
                        case "16":
                            if (flag == "1")
                            {
                                hsl.WriteInt(hsl.locationX16, 4);
                                hsl.WriteInt(hsl.locationY16, 4);
                            }
                            else
                            {
                                hsl.WriteInt(hsl.locationX16, 0);
                                hsl.WriteInt(hsl.locationY16, 0);
                            }
                            ShowLog("写PLC工件16数据" + flag + ":" + hsl.locationX16 + "-" + hsl.locationY16);
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                ShowLog("解析错误:" + ex.Message, 1);
            }
        }

        //         public void GetInfoByResultsuperbig(string str)
        //         {
        //             try
        //             {
        //                 string[] Str = str.Split(';');
        //                 string type = Str[0];//大中小 321
        //                 string PhotoTime = Str[1];//拍照次数
        //                 string info1 = Str[2];//1产品信息
        //                 string info2 = Str[3];//2产品信息
        //                 string info3 = Str[4];//3产品信息
        //                 string info4 = Str[5];//4产品信息
        //                 WorkPiece wp1 = new WorkPiece();
        //                 WorkPiece wp2 = new WorkPiece();
        //                 WorkPiece wp3 = new WorkPiece();
        //                 WorkPiece wp4 = new WorkPiece();
        // 
        //                 switch (PhotoTime)
        //                 {   //第一次拍照
        //                     case "1":
        //                         //初始化任务序号
        //                         IndexOfTask = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00");
        //                         //生成示意图
        //                         GenMap(EWorkPieceType.big);
        // 
        //                         string[] str1 = info1.Split(',');//分割产品信息1
        //                         string flag1 = str1[0];//产品1信息
        //                         string ocr1 = str1[2];
        //                         string code1 = str1[1];
        //                         if (flag1 == "1")
        //                         {
        //                             hsl.WriteInt(hsl.locationX1, 1);
        //                             hsl.WriteInt(hsl.locationY1, 1);
        //                         }
        //                         else
        //                         {
        //                             hsl.WriteInt(hsl.locationX1, 0);
        //                             hsl.WriteInt(hsl.locationY1, 0);
        //                         }
        // 
        //                         wp1.Index = 1;
        //                         wp1.Type = CurrentType;
        //                         wp1.IsExist = flag1 == "1" ? true : false;
        //                         wp1.Ocr = ocr1;
        //                         wp1.BarCode = code1;
        // 
        // 
        //                         string[] str2 = info2.Split(',');//分割产品信息2
        //                         string flag2 = str2[0];//产品2信息
        //                         string ocr2 = str2[2];
        //                         string code2 = str2[1];
        //                         if (flag2 == "1")
        //                         {
        //                             hsl.WriteInt(hsl.locationX2, 2);
        //                             hsl.WriteInt(hsl.locationY2, 1);
        //                         }
        //                         else
        //                         {
        //                             hsl.WriteInt(hsl.locationX2, 0);
        //                             hsl.WriteInt(hsl.locationY2, 0);
        //                         }
        // 
        //                         wp2.Index = 2;
        //                         wp2.Type = CurrentType;
        //                         wp2.IsExist = flag2 == "1" ? true : false;
        //                         wp2.Ocr = ocr2;
        //                         wp2.BarCode = code2;
        // 
        // 
        //                         string[] str3 = info3.Split(',');//分割产品信息3
        //                         string flag3 = str3[0];//产品2信息
        //                         string ocr3 = str3[2];
        //                         string code3 = str3[1];
        //                         if (flag3 == "1")
        //                         {
        //                             hsl.WriteInt(hsl.locationX3, 1);
        //                             hsl.WriteInt(hsl.locationY3, 2);
        //                         }
        //                         else
        //                         {
        //                             hsl.WriteInt(hsl.locationX3, 0);
        //                             hsl.WriteInt(hsl.locationY3, 0);
        //                         }
        // 
        //                         wp3.Index = 3;
        //                         wp3.Type = CurrentType;
        //                         wp3.IsExist = flag3 == "1" ? true : false;
        //                         wp3.Ocr = ocr3;
        //                         wp3.BarCode = code3;
        // 
        // 
        //                         string[] str4 = info4.Split(',');//分割产品信息4
        //                         string flag4 = str4[0];//产品4信息
        //                         string ocr4 = str4[2];
        //                         string code4 = str4[1];
        //                         if (flag4 == "1")
        //                         {
        //                             hsl.WriteInt(hsl.locationX4, 2);
        //                             hsl.WriteInt(hsl.locationY4, 2);
        //                         }
        //                         else
        //                         {
        //                             hsl.WriteInt(hsl.locationX4, 0);
        //                             hsl.WriteInt(hsl.locationY4, 0);
        //                         }
        // 
        //                         wp4.Index = 4;
        //                         wp4.Type = CurrentType;
        //                         wp4.IsExist = flag4 == "1" ? true : false;
        //                         wp4.Ocr = ocr4;
        //                         wp4.BarCode = code4;
        // 
        // 
        //                         SoftConfig.lstWorkPiece.Add(wp1);
        //                         SoftConfig.lstWorkPiece.Add(wp2);
        //                         SoftConfig.lstWorkPiece.Add(wp3);
        //                         SoftConfig.lstWorkPiece.Add(wp4);
        // 
        //                         break;
        // 
        //                     //第二次拍照
        //                     case "2":
        //                         string[] str5 = info1.Split(',');//分割产品信息5
        //                         string flag5 = str5[0];//产品5信息
        //                         string ocr5 = str5[2];
        //                         string code5 = str5[1];
        //                         if (flag5 == "1")
        //                         {
        //                             hsl.WriteInt(hsl.locationX5, 3);
        //                             hsl.WriteInt(hsl.locationY5, 1);
        //                         }
        //                         else
        //                         {
        //                             hsl.WriteInt(hsl.locationX5, 0);
        //                             hsl.WriteInt(hsl.locationY5, 0);
        //                         }
        //                         wp1.Index = 5;
        //                         wp1.Type = CurrentType;
        //                         wp1.IsExist = flag5 == "1" ? true : false;
        //                         wp1.Ocr = ocr5;
        //                         wp1.BarCode = code5;
        // 
        //                         string[] str6 = info2.Split(',');//分割产品信息6
        //                         string flag6 = str6[0];//产品6信息
        //                         string ocr6 = str6[2];
        //                         string code6 = str6[1];
        //                         if (flag6 == "1")
        //                         {
        //                             hsl.WriteInt(hsl.locationX6, 4);
        //                             hsl.WriteInt(hsl.locationY6, 1);
        //                         }
        //                         else
        //                         {
        //                             hsl.WriteInt(hsl.locationX6, 0);
        //                             hsl.WriteInt(hsl.locationY6, 0);
        //                         }
        //                         wp2.Index = 6;
        //                         wp2.Type = CurrentType;
        //                         wp2.IsExist = flag6 == "1" ? true : false;
        //                         wp2.Ocr = ocr6;
        //                         wp2.BarCode = code6;
        // 
        //                         string[] str7 = info3.Split(',');//分割产品信息7
        //                         string flag7 = str7[0];//产品7信息
        //                         string ocr7 = str7[2];
        //                         string code7 = str7[1];
        //                         if (flag7 == "1")
        //                         {
        //                             hsl.WriteInt(hsl.locationX7, 3);
        //                             hsl.WriteInt(hsl.locationY7, 2);
        //                         }
        //                         else
        //                         {
        //                             hsl.WriteInt(hsl.locationX7, 0);
        //                             hsl.WriteInt(hsl.locationY7, 0);
        //                         }
        //                         wp3.Index = 7;
        //                         wp3.Type = CurrentType;
        //                         wp3.IsExist = flag7 == "1" ? true : false;
        //                         wp3.Ocr = ocr7;
        //                         wp3.BarCode = code7;
        // 
        //                         string[] str8 = info4.Split(',');//分割产品信息8
        //                         string flag8 = str8[0];//产品8信息
        //                         string ocr8 = str8[2];
        //                         string code8 = str8[1];
        //                         if (flag8 == "1")
        //                         {
        //                             hsl.WriteInt(hsl.locationX8, 4);
        //                             hsl.WriteInt(hsl.locationY8, 2);
        //                         }
        //                         else
        //                         {
        //                             hsl.WriteInt(hsl.locationX8, 0);
        //                             hsl.WriteInt(hsl.locationY8, 0);
        //                         }
        //                         wp4.Index = 8;
        //                         wp4.Type = CurrentType;
        //                         wp4.IsExist = flag8 == "1" ? true : false;
        //                         wp4.Ocr = ocr8;
        //                         wp4.BarCode = code8;
        // 
        //                         SoftConfig.lstWorkPiece.Add(wp1);
        //                         SoftConfig.lstWorkPiece.Add(wp2);
        //                         SoftConfig.lstWorkPiece.Add(wp3);
        //                         SoftConfig.lstWorkPiece.Add(wp4);
        // 
        //                         break;
        // 
        // 
        //                     //第三次拍照
        // 
        //                     case "3":
        //                         string[] str9 = info1.Split(',');//分割产品信息9
        //                         string flag9 = str9[0];//产品9信息
        //                         string ocr9 = str9[2];
        //                         string code9 = str9[1];
        //                         if (flag9 == "1")
        //                         {
        //                             hsl.WriteInt(hsl.locationX9, 1);
        //                             hsl.WriteInt(hsl.locationY9, 3);
        //                         }
        //                         else
        //                         {
        //                             hsl.WriteInt(hsl.locationX9, 0);
        //                             hsl.WriteInt(hsl.locationY9, 0);
        //                         }
        //                         wp1.Index = 9;
        //                         wp1.Type = CurrentType;
        //                         wp1.IsExist = flag9 == "1" ? true : false;
        //                         wp1.Ocr = ocr9;
        //                         wp1.BarCode = code9;
        // 
        //                         string[] str10 = info2.Split(',');//分割产品信息10
        //                         string flag10 = str10[0];//产品10信息
        //                         string ocr10 = str10[2];
        //                         string code10 = str10[1];
        //                         if (flag10 == "1")
        //                         {
        //                             hsl.WriteInt(hsl.locationX10, 2);
        //                             hsl.WriteInt(hsl.locationY10, 3);
        //                         }
        //                         else
        //                         {
        //                             hsl.WriteInt(hsl.locationX10, 0);
        //                             hsl.WriteInt(hsl.locationY10, 0);
        //                         }
        //                         wp2.Index = 10;
        //                         wp2.Type = CurrentType;
        //                         wp2.IsExist = flag10 == "1" ? true : false;
        //                         wp2.Ocr = ocr10;
        //                         wp2.BarCode = code10;
        // 
        //                         string[] str11 = info3.Split(',');//分割产品信息11
        //                         string flag11 = str11[0];//产品11信息
        //                         string ocr11 = str11[2];
        //                         string code11 = str11[1];
        //                         if (flag11 == "1")
        //                         {
        //                             hsl.WriteInt(hsl.locationX11, 1);
        //                             hsl.WriteInt(hsl.locationY11, 4);
        //                         }
        //                         else
        //                         {
        //                             hsl.WriteInt(hsl.locationX11, 0);
        //                             hsl.WriteInt(hsl.locationY11, 0);
        //                         }
        //                         wp3.Index = 11;
        //                         wp3.Type = CurrentType;
        //                         wp3.IsExist = flag11 == "1" ? true : false;
        //                         wp3.Ocr = ocr11;
        //                         wp3.BarCode = code11;
        // 
        //                         string[] str12 = info4.Split(',');//分割产品信息12
        //                         string flag12 = str12[0];//产品12信息
        //                         string ocr12 = str12[2];
        //                         string code12 = str12[1];
        //                         if (flag12 == "1")
        //                         {
        //                             hsl.WriteInt(hsl.locationX12, 2);
        //                             hsl.WriteInt(hsl.locationY12, 4);
        //                         }
        //                         else
        //                         {
        //                             hsl.WriteInt(hsl.locationX12, 0);
        //                             hsl.WriteInt(hsl.locationY12, 0);
        //                         }
        //                         wp4.Index = 12;
        //                         wp4.Type = CurrentType;
        //                         wp4.IsExist = flag12 == "1" ? true : false;
        //                         wp4.Ocr = ocr12;
        //                         wp4.BarCode = code12;
        // 
        //                         SoftConfig.lstWorkPiece.Add(wp1);
        //                         SoftConfig.lstWorkPiece.Add(wp2);
        //                         SoftConfig.lstWorkPiece.Add(wp3);
        //                         SoftConfig.lstWorkPiece.Add(wp4);
        // 
        //                         break;
        // 
        // 
        //                     //第四次拍照
        // 
        //                     case "4":
        //                         string[] str13 = info1.Split(',');//分割产品信息13
        //                         string flag13 = str13[0];//产品13信息
        //                         string ocr13 = str13[2];
        //                         string code13 = str13[1];
        //                         if (flag13 == "1")
        //                         {
        //                             hsl.WriteInt(hsl.locationX13, 3);
        //                             hsl.WriteInt(hsl.locationY13, 3);
        //                         }
        //                         else
        //                         {
        //                             hsl.WriteInt(hsl.locationX13, 0);
        //                             hsl.WriteInt(hsl.locationY13, 0);
        //                         }
        //                         wp1.Index = 13;
        //                         wp1.Type = CurrentType;
        //                         wp1.IsExist = flag13 == "1" ? true : false;
        //                         wp1.Ocr = ocr13;
        //                         wp1.BarCode = code13;
        // 
        //                         string[] str14 = info2.Split(',');//分割产品信息14
        //                         string flag14 = str14[0];//产品14信息
        //                         string ocr14 = str14[2];
        //                         string code14 = str14[1];
        //                         if (flag14 == "1")
        //                         {
        //                             hsl.WriteInt(hsl.locationX14, 4);
        //                             hsl.WriteInt(hsl.locationY14, 3);
        //                         }
        //                         else
        //                         {
        //                             hsl.WriteInt(hsl.locationX14, 0);
        //                             hsl.WriteInt(hsl.locationY14, 0);
        //                         }
        //                         wp2.Index = 14;
        //                         wp2.Type = CurrentType;
        //                         wp2.IsExist = flag14 == "1" ? true : false;
        //                         wp2.Ocr = ocr14;
        //                         wp2.BarCode = code14;
        // 
        //                         string[] str15 = info3.Split(',');//分割产品信息15
        //                         string flag15 = str15[0];//产品15信息
        //                         string ocr15 = str15[2];
        //                         string code15 = str15[1];
        //                         if (flag15 == "1")
        //                         {
        //                             hsl.WriteInt(hsl.locationX15, 3);
        //                             hsl.WriteInt(hsl.locationY15, 4);
        //                         }
        //                         else
        //                         {
        //                             hsl.WriteInt(hsl.locationX15, 0);
        //                             hsl.WriteInt(hsl.locationY15, 0);
        //                         }
        //                         wp3.Index = 15;
        //                         wp3.Type = CurrentType;
        //                         wp3.IsExist = flag15 == "1" ? true : false;
        //                         wp3.Ocr = ocr15;
        //                         wp3.BarCode = code15;
        // 
        //                         string[] str16 = info4.Split(',');//分割产品信息16
        //                         string flag16 = str16[0];//产品16信息
        //                         string ocr16 = str16[2];
        //                         string code16 = str16[1];
        //                         if (flag16 == "1")
        //                         {
        //                             hsl.WriteInt(hsl.locationX16, 4);
        //                             hsl.WriteInt(hsl.locationY16, 4);
        //                         }
        //                         else
        //                         {
        //                             hsl.WriteInt(hsl.locationX16, 0);
        //                             hsl.WriteInt(hsl.locationY16, 0);
        //                         }
        //                         wp4.Index = 16;
        //                         wp4.Type = CurrentType;
        //                         wp4.IsExist = flag16 == "1" ? true : false;
        //                         wp4.Ocr = ocr16;
        //                         wp4.BarCode = code16;
        // 
        // 
        //                         SoftConfig.lstWorkPiece.Add(wp1);
        //                         SoftConfig.lstWorkPiece.Add(wp2);
        //                         SoftConfig.lstWorkPiece.Add(wp3);
        //                         SoftConfig.lstWorkPiece.Add(wp4);
        // 
        //                         break;
        // 
        //                 }
        //             }
        //             catch (Exception ex)
        //             {
        //                 ShowLog("解析错误:" + ex.Message, 1);
        //             }
        //         }

        private void FCleanNew_Resize(object sender, EventArgs e)
        {
            asc.controlAutoSize(this.Width, this.Height, this);
        }
        

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (ShowAskDialog("退出后数据将清空,确认退出吗？"))
            {
                SoftConfig.lstWorkPiece = new List<WorkPiece>();
                VmSolution.OnWorkStatusEvent -= VmSolution_OnWorkStatusEvent;//注册流程状态回调
                cts.Cancel();
                Close();
            }
        }

        private void timerShow_Tick(object sender, EventArgs e)
        {
            try
            {
                if (SoftConfig.IsDebug)
                {
                    return;
                }
                timerShow.Enabled = false;
                btnClearCleanCount.Text = SoftConfig.ini.IniReadValue("SOFT", "CleanCount");
                //查询状态
                ledUltrasonic.On = hsl.ReadBool("M290", 1)[0] ? true : false;
                ledHot.On = hsl.ReadBool("M291", 1)[0] ? true : false;
                ledLoop.On = hsl.ReadBool("M292", 1)[0] ? true : false;
                //查询自检
                ledCheckState.On = hsl.ReadBool("M18", 1)[0] ? true : false;
                int iResult = hsl.ReadInt("D3047", 1)[0];
                switch (iResult)
                {
                    case 1:
                        ledCheckCleanResult.On = false;
                        ledCheckNGResult.On = false;
                        break;
                    case 2:
                        ledCheckCleanResult.On = false;
                        ledCheckNGResult.On = true;
                        break;
                    case 3:
                        ledCheckCleanResult.On = true;
                        ledCheckNGResult.On = false;
                        break;
                    case 4:
                        ledCheckCleanResult.On = true;
                        ledCheckNGResult.On = true;
                        break;
                }
                //读取流量
                FlowCount.Text = hsl.ReadUShort("D5008",1)[0].ToString() + " ml/min";
                //查询异常
                hsl.SendCommand("check");

                string strError = "";
                for (int i = 0; i < hsl.bWarn.Count(); i++)
                {
                    if (hsl.bWarn[i])
                    {
                        strError += " " + SoftConfig._WarnMap[i];
                    }
                }
                if (strError == "")
                {
                    lbWarn.Text = "运行正常";
                    lbWarn.ForeColor = Color.Green;
                }
                else
                {
                    lbWarn.Text = strError;
                    lbWarn.ForeColor = Color.Red;
                    //记录报警
                    using (Panasonic_SmartCleanEntities ps = new Panasonic_SmartCleanEntities())
                    {
                        Warn w = new Warn();
                        w.State = "0";
                        w.Context = strError;
                        w.WarnTime = DateTime.Now;
                        ps.Warn.Add(w);
                        ps.SaveChanges();
                    }
                }
                timerShow.Enabled = true;
            }
            catch (Exception ex)
            {
                timerShow.Enabled = true;
            }
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!ShowAskDialog("确认开始？"))
            {
                return;
            }
            hsl.WriteBool("M0", true);
            Thread.Sleep(300);
            hsl.WriteBool("M0", false);
        }

        private void btnOrigin_Click(object sender, EventArgs e)
        {
            if (!ShowAskDialog("确认回原点？"))
            {
                return;
            }
            hsl.WriteBool("M1", true);
            Thread.Sleep(300);
            hsl.WriteBool("M1", false);
        }

        //private void btnCheck_Click(object sender, EventArgs e)
        //{
        //    if (!ShowAskDialog("确认自检？"))
        //    {
        //        return;
        //    }
        //    hsl.WriteBool("M7", true);
        //    Thread.Sleep(300);
        //    hsl.WriteBool("M7", false);
        //}

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!ShowAskDialog("确认已处理？"))
            {
                return;
            }
            hsl.WriteBool("M8", true);
            Thread.Sleep(300);
            hsl.WriteBool("M8", false);
        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
            if (!ShowAskDialog("确认复位？"))
            {
                return;
            }
            using (FSelectType f=new FSelectType())
            {
                if (f.ShowDialog()==DialogResult.Yes)
                {
                    switch (f.eType)
                    {
                        case EWorkPieceType.small:
                            hsl.WriteBool("M80", true);
                            break;
                        case EWorkPieceType.big:
                            hsl.WriteBool("M84", true);
                            break;
                        case EWorkPieceType.superbig:
                            hsl.WriteBool("M88", true);
                            break;
                        default:
                            break;
                    }
                    ShowSuccessTip("修改成功");
                }
                else
                {
                    return;
                }
            }
            
        }

        private void uiButton8_Click(object sender, EventArgs e)
        {
            if (!ShowAskDialog("确认复位？"))
            {
                return;
            }
            using (FSelectType f = new FSelectType())
            {
                if (f.ShowDialog() == DialogResult.Yes)
                {
                    switch (f.eType)
                    {
                        case EWorkPieceType.small:
                            hsl.WriteBool("M81", true);
                            break;
                        case EWorkPieceType.big:
                            hsl.WriteBool("M85", true);
                            break;
                        case EWorkPieceType.superbig:
                            hsl.WriteBool("M89", true);
                            break;
                        default:
                            break;
                    }
                    ShowSuccessTip("修改成功");
                }
                else
                {
                    return;
                }
            }
            
        }

        private void uiButton7_Click(object sender, EventArgs e)
        {
            if (!ShowAskDialog("确认复位？"))
            {
                return;
            }
            using (FSelectType f = new FSelectType())
            {
                if (f.ShowDialog() == DialogResult.Yes)
                {
                    switch (f.eType)
                    {
                        case EWorkPieceType.small:
                            hsl.WriteBool("M82", true);
                            break;
                        case EWorkPieceType.big:
                            hsl.WriteBool("M86", true);
                            break;
                        case EWorkPieceType.superbig:
                            hsl.WriteBool("M90", true);
                            break;
                        default:
                            break;
                    }
                    ShowSuccessTip("修改成功");
                }
                else
                {
                    return;
                }
            }
            
        }

        private void uiButton5_Click(object sender, EventArgs e)
        {
            if (!ShowAskDialog("确认复位？"))
            {
                return;
            }
            using (FSelectType f = new FSelectType())
            {
                if (f.ShowDialog() == DialogResult.Yes)
                {
                    switch (f.eType)
                    {
                        case EWorkPieceType.small:
                            hsl.WriteBool("M83", true);
                            break;
                        case EWorkPieceType.big:
                            hsl.WriteBool("M87", true);
                            break;
                        case EWorkPieceType.superbig:
                            
                            break;
                        default:
                            break;
                    }
                    ShowSuccessTip("修改成功");
                }
                else
                {
                    return;
                }
            }
            
        }

        private void btnClearCleanCount_Click(object sender, EventArgs e)
        {
            ////string ss = @"[{"Index":1,"Type":0,"IsExist":false,"Ocr":"","BarCode":"","MouseResult":"","ReflectBoardResult":"","FlowResult":"","MouseBefore":null,"MouseAfter":null,"BoardBefore":null,"BoardAfter":null},{"Index":2,"Type":0,"IsExist":true,"Ocr":"","BarCode":"02400011004170800004","MouseResult":"","ReflectBoardResult":"","FlowResult":"","MouseBefore":null,"MouseAfter":null,"BoardBefore":null,"BoardAfter":null},{"Index":3,"Type":0,"IsExist":false,"Ocr":"","BarCode":"","MouseResult":"","ReflectBoardResult":"","FlowResult":"","MouseBefore":null,"MouseAfter":null,"BoardBefore":null,"BoardAfter":null},{"Index":4,"Type":0,"IsExist":true,"Ocr":"240CSN","BarCode":"","MouseResult":"","ReflectBoardResult":"","FlowResult":"","MouseBefore":null,"MouseAfter":null,"BoardBefore":null,"BoardAfter":null},{"Index":5,"Type":0,"IsExist":true,"Ocr":"240CSN","BarCode":"","MouseResult":"","ReflectBoardResult":"","FlowResult":"","MouseBefore":null,"MouseAfter":null,"BoardBefore":null,"BoardAfter":null},{"Index":6,"Type":0,"IsExist":false,"Ocr":"","BarCode":"","MouseResult":"","ReflectBoardResult":"","FlowResult":"","MouseBefore":null,"MouseAfter":null,"BoardBefore":null,"BoardAfter":null},{"Index":7,"Type":0,"IsExist":false,"Ocr":"","BarCode":"","MouseResult":"","ReflectBoardResult":"","FlowResult":"","MouseBefore":null,"MouseAfter":null,"BoardBefore":null,"BoardAfter":null},{"Index":8,"Type":0,"IsExist":false,"Ocr":"","BarCode":"","MouseResult":"","ReflectBoardResult":"","FlowResult":"","MouseBefore":null,"MouseAfter":null,"BoardBefore":null,"BoardAfter":null},{"Index":9,"Type":0,"IsExist":false,"Ocr":"","BarCode":"","MouseResult":"","ReflectBoardResult":"","FlowResult":"","MouseBefore":null,"MouseAfter":null,"BoardBefore":null,"BoardAfter":null},{"Index":10,"Type":0,"IsExist":false,"Ocr":"","BarCode":"","MouseResult":"","ReflectBoardResult":"","FlowResult":"","MouseBefore":null,"MouseAfter":null,"BoardBefore":null,"BoardAfter":null},{"Index":11,"Type":0,"IsExist":false,"Ocr":"","BarCode":"","MouseResult":"","ReflectBoardResult":"","FlowResult":"","MouseBefore":null,"MouseAfter":null,"BoardBefore":null,"BoardAfter":null},{"Index":12,"Type":0,"IsExist":false,"Ocr":"","BarCode":"","MouseResult":"","ReflectBoardResult":"","FlowResult":"","MouseBefore":null,"MouseAfter":null,"BoardBefore":null,"BoardAfter":null},{"Index":13,"Type":0,"IsExist":false,"Ocr":"","BarCode":"","MouseResult":"","ReflectBoardResult":"","FlowResult":"","MouseBefore":null,"MouseAfter":null,"BoardBefore":null,"BoardAfter":null},{"Index":14,"Type":0,"IsExist":false,"Ocr":"","BarCode":"","MouseResult":"","ReflectBoardResult":"","FlowResult":"","MouseBefore":null,"MouseAfter":null,"BoardBefore":null,"BoardAfter":null},{"Index":15,"Type":0,"IsExist":false,"Ocr":"","BarCode":"","MouseResult":"","ReflectBoardResult":"","FlowResult":"","MouseBefore":null,"MouseAfter":null,"BoardBefore":null,"BoardAfter":null},{"Index":16,"Type":0,"IsExist":false,"Ocr":"","BarCode":"","MouseResult":"","ReflectBoardResult":"","FlowResult":"","MouseBefore":null,"MouseAfter":null,"BoardBefore":null,"BoardAfter":null},{"Index":17,"Type":0,"IsExist":true,"Ocr":"240CS","BarCode":"","MouseResult":"","ReflectBoardResult":"","FlowResult":"","MouseBefore":null,"MouseAfter":null,"BoardBefore":null,"BoardAfter":null},{"Index":18,"Type":0,"IsExist":true,"Ocr":"240CS","BarCode":"","MouseResult":"","ReflectBoardResult":"","FlowResult":"","MouseBefore":null,"MouseAfter":null,"BoardBefore":null,"BoardAfter":null},{"Index":19,"Type":0,"IsExist":false,"Ocr":"","BarCode":"","MouseResult":"","ReflectBoardResult":"","FlowResult":"","MouseBefore":null,"MouseAfter":null,"BoardBefore":null,"BoardAfter":null},{"Index":20,"Type":0,"IsExist":true,"Ocr":"240CSN","BarCode":"","MouseResult":"","ReflectBoardResult":"","FlowResult":"","MouseBefore":null,"MouseAfter":null,"BoardBefore":null,"BoardAfter":null},{"Index":21,"Type":0,"IsExist":false,"Ocr":"","BarCode":"","MouseResult":"","ReflectBoardResult":"","FlowResult":"","MouseBefore":null,"MouseAfter":null,"BoardBefore":null,"BoardAfter":null},{"Index":22,"Type":0,"IsExist":true,"Ocr":"240CSN","BarCode":"02400011001181110726","MouseResult":"","ReflectBoardResult":"","FlowResult":"","MouseBefore":null,"MouseAfter":null,"BoardBefore":null,"BoardAfter":null},{"Index":23,"Type":0,"IsExist":false,"Ocr":"","BarCode":"","MouseResult":"","ReflectBoardResult":"","FlowResult":"","MouseBefore":null,"MouseAfter":null,"BoardBefore":null,"BoardAfter":null},{"Index":24,"Type":0,"IsExist":true,"Ocr":"240CSN","BarCode":"","MouseResult":"","ReflectBoardResult":"","FlowResult":"","MouseBefore":null,"MouseAfter":null,"BoardBefore":null,"BoardAfter":null},{"Index":25,"Type":0,"IsExist":true,"Ocr":"240CS","BarCode":"","MouseResult":"","ReflectBoardResult":"","FlowResult":"","MouseBefore":null,"MouseAfter":null,"BoardBefore":null,"BoardAfter":null},{"Index":26,"Type":0,"IsExist":false,"Ocr":"","BarCode":"","MouseResult":"","ReflectBoardResult":"","FlowResult":"","MouseBefore":null,"MouseAfter":null,"BoardBefore":null,"BoardAfter":null},{"Index":27,"Type":0,"IsExist":false,"Ocr":"","BarCode":"","MouseResult":"","ReflectBoardResult":"","FlowResult":"","MouseBefore":null,"MouseAfter":null,"BoardBefore":null,"BoardAfter":null},{"Index":28,"Type":0,"IsExist":false,"Ocr":"","BarCode":"","MouseResult":"","ReflectBoardResult":"","FlowResult":"","MouseBefore":null,"MouseAfter":null,"BoardBefore":null,"BoardAfter":null},{"Index":29,"Type":0,"IsExist":false,"Ocr":"","BarCode":"","MouseResult":"","ReflectBoardResult":"","FlowResult":"","MouseBefore":null,"MouseAfter":null,"BoardBefore":null,"BoardAfter":null},{"Index":30,"Type":0,"IsExist":false,"Ocr":"","BarCode":"","MouseResult":"","ReflectBoardResult":"","FlowResult":"","MouseBefore":null,"MouseAfter":null,"BoardBefore":null,"BoardAfter":null},{"Index":31,"Type":0,"IsExist":false,"Ocr":"","BarCode":"","MouseResult":"","ReflectBoardResult":"","FlowResult":"","MouseBefore":null,"MouseAfter":null,"BoardBefore":null,"BoardAfter":null},{"Index":32,"Type":0,"IsExist":false,"Ocr":"","BarCode":"","MouseResult":"","ReflectBoardResult":"","FlowResult":"","MouseBefore":null,"MouseAfter":null,"BoardBefore":null,"BoardAfter":null}]";
            //StringBuilder strContext = new StringBuilder();
            //string file = "E://1.txt";
            //FileInfo finfo = new FileInfo(file);
            //FileStream fs = finfo.Open(FileMode.OpenOrCreate,
            //FileAccess.ReadWrite);
            //StreamReader sr = new StreamReader(fs);
            //string strList = sr.ReadLine();
            //while (strList != null)
            //{
            //    strContext.Append(strList);
            //    strList = sr.ReadLine();
            //}
            //sr.Close();
            //fs.Close();
            //CurrentType = EWorkPieceType.big;
            //SoftConfig.lstWorkPiece = JsonConvert.DeserializeObject<List<WorkPiece>>(strContext.ToString());
            //RefreshMap();

            if (!ShowAskDialog("确认清零累计清洗次数？"))
            {
                return;
            }
            SoftConfig.ini.IniWriteValue("SOFT", "CleanCount", "0");
        }

        private void btnDoor_Click(object sender, EventArgs e)
        {
            bool bState = hsl.ReadBool("M9", 1)[0];
            hsl.WriteBool("M9", !bState);
            ShowSuccessTip("修改成功");
            if (bState)
            {
                btnDoor.Text = "门禁已开启";
            }
            else
            {
                btnDoor.Text = "门禁已关闭";
            }
        }

        private void btnBell_Click(object sender, EventArgs e)
        {
            bool bState = hsl.ReadBool("M5", 1)[0];
            hsl.WriteBool("M5", !bState);
            ShowSuccessTip("修改成功");
            if (bState)
            {
                btnBell.Text = "蜂鸣已开启";
            }
            else
            {
                btnBell.Text = "蜂鸣已屏蔽";
            }
        }

        private void btnCountDown_Click(object sender, EventArgs e)
        {
            FCamera f = new FCamera();
            f.Show();
        }

        int iTouch = 0;
        private void FCleanNew_Click(object sender, EventArgs e)
        {
            iTouch++;
            if (iTouch>=6)
            {
                iTouch = 0;
                FCamera f = new FCamera();
                f.Show();
            }
        }
    }
}
