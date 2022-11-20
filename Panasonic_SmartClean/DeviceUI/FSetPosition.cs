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
    public partial class FSetPosition : UIForm
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();
        public Hsl hsl = Hsl.Instance;

        public FSetPosition()
        {
            InitializeComponent();
            asc.controllInitializeSize(this);

        }

        private void FSetPosition_Resize(object sender, EventArgs e)
        {
            asc.controlAutoSize(this.Width, this.Height, this);
        }

        private void FSetPosition_Load(object sender, EventArgs e)
        {
            //读取参数
            ReadData();
        }

        public void ReadData()
        {
            button31.PerformClick();
            Thread.Sleep(200);
            button11.PerformClick();
            Thread.Sleep(200);
            button10.PerformClick();
            Thread.Sleep(200);
            button9.PerformClick();
            Thread.Sleep(200);
            button48.PerformClick();
            Thread.Sleep(200);
            button7.PerformClick();
            Thread.Sleep(200);
            button29.PerformClick();
            Thread.Sleep(200);
            button6.PerformClick();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            switch (cbPosi.Text)
            {
                case "1":
                    txtTakePhoto1.Text = hsl.ReadInt("D1002", 1)[0].ToString();
                    uiTextBox5.Text = hsl.ReadInt("D1502", 1)[0].ToString();
                    uiTextBox1.Text = hsl.ReadInt("D2002", 1)[0].ToString();
                    break;
                case "2":
                    txtTakePhoto1.Text = hsl.ReadInt("D1032", 1)[0].ToString();
                    uiTextBox5.Text = hsl.ReadInt("D1532", 1)[0].ToString();
                    uiTextBox1.Text = hsl.ReadInt("D2024", 1)[0].ToString();
                    break;
                case "3":
                    txtTakePhoto1.Text = hsl.ReadInt("D1062", 1)[0].ToString();
                    uiTextBox5.Text = hsl.ReadInt("D1562", 1)[0].ToString();
                    uiTextBox1.Text = hsl.ReadInt("D2046", 1)[0].ToString();
                    break;
                case "4":
                    txtTakePhoto1.Text = hsl.ReadInt("D1092", 1)[0].ToString();
                    uiTextBox5.Text = hsl.ReadInt("D1592", 1)[0].ToString();
                    uiTextBox1.Text = hsl.ReadInt("D2068", 1)[0].ToString();
                    break;
                    
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            switch (cbPosi.Text)
            {
                case "1":
                    hsl.WriteInt("D1002", int.Parse(txtTakePhoto1.Text));
                    hsl.WriteInt("D1502", int.Parse(uiTextBox5.Text));
                    hsl.WriteInt("D2002", int.Parse(uiTextBox1.Text));
                    break;
                case "2":
                    hsl.WriteInt("D1032", int.Parse(txtTakePhoto1.Text));
                    hsl.WriteInt("D1532", int.Parse(uiTextBox5.Text));
                    hsl.WriteInt("D2024", int.Parse(uiTextBox1.Text));
                    break;
                case "3":
                    hsl.WriteInt("D1062", int.Parse(txtTakePhoto1.Text));
                    hsl.WriteInt("D1562", int.Parse(uiTextBox5.Text));
                    hsl.WriteInt("D2046", int.Parse(uiTextBox1.Text));
                    break;
                case "4":
                    hsl.WriteInt("D1092", int.Parse(txtTakePhoto1.Text));
                    hsl.WriteInt("D1592", int.Parse(uiTextBox5.Text));
                    hsl.WriteInt("D2068", int.Parse(uiTextBox1.Text));
                    break;

            }
        }

        private void button48_Click(object sender, EventArgs e)
        {
            switch (cbPosi.Text)
            {
                case "1":
                    uiTextBox27.Text = hsl.ReadInt("D1022", 1)[0].ToString();
                    uiTextBox12.Text = hsl.ReadInt("D1522", 1)[0].ToString();
                    uiTextBox11.Text = hsl.ReadInt("D2012", 1)[0].ToString();
                    break;
                case "2":
                    uiTextBox27.Text = hsl.ReadInt("D1052", 1)[0].ToString();
                    uiTextBox12.Text = hsl.ReadInt("D1552", 1)[0].ToString();
                    uiTextBox11.Text = hsl.ReadInt("D2034", 1)[0].ToString();
                    break;
                case "3":
                    uiTextBox27.Text = hsl.ReadInt("D1082", 1)[0].ToString();
                    uiTextBox12.Text = hsl.ReadInt("D1582", 1)[0].ToString();
                    uiTextBox11.Text = hsl.ReadInt("D2056", 1)[0].ToString();
                    break;
                case "4":
                    uiTextBox27.Text = hsl.ReadInt("D1112", 1)[0].ToString();
                    uiTextBox12.Text = hsl.ReadInt("D1612", 1)[0].ToString();
                    uiTextBox11.Text = hsl.ReadInt("D2078", 1)[0].ToString();
                    break;

            }
        }
        private void button47_Click(object sender, EventArgs e)
        {
            switch (cbPosi.Text)
            {
                case "1":
                    hsl.WriteInt("D1022", int.Parse(uiTextBox27.Text));
                    hsl.WriteInt("D1522", int.Parse(uiTextBox12.Text));
                    hsl.WriteInt("D2012", int.Parse(uiTextBox11.Text));
                    break;
                case "2":
                    hsl.WriteInt("D1052", int.Parse(uiTextBox27.Text));
                    hsl.WriteInt("D1552", int.Parse(uiTextBox12.Text));
                    hsl.WriteInt("D2034", int.Parse(uiTextBox11.Text));
                    break;
                case "3":
                    hsl.WriteInt("D1082", int.Parse(uiTextBox27.Text));
                    hsl.WriteInt("D1582", int.Parse(uiTextBox12.Text));
                    hsl.WriteInt("D2056", int.Parse(uiTextBox11.Text));
                    break;
                case "4":
                    hsl.WriteInt("D1112", int.Parse(uiTextBox27.Text));
                    hsl.WriteInt("D1612", int.Parse(uiTextBox12.Text));
                    hsl.WriteInt("D2078", int.Parse(uiTextBox11.Text));
                    break;

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            switch (cbPosi.Text)
            {
                case "1":
                    txtExchangeBarCode.Text = hsl.ReadInt("D1014", 1)[0].ToString();
                    uiTextBox3.Text = hsl.ReadInt("D1514", 1)[0].ToString();
                    uiTextBox2.Text = hsl.ReadInt("D2004", 1)[0].ToString();
                    break;
                case "2":
                    txtExchangeBarCode.Text = hsl.ReadInt("D1044", 1)[0].ToString();
                    uiTextBox3.Text = hsl.ReadInt("D1544", 1)[0].ToString();
                    uiTextBox2.Text = hsl.ReadInt("D2026", 1)[0].ToString();
                    break;
                case "3":
                    txtExchangeBarCode.Text = hsl.ReadInt("D1074", 1)[0].ToString();
                    uiTextBox3.Text = hsl.ReadInt("D1574", 1)[0].ToString();
                    uiTextBox2.Text = hsl.ReadInt("D2048", 1)[0].ToString();
                    break;
                case "4":
                    txtExchangeBarCode.Text = hsl.ReadInt("D1104", 1)[0].ToString();
                    uiTextBox3.Text = hsl.ReadInt("D1604", 1)[0].ToString();
                    uiTextBox2.Text = hsl.ReadInt("D2070", 1)[0].ToString();
                    break;

            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            switch (cbPosi.Text)
            {
                case "1":
                    hsl.WriteInt("D1014", int.Parse(txtExchangeBarCode.Text));
                    hsl.WriteInt("D1514", int.Parse(uiTextBox3.Text));
                    hsl.WriteInt("D2004", int.Parse(uiTextBox2.Text));
                    break;
                case "2":
                    hsl.WriteInt("D1044", int.Parse(txtExchangeBarCode.Text));
                    hsl.WriteInt("D1544", int.Parse(uiTextBox3.Text));
                    hsl.WriteInt("D2026", int.Parse(uiTextBox2.Text));
                    break;
                case "3":
                    hsl.WriteInt("D1074", int.Parse(txtExchangeBarCode.Text));
                    hsl.WriteInt("D1574", int.Parse(uiTextBox3.Text));
                    hsl.WriteInt("D2048", int.Parse(uiTextBox2.Text));
                    break;
                case "4":
                    hsl.WriteInt("D1104", int.Parse(txtExchangeBarCode.Text));
                    hsl.WriteInt("D1604", int.Parse(uiTextBox3.Text));
                    hsl.WriteInt("D2070", int.Parse(uiTextBox2.Text));
                    break;

            }


        }

        private void button10_Click(object sender, EventArgs e)
        {
            switch (cbPosi.Text)
            {
                case "1":
                    txtSmallTake.Text = hsl.ReadInt("D1016", 1)[0].ToString();
                    uiTextBox8.Text = hsl.ReadInt("D1516", 1)[0].ToString();
                    uiTextBox6.Text = hsl.ReadInt("D2006", 1)[0].ToString();
                    break;
                case "2":
                    txtSmallTake.Text = hsl.ReadInt("D1046", 1)[0].ToString();
                    uiTextBox8.Text = hsl.ReadInt("D1546", 1)[0].ToString();
                    uiTextBox6.Text = hsl.ReadInt("D2028", 1)[0].ToString();
                    break;
                case "3":
                    txtSmallTake.Text = hsl.ReadInt("D1076", 1)[0].ToString();
                    uiTextBox8.Text = hsl.ReadInt("D1576", 1)[0].ToString();
                    uiTextBox6.Text = hsl.ReadInt("D2050", 1)[0].ToString();
                    break;
                case "4":
                    txtSmallTake.Text = hsl.ReadInt("D1106", 1)[0].ToString();
                    uiTextBox8.Text = hsl.ReadInt("D1606", 1)[0].ToString();
                    uiTextBox6.Text = hsl.ReadInt("D2072", 1)[0].ToString();
                    break;

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            switch (cbPosi.Text)
            {
                case "1":
                    hsl.WriteInt("D1016", int.Parse(txtSmallTake.Text));
                    hsl.WriteInt("D1516", int.Parse(uiTextBox8.Text));
                    hsl.WriteInt("D2006", int.Parse(uiTextBox6.Text));
                    break;
                case "2":
                    hsl.WriteInt("D1046", int.Parse(txtSmallTake.Text));
                    hsl.WriteInt("D1546", int.Parse(uiTextBox8.Text));
                    hsl.WriteInt("D2028", int.Parse(uiTextBox6.Text));
                    break;
                case "3":
                    hsl.WriteInt("D1076", int.Parse(txtSmallTake.Text));
                    hsl.WriteInt("D1576", int.Parse(uiTextBox8.Text));
                    hsl.WriteInt("D2050", int.Parse(uiTextBox6.Text));
                    break;
                case "4":
                    hsl.WriteInt("D1106", int.Parse(txtSmallTake.Text));
                    hsl.WriteInt("D1606", int.Parse(uiTextBox8.Text));
                    hsl.WriteInt("D2072", int.Parse(uiTextBox6.Text));
                    break;

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            switch (cbPosi.Text)
            {
                case "1":
                    txtBigTake.Text = hsl.ReadInt("D1018", 1)[0].ToString();
                    uiTextBox7.Text = hsl.ReadInt("D1518", 1)[0].ToString();
                    uiTextBox4.Text = hsl.ReadInt("D2008", 1)[0].ToString();
                    break;
                case "2":
                    txtBigTake.Text = hsl.ReadInt("D1048", 1)[0].ToString();
                    uiTextBox7.Text = hsl.ReadInt("D1548", 1)[0].ToString();
                    uiTextBox4.Text = hsl.ReadInt("D2030", 1)[0].ToString();
                    break;
                case "3":
                    txtBigTake.Text = hsl.ReadInt("D1078", 1)[0].ToString();
                    uiTextBox7.Text = hsl.ReadInt("D1578", 1)[0].ToString();
                    uiTextBox4.Text = hsl.ReadInt("D2052", 1)[0].ToString();
                    break;
                case "4":
                    txtBigTake.Text = hsl.ReadInt("D1108", 1)[0].ToString();
                    uiTextBox7.Text = hsl.ReadInt("D1608", 1)[0].ToString();
                    uiTextBox4.Text = hsl.ReadInt("D2074", 1)[0].ToString();
                    break;

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            switch (cbPosi.Text)
            {
                case "1":
                    hsl.WriteInt("D1018", int.Parse(txtBigTake.Text));
                    hsl.WriteInt("D1518", int.Parse(uiTextBox7.Text));
                    hsl.WriteInt("D2008", int.Parse(uiTextBox4.Text));
                    break;
                case "2":
                    hsl.WriteInt("D1048", int.Parse(txtBigTake.Text));
                    hsl.WriteInt("D1548", int.Parse(uiTextBox7.Text));
                    hsl.WriteInt("D2030", int.Parse(uiTextBox4.Text));
                    break;
                case "3":
                    hsl.WriteInt("D1078", int.Parse(txtBigTake.Text));
                    hsl.WriteInt("D1578", int.Parse(uiTextBox7.Text));
                    hsl.WriteInt("D2052", int.Parse(uiTextBox4.Text));
                    break;
                case "4":
                    hsl.WriteInt("D1108", int.Parse(txtBigTake.Text));
                    hsl.WriteInt("D1608", int.Parse(uiTextBox7.Text));
                    hsl.WriteInt("D2074", int.Parse(uiTextBox4.Text));
                    break;

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            switch (cbPosi.Text)
            {
                case "1":
                    uiTextBox14.Text = hsl.ReadInt("D1202", 1)[0].ToString();
                    uiTextBox10.Text = hsl.ReadInt("D1702", 1)[0].ToString();
                    uiTextBox28.Text = hsl.ReadInt("D2202", 1)[0].ToString();
                    break;
                case "2":
                    uiTextBox14.Text = hsl.ReadInt("D1232", 1)[0].ToString();
                    uiTextBox10.Text = hsl.ReadInt("D1732", 1)[0].ToString();
                    uiTextBox28.Text = hsl.ReadInt("D2224", 1)[0].ToString();
                    break;
                case "3":
                    uiTextBox14.Text = hsl.ReadInt("D1262", 1)[0].ToString();
                    uiTextBox10.Text = hsl.ReadInt("D1762", 1)[0].ToString();
                    uiTextBox28.Text = hsl.ReadInt("D2246", 1)[0].ToString();
                    break;
                case "4":
                    uiTextBox14.Text = hsl.ReadInt("D1292", 1)[0].ToString();
                    uiTextBox10.Text = hsl.ReadInt("D1792", 1)[0].ToString();
                    uiTextBox28.Text = hsl.ReadInt("D2268", 1)[0].ToString();
                    break;
            }
        }
        private void button28_Click(object sender, EventArgs e)
        {
            switch (cbPosi.Text)
            {
                case "1":
                    hsl.WriteInt("D1202", int.Parse(uiTextBox14.Text));
                    hsl.WriteInt("D1202", int.Parse(uiTextBox10.Text));
                    hsl.WriteInt("D1202", int.Parse(uiTextBox28.Text));
                    break;
                case "2":
                    hsl.WriteInt("D1232", int.Parse(uiTextBox14.Text));
                    hsl.WriteInt("D1202", int.Parse(uiTextBox10.Text));
                    hsl.WriteInt("D1202", int.Parse(uiTextBox28.Text));
                    break;
                case "3":
                    hsl.WriteInt("D1262", int.Parse(uiTextBox14.Text));
                    hsl.WriteInt("D1202", int.Parse(uiTextBox10.Text));
                    hsl.WriteInt("D1202", int.Parse(uiTextBox28.Text));
                    break;
                case "4":
                    hsl.WriteInt("D1292", int.Parse(uiTextBox14.Text));
                    hsl.WriteInt("D1202", int.Parse(uiTextBox10.Text));
                    hsl.WriteInt("D1202", int.Parse(uiTextBox28.Text));
                    break;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            switch (cbPosi.Text)
            {
                case "1":
                    uiTextBox13.Text = hsl.ReadInt("D1216", 1)[0].ToString();
                    uiTextBox32.Text = hsl.ReadInt("D1716", 1)[0].ToString();
                    uiTextBox33.Text = hsl.ReadInt("D2206", 1)[0].ToString();
                    break;
                case "2":
                    uiTextBox13.Text = hsl.ReadInt("D1246", 1)[0].ToString();
                    uiTextBox32.Text = hsl.ReadInt("D1746", 1)[0].ToString();
                    uiTextBox33.Text = hsl.ReadInt("D2228", 1)[0].ToString();
                    break;
                case "3":
                    uiTextBox13.Text = hsl.ReadInt("D1276", 1)[0].ToString();
                    uiTextBox32.Text = hsl.ReadInt("D1776", 1)[0].ToString();
                    uiTextBox33.Text = hsl.ReadInt("D2250", 1)[0].ToString();
                    break;
                case "4":
                    uiTextBox13.Text = hsl.ReadInt("D1306", 1)[0].ToString();
                    uiTextBox32.Text = hsl.ReadInt("D1806", 1)[0].ToString();
                    uiTextBox33.Text = hsl.ReadInt("D2272", 1)[0].ToString();
                    break;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            switch (cbPosi.Text)
            {
                case "1":
                    hsl.WriteInt("D1216", int.Parse(uiTextBox13.Text));
                    hsl.WriteInt("D1716", int.Parse(uiTextBox32.Text));
                    hsl.WriteInt("D2206", int.Parse(uiTextBox33.Text));
                    break;
                case "2":
                    hsl.WriteInt("D1246", int.Parse(uiTextBox13.Text));
                    hsl.WriteInt("D1746", int.Parse(uiTextBox32.Text));
                    hsl.WriteInt("D2228", int.Parse(uiTextBox33.Text));
                    break;
                case "3":
                    hsl.WriteInt("D1276", int.Parse(uiTextBox13.Text));
                    hsl.WriteInt("D1776", int.Parse(uiTextBox32.Text));
                    hsl.WriteInt("D2250", int.Parse(uiTextBox33.Text));
                    break;
                case "4":
                    hsl.WriteInt("D1306", int.Parse(uiTextBox13.Text));
                    hsl.WriteInt("D1806", int.Parse(uiTextBox32.Text));
                    hsl.WriteInt("D2272", int.Parse(uiTextBox33.Text));
                    break;
            }
        }

        //private void button29_Click(object sender, EventArgs e)
        //{
        //    uiTextBox9.Text = hsl.ReadInt("D1222", 1)[0].ToString();
        //    uiTextBox37.Text = hsl.ReadInt("D1722", 1)[0].ToString();
        //    uiTextBox39.Text = hsl.ReadInt("D2212", 1)[0].ToString();
        //}
        //private void button8_Click(object sender, EventArgs e)
        //{
        //    hsl.WriteInt("D1222", int.Parse(uiTextBox9.Text));
        //    hsl.WriteInt("D1722", int.Parse(uiTextBox37.Text));
        //    hsl.WriteInt("D2212", int.Parse(uiTextBox39.Text));
        //}






        private void button23_Click(object sender, EventArgs e)
        {
            txtSmallCleanPosi.Text = hsl.ReadInt("D1122", 1)[0].ToString();
            uiTextBox20.Text = hsl.ReadInt("D1622", 1)[0].ToString();
            uiTextBox26.Text = hsl.ReadInt("D2090", 1)[0].ToString();
        }
        private void button38_Click(object sender, EventArgs e)
        {
            hsl.WriteInt("D1122", int.Parse(txtSmallCleanPosi.Text));
            hsl.WriteInt("D1622", int.Parse(uiTextBox20.Text));
            hsl.WriteInt("D2090", int.Parse(uiTextBox26.Text));
        }

        private void button22_Click(object sender, EventArgs e)
        {
            txtBigCleanPosi.Text = hsl.ReadInt("D1124", 1)[0].ToString();
            uiTextBox19.Text = hsl.ReadInt("D1624", 1)[0].ToString();
            uiTextBox25.Text = hsl.ReadInt("D2092", 1)[0].ToString();
        }
        private void button37_Click(object sender, EventArgs e)
        {
            hsl.WriteInt("D1124", int.Parse(txtBigCleanPosi.Text));
            hsl.WriteInt("D1624", int.Parse(uiTextBox19.Text));
            hsl.WriteInt("D2092", int.Parse(uiTextBox25.Text));
        }

        private void button20_Click(object sender, EventArgs e)
        {
            txtSmallNGPosi.Text = hsl.ReadInt("D1128", 1)[0].ToString();
            uiTextBox17.Text = hsl.ReadInt("D1628", 1)[0].ToString();
            uiTextBox23.Text = hsl.ReadInt("D2096", 1)[0].ToString();
        }
        private void button35_Click(object sender, EventArgs e)
        {
            hsl.WriteInt("D1128", int.Parse(txtSmallNGPosi.Text));
            hsl.WriteInt("D1628", int.Parse(uiTextBox17.Text));
            hsl.WriteInt("D2096", int.Parse(uiTextBox23.Text));
        }

        private void button19_Click(object sender, EventArgs e)
        {
            txtBigNGPosi.Text = hsl.ReadInt("D1130", 1)[0].ToString();
            uiTextBox16.Text = hsl.ReadInt("D1630", 1)[0].ToString();
            uiTextBox22.Text = hsl.ReadInt("D2098", 1)[0].ToString();
        }
        private void button34_Click(object sender, EventArgs e)
        {
            hsl.WriteInt("D1130", int.Parse(txtBigNGPosi.Text));
            hsl.WriteInt("D1630", int.Parse(uiTextBox16.Text));
            hsl.WriteInt("D2098", int.Parse(uiTextBox22.Text));
        }

        private void button17_Click(object sender, EventArgs e)
        {
            txtBlowCheckPosi.Text = hsl.ReadInt("D1134", 1)[0].ToString();
            uiTextBox31.Text = hsl.ReadInt("D1634", 1)[0].ToString();
            uiTextBox36.Text = hsl.ReadInt("D2102", 1)[0].ToString();
        }
        private void button32_Click(object sender, EventArgs e)
        {
            hsl.WriteInt("D1134", int.Parse(txtBlowCheckPosi.Text));
            hsl.WriteInt("D1634", int.Parse(uiTextBox31.Text));
            hsl.WriteInt("D2102", int.Parse(uiTextBox36.Text));
        }

        private void button21_Click(object sender, EventArgs e)
        {
            uiTextBox21.Text = hsl.ReadInt("D1134", 1)[0].ToString();
            uiTextBox18.Text = hsl.ReadInt("D1634", 1)[0].ToString();
            uiTextBox15.Text = hsl.ReadInt("D2112", 1)[0].ToString();
        }
        private void button18_Click(object sender, EventArgs e)
        {
            hsl.WriteInt("D1134", int.Parse(uiTextBox21.Text));
            hsl.WriteInt("D1634", int.Parse(uiTextBox18.Text));
            hsl.WriteInt("D2112", int.Parse(uiTextBox15.Text));
        }

        private void button16_Click(object sender, EventArgs e)
        {
            txtMouseCheckPosi.Text = hsl.ReadInt("D1136", 1)[0].ToString();
            uiTextBox30.Text = hsl.ReadInt("D1636", 1)[0].ToString();
            uiTextBox35.Text = hsl.ReadInt("D2104", 1)[0].ToString();
        }
        private void button30_Click(object sender, EventArgs e)
        {
            hsl.WriteInt("D1136", int.Parse(txtMouseCheckPosi.Text));
            hsl.WriteInt("D1636", int.Parse(uiTextBox30.Text));
            hsl.WriteInt("D2104", int.Parse(uiTextBox35.Text));
        }

        private void button50_Click(object sender, EventArgs e)
        {
            uiTextBox42.Text = hsl.ReadInt("D1136", 1)[0].ToString();
            uiTextBox41.Text = hsl.ReadInt("D1636", 1)[0].ToString();
            uiTextBox40.Text = hsl.ReadInt("D2114", 1)[0].ToString();
        }
        private void button49_Click(object sender, EventArgs e)
        {
            hsl.WriteInt("D1136", int.Parse(uiTextBox42.Text));
            hsl.WriteInt("D1636", int.Parse(uiTextBox41.Text));
            hsl.WriteInt("D2114", int.Parse(uiTextBox40.Text));
        }

        private void button15_Click(object sender, EventArgs e)
        {
            txtBoardCheckPosi.Text = hsl.ReadInt("D1138", 1)[0].ToString();
            uiTextBox29.Text = hsl.ReadInt("D1638", 1)[0].ToString();
            uiTextBox34.Text = hsl.ReadInt("D2106", 1)[0].ToString();
        }
        private void button46_Click(object sender, EventArgs e)
        {
            hsl.WriteInt("D1136", int.Parse(txtBoardCheckPosi.Text));
            hsl.WriteInt("D1636", int.Parse(uiTextBox29.Text));
            hsl.WriteInt("D2106", int.Parse(uiTextBox34.Text));
        }

        private void button36_Click(object sender, EventArgs e)
        {
            uiTextBox45.Text = hsl.ReadInt("D1138", 1)[0].ToString();
            uiTextBox44.Text = hsl.ReadInt("D1638", 1)[0].ToString();
            uiTextBox24.Text = hsl.ReadInt("D2116", 1)[0].ToString();
        }
        private void button33_Click(object sender, EventArgs e)
        {
            hsl.WriteInt("D1136", int.Parse(uiTextBox45.Text));
            hsl.WriteInt("D1636", int.Parse(uiTextBox44.Text));
            hsl.WriteInt("D2116", int.Parse(uiTextBox24.Text));
        }

        private void button14_Click(object sender, EventArgs e)
        {
            txtCleanPosiSpeed.Text = hsl.ReadInt("D1322", 1)[0].ToString();
            uiTextBox46.Text = hsl.ReadInt("D1822", 1)[0].ToString();
            uiTextBox47.Text = hsl.ReadInt("D2290", 1)[0].ToString();
        }
        private void button45_Click(object sender, EventArgs e)
        {
            hsl.WriteInt("D1322", int.Parse(txtCleanPosiSpeed.Text));
            hsl.WriteInt("D1822", int.Parse(uiTextBox46.Text));
            hsl.WriteInt("D2290", int.Parse(uiTextBox47.Text));
        }

        private void button13_Click(object sender, EventArgs e)
        {
            txtNGPosiSpeed.Text = hsl.ReadInt("D1328", 1)[0].ToString();
            uiTextBox51.Text = hsl.ReadInt("D1828", 1)[0].ToString();
            uiTextBox55.Text = hsl.ReadInt("D2296", 1)[0].ToString();
        }
        private void button44_Click(object sender, EventArgs e)
        {
            hsl.WriteInt("D1328", int.Parse(txtNGPosiSpeed.Text));
            hsl.WriteInt("D1828", int.Parse(uiTextBox51.Text));
            hsl.WriteInt("D2296", int.Parse(uiTextBox55.Text));
        }



        private void button26_Click(object sender, EventArgs e)
        {
            txtBlowCheckPosiSpeed.Text = hsl.ReadInt("D1334", 1)[0].ToString();
            uiTextBox50.Text = hsl.ReadInt("D1834", 1)[0].ToString();
            uiTextBox54.Text = hsl.ReadInt("D2302", 1)[0].ToString();
        }
        private void button43_Click(object sender, EventArgs e)
        {
            hsl.WriteInt("D1334", int.Parse(txtBlowCheckPosiSpeed.Text));
            hsl.WriteInt("D1834", int.Parse(uiTextBox50.Text));
            hsl.WriteInt("D2302", int.Parse(uiTextBox54.Text));
        }

        private void button25_Click(object sender, EventArgs e)
        {
            txtMouseCheckPosiSpeed.Text = hsl.ReadInt("D1336", 1)[0].ToString();
            uiTextBox49.Text = hsl.ReadInt("D1836", 1)[0].ToString();
            uiTextBox53.Text = hsl.ReadInt("D2304", 1)[0].ToString();
        }
        private void button42_Click(object sender, EventArgs e)
        {
            hsl.WriteInt("D1336", int.Parse(txtMouseCheckPosiSpeed.Text));
            hsl.WriteInt("D1836", int.Parse(uiTextBox49.Text));
            hsl.WriteInt("D2304", int.Parse(uiTextBox53.Text));
        }

        private void button24_Click(object sender, EventArgs e)
        {
            txtBoardCheckPosiSpeed.Text = hsl.ReadInt("D1338", 1)[0].ToString();
            uiTextBox48.Text = hsl.ReadInt("D1838", 1)[0].ToString();
            uiTextBox52.Text = hsl.ReadInt("D2306", 1)[0].ToString();
        }
        private void button41_Click(object sender, EventArgs e)
        {
            hsl.WriteInt("D1338", int.Parse(txtBoardCheckPosiSpeed.Text));
            hsl.WriteInt("D1838", int.Parse(uiTextBox48.Text));
            hsl.WriteInt("D2306", int.Parse(uiTextBox52.Text));
        }

        private void button12_Click(object sender, EventArgs e)
        {
            txtReadyPosi.Text = hsl.ReadInt("D1000", 1)[0].ToString();
            uiTextBox38.Text = hsl.ReadInt("D1500", 1)[0].ToString();
            uiTextBox43.Text = hsl.ReadInt("D2000", 1)[0].ToString();
        }
        private void button40_Click(object sender, EventArgs e)
        {
            hsl.WriteInt("D1000", int.Parse(txtReadyPosi.Text));
            hsl.WriteInt("D1500", int.Parse(uiTextBox38.Text));
            hsl.WriteInt("D2000", int.Parse(uiTextBox43.Text));
        }

        private void button27_Click(object sender, EventArgs e)
        {
            txtReadyPosiSpeed.Text = hsl.ReadInt("D1200", 1)[0].ToString();
            uiTextBox56.Text = hsl.ReadInt("D1700", 1)[0].ToString();
            uiTextBox57.Text = hsl.ReadInt("D2200", 1)[0].ToString();
        }
        private void button39_Click(object sender, EventArgs e)
        {
            hsl.WriteInt("D1200", int.Parse(txtReadyPosiSpeed.Text));
            hsl.WriteInt("D1700", int.Parse(uiTextBox56.Text));
            hsl.WriteInt("D2200", int.Parse(uiTextBox57.Text));
        }

        private void button51_Click(object sender, EventArgs e)
        {
            FSetPositionSec f = new FSetPositionSec();
            f.ShowDialog();
        }

        private void cbPosi_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReadData();
        }


        private void timerShowXYZ_Tick(object sender, EventArgs e)
        {
            lbLocation.Text = "X:"+hsl.ReadInt("R1010", 1)[0].ToString()+" Y:"+ hsl.ReadInt("R1060", 1)[0].ToString()+" Z:"+hsl.ReadInt("R1110", 1)[0].ToString();
        }

        private void button55_MouseDown(object sender, MouseEventArgs e)
        {
            hsl.WriteBool(hsl.x_add, true);
        }

        private void button55_MouseUp(object sender, MouseEventArgs e)
        {
            hsl.WriteBool(hsl.x_add, false);
        }

        private void button54_MouseDown(object sender, MouseEventArgs e)
        {
            hsl.WriteBool(hsl.x_minu, true);
        }

        private void button54_MouseUp(object sender, MouseEventArgs e)
        {
            hsl.WriteBool(hsl.x_minu, false);
        }

        private void button53_MouseDown(object sender, MouseEventArgs e)
        {
            hsl.WriteBool(hsl.y_add, true);
        }

        private void button53_MouseUp(object sender, MouseEventArgs e)
        {
            hsl.WriteBool(hsl.y_add, false);
        }

        private void button52_MouseDown(object sender, MouseEventArgs e)
        {
            hsl.WriteBool(hsl.y_minu, true);
        }

        private void button52_MouseUp(object sender, MouseEventArgs e)
        {
            hsl.WriteBool(hsl.y_minu, false);
        }

        private void button29_MouseDown(object sender, MouseEventArgs e)
        {
            hsl.WriteBool(hsl.z_add, true);
        }

        private void button29_MouseUp(object sender, MouseEventArgs e)
        {
            hsl.WriteBool(hsl.z_add, false);
        }

        private void button8_MouseDown(object sender, MouseEventArgs e)
        {
            hsl.WriteBool(hsl.z_minu, true);
        }

        private void button8_MouseUp(object sender, MouseEventArgs e)
        {
            hsl.WriteBool(hsl.z_minu, false);
        }
    }
}
