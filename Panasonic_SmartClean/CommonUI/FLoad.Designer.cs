namespace Panasonic_SmartClean
{
    partial class FLoad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

#pragma warning disable CS0115 // “FLoad.Dispose(bool)”: 没有找到适合的方法来重写
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
#pragma warning restore CS0115 // “FLoad.Dispose(bool)”: 没有找到适合的方法来重写
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
            this.lbState = new Sunny.UI.UILabel();
            this.uiProgressIndicator1 = new Sunny.UI.UIProgressIndicator();
            this.timerWaitFinish = new System.Windows.Forms.Timer(this.components);
            this.lbTitle = new Sunny.UI.UILabel();
            this.SuspendLayout();
            // 
            // lbState
            // 
            this.lbState.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbState.Location = new System.Drawing.Point(99, 91);
            this.lbState.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbState.Name = "lbState";
            this.lbState.Size = new System.Drawing.Size(205, 41);
            this.lbState.Style = Sunny.UI.UIStyle.Custom;
            this.lbState.TabIndex = 4;
            this.lbState.Text = "加载中。。。";
            this.lbState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbState.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiProgressIndicator1
            // 
            this.uiProgressIndicator1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiProgressIndicator1.Location = new System.Drawing.Point(24, 52);
            this.uiProgressIndicator1.Margin = new System.Windows.Forms.Padding(2);
            this.uiProgressIndicator1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiProgressIndicator1.Name = "uiProgressIndicator1";
            this.uiProgressIndicator1.Size = new System.Drawing.Size(63, 63);
            this.uiProgressIndicator1.Style = Sunny.UI.UIStyle.Custom;
            this.uiProgressIndicator1.TabIndex = 3;
            this.uiProgressIndicator1.Text = "uiProgressIndicator1";
            this.uiProgressIndicator1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // timerWaitFinish
            // 
            this.timerWaitFinish.Enabled = true;
            this.timerWaitFinish.Interval = 200;
            this.timerWaitFinish.Tick += new System.EventHandler(this.timerWaitFinish_Tick);
            // 
            // lbTitle
            // 
            this.lbTitle.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.Location = new System.Drawing.Point(99, 43);
            this.lbTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(205, 41);
            this.lbTitle.Style = Sunny.UI.UIStyle.Custom;
            this.lbTitle.TabIndex = 5;
            this.lbTitle.Text = "请稍候";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbTitle.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // FLoad
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(325, 140);
            this.ControlBox = false;
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.lbState);
            this.Controls.Add(this.uiProgressIndicator1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FLoad";
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 325, 140);
            this.ResumeLayout(false);

        }

        #endregion

#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
        private Sunny.UI.UILabel lbState;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIProgressIndicator”(是否缺少程序集引用?)
        private Sunny.UI.UIProgressIndicator uiProgressIndicator1;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIProgressIndicator”(是否缺少程序集引用?)
        private System.Windows.Forms.Timer timerWaitFinish;
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
        private Sunny.UI.UILabel lbTitle;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
    }
}