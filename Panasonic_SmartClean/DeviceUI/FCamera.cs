using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Drawing;
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
    public partial class FCamera : UIForm
#pragma warning restore CS0246 // 未能找到类型或命名空间名“UIForm”(是否缺少 using 指令或程序集引用?)
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();
        /// <summary>
        /// 渲染窗口用到的用户控件
        /// </summary>
        private RenderControl renderControl = new RenderControl();

        /// <summary>
        /// 参数配置用到的用户控件
        /// </summary>
        private MainViewControl mainViewControl = new MainViewControl();


        public FCamera()
        {
            InitializeComponent();
            asc.controllInitializeSize(this);
            this.WindowState = FormWindowState.Maximized;

        }

        private void FCamera_Resize(object sender, EventArgs e)
        {
            asc.controlAutoSize(this.Width, this.Height, this);
        }

        private void FCamera_Load(object sender, EventArgs e)
        {

            UpdateProcessComboBox(SoftConfig.processList);
            RegisterProcedureWorkEndCallback(SoftConfig.processList);
            renderControl.ModuleSource = SoftConfig.processList[0];
        }

        /// <summary>
        /// 注册流程工作结束回调
        /// </summary>
        /// <param name="lst"></param>
        public void RegisterProcedureWorkEndCallback(List<VmProcedure> lst)
        {
            try
            {
                foreach (var vmProcedure in SoftConfig.processList)
                {
                    vmProcedure.OnWorkEndStatusCallBack += VmProcedure_OnWorkEndStatusCallBack;
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 注册流程工作结束回调
        /// </summary>
        /// <param name="lst"></param>
        public void CancellRegisterProcedureWorkEndCallback(List<VmProcedure> lst)
        {
            try
            {
                foreach (var vmProcedure in SoftConfig.processList)
                {
                    vmProcedure.OnWorkEndStatusCallBack -= VmProcedure_OnWorkEndStatusCallBack;
                }
            }
            catch (Exception ex)
            {

            }
        }

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
                    var outputList = procedure.ModuResult.GetAllOutputNameInfo();
                    //获取流程输出配置中为out的输出项
                    foreach (var ioNameInfo in outputList)
                    {
                        if (ioNameInfo.Name == "out" &&
                            ioNameInfo.TypeName == IMVS_MODULE_BASE_DATA_TYPE.IMVS_GRAP_TYPE_STRING)
                        {
                            var result = procedure.ModuResult.GetOutputString(ioNameInfo.Name);
                            string resultStrValue = result.astStringVal[0].strValue;
                            Invoke(new Action(()=> {
                                lstResult.Items.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+" "+ resultStrValue);
                                lstResult.SelectedIndex = lstResult.Items.Count - 1;
                            }));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //AppendLog(ex.Message);
            }
        }

        /// <summary>
        /// 更新流程列表下拉控件
        /// </summary>
        /// <param name="lst"></param>
        private void UpdateProcessComboBox(List<VmProcedure> lst)
        {
            comboProcedure.Items.Clear();
            foreach (var vmProcedure in lst)
            {
                comboProcedure.Items.Add(vmProcedure.Name);
            }
            if (comboProcedure.Items.Count > 0)
            {
                comboProcedure.SelectedIndex = 0;
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

        private void buttonRender_Click(object sender, EventArgs e)
        {
            renderPanel.Controls.Clear();
            renderPanel.Controls.Add(renderControl);
            buttonRender.BackColor = Color.Orange;
            buttonConfig.BackColor = Color.Gray;
        }

        private void buttonConfig_Click(object sender, EventArgs e)
        {
            renderPanel.Controls.Clear();
            renderPanel.Controls.Add(mainViewControl);
            mainViewControl.Dock = DockStyle.Fill;
            buttonRender.BackColor = Color.Gray;
            buttonConfig.BackColor = Color.Orange;
        }

        private void buttonContiRun_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboProcedure.SelectedIndex != -1)
                {
                    string processName = comboProcedure.SelectedItem.ToString();
                    VmProcedure procedure = VmSolution.Instance[processName] as VmProcedure;
                    procedure.ContinuousRunEnable = procedure.ContinuousRunEnable ^ true;
                }
            }
            catch (Exception ex)
            {
                //AppendLog(ex.Message);
            }
        }

        private void buttonRunOnce_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboProcedure.SelectedIndex != -1)
                {
                    string processName = comboProcedure.SelectedItem.ToString();
                    VmProcedure procedure = VmSolution.Instance[processName] as VmProcedure;
                    if (procedure != null)
                    {
                        //AppendLog("方案开始执行");
                        procedure.Run();
                    }
                }
            }
            catch (Exception ex)
            {
                //AppendLog(ex.Message);
            }
        }

        private void comboProcedure_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                renderControl.ModuleSource = (VmProcedure)VmSolution.Instance[comboProcedure.SelectedItem.ToString()];
            }
            catch (Exception ex)
            {

            }
        }

        private void FCamera_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否保存方案", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    VmSolution.Save();
                    CancellRegisterProcedureWorkEndCallback(SoftConfig.processList);
                    Close();
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                Close();
            }

        }
    }
}
