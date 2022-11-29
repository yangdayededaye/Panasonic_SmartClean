namespace Panasonic_SmartClean
{
    partial class FProcess
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

#pragma warning disable CS0115 // “FProcess.Dispose(bool)”: 没有找到适合的方法来重写
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
#pragma warning restore CS0115 // “FProcess.Dispose(bool)”: 没有找到适合的方法来重写
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dv = new Sunny.UI.UIDataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.processtype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnNew = new Sunny.UI.UISymbolButton();
            this.txtKey = new Sunny.UI.UITextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dv)).BeginInit();
            this.SuspendLayout();
            // 
            // dv
            // 
            this.dv.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.dv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dv.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dv.BackgroundColor = System.Drawing.Color.White;
            this.dv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dv.ColumnHeadersHeight = 32;
            this.dv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.processtype,
            this.remark,
            this.delete});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dv.DefaultCellStyle = dataGridViewCellStyle3;
            this.dv.EnableHeadersVisualStyles = false;
            this.dv.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.dv.Location = new System.Drawing.Point(15, 92);
            this.dv.Name = "dv";
            this.dv.ReadOnly = true;
            this.dv.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dv.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.dv.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dv.RowTemplate.Height = 27;
            this.dv.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.dv.SelectedIndex = -1;
            this.dv.Size = new System.Drawing.Size(915, 492);
            this.dv.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.dv.Style = Sunny.UI.UIStyle.Custom;
            this.dv.StyleCustomMode = true;
            this.dv.TabIndex = 54;
            this.dv.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.dv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dv_CellClick);
            this.dv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dv_CellDoubleClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ProcessIndex";
            this.ID.HeaderText = "序号";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ProcessID";
            this.dataGridViewTextBoxColumn1.HeaderText = "流程ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ProcessName";
            this.dataGridViewTextBoxColumn2.HeaderText = "流程名称";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // processtype
            // 
            this.processtype.DataPropertyName = "Type";
            this.processtype.HeaderText = "类型";
            this.processtype.Name = "processtype";
            this.processtype.ReadOnly = true;
            // 
            // remark
            // 
            this.remark.DataPropertyName = "Remark";
            this.remark.HeaderText = "备注";
            this.remark.Name = "remark";
            this.remark.ReadOnly = true;
            // 
            // delete
            // 
            this.delete.HeaderText = "删除";
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btnNew
            // 
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNew.Location = new System.Drawing.Point(229, 47);
            this.btnNew.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(100, 35);
            this.btnNew.Style = Sunny.UI.UIStyle.Custom;
            this.btnNew.Symbol = 61543;
            this.btnNew.TabIndex = 56;
            this.btnNew.Text = "新增";
            this.btnNew.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNew.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtKey
            // 
            this.txtKey.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKey.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtKey.Location = new System.Drawing.Point(28, 50);
            this.txtKey.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtKey.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtKey.Name = "txtKey";
            this.txtKey.ShowText = false;
            this.txtKey.Size = new System.Drawing.Size(150, 29);
            this.txtKey.Style = Sunny.UI.UIStyle.Custom;
            this.txtKey.TabIndex = 55;
            this.txtKey.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtKey.Watermark = "ID";
            this.txtKey.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtKey.TextChanged += new System.EventHandler(this.txtKey_TextChanged);
            // 
            // FProcess
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(945, 600);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.dv);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1440, 900);
            this.MinimizeBox = false;
            this.Name = "FProcess";
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ShowFullScreen = true;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "视觉流程";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 600);
            ((System.ComponentModel.ISupportInitialize)(this.dv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIDataGridView”(是否缺少程序集引用?)
        private Sunny.UI.UIDataGridView dv;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIDataGridView”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UISymbolButton”(是否缺少程序集引用?)
        private Sunny.UI.UISymbolButton btnNew;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UISymbolButton”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
        private Sunny.UI.UITextBox txtKey;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UITextBox”(是否缺少程序集引用?)
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn processtype;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
    }
}