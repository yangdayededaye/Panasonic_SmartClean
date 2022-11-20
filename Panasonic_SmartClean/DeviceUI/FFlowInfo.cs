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
    public partial class FFlowInfo : UIForm
    {
        public FlowCls u = null;
        public FFlowInfo(FlowCls _u)
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
                if (SoftConfig.db.Flow.Any(x => x.Ocr == txtCode.Text))
                {
                    ShowErrorTip("OCR已存在");
                    return;
                }
                Flow b = new Flow();
                b.Ocr = txtCode.Text;
                b.Value = int.Parse(txtName.Text);
                SoftConfig.db.Flow.Add(b);
                SoftConfig.db.SaveChanges();

                ShowSuccessTip("添加成功");
            }
            else
            {
                //查询编号是否存在
                if (SoftConfig.db.Flow.Any(x=>x.Ocr== txtCode.Text&&x.ThresholdIndex!=u.ID))
                {
                    ShowErrorTip("OCR已存在");
                    return;
                }
                int iValue = int.Parse(txtName.Text);
                SoftConfig.db.Flow.Where(x => x.ThresholdIndex == u.ID).Update(x => new Flow { Ocr=txtCode.Text,Value = iValue });
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
                txtCode.Text = u.Ocr;
                txtName.Text = u.Value.ToString();
            }
        }
    }
}
