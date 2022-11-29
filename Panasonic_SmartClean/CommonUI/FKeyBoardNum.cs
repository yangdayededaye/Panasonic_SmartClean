using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Panasonic_SmartClean
{
#pragma warning disable CS0246 // 未能找到类型或命名空间名“UIForm”(是否缺少 using 指令或程序集引用?)
    public partial class FKeyBoardNum : UIForm
#pragma warning restore CS0246 // 未能找到类型或命名空间名“UIForm”(是否缺少 using 指令或程序集引用?)
    {
        public string output
        {
            get { return txtInput.Text; }
        }

        public FKeyBoardNum(string _titleTxt="请输入数字")
        {
            InitializeComponent();
            lbTitle.Text = _titleTxt;
        }

        private void FKeyBoardNum_Load(object sender, EventArgs e)
        {
            //int x = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Width - this.Width;
            //int y = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Height - this.Height;
            //this.SetDesktopLocation(x, y);
        }

        private void btn(object sender, EventArgs e)
        {
            UIButton btn = sender as UIButton;
            if (btn.Name.ToString().Contains("Del"))
            {
                txtInput.Text = "";
            }
            else
            {
                txtInput.Text += btn.Name.Substring(3, 1);
            }

        }


    }
}
