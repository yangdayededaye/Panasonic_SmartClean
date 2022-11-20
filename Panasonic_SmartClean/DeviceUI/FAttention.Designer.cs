namespace Panasonic_SmartClean
{
    partial class FAttention
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
            this.lbState = new Sunny.UI.UILabel();
            this.btnNG = new Sunny.UI.UISymbolButton();
            this.uiSymbolLabel1 = new Sunny.UI.UISymbolLabel();
            this.SuspendLayout();
            // 
            // lbState
            // 
            this.lbState.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbState.Location = new System.Drawing.Point(48, 88);
            this.lbState.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbState.Name = "lbState";
            this.lbState.Size = new System.Drawing.Size(614, 95);
            this.lbState.Style = Sunny.UI.UIStyle.Custom;
            this.lbState.TabIndex = 5;
            this.lbState.Text = "异常信息";
            this.lbState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbState.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnNG
            // 
            this.btnNG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNG.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNG.Location = new System.Drawing.Point(234, 386);
            this.btnNG.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnNG.Name = "btnNG";
            this.btnNG.Size = new System.Drawing.Size(254, 45);
            this.btnNG.Style = Sunny.UI.UIStyle.Custom;
            this.btnNG.TabIndex = 6;
            this.btnNG.Text = "确认处理后点击";
            this.btnNG.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNG.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnNG.Click += new System.EventHandler(this.btnNG_Click);
            // 
            // uiSymbolLabel1
            // 
            this.uiSymbolLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolLabel1.Location = new System.Drawing.Point(36, 212);
            this.uiSymbolLabel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolLabel1.Name = "uiSymbolLabel1";
            this.uiSymbolLabel1.Padding = new System.Windows.Forms.Padding(124, 0, 0, 0);
            this.uiSymbolLabel1.Size = new System.Drawing.Size(110, 120);
            this.uiSymbolLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolLabel1.Symbol = 61553;
            this.uiSymbolLabel1.SymbolSize = 120;
            this.uiSymbolLabel1.TabIndex = 7;
            this.uiSymbolLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // FAttention
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(709, 484);
            this.ControlBox = false;
            this.Controls.Add(this.uiSymbolLabel1);
            this.Controls.Add(this.btnNG);
            this.Controls.Add(this.lbState);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1440, 900);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(80, 60);
            this.Name = "FAttention";
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ShowFullScreen = true;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "注意";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.TopMost = true;
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 600);
            this.Resize += new System.EventHandler(this.FAttention_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel lbState;
        private Sunny.UI.UISymbolButton btnNG;
        private Sunny.UI.UISymbolLabel uiSymbolLabel1;
    }
}