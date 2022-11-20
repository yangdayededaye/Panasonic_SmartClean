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
    public partial class FDataView : UIForm
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();

        public FDataView()
        {
            InitializeComponent();
            asc.controllInitializeSize(this);

        }

        private void FDataView_Resize(object sender, EventArgs e)
        {
            asc.controlAutoSize(this.Width, this.Height, this);
        }

        private void log_Click(object sender, EventArgs e)
        {
            FLog f = new FLog();
            f.ShowDialog();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chart_Click(object sender, EventArgs e)
        {
            FReport f = new FReport();
            f.ShowDialog();
        }

        private void warn_Click(object sender, EventArgs e)
        {
            FWarnList f = new FWarnList();
            f.ShowDialog();
        }

    }
}
