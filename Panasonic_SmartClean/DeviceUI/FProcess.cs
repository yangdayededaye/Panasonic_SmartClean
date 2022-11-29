using EntityFramework.Extensions;
using Panasonic_SmartClean.DeviceUI;
using Panasonic_SmartClean.Model;
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
    public partial class FProcess : UIForm
#pragma warning restore CS0246 // 未能找到类型或命名空间名“UIForm”(是否缺少 using 指令或程序集引用?)
    {
        public FProcess()
        {
            InitializeComponent();
            dv.AutoGenerateColumns = false;
            dv.AllowUserToAddRows = false;
            RefreshDv(txtKey.Text);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FProcessInfo f = new FProcessInfo(null);
            f.ShowDialog();
            RefreshDv("");
        }

        private void txtKey_TextChanged(object sender, EventArgs e)
        {
            RefreshDv(txtKey.Text);
        }

        public void RefreshDv(string strKey)
        {
            dv.DataSource = SoftConfig.db.VisonProcess.Where(x => x.ProcessID.Contains(strKey)).ToList();
        }

        private void dv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dv.Columns[e.ColumnIndex].Name == "delete" && e.RowIndex >= 0)
            {
                if (ShowAskDialog("确认删除吗？", false))
                {
                    int id = int.Parse(dv.Rows[e.RowIndex].Cells[0].Value.ToString());
                    var u = SoftConfig.db.VisonProcess.Where(x => x.ProcessIndex == id).Delete();
                    SoftConfig.db.SaveChanges();
                    Util.initDB();
                    ShowSuccessTip("删除成功");
                    RefreshDv(txtKey.Text);
                }
            }
        }

        private void dv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = int.Parse(dv.Rows[e.RowIndex].Cells[0].Value.ToString());
                VisonProcess p = SoftConfig.db.VisonProcess.Where(x => x.ProcessIndex == id).ToList()[0];
                FProcessInfo f = new FProcessInfo(p);
                f.ShowDialog();
                RefreshDv("");
            }
        }
    }
}
