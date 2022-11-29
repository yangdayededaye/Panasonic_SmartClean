using EntityFramework.Extensions;
using Panasonic_SmartClean.DeviceUI;
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
    public partial class FUser : UIForm
#pragma warning restore CS0246 // 未能找到类型或命名空间名“UIForm”(是否缺少 using 指令或程序集引用?)
    {

        //state-类别：0-非待发 1-待发 
        //flag-发送标志：0-未发送 1-已发送

        public string _PreNo = "";
        public Thread th;
        public bool bCancel = false;
        public Mcu m = Mcu.Instance;

        public FUser()
        {
            InitializeComponent();
            dv.AutoGenerateColumns = false;
            RefreshDv(txtKey.Text);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FUserInfo f = new FUserInfo(null);
            f.ShowDialog();
            RefreshDv("");
        }

        private void btnSynPY_Click(object sender, EventArgs e)
        {
            //FLoad f = new FLoad("请稍候", "处理中。。。");
            //Task t = new Task(() =>
            //{
            //    //更新
            //    var vdrugs = SoftConfig.db.Users.Where(x => x.UserCode != "").ToList();
            //    if (vdrugs != null && vdrugs.Count > 0)
            //    {
            //        for (int i = 0; i < vdrugs.Count; i++)
            //        {
            //            vdrugs[i].UserPY = PyHelper.Convert(vdrugs[i].UserName);
            //        }
            //    }
            //    SoftConfig.db.SaveChanges();
                
            //    f.IsFinished = true;
            //});
            //t.Start();
            //f.ShowDialog();
            //RefreshDv(txtKey.Text);

        }

        private void txtKey_TextChanged(object sender, EventArgs e)
        {
            RefreshDv(txtKey.Text);
        }

        public void RefreshDv(string strKey)
        {
            dv.DataSource = SoftConfig.db.User.Where(x => x.UserCode.Contains(strKey) || x.UserPY.Contains(strKey)).ToList();
        }

        private void dv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dv.Columns[e.ColumnIndex].Name == "delete" && e.RowIndex >= 0)
            {
                if (ShowAskDialog("确认删除吗？", false))
                {
                    int id = int.Parse(dv.Rows[e.RowIndex].Cells[0].Value.ToString());
                    var u = SoftConfig.db.User.Where(x => x.ID == id).Delete();
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
                UserCls d = new UserCls(dv.Rows[e.RowIndex].Cells[1].Value.ToString(), dv.Rows[e.RowIndex].Cells[2].Value.ToString(), dv.Rows[e.RowIndex].Cells[3].Value.ToString());
                d.PY = dv.Rows[e.RowIndex].Cells[4].Value.ToString();
                d.ID = int.Parse(dv.Rows[e.RowIndex].Cells[0].Value.ToString());
                FUserInfo f = new FUserInfo(d);
                f.ShowDialog();
                RefreshDv("");
            }
        }
    }
}
