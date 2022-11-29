using EntityFramework.Extensions;
using Panasonic_SmartClean.Service;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Panasonic_SmartClean.DeviceUI
{
#pragma warning disable CS0246 // 未能找到类型或命名空间名“UIForm”(是否缺少 using 指令或程序集引用?)
    public partial class FSet : UIForm
#pragma warning restore CS0246 // 未能找到类型或命名空间名“UIForm”(是否缺少 using 指令或程序集引用?)
    {
        public FSet()
        {
            InitializeComponent();
        }

        public Hsl hsl = Hsl.Instance;

        private void FSet_Load(object sender, EventArgs e)
        {
            try
            {
                lbTitle.Text = SoftConfig.ini.IniReadValue("SOFT", "Sol");
                lbImagePath.Text = SoftConfig.ini.IniReadValue("SOFT", "ImagePath")+ "\\Image";
                cbBeforeEnable.Checked = hsl.ReadBool("M57", 1)[0] ? true : false;
            }
            catch (Exception ex)
            {

            }
        }


        private void KillTime_ValueChanged(object sender, int value)
        {

        }

        private void btnSelectSol_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Title = "请选择视觉文件";
            dialog.Filter = "视觉文件(*.sol)|*.sol";
            if (dialog.ShowDialog()==DialogResult.OK)
            {
                SoftConfig.ini.IniWriteValue("SOFT", "Sol",dialog.FileName);
                lbTitle.Text = dialog.FileName;
                ShowSuccessTip("修改成功,重启后生效");
            }
        }
        
        private void btnFlowSet_Click(object sender, EventArgs e)
        {
            FFlow f = new FFlow();
            f.ShowDialog();
        }

        private void cbBeforeEnable_Click(object sender, EventArgs e)
        {
            bool IsEnable = hsl.ReadBool("M57", 1)[0];
            if (IsEnable)
            {
                hsl.WriteBool("M57", false);
            }
            else
                hsl.WriteBool("M57", true);
        }

        private void button31_Click(object sender, EventArgs e)
        {
            uiTextBox5.Text = (hsl.ReadUShort("D5000", 1)[0]/10).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            hsl.WriteUshort("D5000", (ushort)(ushort.Parse(uiTextBox5.Text) * 10));
            ShowSuccessTip("设置成功");
        }

        private void btnImagePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "选择文件夹";  //提示的文字
            if (folder.ShowDialog() == DialogResult.OK)
            {
                SoftConfig.ini.IniWriteValue("SOFT", "ImagePath", folder.SelectedPath);
                lbImagePath.Text = folder.SelectedPath + "Image";
                ShowSuccessTip("修改成功");
            }

        }

        private void btnVisonProcess_Click(object sender, EventArgs e)
        {
            FProcess f = new FProcess();
            f.ShowDialog();
        }
    }
}
