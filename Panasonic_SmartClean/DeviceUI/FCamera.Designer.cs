namespace Panasonic_SmartClean
{
    partial class FCamera
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
            this.lstResult = new System.Windows.Forms.ListBox();
            this.buttonConfig = new System.Windows.Forms.Button();
            this.buttonRender = new System.Windows.Forms.Button();
            this.renderPanel = new System.Windows.Forms.Panel();
            this.buttonContiRun = new System.Windows.Forms.Button();
            this.comboProcedure = new System.Windows.Forms.ComboBox();
            this.buttonRunOnce = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstResult
            // 
            this.lstResult.FormattingEnabled = true;
            this.lstResult.ItemHeight = 21;
            this.lstResult.Location = new System.Drawing.Point(12, 655);
            this.lstResult.Name = "lstResult";
            this.lstResult.Size = new System.Drawing.Size(1131, 130);
            this.lstResult.TabIndex = 6;
            // 
            // buttonConfig
            // 
            this.buttonConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConfig.BackColor = System.Drawing.Color.DimGray;
            this.buttonConfig.FlatAppearance.BorderSize = 0;
            this.buttonConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfig.ForeColor = System.Drawing.Color.White;
            this.buttonConfig.Location = new System.Drawing.Point(1267, 53);
            this.buttonConfig.Name = "buttonConfig";
            this.buttonConfig.Size = new System.Drawing.Size(85, 33);
            this.buttonConfig.TabIndex = 8;
            this.buttonConfig.Text = "参数配置";
            this.buttonConfig.UseVisualStyleBackColor = false;
            this.buttonConfig.Click += new System.EventHandler(this.buttonConfig_Click);
            // 
            // buttonRender
            // 
            this.buttonRender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRender.BackColor = System.Drawing.Color.DimGray;
            this.buttonRender.FlatAppearance.BorderSize = 0;
            this.buttonRender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRender.ForeColor = System.Drawing.Color.White;
            this.buttonRender.Location = new System.Drawing.Point(1165, 53);
            this.buttonRender.Name = "buttonRender";
            this.buttonRender.Size = new System.Drawing.Size(82, 33);
            this.buttonRender.TabIndex = 7;
            this.buttonRender.Text = "图像显示";
            this.buttonRender.UseVisualStyleBackColor = false;
            this.buttonRender.Click += new System.EventHandler(this.buttonRender_Click);
            // 
            // renderPanel
            // 
            this.renderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.renderPanel.Location = new System.Drawing.Point(0, 0);
            this.renderPanel.Name = "renderPanel";
            this.renderPanel.Size = new System.Drawing.Size(1131, 623);
            this.renderPanel.TabIndex = 9;
            // 
            // buttonContiRun
            // 
            this.buttonContiRun.BackColor = System.Drawing.Color.DimGray;
            this.buttonContiRun.FlatAppearance.BorderSize = 0;
            this.buttonContiRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonContiRun.ForeColor = System.Drawing.Color.White;
            this.buttonContiRun.Location = new System.Drawing.Point(1269, 251);
            this.buttonContiRun.Name = "buttonContiRun";
            this.buttonContiRun.Size = new System.Drawing.Size(73, 42);
            this.buttonContiRun.TabIndex = 1;
            this.buttonContiRun.Text = "连续";
            this.buttonContiRun.UseVisualStyleBackColor = false;
            this.buttonContiRun.Click += new System.EventHandler(this.buttonContiRun_Click);
            // 
            // comboProcedure
            // 
            this.comboProcedure.BackColor = System.Drawing.Color.Gray;
            this.comboProcedure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboProcedure.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboProcedure.ForeColor = System.Drawing.Color.White;
            this.comboProcedure.FormattingEnabled = true;
            this.comboProcedure.Location = new System.Drawing.Point(1176, 205);
            this.comboProcedure.Name = "comboProcedure";
            this.comboProcedure.Size = new System.Drawing.Size(167, 22);
            this.comboProcedure.TabIndex = 0;
            this.comboProcedure.SelectedIndexChanged += new System.EventHandler(this.comboProcedure_SelectedIndexChanged);
            // 
            // buttonRunOnce
            // 
            this.buttonRunOnce.BackColor = System.Drawing.Color.DimGray;
            this.buttonRunOnce.FlatAppearance.BorderSize = 0;
            this.buttonRunOnce.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRunOnce.ForeColor = System.Drawing.Color.White;
            this.buttonRunOnce.Location = new System.Drawing.Point(1176, 251);
            this.buttonRunOnce.Name = "buttonRunOnce";
            this.buttonRunOnce.Size = new System.Drawing.Size(73, 42);
            this.buttonRunOnce.TabIndex = 0;
            this.buttonRunOnce.Text = "一次";
            this.buttonRunOnce.UseVisualStyleBackColor = false;
            this.buttonRunOnce.Click += new System.EventHandler(this.buttonRunOnce_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DimGray;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(1176, 336);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(73, 42);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.renderPanel);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1131, 623);
            this.panel1.TabIndex = 11;
            // 
            // FCamera
            // 
            this.AllowShowTitle = false;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1366, 800);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.buttonContiRun);
            this.Controls.Add(this.comboProcedure);
            this.Controls.Add(this.buttonRunOnce);
            this.Controls.Add(this.buttonConfig);
            this.Controls.Add(this.buttonRender);
            this.Controls.Add(this.lstResult);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1440, 900);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FCamera";
            this.Padding = new System.Windows.Forms.Padding(0);
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ShowFullScreen = true;
            this.ShowTitle = false;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "相机调试";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 600);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FCamera_FormClosing);
            this.Load += new System.EventHandler(this.FCamera_Load);
            this.Resize += new System.EventHandler(this.FCamera_Resize);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox lstResult;
        private System.Windows.Forms.Button buttonConfig;
        private System.Windows.Forms.Button buttonRender;
        private System.Windows.Forms.Panel renderPanel;
        private System.Windows.Forms.Button buttonContiRun;
        private System.Windows.Forms.ComboBox comboProcedure;
        private System.Windows.Forms.Button buttonRunOnce;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel1;
    }
}