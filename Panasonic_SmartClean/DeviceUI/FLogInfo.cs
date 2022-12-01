using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Panasonic_SmartClean
{
#pragma warning disable CS0246 // 未能找到类型或命名空间名“UIForm”(是否缺少 using 指令或程序集引用?)
    public partial class FLogInfo : UIForm
#pragma warning restore CS0246 // 未能找到类型或命名空间名“UIForm”(是否缺少 using 指令或程序集引用?)
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();
        string _image1, _image2, _image3, _image4;
        public FLogInfo(string MouseResult,string BoardResult,string image1, string image2, string image3, string image4)
        {
            InitializeComponent();

            try
            {
                lbMouseResult.Text = MouseResult;
                lbMouseResult.ForeColor = MouseResult == "OK" ? Color.Green : Color.Red;
                lbBoardResult.Text = BoardResult;
                lbBoardResult.ForeColor = BoardResult == "OK" ? Color.Green : Color.Red;
                _image1 = image1;
                _image2 = image2;
                _image3 = image3;
                _image4 = image4;
            }
            catch (Exception)
            {

            }

            try
            {
                picMouseBefore.Image = Image.FromFile(image1);
            }
            catch (Exception ex)
            {

            }
            try
            {
                picMouseAfter.Image = Image.FromFile(image3);
            }
            catch (Exception ex)
            {

            }
            try
            {
                picBoardBefore.Image = Image.FromFile(image2);
            }
            catch (Exception ex)
            {

            }
            try
            {
                picBoardAfter.Image = Image.FromFile(image4);
            }
            catch (Exception ex)
            {

            }
            
            
            
        }

        private void FLogInfo_Resize(object sender, EventArgs e)
        {
            
        }

        public void OpenImage(string FilePath,bool IsWait=true)
        {
            Process process = new Process();
            ProcessStartInfo psi = new ProcessStartInfo(FilePath);
            process.StartInfo = psi;

            process.StartInfo.UseShellExecute = true;

            try
            {
                process.Start();

                //等待打开的程序关闭
                if (IsWait)
                {
                    process.WaitForExit();
                }

            }
            catch (Exception ex)
            {
                ShowWarningTip("图片不存在");
            }
            finally
            {
                process?.Close();

            }
        }

        private void picMouseBefore_DoubleClick(object sender, EventArgs e)
        {
            OpenImage(_image1);
        }

        private void picMouseAfter_DoubleClick(object sender, EventArgs e)
        {
            OpenImage(_image2);
        }

        private void picBoardBefore_DoubleClick(object sender, EventArgs e)
        {
            OpenImage(_image3);
        }

        private void picBoardAfter_DoubleClick(object sender, EventArgs e)
        {
            OpenImage(_image4);
        }
    }
}
