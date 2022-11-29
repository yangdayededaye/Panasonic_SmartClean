namespace Panasonic_SmartClean
{
    partial class FTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

#pragma warning disable CS0115 // “FTest.Dispose(bool)”: 没有找到适合的方法来重写
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
#pragma warning restore CS0115 // “FTest.Dispose(bool)”: 没有找到适合的方法来重写
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
            this.camera = new Sunny.UI.UISymbolButton();
            this.exit = new Sunny.UI.UISymbolButton();
            this.plcAction = new Sunny.UI.UISymbolButton();
            this.SuspendLayout();
            // 
            // camera
            // 
            this.camera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.camera.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.camera.IsCircle = true;
            this.camera.Location = new System.Drawing.Point(307, 92);
            this.camera.MinimumSize = new System.Drawing.Size(1, 1);
            this.camera.Name = "camera";
            this.camera.Radius = 117;
            this.camera.Size = new System.Drawing.Size(190, 171);
            this.camera.StyleCustomMode = true;
            this.camera.Symbol = 362458;
            this.camera.TabIndex = 8;
            this.camera.Text = "相机调试";
            this.camera.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.camera.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.camera.Click += new System.EventHandler(this.camera_Click);
            // 
            // exit
            // 
            this.exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.exit.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.exit.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.exit.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.exit.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.exit.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.exit.IsCircle = true;
            this.exit.Location = new System.Drawing.Point(567, 92);
            this.exit.MinimumSize = new System.Drawing.Size(1, 1);
            this.exit.Name = "exit";
            this.exit.Radius = 117;
            this.exit.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.exit.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.exit.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.exit.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.exit.Size = new System.Drawing.Size(190, 171);
            this.exit.Style = Sunny.UI.UIStyle.Red;
            this.exit.StyleCustomMode = true;
            this.exit.Symbol = 61453;
            this.exit.TabIndex = 7;
            this.exit.Text = "退出";
            this.exit.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.exit.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // plcAction
            // 
            this.plcAction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.plcAction.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plcAction.IsCircle = true;
            this.plcAction.Location = new System.Drawing.Point(47, 92);
            this.plcAction.MinimumSize = new System.Drawing.Size(1, 1);
            this.plcAction.Name = "plcAction";
            this.plcAction.Radius = 117;
            this.plcAction.Size = new System.Drawing.Size(190, 171);
            this.plcAction.StyleCustomMode = true;
            this.plcAction.Symbol = 62171;
            this.plcAction.TabIndex = 6;
            this.plcAction.Text = "PLC动作";
            this.plcAction.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plcAction.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.plcAction.Click += new System.EventHandler(this.plc_Click);
            // 
            // FTest
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 317);
            this.Controls.Add(this.camera);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.plcAction);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1440, 900);
            this.MinimizeBox = false;
            this.Name = "FTest";
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ShowFullScreen = true;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "调试";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 600);
            this.Resize += new System.EventHandler(this.FTest_Resize);
            this.ResumeLayout(false);

        }

        #endregion

#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UISymbolButton”(是否缺少程序集引用?)
        private Sunny.UI.UISymbolButton camera;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UISymbolButton”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UISymbolButton”(是否缺少程序集引用?)
        private Sunny.UI.UISymbolButton exit;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UISymbolButton”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UISymbolButton”(是否缺少程序集引用?)
        private Sunny.UI.UISymbolButton plcAction;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UISymbolButton”(是否缺少程序集引用?)
    }
}