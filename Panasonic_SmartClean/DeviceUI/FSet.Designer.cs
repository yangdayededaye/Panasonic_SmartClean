namespace Panasonic_SmartClean.DeviceUI
{
    partial class FSet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

#pragma warning disable CS0115 // “FSet.Dispose(bool)”: 没有找到适合的方法来重写
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
#pragma warning restore CS0115 // “FSet.Dispose(bool)”: 没有找到适合的方法来重写
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
            this.SaveDays = new Sunny.UI.UIIntegerUpDown();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.uiGroupBox2 = new Sunny.UI.UIGroupBox();
            this.lbTitle = new Sunny.UI.UILabel();
            this.btnSelectSol = new Sunny.UI.UISymbolButton();
            this.btnFlowSet = new Sunny.UI.UISymbolButton();
            this.cbBeforeEnable = new Sunny.UI.UICheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.uiTextBox5 = new Sunny.UI.UITextBox();
            this.button31 = new System.Windows.Forms.Button();
            this.uiGroupBox3 = new Sunny.UI.UIGroupBox();
            this.uiGroupBox4 = new Sunny.UI.UIGroupBox();
            this.lbImagePath = new Sunny.UI.UILabel();
            this.btnImagePath = new Sunny.UI.UISymbolButton();
            this.btnVisonProcess = new Sunny.UI.UISymbolButton();
            this.uiGroupBox5 = new Sunny.UI.UIGroupBox();
            this.lbMesFilePath = new Sunny.UI.UILabel();
            this.uiSymbolButton1 = new Sunny.UI.UISymbolButton();
            this.uiGroupBox1.SuspendLayout();
            this.uiGroupBox2.SuspendLayout();
            this.uiGroupBox3.SuspendLayout();
            this.uiGroupBox4.SuspendLayout();
            this.uiGroupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveDays
            // 
            this.SaveDays.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SaveDays.Location = new System.Drawing.Point(47, 52);
            this.SaveDays.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SaveDays.MinimumSize = new System.Drawing.Size(100, 0);
            this.SaveDays.Name = "SaveDays";
            this.SaveDays.ShowText = false;
            this.SaveDays.Size = new System.Drawing.Size(116, 29);
            this.SaveDays.Style = Sunny.UI.UIStyle.Custom;
            this.SaveDays.TabIndex = 133;
            this.SaveDays.Text = "uiIntegerUpDown1";
            this.SaveDays.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.SaveDays.Value = 90;
            this.SaveDays.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.SaveDays);
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox1.Location = new System.Drawing.Point(36, 90);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(218, 110);
            this.uiGroupBox1.Style = Sunny.UI.UIStyle.Custom;
            this.uiGroupBox1.TabIndex = 134;
            this.uiGroupBox1.Text = "数据保存天数";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiGroupBox1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.lbTitle);
            this.uiGroupBox2.Controls.Add(this.btnSelectSol);
            this.uiGroupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox2.Location = new System.Drawing.Point(278, 90);
            this.uiGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox2.Size = new System.Drawing.Size(633, 110);
            this.uiGroupBox2.Style = Sunny.UI.UIStyle.Custom;
            this.uiGroupBox2.TabIndex = 135;
            this.uiGroupBox2.Text = "视觉文件路径";
            this.uiGroupBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiGroupBox2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lbTitle
            // 
            this.lbTitle.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.Location = new System.Drawing.Point(119, 47);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(497, 34);
            this.lbTitle.Style = Sunny.UI.UIStyle.Custom;
            this.lbTitle.TabIndex = 89;
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbTitle.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnSelectSol
            // 
            this.btnSelectSol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectSol.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelectSol.Location = new System.Drawing.Point(20, 45);
            this.btnSelectSol.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSelectSol.Name = "btnSelectSol";
            this.btnSelectSol.Radius = 20;
            this.btnSelectSol.Size = new System.Drawing.Size(93, 40);
            this.btnSelectSol.Style = Sunny.UI.UIStyle.Custom;
            this.btnSelectSol.Symbol = 61528;
            this.btnSelectSol.TabIndex = 85;
            this.btnSelectSol.Text = "选择";
            this.btnSelectSol.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelectSol.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnSelectSol.Click += new System.EventHandler(this.btnSelectSol_Click);
            // 
            // btnFlowSet
            // 
            this.btnFlowSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFlowSet.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFlowSet.Location = new System.Drawing.Point(59, 268);
            this.btnFlowSet.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnFlowSet.Name = "btnFlowSet";
            this.btnFlowSet.Radius = 20;
            this.btnFlowSet.Size = new System.Drawing.Size(168, 40);
            this.btnFlowSet.Style = Sunny.UI.UIStyle.Custom;
            this.btnFlowSet.Symbol = 61494;
            this.btnFlowSet.TabIndex = 90;
            this.btnFlowSet.Text = "流量阈值设置";
            this.btnFlowSet.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFlowSet.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnFlowSet.Click += new System.EventHandler(this.btnFlowSet_Click);
            // 
            // cbBeforeEnable
            // 
            this.cbBeforeEnable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbBeforeEnable.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbBeforeEnable.Location = new System.Drawing.Point(77, 434);
            this.cbBeforeEnable.MinimumSize = new System.Drawing.Size(1, 1);
            this.cbBeforeEnable.Name = "cbBeforeEnable";
            this.cbBeforeEnable.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.cbBeforeEnable.Size = new System.Drawing.Size(150, 29);
            this.cbBeforeEnable.Style = Sunny.UI.UIStyle.Custom;
            this.cbBeforeEnable.TabIndex = 136;
            this.cbBeforeEnable.Text = "显示清洗前";
            this.cbBeforeEnable.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.cbBeforeEnable.Click += new System.EventHandler(this.cbBeforeEnable_Click);
            // 
            // button4
            // 
            this.button4.ForeColor = System.Drawing.Color.Blue;
            this.button4.Location = new System.Drawing.Point(178, 48);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(67, 36);
            this.button4.TabIndex = 284;
            this.button4.Tag = "1";
            this.button4.Text = "保存";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // uiTextBox5
            // 
            this.uiTextBox5.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBox5.Location = new System.Drawing.Point(16, 48);
            this.uiTextBox5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox5.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox5.Name = "uiTextBox5";
            this.uiTextBox5.ShowText = false;
            this.uiTextBox5.Size = new System.Drawing.Size(73, 36);
            this.uiTextBox5.Style = Sunny.UI.UIStyle.Custom;
            this.uiTextBox5.TabIndex = 282;
            this.uiTextBox5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox5.Watermark = "脉冲数";
            this.uiTextBox5.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // button31
            // 
            this.button31.ForeColor = System.Drawing.Color.Blue;
            this.button31.Location = new System.Drawing.Point(103, 48);
            this.button31.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(67, 36);
            this.button31.TabIndex = 281;
            this.button31.Tag = "1";
            this.button31.Text = "读取";
            this.button31.UseVisualStyleBackColor = true;
            this.button31.Click += new System.EventHandler(this.button31_Click);
            // 
            // uiGroupBox3
            // 
            this.uiGroupBox3.Controls.Add(this.button31);
            this.uiGroupBox3.Controls.Add(this.button4);
            this.uiGroupBox3.Controls.Add(this.uiTextBox5);
            this.uiGroupBox3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox3.Location = new System.Drawing.Point(278, 461);
            this.uiGroupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox3.Name = "uiGroupBox3";
            this.uiGroupBox3.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox3.Size = new System.Drawing.Size(261, 110);
            this.uiGroupBox3.Style = Sunny.UI.UIStyle.Custom;
            this.uiGroupBox3.TabIndex = 285;
            this.uiGroupBox3.Text = "清洗时间(单位:秒)";
            this.uiGroupBox3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiGroupBox3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiGroupBox4
            // 
            this.uiGroupBox4.Controls.Add(this.lbImagePath);
            this.uiGroupBox4.Controls.Add(this.btnImagePath);
            this.uiGroupBox4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox4.Location = new System.Drawing.Point(278, 210);
            this.uiGroupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox4.Name = "uiGroupBox4";
            this.uiGroupBox4.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox4.Size = new System.Drawing.Size(633, 110);
            this.uiGroupBox4.Style = Sunny.UI.UIStyle.Custom;
            this.uiGroupBox4.TabIndex = 136;
            this.uiGroupBox4.Text = "图片存储路径";
            this.uiGroupBox4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiGroupBox4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lbImagePath
            // 
            this.lbImagePath.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbImagePath.Location = new System.Drawing.Point(119, 47);
            this.lbImagePath.Name = "lbImagePath";
            this.lbImagePath.Size = new System.Drawing.Size(497, 34);
            this.lbImagePath.Style = Sunny.UI.UIStyle.Custom;
            this.lbImagePath.TabIndex = 89;
            this.lbImagePath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbImagePath.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnImagePath
            // 
            this.btnImagePath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImagePath.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnImagePath.Location = new System.Drawing.Point(20, 45);
            this.btnImagePath.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnImagePath.Name = "btnImagePath";
            this.btnImagePath.Radius = 20;
            this.btnImagePath.Size = new System.Drawing.Size(93, 40);
            this.btnImagePath.Style = Sunny.UI.UIStyle.Custom;
            this.btnImagePath.Symbol = 61528;
            this.btnImagePath.TabIndex = 85;
            this.btnImagePath.Text = "选择";
            this.btnImagePath.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnImagePath.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnImagePath.Click += new System.EventHandler(this.btnImagePath_Click);
            // 
            // btnVisonProcess
            // 
            this.btnVisonProcess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVisonProcess.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnVisonProcess.Location = new System.Drawing.Point(59, 353);
            this.btnVisonProcess.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnVisonProcess.Name = "btnVisonProcess";
            this.btnVisonProcess.Radius = 20;
            this.btnVisonProcess.Size = new System.Drawing.Size(168, 40);
            this.btnVisonProcess.Style = Sunny.UI.UIStyle.Custom;
            this.btnVisonProcess.Symbol = 61550;
            this.btnVisonProcess.TabIndex = 286;
            this.btnVisonProcess.Text = "视觉流程设置";
            this.btnVisonProcess.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnVisonProcess.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnVisonProcess.Click += new System.EventHandler(this.btnVisonProcess_Click);
            // 
            // uiGroupBox5
            // 
            this.uiGroupBox5.Controls.Add(this.lbMesFilePath);
            this.uiGroupBox5.Controls.Add(this.uiSymbolButton1);
            this.uiGroupBox5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox5.Location = new System.Drawing.Point(278, 330);
            this.uiGroupBox5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox5.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox5.Name = "uiGroupBox5";
            this.uiGroupBox5.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox5.Size = new System.Drawing.Size(633, 110);
            this.uiGroupBox5.Style = Sunny.UI.UIStyle.Custom;
            this.uiGroupBox5.TabIndex = 137;
            this.uiGroupBox5.Text = "共享文件存储路径";
            this.uiGroupBox5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiGroupBox5.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lbMesFilePath
            // 
            this.lbMesFilePath.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMesFilePath.Location = new System.Drawing.Point(119, 47);
            this.lbMesFilePath.Name = "lbMesFilePath";
            this.lbMesFilePath.Size = new System.Drawing.Size(497, 34);
            this.lbMesFilePath.Style = Sunny.UI.UIStyle.Custom;
            this.lbMesFilePath.TabIndex = 89;
            this.lbMesFilePath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbMesFilePath.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiSymbolButton1
            // 
            this.uiSymbolButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.Location = new System.Drawing.Point(20, 45);
            this.uiSymbolButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton1.Name = "uiSymbolButton1";
            this.uiSymbolButton1.Radius = 20;
            this.uiSymbolButton1.Size = new System.Drawing.Size(93, 40);
            this.uiSymbolButton1.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton1.Symbol = 61528;
            this.uiSymbolButton1.TabIndex = 85;
            this.uiSymbolButton1.Text = "选择";
            this.uiSymbolButton1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiSymbolButton1.Click += new System.EventHandler(this.uiSymbolButton1_Click);
            // 
            // FSet
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(940, 600);
            this.Controls.Add(this.uiGroupBox5);
            this.Controls.Add(this.btnVisonProcess);
            this.Controls.Add(this.uiGroupBox4);
            this.Controls.Add(this.uiGroupBox3);
            this.Controls.Add(this.cbBeforeEnable);
            this.Controls.Add(this.btnFlowSet);
            this.Controls.Add(this.uiGroupBox2);
            this.Controls.Add(this.uiGroupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FSet";
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "设置";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Load += new System.EventHandler(this.FSet_Load);
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox2.ResumeLayout(false);
            this.uiGroupBox3.ResumeLayout(false);
            this.uiGroupBox4.ResumeLayout(false);
            this.uiGroupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIIntegerUpDown”(是否缺少程序集引用?)
        private Sunny.UI.UIIntegerUpDown SaveDays;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIIntegerUpDown”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIGroupBox”(是否缺少程序集引用?)
        private Sunny.UI.UIGroupBox uiGroupBox1;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIGroupBox”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIGroupBox”(是否缺少程序集引用?)
        private Sunny.UI.UIGroupBox uiGroupBox2;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIGroupBox”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UISymbolButton”(是否缺少程序集引用?)
        private Sunny.UI.UISymbolButton btnSelectSol;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UISymbolButton”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
        private Sunny.UI.UILabel lbTitle;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UISymbolButton”(是否缺少程序集引用?)
        private Sunny.UI.UISymbolButton btnFlowSet;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UISymbolButton”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UICheckBox”(是否缺少程序集引用?)
        private Sunny.UI.UICheckBox cbBeforeEnable;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UICheckBox”(是否缺少程序集引用?)
        private System.Windows.Forms.Button button4;
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
        private Sunny.UI.UITextBox uiTextBox5;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
        private System.Windows.Forms.Button button31;
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIGroupBox”(是否缺少程序集引用?)
        private Sunny.UI.UIGroupBox uiGroupBox3;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIGroupBox”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIGroupBox”(是否缺少程序集引用?)
        private Sunny.UI.UIGroupBox uiGroupBox4;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIGroupBox”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
        private Sunny.UI.UILabel lbImagePath;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UISymbolButton”(是否缺少程序集引用?)
        private Sunny.UI.UISymbolButton btnImagePath;
        private Sunny.UI.UISymbolButton btnVisonProcess;
        private Sunny.UI.UIGroupBox uiGroupBox5;
        private Sunny.UI.UILabel lbMesFilePath;
        private Sunny.UI.UISymbolButton uiSymbolButton1;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UISymbolButton”(是否缺少程序集引用?)
    }
}