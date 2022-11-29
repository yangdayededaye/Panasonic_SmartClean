using EntityFramework.Extensions;
using Panasonic_SmartClean.Model;
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
#pragma warning disable CS0246 // 未能找到类型或命名空间名“UIForm”(是否缺少 using 指令或程序集引用?)
    public partial class FProcessInfo : UIForm
#pragma warning restore CS0246 // 未能找到类型或命名空间名“UIForm”(是否缺少 using 指令或程序集引用?)
    {
        public VisonProcess u = null;
        public FProcessInfo(VisonProcess _u)
        {
            InitializeComponent();
            u = _u;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "" || txtName.Text == ""||cbType.Text=="")
            {
                ShowWarningTip("请输入完整");
                return;
            }

            if (u==null)
            {
                //查询编号是否存在
                if (SoftConfig.db.VisonProcess.Any(x => x.ProcessID == txtCode.Text||x.ProcessName==txtName.Text))
                {
                    ShowErrorTip("已存在的流程ID或名称");
                    return;
                }
                //除吸嘴清洗后之外都只有一条记录
                if (cbType.Text!= "吸嘴清洗后")
                {
                    if (SoftConfig.db.VisonProcess.Any(x => x.Type == cbType.Text))
                    {
                        ShowErrorTip("该类型数据唯一且已存在");
                        return;
                    }
                }

                VisonProcess b = new VisonProcess();
                b.ProcessID = txtCode.Text;
                b.ProcessName = txtName.Text;
                b.Type = cbType.Text;
                b.Remark = txtRemark.Text;
                SoftConfig.db.VisonProcess.Add(b);
                SoftConfig.db.SaveChanges();

                ShowSuccessTip("添加成功");
            }
            else
            {
                //查询编号是否存在
                if (SoftConfig.db.VisonProcess.Any(x=>(x.ProcessID== txtCode.Text|| x.ProcessName == txtName.Text) &&x.ProcessIndex!=u.ProcessIndex))
                {
                    ShowErrorTip("已存在的流程ID或名称");
                    return;
                }
                //除吸嘴清洗后之外都只有一条记录
                if (cbType.Text != "吸嘴清洗后")
                {
                    if (SoftConfig.db.VisonProcess.Any(x => x.Type == cbType.Text&& x.ProcessIndex != u.ProcessIndex))
                    {
                        ShowErrorTip("该类型数据唯一且已存在");
                        return;
                    }
                }
                SoftConfig.db.VisonProcess.Where(x => x.ProcessIndex == u.ProcessIndex).Update(x => new VisonProcess { ProcessID=txtCode.Text,ProcessName = txtName.Text, Type = cbType.Text, Remark = txtRemark.Text });
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
                txtCode.Text = u.ProcessID;
                txtName.Text = u.ProcessName;
                cbType.Text = u.Type;
                txtRemark.Text = u.Remark;
            }
        }
    }
}
