namespace Panasonic_SmartClean
{
    partial class FMain_DeviceNew
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

#pragma warning disable CS0115 // “FMain_DeviceNew.Dispose(bool)”: 没有找到适合的方法来重写
        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
#pragma warning restore CS0115 // “FMain_DeviceNew.Dispose(bool)”: 没有找到适合的方法来重写
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerDateTime = new System.Windows.Forms.Timer(this.components);
            this.UserCenter = new Sunny.UI.UIHeaderButton();
            this.btnClean = new Sunny.UI.UIButton();
            this.btnSet = new Sunny.UI.UIButton();
            this.btnUser = new Sunny.UI.UIButton();
            this.btnTest = new Sunny.UI.UIButton();
            this.btnReport = new Sunny.UI.UIButton();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.lightScan = new Sunny.UI.UILight();
            this.lightPLC = new Sunny.UI.UILight();
            this.lightDB = new Sunny.UI.UILight();
            this.lbTime = new Sunny.UI.UILabel();
            this.btnExit = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // timerDateTime
            // 
            this.timerDateTime.Enabled = true;
            this.timerDateTime.Interval = 1000;
            this.timerDateTime.Tick += new System.EventHandler(this.timerDateTime_Tick);
            // 
            // UserCenter
            // 
            this.UserCenter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserCenter.BackColor = System.Drawing.Color.Transparent;
            this.UserCenter.CircleColor = System.Drawing.Color.SlateGray;
            this.UserCenter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UserCenter.FillColor = System.Drawing.Color.Transparent;
            this.UserCenter.FillDisableColor = System.Drawing.Color.Transparent;
            this.UserCenter.FillHoverColor = System.Drawing.Color.Transparent;
            this.UserCenter.FillPressColor = System.Drawing.Color.Transparent;
            this.UserCenter.FillSelectedColor = System.Drawing.Color.Transparent;
            this.UserCenter.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserCenter.ForeColor = System.Drawing.Color.Black;
            this.UserCenter.ForeHoverColor = System.Drawing.Color.Gray;
            this.UserCenter.ForePressColor = System.Drawing.Color.Gray;
            this.UserCenter.ForeSelectedColor = System.Drawing.Color.Gray;
            this.UserCenter.Location = new System.Drawing.Point(898, 5);
            this.UserCenter.MinimumSize = new System.Drawing.Size(1, 1);
            this.UserCenter.Name = "UserCenter";
            this.UserCenter.Padding = new System.Windows.Forms.Padding(0, 8, 0, 3);
            this.UserCenter.Radius = 0;
            this.UserCenter.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.UserCenter.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.UserCenter.Size = new System.Drawing.Size(110, 90);
            this.UserCenter.Style = Sunny.UI.UIStyle.Custom;
            this.UserCenter.StyleCustomMode = true;
            this.UserCenter.Symbol = 61447;
            this.UserCenter.SymbolOffset = new System.Drawing.Point(1, 2);
            this.UserCenter.SymbolSize = 41;
            this.UserCenter.TabIndex = 7;
            this.UserCenter.Text = "admin";
            this.UserCenter.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserCenter.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.UserCenter.Click += new System.EventHandler(this.UserCenter_Click);
            // 
            // btnClean
            // 
            this.btnClean.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClean.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClean.FillColor = System.Drawing.Color.Silver;
            this.btnClean.FillHoverColor = System.Drawing.Color.Gray;
            this.btnClean.FillPressColor = System.Drawing.Color.Gray;
            this.btnClean.FillSelectedColor = System.Drawing.Color.Gray;
            this.btnClean.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClean.ForeColor = System.Drawing.Color.Black;
            this.btnClean.Location = new System.Drawing.Point(18, 18);
            this.btnClean.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnClean.Name = "btnClean";
            this.btnClean.Radius = 0;
            this.btnClean.RectColor = System.Drawing.Color.Transparent;
            this.btnClean.RectDisableColor = System.Drawing.Color.Transparent;
            this.btnClean.RectHoverColor = System.Drawing.Color.Transparent;
            this.btnClean.RectPressColor = System.Drawing.Color.Transparent;
            this.btnClean.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btnClean.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.btnClean.Size = new System.Drawing.Size(130, 100);
            this.btnClean.Style = Sunny.UI.UIStyle.Custom;
            this.btnClean.StyleCustomMode = true;
            this.btnClean.TabIndex = 182;
            this.btnClean.Text = "自动清洗";
            this.btnClean.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClean.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // btnSet
            // 
            this.btnSet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSet.FillColor = System.Drawing.Color.Silver;
            this.btnSet.FillHoverColor = System.Drawing.Color.Gray;
            this.btnSet.FillPressColor = System.Drawing.Color.Gray;
            this.btnSet.FillSelectedColor = System.Drawing.Color.Gray;
            this.btnSet.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSet.ForeColor = System.Drawing.Color.Black;
            this.btnSet.Location = new System.Drawing.Point(18, 458);
            this.btnSet.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSet.Name = "btnSet";
            this.btnSet.Radius = 0;
            this.btnSet.RectColor = System.Drawing.Color.Transparent;
            this.btnSet.RectDisableColor = System.Drawing.Color.Transparent;
            this.btnSet.RectHoverColor = System.Drawing.Color.Transparent;
            this.btnSet.RectPressColor = System.Drawing.Color.Transparent;
            this.btnSet.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btnSet.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.btnSet.Size = new System.Drawing.Size(130, 100);
            this.btnSet.Style = Sunny.UI.UIStyle.Custom;
            this.btnSet.StyleCustomMode = true;
            this.btnSet.TabIndex = 183;
            this.btnSet.Text = "系统设置";
            this.btnSet.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSet.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnUser
            // 
            this.btnUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUser.FillColor = System.Drawing.Color.Silver;
            this.btnUser.FillHoverColor = System.Drawing.Color.Gray;
            this.btnUser.FillPressColor = System.Drawing.Color.Gray;
            this.btnUser.FillSelectedColor = System.Drawing.Color.Gray;
            this.btnUser.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUser.ForeColor = System.Drawing.Color.Black;
            this.btnUser.Location = new System.Drawing.Point(18, 238);
            this.btnUser.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnUser.Name = "btnUser";
            this.btnUser.Radius = 0;
            this.btnUser.RectColor = System.Drawing.Color.Transparent;
            this.btnUser.RectDisableColor = System.Drawing.Color.Transparent;
            this.btnUser.RectHoverColor = System.Drawing.Color.Transparent;
            this.btnUser.RectPressColor = System.Drawing.Color.Transparent;
            this.btnUser.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btnUser.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.btnUser.Size = new System.Drawing.Size(130, 100);
            this.btnUser.Style = Sunny.UI.UIStyle.Custom;
            this.btnUser.StyleCustomMode = true;
            this.btnUser.TabIndex = 184;
            this.btnUser.Text = "用户管理";
            this.btnUser.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUser.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnTest
            // 
            this.btnTest.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTest.FillColor = System.Drawing.Color.Silver;
            this.btnTest.FillHoverColor = System.Drawing.Color.Gray;
            this.btnTest.FillPressColor = System.Drawing.Color.Gray;
            this.btnTest.FillSelectedColor = System.Drawing.Color.Gray;
            this.btnTest.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTest.ForeColor = System.Drawing.Color.Black;
            this.btnTest.Location = new System.Drawing.Point(18, 128);
            this.btnTest.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnTest.Name = "btnTest";
            this.btnTest.Radius = 0;
            this.btnTest.RectColor = System.Drawing.Color.Transparent;
            this.btnTest.RectDisableColor = System.Drawing.Color.Transparent;
            this.btnTest.RectHoverColor = System.Drawing.Color.Transparent;
            this.btnTest.RectPressColor = System.Drawing.Color.Transparent;
            this.btnTest.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btnTest.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.btnTest.Size = new System.Drawing.Size(130, 100);
            this.btnTest.Style = Sunny.UI.UIStyle.Custom;
            this.btnTest.StyleCustomMode = true;
            this.btnTest.TabIndex = 185;
            this.btnTest.Text = "设备调试";
            this.btnTest.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTest.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnReport
            // 
            this.btnReport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReport.FillColor = System.Drawing.Color.Silver;
            this.btnReport.FillHoverColor = System.Drawing.Color.Gray;
            this.btnReport.FillPressColor = System.Drawing.Color.Gray;
            this.btnReport.FillSelectedColor = System.Drawing.Color.Gray;
            this.btnReport.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReport.ForeColor = System.Drawing.Color.Black;
            this.btnReport.Location = new System.Drawing.Point(18, 348);
            this.btnReport.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnReport.Name = "btnReport";
            this.btnReport.Radius = 0;
            this.btnReport.RectColor = System.Drawing.Color.Transparent;
            this.btnReport.RectDisableColor = System.Drawing.Color.Transparent;
            this.btnReport.RectHoverColor = System.Drawing.Color.Transparent;
            this.btnReport.RectPressColor = System.Drawing.Color.Transparent;
            this.btnReport.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btnReport.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.btnReport.Size = new System.Drawing.Size(130, 100);
            this.btnReport.Style = Sunny.UI.UIStyle.Custom;
            this.btnReport.StyleCustomMode = true;
            this.btnReport.TabIndex = 186;
            this.btnReport.Text = "记录查询";
            this.btnReport.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReport.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.uiLabel3.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(273, 734);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(72, 23);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 192;
            this.uiLabel3.Text = "相机";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.uiLabel2.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(145, 734);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(72, 23);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 191;
            this.uiLabel2.Text = "PLC";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.uiLabel1.BackColor = System.Drawing.Color.Transparent;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(14, 734);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(72, 23);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 190;
            this.uiLabel1.Text = "数据库";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lightScan
            // 
            this.lightScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lightScan.BackColor = System.Drawing.Color.Transparent;
            this.lightScan.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lightScan.Location = new System.Drawing.Point(352, 727);
            this.lightScan.MinimumSize = new System.Drawing.Size(1, 1);
            this.lightScan.Name = "lightScan";
            this.lightScan.Radius = 35;
            this.lightScan.Size = new System.Drawing.Size(35, 35);
            this.lightScan.State = Sunny.UI.UILightState.Off;
            this.lightScan.Style = Sunny.UI.UIStyle.Custom;
            this.lightScan.TabIndex = 189;
            this.lightScan.Text = "uiLight1";
            this.lightScan.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lightPLC
            // 
            this.lightPLC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lightPLC.BackColor = System.Drawing.Color.Transparent;
            this.lightPLC.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lightPLC.Location = new System.Drawing.Point(226, 727);
            this.lightPLC.MinimumSize = new System.Drawing.Size(1, 1);
            this.lightPLC.Name = "lightPLC";
            this.lightPLC.Radius = 35;
            this.lightPLC.Size = new System.Drawing.Size(35, 35);
            this.lightPLC.State = Sunny.UI.UILightState.Off;
            this.lightPLC.Style = Sunny.UI.UIStyle.Custom;
            this.lightPLC.TabIndex = 188;
            this.lightPLC.Text = "uiLight1";
            this.lightPLC.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lightDB
            // 
            this.lightDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lightDB.BackColor = System.Drawing.Color.Transparent;
            this.lightDB.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lightDB.Location = new System.Drawing.Point(97, 727);
            this.lightDB.MinimumSize = new System.Drawing.Size(1, 1);
            this.lightDB.Name = "lightDB";
            this.lightDB.Radius = 35;
            this.lightDB.Size = new System.Drawing.Size(35, 35);
            this.lightDB.State = Sunny.UI.UILightState.Off;
            this.lightDB.Style = Sunny.UI.UIStyle.Custom;
            this.lightDB.TabIndex = 187;
            this.lightDB.Text = "uiLight1";
            this.lightDB.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lbTime
            // 
            this.lbTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTime.BackColor = System.Drawing.Color.Transparent;
            this.lbTime.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTime.Location = new System.Drawing.Point(761, 727);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(255, 34);
            this.lbTime.Style = Sunny.UI.UIStyle.Custom;
            this.lbTime.TabIndex = 193;
            this.lbTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbTime.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnExit.FillHoverColor = System.Drawing.Color.Red;
            this.btnExit.FillPressColor = System.Drawing.Color.Red;
            this.btnExit.FillSelectedColor = System.Drawing.Color.Red;
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(18, 568);
            this.btnExit.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnExit.Name = "btnExit";
            this.btnExit.Radius = 0;
            this.btnExit.RectColor = System.Drawing.Color.Transparent;
            this.btnExit.RectDisableColor = System.Drawing.Color.Transparent;
            this.btnExit.RectHoverColor = System.Drawing.Color.Transparent;
            this.btnExit.RectPressColor = System.Drawing.Color.Transparent;
            this.btnExit.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btnExit.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.btnExit.Size = new System.Drawing.Size(130, 100);
            this.btnExit.Style = Sunny.UI.UIStyle.Custom;
            this.btnExit.StyleCustomMode = true;
            this.btnExit.TabIndex = 194;
            this.btnExit.Text = "退出系统";
            this.btnExit.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FMain_DeviceNew
            // 
            this.AllowShowTitle = false;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.lightScan);
            this.Controls.Add(this.lightPLC);
            this.Controls.Add(this.lightDB);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnUser);
            this.Controls.Add(this.UserCenter);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.btnClean);
            this.MaximumSize = new System.Drawing.Size(1440, 900);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FMain_DeviceNew";
            this.Padding = new System.Windows.Forms.Padding(0);
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ShowFullScreen = true;
            this.ShowTitle = false;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "XXX系统V1.0";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 1024, 728);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FMain_DeviceNew_FormClosing);
            this.Click += new System.EventHandler(this.FMain_DeviceNew_Click);
            this.Resize += new System.EventHandler(this.FMain_DeviceNew_Resize);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerDateTime;
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIHeaderButton”(是否缺少程序集引用?)
        private Sunny.UI.UIHeaderButton UserCenter;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIHeaderButton”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIButton”(是否缺少程序集引用?)
        private Sunny.UI.UIButton btnReport;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIButton”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIButton”(是否缺少程序集引用?)
        private Sunny.UI.UIButton btnTest;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIButton”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIButton”(是否缺少程序集引用?)
        private Sunny.UI.UIButton btnUser;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIButton”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIButton”(是否缺少程序集引用?)
        private Sunny.UI.UIButton btnSet;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIButton”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIButton”(是否缺少程序集引用?)
        private Sunny.UI.UIButton btnClean;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIButton”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
        private Sunny.UI.UILabel uiLabel3;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
        private Sunny.UI.UILabel uiLabel2;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
        private Sunny.UI.UILabel uiLabel1;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILight”(是否缺少程序集引用?)
        private Sunny.UI.UILight lightScan;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILight”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILight”(是否缺少程序集引用?)
        private Sunny.UI.UILight lightPLC;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILight”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILight”(是否缺少程序集引用?)
        private Sunny.UI.UILight lightDB;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILight”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
        private Sunny.UI.UILabel lbTime;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIButton”(是否缺少程序集引用?)
        private Sunny.UI.UIButton btnExit;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIButton”(是否缺少程序集引用?)
    }
}

