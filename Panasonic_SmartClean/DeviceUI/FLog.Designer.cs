namespace Panasonic_SmartClean
{
    partial class FLog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

#pragma warning disable CS0115 // “FLog.Dispose(bool)”: 没有找到适合的方法来重写
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
#pragma warning restore CS0115 // “FLog.Dispose(bool)”: 没有找到适合的方法来重写
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
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.cbUser = new Sunny.UI.UIComboBox();
            this.dpUseEnd = new Sunny.UI.UIDatetimePicker();
            this.dpUseStart = new Sunny.UI.UIDatetimePicker();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.dv = new Sunny.UI.UIDataGridView();
            this.btnStart = new Sunny.UI.UIButton();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.cbMouse = new Sunny.UI.UIComboBox();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.cbBoard = new Sunny.UI.UIComboBox();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.cbFlow = new Sunny.UI.UIComboBox();
            this.index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workpieceindex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OCR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentsort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.specamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.boardresult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FlowResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FlowCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.image1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.image2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.image3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.image4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dv)).BeginInit();
            this.SuspendLayout();
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(29, 63);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(45, 23);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 141;
            this.uiLabel1.Text = "用户";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cbUser
            // 
            this.cbUser.DataSource = null;
            this.cbUser.FillColor = System.Drawing.Color.White;
            this.cbUser.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbUser.Location = new System.Drawing.Point(93, 61);
            this.cbUser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbUser.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbUser.Name = "cbUser";
            this.cbUser.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbUser.Size = new System.Drawing.Size(150, 29);
            this.cbUser.Style = Sunny.UI.UIStyle.Custom;
            this.cbUser.TabIndex = 140;
            this.cbUser.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbUser.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // dpUseEnd
            // 
            this.dpUseEnd.FillColor = System.Drawing.Color.White;
            this.dpUseEnd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dpUseEnd.Location = new System.Drawing.Point(365, 116);
            this.dpUseEnd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dpUseEnd.MaxLength = 19;
            this.dpUseEnd.MinimumSize = new System.Drawing.Size(63, 0);
            this.dpUseEnd.Name = "dpUseEnd";
            this.dpUseEnd.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.dpUseEnd.Size = new System.Drawing.Size(224, 29);
            this.dpUseEnd.Style = Sunny.UI.UIStyle.Custom;
            this.dpUseEnd.SymbolDropDown = 61555;
            this.dpUseEnd.SymbolNormal = 61555;
            this.dpUseEnd.TabIndex = 144;
            this.dpUseEnd.Text = "2022-06-13 10:42:25";
            this.dpUseEnd.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.dpUseEnd.Value = new System.DateTime(2022, 6, 13, 10, 42, 25, 201);
            this.dpUseEnd.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // dpUseStart
            // 
            this.dpUseStart.FillColor = System.Drawing.Color.White;
            this.dpUseStart.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dpUseStart.Location = new System.Drawing.Point(91, 116);
            this.dpUseStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dpUseStart.MaxLength = 19;
            this.dpUseStart.MinimumSize = new System.Drawing.Size(63, 0);
            this.dpUseStart.Name = "dpUseStart";
            this.dpUseStart.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.dpUseStart.Size = new System.Drawing.Size(224, 29);
            this.dpUseStart.Style = Sunny.UI.UIStyle.Custom;
            this.dpUseStart.SymbolDropDown = 61555;
            this.dpUseStart.SymbolNormal = 61555;
            this.dpUseStart.TabIndex = 143;
            this.dpUseStart.Text = "2022-06-13 10:42:25";
            this.dpUseStart.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.dpUseStart.Value = new System.DateTime(2022, 6, 13, 10, 42, 25, 0);
            this.dpUseStart.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(320, 118);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(40, 23);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 142;
            this.uiLabel2.Text = "~";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // dv
            // 
            this.dv.AllowUserToAddRows = false;
            this.dv.AllowUserToDeleteRows = false;
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
            this.index,
            this.taskno,
            this.workpieceindex,
            this.BarCode,
            this.OCR,
            this.currentsort,
            this.specamount,
            this.totalamount,
            this.boardresult,
            this.FlowResult,
            this.FlowCount,
            this.image1,
            this.image2,
            this.image3,
            this.image4});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dv.DefaultCellStyle = dataGridViewCellStyle3;
            this.dv.EnableHeadersVisualStyles = false;
            this.dv.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.dv.Location = new System.Drawing.Point(29, 177);
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
            this.dv.Size = new System.Drawing.Size(904, 468);
            this.dv.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.dv.Style = Sunny.UI.UIStyle.Custom;
            this.dv.StyleCustomMode = true;
            this.dv.TabIndex = 145;
            this.dv.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.dv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dv_CellClick);
            // 
            // btnStart
            // 
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.Location = new System.Drawing.Point(695, 105);
            this.btnStart.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnStart.Name = "btnStart";
            this.btnStart.Radius = 10;
            this.btnStart.RectSize = 2;
            this.btnStart.Size = new System.Drawing.Size(224, 47);
            this.btnStart.StyleCustomMode = true;
            this.btnStart.TabIndex = 146;
            this.btnStart.Text = "查询";
            this.btnStart.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(29, 119);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(45, 23);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 147;
            this.uiLabel3.Text = "时间";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(275, 63);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(45, 23);
            this.uiLabel4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel4.TabIndex = 149;
            this.uiLabel4.Text = "吸嘴";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cbMouse
            // 
            this.cbMouse.DataSource = null;
            this.cbMouse.FillColor = System.Drawing.Color.White;
            this.cbMouse.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbMouse.Items.AddRange(new object[] {
            "不限",
            "OK",
            "NG"});
            this.cbMouse.Location = new System.Drawing.Point(333, 61);
            this.cbMouse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbMouse.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbMouse.Name = "cbMouse";
            this.cbMouse.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbMouse.Size = new System.Drawing.Size(87, 29);
            this.cbMouse.Style = Sunny.UI.UIStyle.Custom;
            this.cbMouse.TabIndex = 148;
            this.cbMouse.Text = "不限";
            this.cbMouse.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbMouse.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.Location = new System.Drawing.Point(444, 63);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(66, 23);
            this.uiLabel5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel5.TabIndex = 151;
            this.uiLabel5.Text = "反光板";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel5.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cbBoard
            // 
            this.cbBoard.DataSource = null;
            this.cbBoard.FillColor = System.Drawing.Color.White;
            this.cbBoard.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbBoard.Items.AddRange(new object[] {
            "不限",
            "OK",
            "NG"});
            this.cbBoard.Location = new System.Drawing.Point(522, 61);
            this.cbBoard.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbBoard.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbBoard.Name = "cbBoard";
            this.cbBoard.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbBoard.Size = new System.Drawing.Size(87, 29);
            this.cbBoard.Style = Sunny.UI.UIStyle.Custom;
            this.cbBoard.TabIndex = 150;
            this.cbBoard.Text = "不限";
            this.cbBoard.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbBoard.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel6.Location = new System.Drawing.Point(636, 63);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(45, 23);
            this.uiLabel6.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel6.TabIndex = 153;
            this.uiLabel6.Text = "流量";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel6.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cbFlow
            // 
            this.cbFlow.DataSource = null;
            this.cbFlow.FillColor = System.Drawing.Color.White;
            this.cbFlow.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbFlow.Items.AddRange(new object[] {
            "不限",
            "OK",
            "NG"});
            this.cbFlow.Location = new System.Drawing.Point(693, 61);
            this.cbFlow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbFlow.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbFlow.Name = "cbFlow";
            this.cbFlow.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbFlow.Size = new System.Drawing.Size(87, 29);
            this.cbFlow.Style = Sunny.UI.UIStyle.Custom;
            this.cbFlow.TabIndex = 152;
            this.cbFlow.Text = "不限";
            this.cbFlow.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbFlow.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // index
            // 
            this.index.DataPropertyName = "LogIndex";
            this.index.HeaderText = "index";
            this.index.Name = "index";
            this.index.ReadOnly = true;
            this.index.Visible = false;
            // 
            // taskno
            // 
            this.taskno.DataPropertyName = "TaskIndex";
            this.taskno.HeaderText = "任务号";
            this.taskno.Name = "taskno";
            this.taskno.ReadOnly = true;
            // 
            // workpieceindex
            // 
            this.workpieceindex.DataPropertyName = "WorkPieceIndex";
            this.workpieceindex.HeaderText = "序号";
            this.workpieceindex.Name = "workpieceindex";
            this.workpieceindex.ReadOnly = true;
            // 
            // BarCode
            // 
            this.BarCode.DataPropertyName = "BarCode";
            this.BarCode.HeaderText = "条码";
            this.BarCode.Name = "BarCode";
            this.BarCode.ReadOnly = true;
            // 
            // OCR
            // 
            this.OCR.DataPropertyName = "Ocr";
            this.OCR.HeaderText = "OCR";
            this.OCR.Name = "OCR";
            this.OCR.ReadOnly = true;
            // 
            // currentsort
            // 
            this.currentsort.DataPropertyName = "LogTime";
            this.currentsort.HeaderText = "时间";
            this.currentsort.Name = "currentsort";
            this.currentsort.ReadOnly = true;
            // 
            // specamount
            // 
            this.specamount.DataPropertyName = "Type";
            this.specamount.HeaderText = "类别";
            this.specamount.Name = "specamount";
            this.specamount.ReadOnly = true;
            // 
            // totalamount
            // 
            this.totalamount.DataPropertyName = "MouseResult";
            this.totalamount.HeaderText = "吸嘴";
            this.totalamount.Name = "totalamount";
            this.totalamount.ReadOnly = true;
            // 
            // boardresult
            // 
            this.boardresult.DataPropertyName = "ReflectPanelResult";
            this.boardresult.HeaderText = "反光板";
            this.boardresult.Name = "boardresult";
            this.boardresult.ReadOnly = true;
            // 
            // FlowResult
            // 
            this.FlowResult.DataPropertyName = "FlowResult";
            this.FlowResult.HeaderText = "流量";
            this.FlowResult.Name = "FlowResult";
            this.FlowResult.ReadOnly = true;
            // 
            // FlowCount
            // 
            this.FlowCount.DataPropertyName = "FlowCount";
            this.FlowCount.HeaderText = "流量值";
            this.FlowCount.Name = "FlowCount";
            this.FlowCount.ReadOnly = true;
            // 
            // image1
            // 
            this.image1.DataPropertyName = "MouseBefore";
            this.image1.HeaderText = "image1";
            this.image1.Name = "image1";
            this.image1.ReadOnly = true;
            this.image1.Visible = false;
            // 
            // image2
            // 
            this.image2.DataPropertyName = "BoardBefore";
            this.image2.HeaderText = "image2";
            this.image2.Name = "image2";
            this.image2.ReadOnly = true;
            this.image2.Visible = false;
            // 
            // image3
            // 
            this.image3.DataPropertyName = "MouseAfter";
            this.image3.HeaderText = "image3";
            this.image3.Name = "image3";
            this.image3.ReadOnly = true;
            this.image3.Visible = false;
            // 
            // image4
            // 
            this.image4.DataPropertyName = "BoardAfter";
            this.image4.HeaderText = "image4";
            this.image4.Name = "image4";
            this.image4.ReadOnly = true;
            this.image4.Visible = false;
            // 
            // FLog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(962, 665);
            this.Controls.Add(this.uiLabel6);
            this.Controls.Add(this.cbFlow);
            this.Controls.Add(this.uiLabel5);
            this.Controls.Add(this.cbBoard);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.cbMouse);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.dv);
            this.Controls.Add(this.dpUseEnd);
            this.Controls.Add(this.dpUseStart);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.cbUser);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1440, 900);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FLog";
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ShowFullScreen = true;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "记录";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 600);
            this.Load += new System.EventHandler(this.FLog_Load);
            this.Resize += new System.EventHandler(this.FLog_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
        private Sunny.UI.UILabel uiLabel1;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIComboBox”(是否缺少程序集引用?)
        private Sunny.UI.UIComboBox cbUser;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIComboBox”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIDatetimePicker”(是否缺少程序集引用?)
        private Sunny.UI.UIDatetimePicker dpUseEnd;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIDatetimePicker”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIDatetimePicker”(是否缺少程序集引用?)
        private Sunny.UI.UIDatetimePicker dpUseStart;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIDatetimePicker”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
        private Sunny.UI.UILabel uiLabel2;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIDataGridView”(是否缺少程序集引用?)
        private Sunny.UI.UIDataGridView dv;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIDataGridView”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIButton”(是否缺少程序集引用?)
        private Sunny.UI.UIButton btnStart;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIButton”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
        private Sunny.UI.UILabel uiLabel3;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
        private Sunny.UI.UILabel uiLabel4;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIComboBox”(是否缺少程序集引用?)
        private Sunny.UI.UIComboBox cbMouse;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIComboBox”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
        private Sunny.UI.UILabel uiLabel5;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIComboBox”(是否缺少程序集引用?)
        private Sunny.UI.UIComboBox cbBoard;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIComboBox”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
        private Sunny.UI.UILabel uiLabel6;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UILabel”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIComboBox”(是否缺少程序集引用?)
        private Sunny.UI.UIComboBox cbFlow;
#pragma warning restore CS0234 // 命名空间“Sunny.UI”中不存在类型或命名空间名“UIComboBox”(是否缺少程序集引用?)
        private System.Windows.Forms.DataGridViewTextBoxColumn index;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskno;
        private System.Windows.Forms.DataGridViewTextBoxColumn workpieceindex;
        private System.Windows.Forms.DataGridViewTextBoxColumn BarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn OCR;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentsort;
        private System.Windows.Forms.DataGridViewTextBoxColumn specamount;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalamount;
        private System.Windows.Forms.DataGridViewTextBoxColumn boardresult;
        private System.Windows.Forms.DataGridViewTextBoxColumn FlowResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn FlowCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn image1;
        private System.Windows.Forms.DataGridViewTextBoxColumn image2;
        private System.Windows.Forms.DataGridViewTextBoxColumn image3;
        private System.Windows.Forms.DataGridViewTextBoxColumn image4;
    }
}