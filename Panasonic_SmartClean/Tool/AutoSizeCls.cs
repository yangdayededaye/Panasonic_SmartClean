using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Sunny.UI;

namespace Panasonic_SmartClean
{
    class AutoSizeFormClass
    {
        //(1).声明结构,只记录窗体和其控件的初始位置和大小。
        public struct controlRect
        {
            public int Left;
            public int Top;
            public int Width;
            public int Height;
            public Font f;
        }
        //(2).声明 1个对象
        //注意这里不能使用控件列表记录 List<Control> nCtrl;，因为控件的关联性，记录的始终是当前的大小。
        public List<controlRect> oldCtrl;
        //int ctrl_first = 0;
        //(3). 创建两个函数
        //(3.1)记录窗体和其控件的初始位置和大小,
        public void controllInitializeSize(Form mForm,bool ExistPanelForm=false)
        {
            oldCtrl = new List<controlRect>();
            controlRect cR;
            cR.Left = mForm.Left; cR.Top = mForm.Top; cR.Width = mForm.Width; cR.Height = mForm.Height; cR.f = null;
            oldCtrl.Add(cR);
            foreach (Control c in mForm.Controls)
            {
                controlRect objCtrl;
                objCtrl.Left = c.Left; objCtrl.Top = c.Top; objCtrl.Width = c.Width; objCtrl.Height = c.Height;
                objCtrl.f = c.Font;
                oldCtrl.Add(objCtrl);
                if (ExistPanelForm)
                {
                    //if (c.GetType().ToString().Contains("Panel") || c.GetType().ToString().Contains("Group"))
                    //{
                    //    foreach (Control d in c.Controls)
                    //    {
                    //        controlRect dd;
                    //        dd.Left = d.Left; dd.Top = d.Top; dd.Width = d.Width; dd.Height = d.Height;
                    //        dd.f = d.Font;
                    //        oldCtrl.Add(dd);
                    //    }
                    //}
                }
            }
        }
        //(3.2)控件自适应大小,
        public void controlAutoSize(float parentWidth,float parentHeight,Form mForm, bool ExistPanelForm = false)
        {
            //int wLeft0 = oldCtrl[0].Left; ;//窗体最初的位置  
            //int wTop0 = oldCtrl[0].Top;  
            ////int wLeft1 = this.Left;//窗体当前的位置  
            //int wTop1 = this.Top;  
            float wScale = parentWidth / (float)oldCtrl[0].Width;//新旧窗体之间的比例，与最早的旧窗体  
            float hScale = parentHeight / (float)oldCtrl[0].Height;//.Height;  
            int ctrLeft0, ctrTop0, ctrWidth0, ctrHeight0;
            Font ctrlfont;
            int ctrlNo = 1;//第1个是窗体自身的 Left,Top,Width,Height，所以窗体控件从ctrlNo=1开始  
            foreach (Control c in mForm.Controls)
            {
                ctrLeft0 = oldCtrl[ctrlNo].Left;
                ctrTop0 = oldCtrl[ctrlNo].Top;
                ctrWidth0 = oldCtrl[ctrlNo].Width;
                ctrHeight0 = oldCtrl[ctrlNo].Height;
                ctrlfont = oldCtrl[ctrlNo].f;
                c.Left = (int)((ctrLeft0) * (wScale));//新旧控件之间的线性比例。控件位置只相对于窗体，所以不能加 + wLeft1  
                c.Top = (int)((ctrTop0) * (hScale));//  
                c.Width = (int)(ctrWidth0 * ( wScale));//只与最初的大小相关，所以不能与现在的宽度相乘 (int)(c.Width * w);  
                c.Height = (int)(ctrHeight0 * (hScale));//  
                //c.Font = new Font(ctrlfont.Name,ctrlfont.Size* 1, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                //c.Font = ctrlfont;
                ctrlNo += 1;
                if (ExistPanelForm)
                {
                    //if (c.GetType().ToString().Contains("Panel")|| c.GetType().ToString().Contains("Group"))
                    //{
                    //    foreach (Control d in c.Controls)
                    //    {
                    //        ctrLeft0 = oldCtrl[ctrlNo].Left;
                    //        ctrTop0 = oldCtrl[ctrlNo].Top;
                    //        ctrWidth0 = oldCtrl[ctrlNo].Width;
                    //        ctrHeight0 = oldCtrl[ctrlNo].Height;
                    //        ctrlfont = oldCtrl[ctrlNo].f;
                    //        d.Left = (int)((ctrLeft0) * wScale);//新旧控件之间的线性比例。控件位置只相对于窗体，所以不能加 + wLeft1  
                    //        d.Top = (int)((ctrTop0) * hScale);//  
                    //        d.Width = (int)(ctrWidth0 * wScale);//只与最初的大小相关，所以不能与现在的宽度相乘 (int)(c.Width * w);  
                    //        d.Height = (int)(ctrHeight0 * hScale);//  
                    //        d.Font = new Font(ctrlfont.Name, ctrlfont.Size * hScale, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    //        ctrlNo += 1;
                    //    }
                    //}
                }

            }  
        }

    }


}
