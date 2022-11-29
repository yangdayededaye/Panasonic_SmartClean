using Panasonic_SmartClean.Service;
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
    public partial class FPlc : UIForm
#pragma warning restore CS0246 // 未能找到类型或命名空间名“UIForm”(是否缺少 using 指令或程序集引用?)
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();
        public Hsl hsl = Hsl.Instance;
        public FPlc()
        {
            InitializeComponent();
            asc.controllInitializeSize(this);
            try
            {
                bool[] bSpeed = hsl.ReadBool("M1000", 3);
                if (bSpeed[2])
                {
                    rbLowSpeed.Checked = true;
                }
                if (bSpeed[1])
                {
                    rbMiddleSpeed.Checked = true;
                }
                if (bSpeed[0])
                {
                    rbHighSpeed.Checked = true;
                }
            }
            catch (Exception)
            {

            }
        }

        private void FPlc_Resize(object sender, EventArgs e)
        {
            asc.controlAutoSize(this.Width, this.Height, this);
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            switch (cbPosi.Text)
            {
                case "1":
                    hsl.WriteBool(hsl.front_after_air_out_1, true);
                    break;
                case "2":
                    hsl.WriteBool(hsl.front_after_air_out_2, true);
                    break;
                case "3":
                    hsl.WriteBool(hsl.front_after_air_out_3, true);
                    break;
                case "4":
                    hsl.WriteBool(hsl.front_after_air_out_4, true);
                    break;
            }
            Thread.Sleep(200);
            switch (cbPosi.Text)
            {
                case "1":
                    hsl.WriteBool(hsl.front_after_air_out_1, false);
                    break;
                case "2":
                    hsl.WriteBool(hsl.front_after_air_out_2, false);
                    break;
                case "3":
                    hsl.WriteBool(hsl.front_after_air_out_3, false);
                    break;
                case "4":
                    hsl.WriteBool(hsl.front_after_air_out_4, false);
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (cbPosi.Text)
            {
                case "1":
                    hsl.WriteBool(hsl.front_after_air_back_1, true);
                    break;
                case "2":
                    hsl.WriteBool(hsl.front_after_air_back_2, true);
                    break;
                case "3":
                    hsl.WriteBool(hsl.front_after_air_back_3, true);
                    break;
                case "4":
                    hsl.WriteBool(hsl.front_after_air_back_4, true);
                    break;
            }
            Thread.Sleep(200);
            switch (cbPosi.Text)
            {
                case "1":
                    hsl.WriteBool(hsl.front_after_air_back_1, false);
                    break;
                case "2":
                    hsl.WriteBool(hsl.front_after_air_back_2, false);
                    break;
                case "3":
                    hsl.WriteBool(hsl.front_after_air_back_3, false);
                    break;
                case "4":
                    hsl.WriteBool(hsl.front_after_air_back_4, false);
                    break;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            switch (cbPosi.Text)
            {
                case "1":
                    hsl.WriteBool(hsl.clip_air_close_1, true);
                    break;
                case "2":
                    hsl.WriteBool(hsl.clip_air_close_2, true);
                    break;
                case "3":
                    hsl.WriteBool(hsl.clip_air_close_3, true);
                    break;
                case "4":
                    hsl.WriteBool(hsl.clip_air_close_4, true);
                    break;
            }
            Thread.Sleep(200);
            switch (cbPosi.Text)
            {
                case "1":
                    hsl.WriteBool(hsl.clip_air_close_1, false);
                    break;
                case "2":
                    hsl.WriteBool(hsl.clip_air_close_2, false);
                    break;
                case "3":
                    hsl.WriteBool(hsl.clip_air_close_3, false);
                    break;
                case "4":
                    hsl.WriteBool(hsl.clip_air_close_4, false);
                    break;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            switch (cbPosi.Text)
            {
                case "1":
                    hsl.WriteBool(hsl.clip_air_open_1, true);
                    break;
                case "2":
                    hsl.WriteBool(hsl.clip_air_open_2, true);
                    break;
                case "3":
                    hsl.WriteBool(hsl.clip_air_open_3, true);
                    break;
                case "4":
                    hsl.WriteBool(hsl.clip_air_open_4, true);
                    break;
            }
            Thread.Sleep(200);
            switch (cbPosi.Text)
            {
                case "1":
                    hsl.WriteBool(hsl.clip_air_open_1, false);
                    break;
                case "2":
                    hsl.WriteBool(hsl.clip_air_open_2, false);
                    break;
                case "3":
                    hsl.WriteBool(hsl.clip_air_open_3, false);
                    break;
                case "4":
                    hsl.WriteBool(hsl.clip_air_open_4, false);
                    break;
            }
        }

        private void btnFJRun_Click(object sender, EventArgs e)
        {
            hsl.WriteBool(hsl.cleancover_air_out, true);
            Thread.Sleep(200);
            hsl.WriteBool(hsl.cleancover_air_out, false);
        }

        private void btnFJRunBack_Click(object sender, EventArgs e)
        {
            hsl.WriteBool(hsl.cleancover_air_back, true);
            Thread.Sleep(200);
            hsl.WriteBool(hsl.cleancover_air_back, false);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            hsl.WriteBool(hsl.blow_emvalve_work, true);
            Thread.Sleep(200);
            hsl.WriteBool(hsl.blow_emvalve_work, false);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            hsl.WriteBool(hsl.blow_emvalve_stop, true);
            Thread.Sleep(200);
            hsl.WriteBool(hsl.blow_emvalve_stop, false);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            hsl.WriteBool(hsl.Penetrability_emvalve_work, true);
            Thread.Sleep(200);
            hsl.WriteBool(hsl.Penetrability_emvalve_work, false);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            hsl.WriteBool(hsl.Penetrability_emvalve_stop, true);
            Thread.Sleep(200);
            hsl.WriteBool(hsl.Penetrability_emvalve_stop, false);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            hsl.WriteBool(hsl.bigsmall_clip_air_close_1, true);
            Thread.Sleep(200);
            hsl.WriteBool(hsl.bigsmall_clip_air_close_1, false);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            hsl.WriteBool(hsl.bigsmall_clip_air_open_1, true);
            Thread.Sleep(200);
            hsl.WriteBool(hsl.bigsmall_clip_air_open_1, false);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            hsl.WriteBool(hsl.superbig_clip_air_close_1, true);
            Thread.Sleep(200);
            hsl.WriteBool(hsl.superbig_clip_air_close_1, false);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            hsl.WriteBool(hsl.superbig_clip_air_open_1, true);
            Thread.Sleep(200);
            hsl.WriteBool(hsl.superbig_clip_air_open_1, false);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            hsl.WriteBool(hsl.ultrasonic, true);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            hsl.WriteBool(hsl.ultrasonic, false);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            hsl.WriteBool(hsl.heating, true);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            hsl.WriteBool(hsl.heating, false);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            hsl.WriteBool(hsl.loop, true);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            hsl.WriteBool(hsl.loop, false);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            hsl.WriteBool(hsl.x_origin, true);
            Thread.Sleep(200);
            hsl.WriteBool(hsl.x_origin, false);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            hsl.WriteBool(hsl.y_origin, true);
            Thread.Sleep(200);
            hsl.WriteBool(hsl.y_origin, false);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            hsl.WriteBool(hsl.z_origin, true);
            Thread.Sleep(200);
            hsl.WriteBool(hsl.z_origin, false);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            hsl.WriteInt(hsl.x_posi_value,int.Parse(txtXPulse.Text));
            Thread.Sleep(100);
            hsl.WriteInt(hsl.y_posi_value, int.Parse(txtYPulse.Text));
            Thread.Sleep(100);
            hsl.WriteInt(hsl.z_posi_value, int.Parse(txtZPulse.Text));
            Thread.Sleep(100);
            hsl.WriteBool("M450", true);
            Thread.Sleep(200);
            hsl.WriteBool("M450", false);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            hsl.WriteInt(hsl.y_posi_value, int.Parse(txtYPulse.Text));
            Thread.Sleep(100);
            hsl.WriteBool(hsl.y_posi, true);
            Thread.Sleep(200);
            hsl.WriteBool(hsl.y_posi, false);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            hsl.WriteInt(hsl.z_posi_value, int.Parse(txtZPulse.Text));
            Thread.Sleep(100);
            hsl.WriteBool(hsl.z_posi, true);
            Thread.Sleep(200);
            hsl.WriteBool(hsl.z_posi, false);
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex==2)
            {
                timerShowWarn.Enabled = true;
            }
            else
            {
                timerShowWarn.Enabled = false;
            }
                
        }









        /// <summary>
        /// IO查询页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerShowWarn_Tick(object sender, EventArgs e)
        {
            hsl.SendCommand("check");
            for (int i = 0; i < hsl.bWarn.Count(); i++)
            {
                Control[] lstControl = this.Controls.Find("light"+i.ToString(),true);
                if (lstControl.Count()>0)
                {
                    UILedBulb ub = (UILedBulb)lstControl[0];
                    ub.On = hsl.bWarn[i];
                }
            }
        }






        //参数设置页面
        private void button49_Click(object sender, EventArgs e)
        {
            FSetPosition f = new FSetPosition();
            f.ShowDialog();
        }


        private void button33_Click(object sender, EventArgs e)
        {
            bool bResult = false;
            bResult = hsl.WriteInt("D1350", int.Parse(uiTextBox3.Text));
            if (bResult)
            {
                ShowSuccessTip("修改成功");
            }
            else
                ShowSuccessTip("修改失败");
        }

        private void button41_Click(object sender, EventArgs e)
        {
            bool bResult = false;
            bResult = hsl.WriteInt("D1352", int.Parse(uiTextBox11.Text));
            if (bResult)
            {
                ShowSuccessTip("修改成功");
            }
            else
                ShowSuccessTip("修改失败");
        }

        private void button34_Click(object sender, EventArgs e)
        {
            bool bResult = false;
            bResult = hsl.WriteInt("D1850", int.Parse(uiTextBox4.Text));
            if (bResult)
            {
                ShowSuccessTip("修改成功");
            }
            else
                ShowSuccessTip("修改失败");
        }

        private void button44_Click(object sender, EventArgs e)
        {
            bool bResult = false;
            bResult = hsl.WriteInt("D1852", int.Parse(uiTextBox14.Text));
            if (bResult)
            {
                ShowSuccessTip("修改成功");
            }
            else
                ShowSuccessTip("修改失败");
        }

        private void button37_Click(object sender, EventArgs e)
        {
            bool bResult = false;
            bResult = hsl.WriteInt("D2350", int.Parse(uiTextBox7.Text));
            if (bResult)
            {
                ShowSuccessTip("修改成功");
            }
            else
                ShowSuccessTip("修改失败");
        }

        private void button47_Click(object sender, EventArgs e)
        {
            bool bResult = false;
            bResult = hsl.WriteInt("D2352", int.Parse(uiTextBox17.Text));
            if (bResult)
            {
                ShowSuccessTip("修改成功");
            }
            else
                ShowSuccessTip("修改失败");
        }

        /// <summary>
        /// 刷新参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button31_Click(object sender, EventArgs e)
        {
            int[] fx = hsl.ReadInt("D1350", 2);
            uiTextBox3.Text = fx[0].ToString();
            uiTextBox11.Text = fx[1].ToString();
            int[] fy = hsl.ReadInt("D1850", 2);
            uiTextBox4.Text = fy[0].ToString();
            uiTextBox14.Text = fy[1].ToString();
            int[] fz = hsl.ReadInt("D2350", 2);
            uiTextBox7.Text = fz[0].ToString();
            uiTextBox17.Text = fz[1].ToString();
        }

        

        /// <summary>
        /// 读取小大型流通量范围
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button42_Click(object sender, EventArgs e)
        {
            uiTextBox1.Text = hsl.ReadUShort("D5035", 1)[0].ToString();
            uiTextBox6.Text = hsl.ReadUShort("D5037", 1)[0].ToString();
        }

        private void button43_Click(object sender, EventArgs e)
        {
            hsl.WriteUshort("D5035",Convert.ToUInt16(uiTextBox1.Text));
            hsl.WriteUshort("D5037", Convert.ToUInt16(uiTextBox6.Text));
        }

        private void button46_Click(object sender, EventArgs e)
        {
            uiTextBox2.Text = hsl.ReadUShort("D5039", 1)[0].ToString();
            uiTextBox5.Text = hsl.ReadUShort("D5041", 1)[0].ToString();
        }

        private void button45_Click(object sender, EventArgs e)
        {
            hsl.WriteUshort("D5039", Convert.ToUInt16(uiTextBox2.Text));
            hsl.WriteUshort("D5041", Convert.ToUInt16(uiTextBox5.Text));
        }

        //private void cbUser_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    switch (cbUser.Text)
        //    {
        //        case "低速":
        //            hsl.WriteBool("M1002", true);
        //            hsl.WriteBool("M1001", false);
        //            hsl.WriteBool("M1000", false);
        //            break;
        //        case "中速":
        //            hsl.WriteBool("M1002", false);
        //            hsl.WriteBool("M1001", true);
        //            hsl.WriteBool("M1000", false);
        //            break;
        //        case "高速":
        //            hsl.WriteBool("M1002", false);
        //            hsl.WriteBool("M1001", false);
        //            hsl.WriteBool("M1000", true);
        //            break;
        //        default:
        //            ShowWarningTip("无效选项");
        //            break;
        //    }
        //    ShowWarningTip("设置成功");
        //}

        private void rbLowSpeed_Click(object sender, EventArgs e)
        {
            hsl.WriteBool("M1002", true);
            hsl.WriteBool("M1001", false);
            hsl.WriteBool("M1000", false);
        }

        private void rbMiddleSpeed_Click(object sender, EventArgs e)
        {
            hsl.WriteBool("M1002", false);
            hsl.WriteBool("M1001", true);
            hsl.WriteBool("M1000", false);
        }

        private void rbHighSpeed_Click(object sender, EventArgs e)
        {
            hsl.WriteBool("M1002", false);
            hsl.WriteBool("M1001", false);
            hsl.WriteBool("M1000", true);
        }

        

        /// <summary>
        /// I
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button29_Click_1(object sender, EventArgs e)
        {
            FIState f = new FIState();
            f.ShowDialog();
        }

        /// <summary>
        /// O
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button30_Click_1(object sender, EventArgs e)
        {
            FOState f = new FOState();
            f.ShowDialog();
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                hsl.WriteBool(hsl.x_add, true);
            }
            catch (Exception)
            {

            }
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                hsl.WriteBool(hsl.x_add, false);
            }
            catch (Exception)
            {

            }
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            hsl.WriteBool(hsl.x_minu, true);
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            hsl.WriteBool(hsl.x_minu, false);
        }

        private void button6_MouseDown(object sender, MouseEventArgs e)
        {
            hsl.WriteBool(hsl.y_add, true);
        }

        private void button6_MouseUp(object sender, MouseEventArgs e)
        {
            hsl.WriteBool(hsl.y_add, false);
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            hsl.WriteBool(hsl.y_minu, true);
        }

        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            hsl.WriteBool(hsl.y_minu, false);
        }

        private void button8_MouseDown(object sender, MouseEventArgs e)
        {
            hsl.WriteBool(hsl.z_add, true);
        }

        private void button8_MouseUp(object sender, MouseEventArgs e)
        {
            hsl.WriteBool(hsl.z_add, false);
        }

        private void button7_MouseDown(object sender, MouseEventArgs e)
        {
            hsl.WriteBool(hsl.z_minu, true);
        }

        private void button7_MouseUp(object sender, MouseEventArgs e)
        {
            hsl.WriteBool(hsl.z_minu, false);
        }
    }
}
