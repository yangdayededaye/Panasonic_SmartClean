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

namespace Panasonic_SmartClean
{
#pragma warning disable CS0246 // 未能找到类型或命名空间名“UIForm”(是否缺少 using 指令或程序集引用?)
    public partial class FReport : UIForm
#pragma warning restore CS0246 // 未能找到类型或命名空间名“UIForm”(是否缺少 using 指令或程序集引用?)
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();

        public FReport()
        {
            InitializeComponent();
            asc.controllInitializeSize(this);
            dpUseStart.Value = DateTime.Now.AddDays(-30);
            dpUseEnd.Value = DateTime.Now;
        }

        private void FReport_Resize(object sender, EventArgs e)
        {
            //asc.controlAutoSize(this.Width, this.Height, this);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var vLog = SoftConfig.db.CleanLog.Where(x => DbFunctions.DiffDays(dpUseStart.Value, x.LogTime) >= 0 && DbFunctions.DiffDays(x.LogTime, dpUseEnd.Value) >= 0).ToList();
            if (vLog==null||vLog.Count<=0)
            {
                return;
            }
            lbTotalCount.Text = "清洗总数:"+vLog.Count().ToString();
            var option = new UIPieOption();

            //设置Title
            option.Title = new UITitle();
            option.Title.Text = "清洗结果分析";
            option.Title.SubText = "数量";
            option.Title.Left = UILeftAlignment.Center;

            //设置ToolTip
            option.ToolTip.Visible = true;

            //设置Legend
            option.Legend = new UILegend();
            option.Legend.Orient = UIOrient.Vertical;
            option.Legend.Top = UITopAlignment.Top;
            option.Legend.Left = UILeftAlignment.Left;

            option.Legend.AddData("全部OK");
            option.Legend.AddData("吸嘴OK");
            option.Legend.AddData("反光板OK");
            option.Legend.AddData("流量OK");
            option.Legend.AddData("吸嘴NG");
            option.Legend.AddData("反光板NG");
            option.Legend.AddData("流量NG");
            option.Legend.AddData("全部NG");

            //设置Series
            var series = new UIPieSeries();
            series.Name = "StarCount";
            series.Center = new UICenter(50, 55);
            series.Radius = 70;
            series.Label.Show = true;

            //增加数据
            series.AddData("全部OK", vLog.Where(x=>x.MouseResult=="OK"&& x.ReflectPanelResult == "OK"&& x.FlowResult == "OK").Count());
            series.AddData("吸嘴OK", vLog.Where(x => x.MouseResult == "OK").Count());
            series.AddData("反光板OK", vLog.Where(x => x.ReflectPanelResult == "OK").Count());
            series.AddData("流量OK", vLog.Where(x => x.FlowResult == "OK").Count());
            series.AddData("吸嘴NG", vLog.Where(x => x.MouseResult != "OK").Count());
            series.AddData("反光板NG", vLog.Where(x => x.ReflectPanelResult != "OK").Count());
            series.AddData("流量NG", vLog.Where(x => x.FlowResult != "OK").Count());
            series.AddData("全部NG", vLog.Where(x => x.MouseResult != "OK" && x.ReflectPanelResult != "OK" && x.FlowResult != "OK").Count());

            //增加Series
            option.Series.Clear();
            option.Series.Add(series);

            //设置Option
            PieChart.SetOption(option);

        }
    }
}
