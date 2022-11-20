namespace Panasonic_SmartClean
{
    partial class FCleanNew
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
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
            this.components = new System.ComponentModel.Container();
            this.timerShow = new System.Windows.Forms.Timer(this.components);
            this.lbWarn = new Sunny.UI.UISymbolLabel();
            this.ledUltrasonic = new Sunny.UI.UILedBulb();
            this.ledHot = new Sunny.UI.UILedBulb();
            this.ledCheckState = new Sunny.UI.UILedBulb();
            this.ledLoop = new Sunny.UI.UILedBulb();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.uiLabel8 = new Sunny.UI.UILabel();
            this.btnExit = new Sunny.UI.UIButton();
            this.uiLabel14 = new Sunny.UI.UILabel();
            this.uiLabel16 = new Sunny.UI.UILabel();
            this.ledCheckNGResult = new Sunny.UI.UILedBulb();
            this.ledCheckCleanResult = new Sunny.UI.UILedBulb();
            this.btnStart = new Sunny.UI.UIButton();
            this.btnOrigin = new Sunny.UI.UIButton();
            this.btnConfirm = new Sunny.UI.UIButton();
            this.vmRenderControl1 = new VMControls.Winform.Release.VmRenderControl();
            this.MouseResult = new Sunny.UI.UIButton();
            this.BoardResult = new Sunny.UI.UIButton();
            this.FlowResult = new Sunny.UI.UIButton();
            this.uiLabel17 = new Sunny.UI.UILabel();
            this.uiLabel18 = new Sunny.UI.UILabel();
            this.uiLabel19 = new Sunny.UI.UILabel();
            this.FlowCount = new Sunny.UI.UIButton();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiButton4 = new Sunny.UI.UIButton();
            this.uiButton5 = new Sunny.UI.UIButton();
            this.uiButton7 = new Sunny.UI.UIButton();
            this.uiButton8 = new Sunny.UI.UIButton();
            this.uiLabel10 = new Sunny.UI.UILabel();
            this.uiButton6 = new Sunny.UI.UIButton();
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiButton3 = new Sunny.UI.UIButton();
            this.uiButton2 = new Sunny.UI.UIButton();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pMap = new System.Windows.Forms.Panel();
            this.btnType = new Sunny.UI.UIButton();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.btnClearCleanCount = new Sunny.UI.UIButton();
            this.uiLabel11 = new Sunny.UI.UILabel();
            this.lstLog = new Sunny.UI.UIListBox();
            this.uiLabel12 = new Sunny.UI.UILabel();
            this.lbCleanTime = new Sunny.UI.UILabel();
            this.uiLabel15 = new Sunny.UI.UILabel();
            this.btnDoor = new Sunny.UI.UIButton();
            this.btnBell = new Sunny.UI.UIButton();
            this.btnCountDown = new Sunny.UI.UIButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerShow
            // 
            this.timerShow.Enabled = true;
            this.timerShow.Interval = 2000;
            this.timerShow.Tick += new System.EventHandler(this.timerShow_Tick);
            // 
            // lbWarn
            // 
            this.lbWarn.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbWarn.Location = new System.Drawing.Point(805, 79);
            this.lbWarn.MinimumSize = new System.Drawing.Size(1, 1);
            this.lbWarn.Name = "lbWarn";
            this.lbWarn.Padding = new System.Windows.Forms.Padding(34, 0, 0, 0);
            this.lbWarn.Size = new System.Drawing.Size(365, 51);
            this.lbWarn.Style = Sunny.UI.UIStyle.Custom;
            this.lbWarn.StyleCustomMode = true;
            this.lbWarn.Symbol = 61553;
            this.lbWarn.SymbolColor = System.Drawing.Color.Green;
            this.lbWarn.SymbolOffset = new System.Drawing.Point(0, 2);
            this.lbWarn.SymbolSize = 30;
            this.lbWarn.TabIndex = 63;
            this.lbWarn.Text = "运行正常";
            this.lbWarn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbWarn.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // ledUltrasonic
            // 
            this.ledUltrasonic.Location = new System.Drawing.Point(27, 79);
            this.ledUltrasonic.Name = "ledUltrasonic";
            this.ledUltrasonic.On = false;
            this.ledUltrasonic.Size = new System.Drawing.Size(50, 50);
            this.ledUltrasonic.TabIndex = 146;
            this.ledUltrasonic.Text = "uiLedBulb1";
            this.ledUltrasonic.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // ledHot
            // 
            this.ledHot.Location = new System.Drawing.Point(166, 79);
            this.ledHot.Name = "ledHot";
            this.ledHot.On = false;
            this.ledHot.Size = new System.Drawing.Size(50, 50);
            this.ledHot.TabIndex = 147;
            this.ledHot.Text = "uiLedBulb2";
            this.ledHot.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // ledCheckState
            // 
            this.ledCheckState.Location = new System.Drawing.Point(444, 79);
            this.ledCheckState.Name = "ledCheckState";
            this.ledCheckState.On = false;
            this.ledCheckState.Size = new System.Drawing.Size(50, 50);
            this.ledCheckState.TabIndex = 148;
            this.ledCheckState.Text = "ledCheckState";
            this.ledCheckState.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // ledLoop
            // 
            this.ledLoop.Location = new System.Drawing.Point(305, 79);
            this.ledLoop.Name = "ledLoop";
            this.ledLoop.On = false;
            this.ledLoop.Size = new System.Drawing.Size(50, 50);
            this.ledLoop.TabIndex = 149;
            this.ledLoop.Text = "uiLedBulb4";
            this.ledLoop.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(19, 159);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(68, 23);
            this.uiLabel4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel4.TabIndex = 154;
            this.uiLabel4.Text = "超声波";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel6.Location = new System.Drawing.Point(156, 159);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(68, 23);
            this.uiLabel6.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel6.TabIndex = 156;
            this.uiLabel6.Text = "加热";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel6.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel7
            // 
            this.uiLabel7.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel7.Location = new System.Drawing.Point(296, 159);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(68, 23);
            this.uiLabel7.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel7.TabIndex = 157;
            this.uiLabel7.Text = "循环泵";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel7.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel8
            // 
            this.uiLabel8.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel8.Location = new System.Drawing.Point(419, 159);
            this.uiLabel8.Name = "uiLabel8";
            this.uiLabel8.Size = new System.Drawing.Size(102, 23);
            this.uiLabel8.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel8.TabIndex = 158;
            this.uiLabel8.Text = "自检状态";
            this.uiLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel8.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnExit.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnExit.FillHoverColor = System.Drawing.Color.Gray;
            this.btnExit.FillPressColor = System.Drawing.Color.Gray;
            this.btnExit.FillSelectedColor = System.Drawing.Color.Gray;
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(7, 12);
            this.btnExit.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnExit.Name = "btnExit";
            this.btnExit.Radius = 10;
            this.btnExit.RectColor = System.Drawing.Color.Transparent;
            this.btnExit.RectHoverColor = System.Drawing.Color.Transparent;
            this.btnExit.RectPressColor = System.Drawing.Color.Transparent;
            this.btnExit.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btnExit.RectSize = 2;
            this.btnExit.Size = new System.Drawing.Size(71, 47);
            this.btnExit.Style = Sunny.UI.UIStyle.Custom;
            this.btnExit.StyleCustomMode = true;
            this.btnExit.TabIndex = 162;
            this.btnExit.Text = "返回";
            this.btnExit.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // uiLabel14
            // 
            this.uiLabel14.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel14.Location = new System.Drawing.Point(694, 159);
            this.uiLabel14.Name = "uiLabel14";
            this.uiLabel14.Size = new System.Drawing.Size(115, 23);
            this.uiLabel14.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel14.TabIndex = 173;
            this.uiLabel14.Text = "NG自检";
            this.uiLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel14.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel16
            // 
            this.uiLabel16.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel16.Location = new System.Drawing.Point(561, 159);
            this.uiLabel16.Name = "uiLabel16";
            this.uiLabel16.Size = new System.Drawing.Size(103, 23);
            this.uiLabel16.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel16.TabIndex = 171;
            this.uiLabel16.Text = "清洗自检";
            this.uiLabel16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel16.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // ledCheckNGResult
            // 
            this.ledCheckNGResult.Color = System.Drawing.Color.Red;
            this.ledCheckNGResult.Location = new System.Drawing.Point(722, 79);
            this.ledCheckNGResult.Name = "ledCheckNGResult";
            this.ledCheckNGResult.On = false;
            this.ledCheckNGResult.Size = new System.Drawing.Size(50, 50);
            this.ledCheckNGResult.TabIndex = 164;
            this.ledCheckNGResult.Text = "uiLedBulb15";
            this.ledCheckNGResult.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // ledCheckCleanResult
            // 
            this.ledCheckCleanResult.Color = System.Drawing.Color.Red;
            this.ledCheckCleanResult.Location = new System.Drawing.Point(583, 79);
            this.ledCheckCleanResult.Name = "ledCheckCleanResult";
            this.ledCheckCleanResult.On = false;
            this.ledCheckCleanResult.Size = new System.Drawing.Size(50, 50);
            this.ledCheckCleanResult.TabIndex = 163;
            this.ledCheckCleanResult.Text = "ledCheckResult";
            this.ledCheckCleanResult.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnStart
            // 
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnStart.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnStart.FillHoverColor = System.Drawing.Color.Gray;
            this.btnStart.FillPressColor = System.Drawing.Color.Gray;
            this.btnStart.FillSelectedColor = System.Drawing.Color.Gray;
            this.btnStart.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.ForeColor = System.Drawing.Color.Black;
            this.btnStart.Location = new System.Drawing.Point(167, 12);
            this.btnStart.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnStart.Name = "btnStart";
            this.btnStart.Radius = 10;
            this.btnStart.RectColor = System.Drawing.Color.Transparent;
            this.btnStart.RectHoverColor = System.Drawing.Color.Transparent;
            this.btnStart.RectPressColor = System.Drawing.Color.Transparent;
            this.btnStart.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btnStart.RectSize = 2;
            this.btnStart.Size = new System.Drawing.Size(71, 47);
            this.btnStart.Style = Sunny.UI.UIStyle.Custom;
            this.btnStart.StyleCustomMode = true;
            this.btnStart.TabIndex = 180;
            this.btnStart.Text = "开始";
            this.btnStart.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnOrigin
            // 
            this.btnOrigin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrigin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOrigin.FillHoverColor = System.Drawing.Color.Gray;
            this.btnOrigin.FillPressColor = System.Drawing.Color.Gray;
            this.btnOrigin.FillSelectedColor = System.Drawing.Color.Gray;
            this.btnOrigin.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOrigin.ForeColor = System.Drawing.Color.Black;
            this.btnOrigin.Location = new System.Drawing.Point(87, 12);
            this.btnOrigin.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnOrigin.Name = "btnOrigin";
            this.btnOrigin.Radius = 10;
            this.btnOrigin.RectColor = System.Drawing.Color.Transparent;
            this.btnOrigin.RectHoverColor = System.Drawing.Color.Transparent;
            this.btnOrigin.RectPressColor = System.Drawing.Color.Transparent;
            this.btnOrigin.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btnOrigin.RectSize = 2;
            this.btnOrigin.Size = new System.Drawing.Size(71, 47);
            this.btnOrigin.Style = Sunny.UI.UIStyle.Custom;
            this.btnOrigin.StyleCustomMode = true;
            this.btnOrigin.TabIndex = 181;
            this.btnOrigin.Text = "原点";
            this.btnOrigin.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOrigin.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnOrigin.Click += new System.EventHandler(this.btnOrigin_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnConfirm.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.btnConfirm.FillHoverColor = System.Drawing.Color.Gray;
            this.btnConfirm.FillPressColor = System.Drawing.Color.Gray;
            this.btnConfirm.FillSelectedColor = System.Drawing.Color.Gray;
            this.btnConfirm.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.ForeColor = System.Drawing.Color.Black;
            this.btnConfirm.Location = new System.Drawing.Point(249, 12);
            this.btnConfirm.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Radius = 10;
            this.btnConfirm.RectColor = System.Drawing.Color.Transparent;
            this.btnConfirm.RectHoverColor = System.Drawing.Color.Transparent;
            this.btnConfirm.RectPressColor = System.Drawing.Color.Transparent;
            this.btnConfirm.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btnConfirm.RectSize = 2;
            this.btnConfirm.Size = new System.Drawing.Size(96, 47);
            this.btnConfirm.Style = Sunny.UI.UIStyle.Custom;
            this.btnConfirm.StyleCustomMode = true;
            this.btnConfirm.TabIndex = 183;
            this.btnConfirm.Text = "自检确认";
            this.btnConfirm.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // vmRenderControl1
            // 
            this.vmRenderControl1.BackColor = System.Drawing.Color.Black;
            this.vmRenderControl1.CoordinateInfoVisible = true;
            this.vmRenderControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vmRenderControl1.ImageSource = null;
            this.vmRenderControl1.IsShowCustomROIMenu = false;
            this.vmRenderControl1.Location = new System.Drawing.Point(0, 0);
            this.vmRenderControl1.ModuleSource = null;
            this.vmRenderControl1.Name = "vmRenderControl1";
            this.vmRenderControl1.Size = new System.Drawing.Size(543, 331);
            this.vmRenderControl1.TabIndex = 186;
            // 
            // MouseResult
            // 
            this.MouseResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MouseResult.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.MouseResult.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.MouseResult.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.MouseResult.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.MouseResult.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.MouseResult.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MouseResult.ForeColor = System.Drawing.Color.Red;
            this.MouseResult.Location = new System.Drawing.Point(793, 301);
            this.MouseResult.MinimumSize = new System.Drawing.Size(1, 1);
            this.MouseResult.Name = "MouseResult";
            this.MouseResult.Radius = 10;
            this.MouseResult.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.MouseResult.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.MouseResult.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.MouseResult.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.MouseResult.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.MouseResult.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.MouseResult.RectSize = 2;
            this.MouseResult.Size = new System.Drawing.Size(223, 43);
            this.MouseResult.Style = Sunny.UI.UIStyle.Custom;
            this.MouseResult.StyleCustomMode = true;
            this.MouseResult.TabIndex = 187;
            this.MouseResult.Text = "未知";
            this.MouseResult.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MouseResult.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // BoardResult
            // 
            this.BoardResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BoardResult.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BoardResult.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.BoardResult.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.BoardResult.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.BoardResult.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.BoardResult.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BoardResult.ForeColor = System.Drawing.Color.Red;
            this.BoardResult.Location = new System.Drawing.Point(793, 373);
            this.BoardResult.MinimumSize = new System.Drawing.Size(1, 1);
            this.BoardResult.Name = "BoardResult";
            this.BoardResult.Radius = 10;
            this.BoardResult.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.BoardResult.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.BoardResult.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.BoardResult.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.BoardResult.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.BoardResult.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.BoardResult.RectSize = 2;
            this.BoardResult.Size = new System.Drawing.Size(223, 43);
            this.BoardResult.Style = Sunny.UI.UIStyle.Custom;
            this.BoardResult.StyleCustomMode = true;
            this.BoardResult.TabIndex = 188;
            this.BoardResult.Text = "未知";
            this.BoardResult.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BoardResult.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // FlowResult
            // 
            this.FlowResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FlowResult.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FlowResult.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.FlowResult.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.FlowResult.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.FlowResult.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.FlowResult.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FlowResult.ForeColor = System.Drawing.Color.Red;
            this.FlowResult.Location = new System.Drawing.Point(793, 445);
            this.FlowResult.MinimumSize = new System.Drawing.Size(1, 1);
            this.FlowResult.Name = "FlowResult";
            this.FlowResult.Radius = 10;
            this.FlowResult.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.FlowResult.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.FlowResult.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.FlowResult.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.FlowResult.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.FlowResult.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.FlowResult.RectSize = 2;
            this.FlowResult.Size = new System.Drawing.Size(223, 43);
            this.FlowResult.Style = Sunny.UI.UIStyle.Custom;
            this.FlowResult.StyleCustomMode = true;
            this.FlowResult.TabIndex = 189;
            this.FlowResult.Text = "未知";
            this.FlowResult.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FlowResult.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel17
            // 
            this.uiLabel17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.uiLabel17.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel17.Location = new System.Drawing.Point(611, 307);
            this.uiLabel17.Name = "uiLabel17";
            this.uiLabel17.Size = new System.Drawing.Size(137, 30);
            this.uiLabel17.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel17.TabIndex = 190;
            this.uiLabel17.Text = "吸嘴尖端";
            this.uiLabel17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel17.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel18
            // 
            this.uiLabel18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.uiLabel18.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel18.Location = new System.Drawing.Point(611, 380);
            this.uiLabel18.Name = "uiLabel18";
            this.uiLabel18.Size = new System.Drawing.Size(137, 30);
            this.uiLabel18.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel18.TabIndex = 191;
            this.uiLabel18.Text = "反光板";
            this.uiLabel18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel18.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel19
            // 
            this.uiLabel19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.uiLabel19.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel19.Location = new System.Drawing.Point(611, 453);
            this.uiLabel19.Name = "uiLabel19";
            this.uiLabel19.Size = new System.Drawing.Size(137, 30);
            this.uiLabel19.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel19.TabIndex = 192;
            this.uiLabel19.Text = "流量";
            this.uiLabel19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel19.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // FlowCount
            // 
            this.FlowCount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FlowCount.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FlowCount.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.FlowCount.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.FlowCount.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.FlowCount.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.FlowCount.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FlowCount.ForeColor = System.Drawing.Color.Teal;
            this.FlowCount.Location = new System.Drawing.Point(793, 517);
            this.FlowCount.MinimumSize = new System.Drawing.Size(1, 1);
            this.FlowCount.Name = "FlowCount";
            this.FlowCount.Radius = 10;
            this.FlowCount.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.FlowCount.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.FlowCount.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.FlowCount.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.FlowCount.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.FlowCount.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.FlowCount.RectSize = 2;
            this.FlowCount.Size = new System.Drawing.Size(223, 43);
            this.FlowCount.Style = Sunny.UI.UIStyle.Custom;
            this.FlowCount.StyleCustomMode = true;
            this.FlowCount.TabIndex = 196;
            this.FlowCount.Text = "00 ml/min";
            this.FlowCount.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FlowCount.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel3
            // 
            this.uiLabel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(608, 526);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(140, 30);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 195;
            this.uiLabel3.Text = "流量值";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiButton4
            // 
            this.uiButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.uiButton4.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.uiButton4.FillHoverColor = System.Drawing.Color.Gray;
            this.uiButton4.FillPressColor = System.Drawing.Color.Gray;
            this.uiButton4.FillSelectedColor = System.Drawing.Color.Gray;
            this.uiButton4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton4.ForeColor = System.Drawing.Color.Black;
            this.uiButton4.Location = new System.Drawing.Point(571, 12);
            this.uiButton4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton4.Name = "uiButton4";
            this.uiButton4.Radius = 10;
            this.uiButton4.RectColor = System.Drawing.Color.Transparent;
            this.uiButton4.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiButton4.RectPressColor = System.Drawing.Color.Transparent;
            this.uiButton4.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiButton4.RectSize = 2;
            this.uiButton4.Size = new System.Drawing.Size(180, 47);
            this.uiButton4.Style = Sunny.UI.UIStyle.Custom;
            this.uiButton4.StyleCustomMode = true;
            this.uiButton4.TabIndex = 186;
            this.uiButton4.Text = "通透检测NG槽复位";
            this.uiButton4.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButton4.Click += new System.EventHandler(this.uiButton4_Click);
            // 
            // uiButton5
            // 
            this.uiButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton5.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.uiButton5.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.uiButton5.FillHoverColor = System.Drawing.Color.Gray;
            this.uiButton5.FillPressColor = System.Drawing.Color.Gray;
            this.uiButton5.FillSelectedColor = System.Drawing.Color.Gray;
            this.uiButton5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton5.ForeColor = System.Drawing.Color.Black;
            this.uiButton5.Location = new System.Drawing.Point(760, 12);
            this.uiButton5.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton5.Name = "uiButton5";
            this.uiButton5.Radius = 10;
            this.uiButton5.RectColor = System.Drawing.Color.Transparent;
            this.uiButton5.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiButton5.RectPressColor = System.Drawing.Color.Transparent;
            this.uiButton5.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiButton5.RectSize = 2;
            this.uiButton5.Size = new System.Drawing.Size(221, 47);
            this.uiButton5.Style = Sunny.UI.UIStyle.Custom;
            this.uiButton5.StyleCustomMode = true;
            this.uiButton5.TabIndex = 187;
            this.uiButton5.Text = "吸嘴反光板破损NG槽复位";
            this.uiButton5.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton5.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButton5.Click += new System.EventHandler(this.uiButton5_Click);
            // 
            // uiButton7
            // 
            this.uiButton7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton7.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.uiButton7.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.uiButton7.FillHoverColor = System.Drawing.Color.Gray;
            this.uiButton7.FillPressColor = System.Drawing.Color.Gray;
            this.uiButton7.FillSelectedColor = System.Drawing.Color.Gray;
            this.uiButton7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton7.ForeColor = System.Drawing.Color.Black;
            this.uiButton7.Location = new System.Drawing.Point(990, 12);
            this.uiButton7.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton7.Name = "uiButton7";
            this.uiButton7.Radius = 10;
            this.uiButton7.RectColor = System.Drawing.Color.Transparent;
            this.uiButton7.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiButton7.RectPressColor = System.Drawing.Color.Transparent;
            this.uiButton7.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiButton7.RectSize = 2;
            this.uiButton7.Size = new System.Drawing.Size(180, 47);
            this.uiButton7.Style = Sunny.UI.UIStyle.Custom;
            this.uiButton7.StyleCustomMode = true;
            this.uiButton7.TabIndex = 185;
            this.uiButton7.Text = "反光板NG槽复位";
            this.uiButton7.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton7.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButton7.Click += new System.EventHandler(this.uiButton7_Click);
            // 
            // uiButton8
            // 
            this.uiButton8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton8.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.uiButton8.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(0)))));
            this.uiButton8.FillHoverColor = System.Drawing.Color.Gray;
            this.uiButton8.FillPressColor = System.Drawing.Color.Gray;
            this.uiButton8.FillSelectedColor = System.Drawing.Color.Gray;
            this.uiButton8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton8.ForeColor = System.Drawing.Color.Black;
            this.uiButton8.Location = new System.Drawing.Point(1179, 12);
            this.uiButton8.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton8.Name = "uiButton8";
            this.uiButton8.Radius = 10;
            this.uiButton8.RectColor = System.Drawing.Color.Transparent;
            this.uiButton8.RectHoverColor = System.Drawing.Color.Transparent;
            this.uiButton8.RectPressColor = System.Drawing.Color.Transparent;
            this.uiButton8.RectSelectedColor = System.Drawing.Color.Transparent;
            this.uiButton8.RectSize = 2;
            this.uiButton8.Size = new System.Drawing.Size(221, 47);
            this.uiButton8.Style = Sunny.UI.UIStyle.Custom;
            this.uiButton8.StyleCustomMode = true;
            this.uiButton8.TabIndex = 184;
            this.uiButton8.Text = "吸嘴堵塞NG槽复位";
            this.uiButton8.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton8.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButton8.Click += new System.EventHandler(this.uiButton8_Click);
            // 
            // uiLabel10
            // 
            this.uiLabel10.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel10.Location = new System.Drawing.Point(1110, 724);
            this.uiLabel10.Name = "uiLabel10";
            this.uiLabel10.Size = new System.Drawing.Size(82, 23);
            this.uiLabel10.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel10.TabIndex = 206;
            this.uiLabel10.Text = "OK";
            this.uiLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel10.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiButton6
            // 
            this.uiButton6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.uiButton6.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.uiButton6.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.uiButton6.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.uiButton6.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.uiButton6.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton6.ForeColor = System.Drawing.Color.Red;
            this.uiButton6.Location = new System.Drawing.Point(1071, 726);
            this.uiButton6.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton6.Name = "uiButton6";
            this.uiButton6.Radius = 10;
            this.uiButton6.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.uiButton6.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.uiButton6.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.uiButton6.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.uiButton6.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.uiButton6.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiButton6.RectSize = 2;
            this.uiButton6.Size = new System.Drawing.Size(25, 21);
            this.uiButton6.Style = Sunny.UI.UIStyle.Custom;
            this.uiButton6.StyleCustomMode = true;
            this.uiButton6.TabIndex = 205;
            this.uiButton6.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton6.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel9
            // 
            this.uiLabel9.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel9.Location = new System.Drawing.Point(1268, 722);
            this.uiLabel9.Name = "uiLabel9";
            this.uiLabel9.Size = new System.Drawing.Size(82, 23);
            this.uiLabel9.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel9.TabIndex = 202;
            this.uiLabel9.Text = "NG";
            this.uiLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel9.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(1268, 685);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(82, 23);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 200;
            this.uiLabel2.Text = "有产品";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(1110, 688);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(82, 23);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 195;
            this.uiLabel1.Text = "无产品";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiButton3
            // 
            this.uiButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.uiButton3.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.uiButton3.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.uiButton3.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.uiButton3.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.uiButton3.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton3.ForeColor = System.Drawing.Color.Red;
            this.uiButton3.Location = new System.Drawing.Point(1229, 688);
            this.uiButton3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton3.Name = "uiButton3";
            this.uiButton3.Radius = 10;
            this.uiButton3.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.uiButton3.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.uiButton3.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.uiButton3.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.uiButton3.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.uiButton3.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiButton3.RectSize = 2;
            this.uiButton3.Size = new System.Drawing.Size(25, 21);
            this.uiButton3.Style = Sunny.UI.UIStyle.Custom;
            this.uiButton3.StyleCustomMode = true;
            this.uiButton3.TabIndex = 198;
            this.uiButton3.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiButton2
            // 
            this.uiButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton2.FillColor = System.Drawing.Color.Red;
            this.uiButton2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.uiButton2.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.uiButton2.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.uiButton2.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.uiButton2.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton2.ForeColor = System.Drawing.Color.Red;
            this.uiButton2.Location = new System.Drawing.Point(1229, 726);
            this.uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Radius = 10;
            this.uiButton2.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.uiButton2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.uiButton2.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.uiButton2.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.uiButton2.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.uiButton2.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiButton2.RectSize = 2;
            this.uiButton2.Size = new System.Drawing.Size(25, 21);
            this.uiButton2.Style = Sunny.UI.UIStyle.Custom;
            this.uiButton2.StyleCustomMode = true;
            this.uiButton2.TabIndex = 198;
            this.uiButton2.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.uiButton1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.uiButton1.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.uiButton1.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.uiButton1.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.uiButton1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.ForeColor = System.Drawing.Color.Red;
            this.uiButton1.Location = new System.Drawing.Point(1071, 688);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Radius = 10;
            this.uiButton1.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.uiButton1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.uiButton1.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.uiButton1.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.uiButton1.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.uiButton1.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiButton1.RectSize = 2;
            this.uiButton1.Size = new System.Drawing.Size(25, 21);
            this.uiButton1.Style = Sunny.UI.UIStyle.Custom;
            this.uiButton1.StyleCustomMode = true;
            this.uiButton1.TabIndex = 197;
            this.uiButton1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.vmRenderControl1);
            this.panel1.Location = new System.Drawing.Point(19, 229);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(543, 331);
            this.panel1.TabIndex = 207;
            // 
            // pMap
            // 
            this.pMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pMap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pMap.Location = new System.Drawing.Point(1068, 229);
            this.pMap.Name = "pMap";
            this.pMap.Size = new System.Drawing.Size(332, 444);
            this.pMap.TabIndex = 208;
            // 
            // btnType
            // 
            this.btnType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnType.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnType.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnType.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.btnType.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnType.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnType.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnType.ForeColor = System.Drawing.Color.Black;
            this.btnType.Location = new System.Drawing.Point(793, 229);
            this.btnType.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnType.Name = "btnType";
            this.btnType.Radius = 10;
            this.btnType.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.btnType.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnType.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.btnType.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnType.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnType.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.btnType.RectSize = 2;
            this.btnType.Size = new System.Drawing.Size(223, 43);
            this.btnType.Style = Sunny.UI.UIStyle.Custom;
            this.btnType.StyleCustomMode = true;
            this.btnType.TabIndex = 209;
            this.btnType.Text = "未知";
            this.btnType.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnType.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel5
            // 
            this.uiLabel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.Location = new System.Drawing.Point(611, 234);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(137, 30);
            this.uiLabel5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel5.TabIndex = 210;
            this.uiLabel5.Text = "型号";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel5.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnClearCleanCount
            // 
            this.btnClearCleanCount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearCleanCount.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClearCleanCount.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnClearCleanCount.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.btnClearCleanCount.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnClearCleanCount.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnClearCleanCount.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClearCleanCount.ForeColor = System.Drawing.Color.Black;
            this.btnClearCleanCount.Location = new System.Drawing.Point(879, 679);
            this.btnClearCleanCount.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnClearCleanCount.Name = "btnClearCleanCount";
            this.btnClearCleanCount.Radius = 10;
            this.btnClearCleanCount.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.btnClearCleanCount.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnClearCleanCount.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.btnClearCleanCount.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnClearCleanCount.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnClearCleanCount.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.btnClearCleanCount.RectSize = 2;
            this.btnClearCleanCount.Size = new System.Drawing.Size(164, 70);
            this.btnClearCleanCount.Style = Sunny.UI.UIStyle.Custom;
            this.btnClearCleanCount.StyleCustomMode = true;
            this.btnClearCleanCount.TabIndex = 211;
            this.btnClearCleanCount.Text = "未知";
            this.btnClearCleanCount.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClearCleanCount.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnClearCleanCount.Click += new System.EventHandler(this.btnClearCleanCount_Click);
            // 
            // uiLabel11
            // 
            this.uiLabel11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.uiLabel11.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel11.Location = new System.Drawing.Point(877, 598);
            this.uiLabel11.Name = "uiLabel11";
            this.uiLabel11.Size = new System.Drawing.Size(166, 56);
            this.uiLabel11.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel11.TabIndex = 212;
            this.uiLabel11.Text = "累计清洗次数";
            this.uiLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel11.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lstLog
            // 
            this.lstLog.FillColor = System.Drawing.Color.White;
            this.lstLog.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lstLog.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.lstLog.ItemSelectForeColor = System.Drawing.Color.White;
            this.lstLog.Location = new System.Drawing.Point(19, 598);
            this.lstLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstLog.MinimumSize = new System.Drawing.Size(1, 1);
            this.lstLog.Name = "lstLog";
            this.lstLog.Padding = new System.Windows.Forms.Padding(2);
            this.lstLog.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lstLog.ShowText = false;
            this.lstLog.Size = new System.Drawing.Size(840, 151);
            this.lstLog.Style = Sunny.UI.UIStyle.Custom;
            this.lstLog.TabIndex = 213;
            this.lstLog.Text = "lstLog";
            this.lstLog.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel12
            // 
            this.uiLabel12.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel12.Location = new System.Drawing.Point(1197, 74);
            this.uiLabel12.Name = "uiLabel12";
            this.uiLabel12.Size = new System.Drawing.Size(178, 23);
            this.uiLabel12.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel12.TabIndex = 216;
            this.uiLabel12.Text = "超声波强度 : 90%";
            this.uiLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel12.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lbCleanTime
            // 
            this.lbCleanTime.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCleanTime.Location = new System.Drawing.Point(1197, 192);
            this.lbCleanTime.Name = "lbCleanTime";
            this.lbCleanTime.Size = new System.Drawing.Size(178, 23);
            this.lbCleanTime.Style = Sunny.UI.UIStyle.Custom;
            this.lbCleanTime.TabIndex = 215;
            this.lbCleanTime.Text = "时间 : 4min";
            this.lbCleanTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbCleanTime.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel15
            // 
            this.uiLabel15.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel15.Location = new System.Drawing.Point(1197, 133);
            this.uiLabel15.Name = "uiLabel15";
            this.uiLabel15.Size = new System.Drawing.Size(178, 23);
            this.uiLabel15.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel15.TabIndex = 214;
            this.uiLabel15.Text = "水温 : 40℃";
            this.uiLabel15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel15.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnDoor
            // 
            this.btnDoor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDoor.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDoor.FillHoverColor = System.Drawing.Color.Gray;
            this.btnDoor.FillPressColor = System.Drawing.Color.Gray;
            this.btnDoor.FillSelectedColor = System.Drawing.Color.Gray;
            this.btnDoor.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDoor.ForeColor = System.Drawing.Color.Black;
            this.btnDoor.Location = new System.Drawing.Point(464, 12);
            this.btnDoor.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnDoor.Name = "btnDoor";
            this.btnDoor.Radius = 10;
            this.btnDoor.RectColor = System.Drawing.Color.Transparent;
            this.btnDoor.RectHoverColor = System.Drawing.Color.Transparent;
            this.btnDoor.RectPressColor = System.Drawing.Color.Transparent;
            this.btnDoor.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btnDoor.RectSize = 2;
            this.btnDoor.Size = new System.Drawing.Size(96, 47);
            this.btnDoor.Style = Sunny.UI.UIStyle.Custom;
            this.btnDoor.StyleCustomMode = true;
            this.btnDoor.TabIndex = 218;
            this.btnDoor.Text = "门禁开关";
            this.btnDoor.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDoor.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnDoor.Click += new System.EventHandler(this.btnDoor_Click);
            // 
            // btnBell
            // 
            this.btnBell.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBell.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBell.FillHoverColor = System.Drawing.Color.Gray;
            this.btnBell.FillPressColor = System.Drawing.Color.Gray;
            this.btnBell.FillSelectedColor = System.Drawing.Color.Gray;
            this.btnBell.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBell.ForeColor = System.Drawing.Color.Black;
            this.btnBell.Location = new System.Drawing.Point(357, 12);
            this.btnBell.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnBell.Name = "btnBell";
            this.btnBell.Radius = 10;
            this.btnBell.RectColor = System.Drawing.Color.Transparent;
            this.btnBell.RectHoverColor = System.Drawing.Color.Transparent;
            this.btnBell.RectPressColor = System.Drawing.Color.Transparent;
            this.btnBell.RectSelectedColor = System.Drawing.Color.Transparent;
            this.btnBell.RectSize = 2;
            this.btnBell.Size = new System.Drawing.Size(96, 47);
            this.btnBell.Style = Sunny.UI.UIStyle.Custom;
            this.btnBell.StyleCustomMode = true;
            this.btnBell.TabIndex = 217;
            this.btnBell.Text = "蜂鸣开关";
            this.btnBell.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBell.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnBell.Click += new System.EventHandler(this.btnBell_Click);
            // 
            // btnCountDown
            // 
            this.btnCountDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCountDown.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCountDown.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnCountDown.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.btnCountDown.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnCountDown.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnCountDown.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCountDown.ForeColor = System.Drawing.Color.Black;
            this.btnCountDown.Location = new System.Drawing.Point(1068, 159);
            this.btnCountDown.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnCountDown.Name = "btnCountDown";
            this.btnCountDown.Radius = 10;
            this.btnCountDown.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.btnCountDown.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnCountDown.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.btnCountDown.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnCountDown.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btnCountDown.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.btnCountDown.RectSize = 2;
            this.btnCountDown.Size = new System.Drawing.Size(109, 64);
            this.btnCountDown.Style = Sunny.UI.UIStyle.Custom;
            this.btnCountDown.StyleCustomMode = true;
            this.btnCountDown.TabIndex = 219;
            this.btnCountDown.Text = "未知(&Q)";
            this.btnCountDown.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCountDown.Visible = false;
            this.btnCountDown.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnCountDown.Click += new System.EventHandler(this.btnCountDown_Click);
            // 
            // FCleanNew
            // 
            this.AllowShowTitle = false;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1420, 768);
            this.Controls.Add(this.btnCountDown);
            this.Controls.Add(this.btnDoor);
            this.Controls.Add(this.lbWarn);
            this.Controls.Add(this.btnBell);
            this.Controls.Add(this.uiLabel12);
            this.Controls.Add(this.lbCleanTime);
            this.Controls.Add(this.uiLabel15);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.uiLabel11);
            this.Controls.Add(this.btnClearCleanCount);
            this.Controls.Add(this.btnType);
            this.Controls.Add(this.uiLabel5);
            this.Controls.Add(this.pMap);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.FlowCount);
            this.Controls.Add(this.uiLabel10);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.FlowResult);
            this.Controls.Add(this.uiButton6);
            this.Controls.Add(this.BoardResult);
            this.Controls.Add(this.MouseResult);
            this.Controls.Add(this.uiLabel19);
            this.Controls.Add(this.uiLabel9);
            this.Controls.Add(this.uiLabel18);
            this.Controls.Add(this.uiButton4);
            this.Controls.Add(this.uiLabel17);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.uiButton3);
            this.Controls.Add(this.uiButton5);
            this.Controls.Add(this.uiButton2);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.uiButton7);
            this.Controls.Add(this.ledHot);
            this.Controls.Add(this.uiButton8);
            this.Controls.Add(this.ledUltrasonic);
            this.Controls.Add(this.uiLabel16);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.uiLabel14);
            this.Controls.Add(this.btnOrigin);
            this.Controls.Add(this.ledCheckState);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.ledCheckNGResult);
            this.Controls.Add(this.ledLoop);
            this.Controls.Add(this.ledCheckCleanResult);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.uiLabel8);
            this.Controls.Add(this.uiLabel6);
            this.Controls.Add(this.uiLabel7);
            this.MaximumSize = new System.Drawing.Size(1440, 900);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FCleanNew";
            this.Padding = new System.Windows.Forms.Padding(0);
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ShowFullScreen = true;
            this.ShowIcon = false;
            this.ShowTitle = false;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "智能清洗";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 600);
            this.Load += new System.EventHandler(this.FCleanNew_Load);
            this.Click += new System.EventHandler(this.FCleanNew_Click);
            this.Resize += new System.EventHandler(this.FCleanNew_Resize);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerShow;
        private Sunny.UI.UISymbolLabel lbWarn;
        private Sunny.UI.UILedBulb ledUltrasonic;
        private Sunny.UI.UILedBulb ledHot;
        private Sunny.UI.UILedBulb ledCheckState;
        private Sunny.UI.UILedBulb ledLoop;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UIButton btnExit;
        private Sunny.UI.UILabel uiLabel14;
        private Sunny.UI.UILabel uiLabel16;
        private Sunny.UI.UILedBulb ledCheckNGResult;
        private Sunny.UI.UILedBulb ledCheckCleanResult;
        private Sunny.UI.UIButton btnStart;
        private Sunny.UI.UIButton btnOrigin;
        private Sunny.UI.UIButton btnConfirm;
        private VMControls.Winform.Release.VmRenderControl vmRenderControl1;
        private Sunny.UI.UIButton MouseResult;
        private Sunny.UI.UIButton BoardResult;
        private Sunny.UI.UIButton FlowResult;
        private Sunny.UI.UILabel uiLabel17;
        private Sunny.UI.UILabel uiLabel18;
        private Sunny.UI.UILabel uiLabel19;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIButton uiButton3;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel10;
        private Sunny.UI.UIButton uiButton6;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UIButton FlowCount;
        private Sunny.UI.UIButton uiButton4;
        private Sunny.UI.UIButton uiButton5;
        private Sunny.UI.UIButton uiButton7;
        private Sunny.UI.UIButton uiButton8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pMap;
        private Sunny.UI.UIButton btnType;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UIButton btnClearCleanCount;
        private Sunny.UI.UILabel uiLabel11;
        private Sunny.UI.UIListBox lstLog;
        private Sunny.UI.UILabel uiLabel12;
        private Sunny.UI.UILabel lbCleanTime;
        private Sunny.UI.UILabel uiLabel15;
        private Sunny.UI.UIButton btnDoor;
        private Sunny.UI.UIButton btnBell;
        private Sunny.UI.UIButton btnCountDown;
    }
}