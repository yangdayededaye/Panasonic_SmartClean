namespace Panasonic_SmartClean
{
    partial class FChangePsw
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
            this.btnExit = new Sunny.UI.UISymbolButton();
            this.btnSubmit = new Sunny.UI.UISymbolButton();
            this.txtNewPswValid = new Sunny.UI.UITextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.txtNewPsw = new Sunny.UI.UITextBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.txtOldPsw = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnExit.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnExit.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.btnExit.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExit.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnExit.Location = new System.Drawing.Point(310, 281);
            this.btnExit.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnExit.Name = "btnExit";
            this.btnExit.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnExit.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.btnExit.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExit.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExit.Size = new System.Drawing.Size(100, 35);
            this.btnExit.Style = Sunny.UI.UIStyle.Red;
            this.btnExit.StyleCustomMode = true;
            this.btnExit.Symbol = 61453;
            this.btnExit.TabIndex = 90;
            this.btnExit.Text = "取消";
            this.btnExit.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnSubmit.ForeSelectedColor = System.Drawing.Color.Empty;
            this.btnSubmit.Location = new System.Drawing.Point(149, 281);
            this.btnSubmit.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.RectSelectedColor = System.Drawing.Color.Empty;
            this.btnSubmit.Size = new System.Drawing.Size(100, 35);
            this.btnSubmit.Style = Sunny.UI.UIStyle.Custom;
            this.btnSubmit.StyleCustomMode = true;
            this.btnSubmit.TabIndex = 89;
            this.btnSubmit.Text = "提交";
            this.btnSubmit.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSubmit.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtNewPswValid
            // 
            this.txtNewPswValid.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNewPswValid.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNewPswValid.Location = new System.Drawing.Point(260, 211);
            this.txtNewPswValid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNewPswValid.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtNewPswValid.Name = "txtNewPswValid";
            this.txtNewPswValid.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.txtNewPswValid.ShowText = false;
            this.txtNewPswValid.Size = new System.Drawing.Size(150, 29);
            this.txtNewPswValid.Style = Sunny.UI.UIStyle.Custom;
            this.txtNewPswValid.TabIndex = 88;
            this.txtNewPswValid.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtNewPswValid.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(108, 206);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(128, 35);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 87;
            this.uiLabel3.Text = "验证新密码";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtNewPsw
            // 
            this.txtNewPsw.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNewPsw.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNewPsw.Location = new System.Drawing.Point(260, 156);
            this.txtNewPsw.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNewPsw.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtNewPsw.Name = "txtNewPsw";
            this.txtNewPsw.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.txtNewPsw.ShowText = false;
            this.txtNewPsw.Size = new System.Drawing.Size(150, 29);
            this.txtNewPsw.Style = Sunny.UI.UIStyle.Custom;
            this.txtNewPsw.TabIndex = 86;
            this.txtNewPsw.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtNewPsw.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(148, 151);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(84, 35);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 85;
            this.uiLabel2.Text = "新密码";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtOldPsw
            // 
            this.txtOldPsw.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOldPsw.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOldPsw.Location = new System.Drawing.Point(260, 98);
            this.txtOldPsw.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOldPsw.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtOldPsw.Name = "txtOldPsw";
            this.txtOldPsw.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.txtOldPsw.ShowText = false;
            this.txtOldPsw.Size = new System.Drawing.Size(150, 29);
            this.txtOldPsw.Style = Sunny.UI.UIStyle.Custom;
            this.txtOldPsw.TabIndex = 84;
            this.txtOldPsw.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtOldPsw.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(148, 93);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(84, 35);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 83;
            this.uiLabel1.Text = "原密码";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // FChangePsw
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(544, 367);
            this.ControlBox = false;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtNewPswValid);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.txtNewPsw);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.txtOldPsw);
            this.Controls.Add(this.uiLabel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FChangePsw";
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "修改密码";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 544, 367);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UISymbolButton btnExit;
        private Sunny.UI.UISymbolButton btnSubmit;
        private Sunny.UI.UITextBox txtNewPswValid;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UITextBox txtNewPsw;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox txtOldPsw;
        private Sunny.UI.UILabel uiLabel1;
    }
}