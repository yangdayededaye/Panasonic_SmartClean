using Panasonic_SmartClean.Service;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Panasonic_SmartClean
{
#pragma warning disable CS0246 // 未能找到类型或命名空间名“UIForm”(是否缺少 using 指令或程序集引用?)
    public partial class FAttention : UIForm
#pragma warning restore CS0246 // 未能找到类型或命名空间名“UIForm”(是否缺少 using 指令或程序集引用?)
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();
        public Hsl hsl = Hsl.Instance;
        public FAttention(string strTitle)
        {
            InitializeComponent();
            lbState.Text = strTitle;
            asc.controllInitializeSize(this);
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnNG_Click(object sender, EventArgs e)
        {
            if (!ShowAskDialog("确认已清理？请务必处理后点击！！！"))
            {
                return;
            }
            //写NG
            switch (lbState.Text)
            {
                case "小型通透检测NG槽位满":
                    hsl.WriteBool("M80", true);
                    break;
                case "小型吸嘴堵塞NG槽位满":
                    hsl.WriteBool("M81", true);
                    break;
                case "小型反光板NG槽位满":
                    hsl.WriteBool("M82", true);
                    break;
                case "小型吸嘴反光板破损NG槽位满":
                    hsl.WriteBool("M83", true);
                    break;

                case "大型通透检测NG槽位满":
                    hsl.WriteBool("M84", true);
                    break;
                case "大型吸嘴堵塞NG槽位满":
                    hsl.WriteBool("M85", true);
                    break;
                case "大型反光板NG槽位满":
                    hsl.WriteBool("M86", true);
                    break;
                case "大型吸嘴反光板破损NG槽位满":
                    hsl.WriteBool("M87", true);
                    break;

                case "超大型通透检测NG槽位满":
                    hsl.WriteBool("M88", true);
                    break;
                case "超大型吸嘴NG槽位满":
                    hsl.WriteBool("M89", true);
                    break;
                case "超大型反光板NG槽位满":
                    hsl.WriteBool("M90", true);
                    break;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void FAttention_Resize(object sender, EventArgs e)
        {
            asc.controlAutoSize(this.Width, this.Height, this);
        }
    }
}
