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
    public partial class FWarnList : UIForm
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();

        public FWarnList()
        {
            InitializeComponent();
            //asc.controllInitializeSize(this);

            dv.ReadOnly = true;
            dv.AutoGenerateColumns = false;
            dv.AllowUserToAddRows = false;
        }

        private void FWarnList_Resize(object sender, EventArgs e)
        {
            //asc.controlAutoSize(this.Width, this.Height, this);
        }

        private void FWarnList_Load(object sender, EventArgs e)
        {
            Invoke(new Action(() => {
                dv.DataSource = SoftConfig.db.Warn.Where(x => x.State == "0").OrderByDescending(x => x.WarnIndex).ToList();
            }));
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //
            var vlist = SoftConfig.db.Warn.Where(x => x.State == "0").ToList();
            if (vlist!=null&&vlist.Count>0)
            {
                for (int i = 0; i < vlist.Count; i++)
                {
                    vlist[i].State = "1";
                }
                SoftConfig.db.SaveChanges();
            }
            dv.DataSource = null;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            Invoke(new Action(() => {
                dv.DataSource = SoftConfig.db.Warn.Where(x => x.State == "").Take(10).OrderByDescending(x=>x.WarnIndex).ToList();
            }));
        }
    }
}
