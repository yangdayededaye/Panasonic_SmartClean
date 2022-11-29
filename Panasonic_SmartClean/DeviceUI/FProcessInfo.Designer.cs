namespace Panasonic_SmartClean.DeviceUI
{
    partial class FProcessInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

#pragma warning disable CS0115 // “FProcessInfo.Dispose(bool)”: 没有找到适合的方法来重写
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
#pragma warning restore CS0115 // “FProcessInfo.Dispose(bool)”: 没有找到适合的方法来重写
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
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.btnSubmit = new Sunny.UI.UISymbolButton();
            this.txtName = new Sunny.UI.UITextBox();
            this.txtCode = new Sunny.UI.UITextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.txtRemark = new Sunny.UI.UITextBox();
            this.cbType = new Sunny.UI.UIComboBox();
            this.SuspendLayout();
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(39, 112);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(68, 23);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 129;
            this.uiLabel2.Text = "名称";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(39, 62);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(68, 23);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 128;
            this.uiLabel1.Text = "ID";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSubmit.Location = new System.Drawing.Point(505, 127);
            this.btnSubmit.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Radius = 20;
            this.btnSubmit.Size = new System.Drawing.Size(150, 45);
            this.btnSubmit.Style = Sunny.UI.UIStyle.Custom;
            this.btnSubmit.Symbol = 61528;
            this.btnSubmit.TabIndex = 127;
            this.btnSubmit.Text = "保存";
            this.btnSubmit.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSubmit.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(156, 111);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtName.Name = "txtName";
            this.txtName.ShowText = false;
            this.txtName.Size = new System.Drawing.Size(257, 29);
            this.txtName.Style = Sunny.UI.UIStyle.Custom;
            this.txtName.TabIndex = 126;
            this.txtName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtName.Watermark = "";
            this.txtName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtCode
            // 
            this.txtCode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCode.Location = new System.Drawing.Point(156, 59);
            this.txtCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCode.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtCode.Name = "txtCode";
            this.txtCode.ShowText = false;
            this.txtCode.Size = new System.Drawing.Size(257, 29);
            this.txtCode.Style = Sunny.UI.UIStyle.Custom;
            this.txtCode.TabIndex = 125;
            this.txtCode.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtCode.Watermark = "";
            this.txtCode.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(39, 167);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(68, 23);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 131;
            this.uiLabel3.Text = "类型";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(39, 221);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(68, 23);
            this.uiLabel4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel4.TabIndex = 133;
            this.uiLabel4.Text = "备注";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRemark.Location = new System.Drawing.Point(156, 217);
            this.txtRemark.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRemark.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ShowText = false;
            this.txtRemark.Size = new System.Drawing.Size(257, 29);
            this.txtRemark.Style = Sunny.UI.UIStyle.Custom;
            this.txtRemark.TabIndex = 132;
            this.txtRemark.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtRemark.Watermark = "";
            this.txtRemark.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cbType
            // 
            this.cbType.DataSource = null;
            this.cbType.FillColor = System.Drawing.Color.White;
            this.cbType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbType.Items.AddRange(new object[] {
            "小型",
            "大型",
            "超大型",
            "吸嘴清洗前",
            "吸嘴清洗后",
            "反光板清洗前",
            "反光板清洗后"});
            this.cbType.Location = new System.Drawing.Point(156, 165);
            this.cbType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbType.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbType.Name = "cbType";
            this.cbType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbType.Size = new System.Drawing.Size(257, 31);
            this.cbType.Style = Sunny.UI.UIStyle.Custom;
            this.cbType.TabIndex = 135;
            this.cbType.Text = "吸嘴清洗后";
            this.cbType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbType.Watermark = "";
            this.cbType.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // FProcessInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(751, 287);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCode);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FProcessInfo";
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "视觉流程维护";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Load += new System.EventHandler(this.FUserInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
        private Sunny.UI.UILabel uiLabel2;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
        private Sunny.UI.UILabel uiLabel1;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UISymbolButton”(是否缺少程序集引用?)
        private Sunny.UI.UISymbolButton btnSubmit;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UISymbolButton”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
        private Sunny.UI.UITextBox txtName;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
        private Sunny.UI.UITextBox txtCode;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
        private Sunny.UI.UILabel uiLabel3;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
        private Sunny.UI.UILabel uiLabel4;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
        private Sunny.UI.UITextBox txtRemark;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIComboBox”(是否缺少程序集引用?)
        private Sunny.UI.UIComboBox cbType;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIComboBox”(是否缺少程序集引用?)
    }
}