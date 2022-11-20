using System;
using System.Drawing;
using System.Windows.Forms;
namespace Panasonic_SmartClean
{
    public partial class FrmKeyboard : Form
    {
        public FrmKeyboard()
        {
            InitializeComponent();
        }
        private Size _size;
        private Point _point;
        public FrmKeyboard(Size size,Point p)
        {
             
            InitializeComponent();
            _size = size;
            _point = p;
        }
    
        public int[] KeyLst = new int[] { 48,49,50,51,52,53,54,55,56,57, 81, 87, 69, 82, 84, 89, 85, 73, 79, 80, 65, 83, 68, 70, 71, 72, 74, 75, 76, 46, 90, 88, 67, 86, 66, 78, 77,08,999 };
        public enum WindowStyles : uint
        {
            WS_OVERLAPPED = 0x00000000,
            WS_POPUP = 0x80000000,
            WS_CHILD = 0x40000000,
            WS_MINIMIZE = 0x20000000,
            WS_VISIBLE = 0x10000000,
            WS_DISABLED = 0x08000000,
            WS_CLIPSIBLINGS = 0x04000000,
            WS_CLIPCHILDREN = 0x02000000,
            WS_MAXIMIZE = 0x01000000,
            WS_BORDER = 0x00800000,
            WS_DLGFRAME = 0x00400000,
            WS_VSCROLL = 0x00200000,
            WS_HSCROLL = 0x00100000,
            WS_SYSMENU = 0x00080000,
            WS_THICKFRAME = 0x00040000,
            WS_GROUP = 0x00020000,
            WS_TABSTOP = 0x00010000,

            WS_MINIMIZEBOX = 0x00020000,
            WS_MAXIMIZEBOX = 0x00010000,

            WS_CAPTION = WS_BORDER | WS_DLGFRAME,
            WS_TILED = WS_OVERLAPPED,
            WS_ICONIC = WS_MINIMIZE,
            WS_SIZEBOX = WS_THICKFRAME,
            WS_TILEDWINDOW = WS_OVERLAPPEDWINDOW,

            WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX,
            WS_POPUPWINDOW = WS_POPUP | WS_BORDER | WS_SYSMENU,
            WS_CHILDWINDOW = WS_CHILD,

            //Extended Window Styles

            WS_EX_DLGMODALFRAME = 0x00000001,
            WS_EX_NOPARENTNOTIFY = 0x00000004,
            WS_EX_TOPMOST = 0x00000008,
            WS_EX_ACCEPTFILES = 0x00000010,
            WS_EX_TRANSPARENT = 0x00000020,

            //#if(WINVER >= 0x0400)

            WS_EX_MDICHILD = 0x00000040,
            WS_EX_TOOLWINDOW = 0x00000080,
            WS_EX_WINDOWEDGE = 0x00000100,
            WS_EX_CLIENTEDGE = 0x00000200,
            WS_EX_CONTEXTHELP = 0x00000400,

            WS_EX_RIGHT = 0x00001000,
            WS_EX_LEFT = 0x00000000,
            WS_EX_RTLREADING = 0x00002000,
            WS_EX_LTRREADING = 0x00000000,
            WS_EX_LEFTSCROLLBAR = 0x00004000,
            WS_EX_RIGHTSCROLLBAR = 0x00000000,

            WS_EX_CONTROLPARENT = 0x00010000,
            WS_EX_STATICEDGE = 0x00020000,
            WS_EX_APPWINDOW = 0x00040000,

            WS_EX_OVERLAPPEDWINDOW = (WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE),
            WS_EX_PALETTEWINDOW = (WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST),

            //#endif /* WINVER >= 0x0400 */

            //#if(WIN32WINNT >= 0x0500)

            WS_EX_LAYERED = 0x00080000,

            //#endif /* WIN32WINNT >= 0x0500 */

            //#if(WINVER >= 0x0500)

            WS_EX_NOINHERITLAYOUT = 0x00100000, // Disable inheritence of mirroring by children
            WS_EX_LAYOUTRTL = 0x00400000, // Right to left mirroring

            //#endif /* WINVER >= 0x0500 */

            //#if(WIN32WINNT >= 0x0500)

            WS_EX_COMPOSITED = 0x02000000,
            WS_EX_NOACTIVATE = 0x08000000

            //#endif /* WIN32WINNT >= 0x0500 */

        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams ret = base.CreateParams;
                ret.Style =(int)WindowStyles.WS_CHILD;
                //ret.ExStyle |= (int)WindowStyles.WS_EX_NOACTIVATE;
                //ret.X = this.PointToScreen(this.Location).X;
                //ret.Y = this.PointToScreen(this.Location).Y;
                return ret;
            }
        }
        private void FrmKeyboard_Load(object sender, EventArgs e)
        {
            //this.Size = new System.Drawing.Size(600, 300);
      
            this.Size = GetSize();
            this.Location = GetLocation();
            LoadUI();
          
            //this.StartPosition = FormStartPosition.CenterScreen;
        }

        private Size GetSize()
        {
            Size s = new Size();
            s.Width = _size.Width;
            s.Height = _size.Height / 3;
            return s;
        }

        private Point GetLocation()
        {
            Point p = new Point();
            p.X = this.PointToScreen(_point).X;
            p.Y = this.PointToScreen(_point).Y +_size.Height- this.Height;
           
            return p;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int x=(int)btn.Tag;
          
            if (x == 999)
            {
                this.Close();
            }
            else
            {

                SendKeys.Send(((char)x).ToString());
            }
        }

        public void LoadUI()
        {
            int btnWidth = (this.Width - 10) / 10;
            int btnHeight = (this.Height - 10) / 4;
            this.BackColor = ColorTranslator.FromHtml("#" + Convert.ToString((int)0xd2caca, 16).PadLeft(6, '0'));
            for (int i = 0; i < KeyLst.Length; i++)
            {

                Button btn = new Button();
                //btn.FadeGlow = false;
                //btn.IsDrawGlass = false;
                ////btn.BaseColor = Color.DodgerBlue;
                //btn.BaseColor = Color.Gray;
                //btn.DownBaseColor = Color.LightSteelBlue;
                //btn.MouseBaseColor = Color.DodgerBlue;
                //btn.BaseColor = PublicCls.GetColor(Themes.Kb1);
                //btn.DownBaseColor = PublicCls.GetColor(Themes.Kb1);
                //btn.MouseBaseColor = PublicCls.GetColor(Themes.Kb1);
                //btn.BorderColor = PublicCls.GetColor(Themes.Kb1);
                btn.Font = new System.Drawing.Font("微软雅黑", 14, FontStyle.Bold);
                btn.ForeColor = Color.White;
                btn.Size = new Size(btnWidth, btnHeight);

                btn.Click += new EventHandler(btn_Click);

                int x = KeyLst[i];
                btn.Tag = x;
                string text = "";
                if (x == 8)
                {
                    text = "Back";

                }
                else if (x == 999)
                {
                    text = "OK";
                    btn.Size = new Size(btn.Width * 2, btnHeight);
                }
                else
                {
                    text = ((char)x).ToString();
                }

                btn.Text = text;

                if (i < 10)
                {
                    btn.Location = new Point(5 + i * btnWidth, 5);
                }
                else if (i < 20)
                {
                    btn.Location = new Point(5 + (i - 10) * btnWidth, 5 + btnHeight);
                }
                else if (i < 30)
                {
                    btn.Location = new Point(5 + (i - 20) * btnWidth, 5 + btnHeight * 2);
                }
                else
                {
                    btn.Location = new Point(5 + (i - 30) * btnWidth, 5 + btnHeight * 3);
                }

                btn.Parent = this;
            }

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FrmKeyboard
            // 
            this.ClientSize = new System.Drawing.Size(725, 237);
            this.Name = "FrmKeyboard";
            this.ResumeLayout(false);

        }

        //public void LoadUI()
        //{
        //    int btnWidth=(this.Width-10)/10;
        //    int btnHeight=(this.Height-20)/5;

        //    for (int i = 0; i < KeyLst.Length; i++)
        //    {

        //        SkinButton btn = new SkinButton();
        //        btn.BaseColor = Color.DodgerBlue;
        //        btn.DownBaseColor = Color.LightSteelBlue;
        //        btn.MouseBaseColor = Color.DodgerBlue;
        //        btn.Font = new System.Drawing.Font("微软雅黑", 14, FontStyle.Bold);
        //        btn.Size = new Size(btnWidth, btnHeight);

        //        btn.Click+=new EventHandler(btn_Click);

        //         int x  = KeyLst[i];
        //         btn.Tag = x;
        //        string text="";
        //        if(x==8)
        //        {
        //            text="BackSpace";

        //        }
        //        else if (x == 999)
        //        {
        //            text = "OK";
        //            btn.Size = new Size(btn.Width * 2, btnHeight);
        //        }
        //        else
        //        {
        //            text = ((char)x).ToString();
        //        }

        //        btn.Text = text;

        //        if(i<10)
        //        {
        //            btn.Location = new Point(5 + i * btnWidth, 5);
        //        }
        //        else if (i < 20)
        //        {
        //            btn.Location = new Point(5 + (i -10)* btnWidth, 5 + btnHeight);
        //        }
        //        else if (i < 30)
        //        {
        //            btn.Location = new Point(5 + (i-20) * btnWidth, 5 + btnHeight * 2);
        //        }
        //        else
        //        {
        //            btn.Location = new Point(5 + (i -30)* btnWidth, 5 + btnHeight * 3);
        //        }

        //        btn.Parent = this;
        //    }

        //}
    }
}
