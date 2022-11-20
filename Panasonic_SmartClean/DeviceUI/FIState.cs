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
    public partial class FIState : UIForm
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();
        public Hsl hsl = Hsl.Instance;

        public FIState()
        {
            InitializeComponent();
            asc.controllInitializeSize(this);

        }

        private void FIState_Load(object sender, EventArgs e)
        {
            int iCount = 1;
            //显示
            int iWidth = this.Width / 11;
            int iHeight = this.Height / 11;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (iCount>SoftConfig._IMap.Count)
                    {
                        break;
                    }
                    UILedBulb u = new UILedBulb();
                    u.Name = "l"+SoftConfig._IMap[iCount-1].index.ToString();
                    u.Size = new Size(iWidth/2,iHeight/2);
                    u.Location = new Point(j * (iWidth + 5) + 35 + iWidth / 4, i * (iHeight + 15) + 30 + iHeight / 3);

                    Label b = new Label();
                    b.Name = "b"+ SoftConfig._IMap[iCount - 1].index.ToString();
                    b.Size = new Size(iWidth+10, iHeight / 2);
                    b.Font = new Font("微软雅黑", 7, FontStyle.Regular);
                    b.Location = new Point(j * (iWidth + 5) + 5 + iWidth / 4, i * (iHeight + 15) + 30+ iHeight / 2 + iHeight / 3);
                    b.Text = SoftConfig._IMap[iCount - 1].remark;
                    b.TextAlign = ContentAlignment.MiddleCenter;
                    this.Controls.Add(b);
                    this.Controls.Add(u);
                    iCount++;
                }
            }
        }

        private void timerShow_Tick(object sender, EventArgs e)
        {
            try
            {
                bool[] b = hsl.ReadBool("X0", 113);
                for (int i = 0; i < b.Count(); i++)
                {
                    Control[] lstControl = this.Controls.Find("l" + i.ToString(), true);
                    if (lstControl.Count() > 0)
                    {
                        UILedBulb ub = (UILedBulb)lstControl[0];
                        ub.On = b[i];
                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
