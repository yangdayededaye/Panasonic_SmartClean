using EntityFramework.Extensions;
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

namespace Panasonic_SmartClean.DeviceUI
{
    public partial class FUserInfo : UIForm
    {
        public UserCls u = null;
        public FUserInfo(UserCls _u)
        {
            InitializeComponent();
            u = _u;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "" || txtName.Text == "")
            {
                ShowWarningTip("请输入完整");
                return;
            }

            if (u==null)
            {
                //查询编号是否存在
                if (SoftConfig.db.User.Any(x => x.UserCode == txtCode.Text))
                {
                    ShowErrorTip("编号已存在");
                    return;
                }
                User b = new User();
                b.UserCode = txtCode.Text;
                b.UserName = txtName.Text;
                b.UserPsw = "1234";
                b.UserPY = txtPY.Text;
                b.UserType = cbRole.Text == "普通" ? "0" : "1";
                b.State = "0";
                SoftConfig.db.User.Add(b);
                SoftConfig.db.SaveChanges();

                ShowSuccessTip("添加成功");
            }
            else
            {
                //查询编号是否存在
                if (SoftConfig.db.User.Any(x=>x.UserCode== txtCode.Text&&x.ID!=SoftConfig.user.ID))
                {
                    ShowErrorTip("编号已存在");
                    return;
                }

                string strType = cbRole.Text == "普通" ? "0" : "1";
                SoftConfig.db.User.Where(x => x.ID == u.ID).Update(x => new User { UserCode=txtCode.Text,UserName = txtName.Text, UserPY = txtPY.Text,UserType= strType });
                SoftConfig.db.SaveChanges();
                Util.initDB();
                ShowSuccessTip("修改成功");
            }
            
            Close();
        }

        private void FUserInfo_Load(object sender, EventArgs e)
        {
            if (u != null)
            {
                txtCode.Text = u.No;
                txtName.Text = u.Name;
                txtPY.Text = u.PY;
                cbRole.Text = u.Type == "0" ? "普通" : "管理员";
            }
        }
    }
}
