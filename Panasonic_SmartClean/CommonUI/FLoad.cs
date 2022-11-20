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
    public partial class FLoad : UIForm
    {
        public bool IsFinished = false;
        public FLoad(string _title = "请稍候", string _state = "加载中。。。")
        {
            InitializeComponent();
            lbTitle.Text = _title;
            lbState.Text = _state;
        }

        private void timerWaitFinish_Tick(object sender, EventArgs e)
        {
            if (IsFinished)
            {
                Close();
            }
        }
    }
}
