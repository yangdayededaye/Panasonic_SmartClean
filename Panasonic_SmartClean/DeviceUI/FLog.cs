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
    public partial class FLog : UIForm
#pragma warning restore CS0246 // 未能找到类型或命名空间名“UIForm”(是否缺少 using 指令或程序集引用?)
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();

        public FLog()
        {
            InitializeComponent();
            //asc.controllInitializeSize(this);

            dv.ReadOnly = true;
            dv.AutoGenerateColumns = false;
            dv.AllowUserToAddRows = false;
        }

        private void FLog_Resize(object sender, EventArgs e)
        {
            //asc.controlAutoSize(this.Width, this.Height, this);
        }

        private void FLog_Load(object sender, EventArgs e)
        {
            dpUseStart.Value = DateTime.Now.AddDays(-3);
            dpUseEnd.Value = DateTime.Now;

            var users = SoftConfig.db.User.Where(x => x.State == "0").ToList();
            if (users != null&& users.Count()>0)
            {
                foreach (var item in users)
                {
                    cbUser.Items.Add(item.UserCode+"|"+item.UserName);
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string strKey = cbUser.Text != "" ? cbUser.Text.Split('|')[0] : "";
            Invoke(new Action(()=> {
                List<CleanLog> lst = SoftConfig.db.CleanLog.Where(x => x.CabNo==SoftConfig.CabNo&&x.Operator.Contains(strKey) && DbFunctions.DiffDays(dpUseStart.Value, x.LogTime) >= 0 && DbFunctions.DiffDays(dpUseEnd.Value, x.LogTime) <= 0).ToList();
                if (cbMouse.Text!="不限")
                {
                    lst = lst.Where(x => x.MouseResult == cbMouse.Text).ToList();
                }
                if (cbBoard.Text != "不限")
                {
                    lst = lst.Where(x => x.ReflectPanelResult == cbBoard.Text).ToList();
                }
                if (cbFlow.Text != "不限")
                {
                    lst = lst.Where(x => x.FlowResult == cbFlow.Text).ToList();
                }
                dv.DataSource = lst;

            }));
        }

        private void dv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                FLogInfo f = new FLogInfo(dv.Rows[e.RowIndex].Cells[7].Value == null ? "" : dv.Rows[e.RowIndex].Cells[7].Value.ToString(), dv.Rows[e.RowIndex].Cells[8].Value == null ? "" : dv.Rows[e.RowIndex].Cells[8].Value.ToString(), dv.Rows[e.RowIndex].Cells[11].Value == null ? "" : dv.Rows[e.RowIndex].Cells[11].Value.ToString(), dv.Rows[e.RowIndex].Cells[12].Value == null ? "" : dv.Rows[e.RowIndex].Cells[12].Value.ToString(), dv.Rows[e.RowIndex].Cells[13].Value == null ? "" : dv.Rows[e.RowIndex].Cells[13].Value.ToString(), dv.Rows[e.RowIndex].Cells[14].Value == null ? "" : dv.Rows[e.RowIndex].Cells[14].Value.ToString());
                f.ShowDialog();
            }
        }

    }
}
