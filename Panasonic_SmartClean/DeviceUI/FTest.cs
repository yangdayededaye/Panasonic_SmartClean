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
    public partial class FTest : UIForm
#pragma warning restore CS0246 // 未能找到类型或命名空间名“UIForm”(是否缺少 using 指令或程序集引用?)
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();

        public FTest()
        {
            InitializeComponent();
            asc.controllInitializeSize(this);

        }

        private void FTest_Resize(object sender, EventArgs e)
        {
            asc.controlAutoSize(this.Width, this.Height, this);
        }

        private void plc_Click(object sender, EventArgs e)
        {
            FPlc f = new FPlc();
            f.ShowDialog();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void camera_Click(object sender, EventArgs e)
        {
            FCamera f = new FCamera();
            f.ShowDialog();
        }

    }
}
