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
    public partial class FFlow : UIForm
    {
        public FFlow()
        {
            InitializeComponent();
            dv.AutoGenerateColumns = false;
            dv.AllowUserToAddRows = false;
            RefreshDv(txtKey.Text);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FFlowInfo f = new FFlowInfo(null);
            f.ShowDialog();
            RefreshDv("");
        }

        private void txtKey_TextChanged(object sender, EventArgs e)
        {
            RefreshDv(txtKey.Text);
        }

        public void RefreshDv(string strKey)
        {
            dv.DataSource = SoftConfig.db.Flow.Where(x => x.Ocr.Contains(strKey)).ToList();
        }

        private void dv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dv.Columns[e.ColumnIndex].Name == "delete" && e.RowIndex >= 0)
            {
                if (ShowAskDialog("确认删除吗？", false))
                {
                    int id = int.Parse(dv.Rows[e.RowIndex].Cells[0].Value.ToString());
                    var u = SoftConfig.db.Flow.Where(x => x.ThresholdIndex == id).Delete();
                    SoftConfig.db.SaveChanges();
                    Util.initDB();
                    ShowSuccessTip("删除成功");
                    RefreshDv(txtKey.Text);
                }
            }
        }

        private void dv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                FlowCls d = new FlowCls(dv.Rows[e.RowIndex].Cells[1].Value.ToString(), int.Parse(dv.Rows[e.RowIndex].Cells[2].Value.ToString()));
                d.ID = int.Parse(dv.Rows[e.RowIndex].Cells[0].Value.ToString());
                FFlowInfo f = new FFlowInfo(d);
                f.ShowDialog();
                RefreshDv("");
            }
        }
    }
}
