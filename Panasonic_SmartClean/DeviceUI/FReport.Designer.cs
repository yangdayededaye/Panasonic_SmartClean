namespace Panasonic_SmartClean
{
    partial class FReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

#pragma warning disable CS0115 // “FReport.Dispose(bool)”: 没有找到适合的方法来重写
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
#pragma warning restore CS0115 // “FReport.Dispose(bool)”: 没有找到适合的方法来重写
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PieChart = new Sunny.UI.UIPieChart();
            this.dpUseEnd = new Sunny.UI.UIDatetimePicker();
            this.dpUseStart = new Sunny.UI.UIDatetimePicker();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.btnStart = new Sunny.UI.UIButton();
            this.lbTotalCount = new Sunny.UI.UILabel();
            this.SuspendLayout();
            // 
            // PieChart
            // 
            this.PieChart.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PieChart.LegendFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PieChart.Location = new System.Drawing.Point(31, 223);
            this.PieChart.MinimumSize = new System.Drawing.Size(1, 1);
            this.PieChart.Name = "PieChart";
            this.PieChart.Size = new System.Drawing.Size(897, 414);
            this.PieChart.Style = Sunny.UI.UIStyle.Custom;
            this.PieChart.SubFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PieChart.TabIndex = 0;
            this.PieChart.Text = "uiPieChart1";
            this.PieChart.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // dpUseEnd
            // 
            this.dpUseEnd.FillColor = System.Drawing.Color.White;
            this.dpUseEnd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dpUseEnd.Location = new System.Drawing.Point(366, 75);
            this.dpUseEnd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dpUseEnd.MaxLength = 19;
            this.dpUseEnd.MinimumSize = new System.Drawing.Size(63, 0);
            this.dpUseEnd.Name = "dpUseEnd";
            this.dpUseEnd.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.dpUseEnd.Size = new System.Drawing.Size(224, 29);
            this.dpUseEnd.Style = Sunny.UI.UIStyle.Custom;
            this.dpUseEnd.SymbolDropDown = 61555;
            this.dpUseEnd.SymbolNormal = 61555;
            this.dpUseEnd.TabIndex = 147;
            this.dpUseEnd.Text = "2022-06-13 10:42:25";
            this.dpUseEnd.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.dpUseEnd.Value = new System.DateTime(2022, 6, 13, 10, 42, 25, 201);
            this.dpUseEnd.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // dpUseStart
            // 
            this.dpUseStart.FillColor = System.Drawing.Color.White;
            this.dpUseStart.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dpUseStart.Location = new System.Drawing.Point(92, 75);
            this.dpUseStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dpUseStart.MaxLength = 19;
            this.dpUseStart.MinimumSize = new System.Drawing.Size(63, 0);
            this.dpUseStart.Name = "dpUseStart";
            this.dpUseStart.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.dpUseStart.Size = new System.Drawing.Size(224, 29);
            this.dpUseStart.Style = Sunny.UI.UIStyle.Custom;
            this.dpUseStart.SymbolDropDown = 61555;
            this.dpUseStart.SymbolNormal = 61555;
            this.dpUseStart.TabIndex = 146;
            this.dpUseStart.Text = "2022-06-13 10:42:25";
            this.dpUseStart.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.dpUseStart.Value = new System.DateTime(2022, 6, 13, 10, 42, 25, 0);
            this.dpUseStart.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(321, 77);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(40, 23);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 145;
            this.uiLabel2.Text = "~";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnStart
            // 
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.Location = new System.Drawing.Point(637, 69);
            this.btnStart.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnStart.Name = "btnStart";
            this.btnStart.Radius = 10;
            this.btnStart.RectSize = 2;
            this.btnStart.Size = new System.Drawing.Size(187, 38);
            this.btnStart.StyleCustomMode = true;
            this.btnStart.TabIndex = 148;
            this.btnStart.Text = "查询";
            this.btnStart.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lbTotalCount
            // 
            this.lbTotalCount.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTotalCount.Location = new System.Drawing.Point(34, 152);
            this.lbTotalCount.Name = "lbTotalCount";
            this.lbTotalCount.Size = new System.Drawing.Size(736, 47);
            this.lbTotalCount.Style = Sunny.UI.UIStyle.Custom;
            this.lbTotalCount.TabIndex = 149;
            this.lbTotalCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbTotalCount.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // FReport
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(962, 665);
            this.Controls.Add(this.lbTotalCount);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.dpUseEnd);
            this.Controls.Add(this.dpUseStart);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.PieChart);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1440, 900);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FReport";
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ShowFullScreen = true;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "报表";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 600);
            this.Resize += new System.EventHandler(this.FReport_Resize);
            this.ResumeLayout(false);

        }

        #endregion

#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIPieChart”(是否缺少程序集引用?)
        private Sunny.UI.UIPieChart PieChart;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIPieChart”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIDatetimePicker”(是否缺少程序集引用?)
        private Sunny.UI.UIDatetimePicker dpUseEnd;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIDatetimePicker”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIDatetimePicker”(是否缺少程序集引用?)
        private Sunny.UI.UIDatetimePicker dpUseStart;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIDatetimePicker”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
        private Sunny.UI.UILabel uiLabel2;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIButton”(是否缺少程序集引用?)
        private Sunny.UI.UIButton btnStart;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIButton”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
        private Sunny.UI.UILabel lbTotalCount;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
    }
}