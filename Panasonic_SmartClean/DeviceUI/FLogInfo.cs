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
    public partial class FLogInfo : UIForm
#pragma warning restore CS0246 // 未能找到类型或命名空间名“UIForm”(是否缺少 using 指令或程序集引用?)
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();

        public FLogInfo(string MouseResult,string BoardResult,string image1, string image2, string image3, string image4)
        {
            InitializeComponent();

            try
            {
                lbMouseResult.Text = MouseResult;
                lbMouseResult.ForeColor = MouseResult == "OK" ? Color.Green : Color.Red;
                lbBoardResult.Text = BoardResult;
                lbBoardResult.ForeColor = BoardResult == "OK" ? Color.Green : Color.Red;
            }
            catch (Exception)
            {

            }

            try
            {
                picMouseBefore.Image = Image.FromFile(SoftConfig.ImagePath + "\\" + image1);
            }
            catch (Exception ex)
            {

            }
            try
            {
                picMouseAfter.Image = Image.FromFile(SoftConfig.ImagePath + "\\" + image3);
            }
            catch (Exception ex)
            {

            }
            try
            {
                picBoardBefore.Image = Image.FromFile(SoftConfig.ImagePath + "\\" + image2);
            }
            catch (Exception ex)
            {

            }
            try
            {
                picBoardAfter.Image = Image.FromFile(SoftConfig.ImagePath + "\\" + image4);
            }
            catch (Exception ex)
            {

            }
            
            
            
        }

        private void FLogInfo_Resize(object sender, EventArgs e)
        {
            
        }



        
    }
}
