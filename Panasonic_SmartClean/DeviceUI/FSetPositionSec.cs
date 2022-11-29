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
    public partial class FSetPositionSec : UIForm
#pragma warning restore CS0246 // 未能找到类型或命名空间名“UIForm”(是否缺少 using 指令或程序集引用?)
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();
        public Hsl hsl = Hsl.Instance;

        public FSetPositionSec()
        {
            InitializeComponent();
            asc.controllInitializeSize(this);

        }

        private void FSetPositionSec_Resize(object sender, EventArgs e)
        {
            asc.controlAutoSize(this.Width, this.Height, this);
        }

        private void FSetPositionSec_Load(object sender, EventArgs e)
        {
            //读取X轴参数


        }

        private void button23_Click(object sender, EventArgs e)
        {
            uiTextBox11.Text = hsl.ReadInt("D1170", 1)[0].ToString();
            uiTextBox20.Text = hsl.ReadInt("D1670", 1)[0].ToString();
            uiTextBox26.Text = hsl.ReadInt("D2170", 1)[0].ToString();
        }
        private void button38_Click(object sender, EventArgs e)
        {
            hsl.WriteInt("D1170", int.Parse(uiTextBox11.Text));
            hsl.WriteInt("D1670", int.Parse(uiTextBox20.Text));
            hsl.WriteInt("D2170", int.Parse(uiTextBox26.Text));
        }

        private void button22_Click(object sender, EventArgs e)
        {
            uiTextBox10.Text = hsl.ReadInt("D1172", 1)[0].ToString();
            uiTextBox19.Text = hsl.ReadInt("D1672", 1)[0].ToString();
            uiTextBox25.Text = hsl.ReadInt("D2170", 1)[0].ToString();
        }
        private void button37_Click(object sender, EventArgs e)
        {
            hsl.WriteInt("D1172", int.Parse(uiTextBox10.Text));
            hsl.WriteInt("D1672", int.Parse(uiTextBox19.Text));
            hsl.WriteInt("D2170", int.Parse(uiTextBox25.Text));
        }

        private void button20_Click(object sender, EventArgs e)
        {
            uiTextBox8.Text = hsl.ReadInt("D1174", 1)[0].ToString();
            uiTextBox17.Text = hsl.ReadInt("D1674", 1)[0].ToString();
            uiTextBox23.Text = hsl.ReadInt("D2170", 1)[0].ToString();
        }
        private void button35_Click(object sender, EventArgs e)
        {
            hsl.WriteInt("D1174", int.Parse(uiTextBox8.Text));
            hsl.WriteInt("D1674", int.Parse(uiTextBox17.Text));
            hsl.WriteInt("D2170", int.Parse(uiTextBox23.Text));
        }

        private void button19_Click(object sender, EventArgs e)
        {
            uiTextBox9.Text = hsl.ReadInt("D1176", 1)[0].ToString();
            uiTextBox16.Text = hsl.ReadInt("D1676", 1)[0].ToString();
            uiTextBox22.Text = hsl.ReadInt("D2170", 1)[0].ToString();
        }
        private void button34_Click(object sender, EventArgs e)
        {
            hsl.WriteInt("D1176", int.Parse(uiTextBox9.Text));
            hsl.WriteInt("D1676", int.Parse(uiTextBox16.Text));
            hsl.WriteInt("D2170", int.Parse(uiTextBox22.Text));
        }



        private void button15_Click(object sender, EventArgs e)
        {
            uiTextBox7.Text = hsl.ReadInt("D1184", 1)[0].ToString();
            uiTextBox29.Text = hsl.ReadInt("D1684", 1)[0].ToString();
            uiTextBox34.Text = hsl.ReadInt("D2172", 1)[0].ToString();
        }
        private void button46_Click(object sender, EventArgs e)
        {
            hsl.WriteInt("D1184", int.Parse(uiTextBox7.Text));
            hsl.WriteInt("D1684", int.Parse(uiTextBox29.Text));
            hsl.WriteInt("D2172", int.Parse(uiTextBox34.Text));
        }

        private void button36_Click(object sender, EventArgs e)
        {
            uiTextBox6.Text = hsl.ReadInt("D1186", 1)[0].ToString();
            uiTextBox44.Text = hsl.ReadInt("D1686", 1)[0].ToString();
            uiTextBox24.Text = hsl.ReadInt("D2172", 1)[0].ToString();
        }
        private void button33_Click(object sender, EventArgs e)
        {
            hsl.WriteInt("D1186", int.Parse(uiTextBox6.Text));
            hsl.WriteInt("D1686", int.Parse(uiTextBox44.Text));
            hsl.WriteInt("D2172", int.Parse(uiTextBox24.Text));
        }

        private void button14_Click(object sender, EventArgs e)
        {
            uiTextBox4.Text = hsl.ReadInt("D1188", 1)[0].ToString();
            uiTextBox46.Text = hsl.ReadInt("D1688", 1)[0].ToString();
            uiTextBox47.Text = hsl.ReadInt("D2172", 1)[0].ToString();
        }
        private void button45_Click(object sender, EventArgs e)
        {
            hsl.WriteInt("D1188", int.Parse(uiTextBox4.Text));
            hsl.WriteInt("D1688", int.Parse(uiTextBox46.Text));
            hsl.WriteInt("D2172", int.Parse(uiTextBox47.Text));
        }

        private void button13_Click(object sender, EventArgs e)
        {
            uiTextBox5.Text = hsl.ReadInt("D1190", 1)[0].ToString();
            uiTextBox51.Text = hsl.ReadInt("D1690", 1)[0].ToString();
            uiTextBox55.Text = hsl.ReadInt("D2172", 1)[0].ToString();
        }
        private void button44_Click(object sender, EventArgs e)
        {
            hsl.WriteInt("D1190", int.Parse(uiTextBox5.Text));
            hsl.WriteInt("D1690", int.Parse(uiTextBox51.Text));
            hsl.WriteInt("D2172", int.Parse(uiTextBox55.Text));
        }
        //速度
        private void button2_Click(object sender, EventArgs e)
        {
            uiTextBox3.Text = hsl.ReadInt("D1370", 1)[0].ToString();
            uiTextBox2.Text = hsl.ReadInt("D1870", 1)[0].ToString();
            uiTextBox1.Text = hsl.ReadInt("D2370", 1)[0].ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            hsl.WriteInt("D1370", int.Parse(uiTextBox3.Text));
            hsl.WriteInt("D1870", int.Parse(uiTextBox2.Text));
            hsl.WriteInt("D2370", int.Parse(uiTextBox1.Text));
        }
    }
}
